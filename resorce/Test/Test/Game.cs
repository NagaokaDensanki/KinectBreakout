using System;
using System.Windows.Forms;
using DxLibDLL;

class Game{

	public static readonly int BLOCK_SIZE = 60;

	public static Bar bar;
	public static Boll boll;
	public static Block[] block = new Block[BLOCK_SIZE];

	private bool missFlag;

	/// <summary>
	/// ゲームの本体
	/// </summary>
	public Game(){
		DX.ChangeWindowMode(1);
		if(DX.DxLib_Init() == -1){
			Application.Exit();
		}
		DX.SetDrawScreen(DX.DX_SCREEN_BACK);
		while(true){
			if(DX.ProcessMessage() == -1) break;
			ResetBlock();
			while(true){
				if(DX.ProcessMessage() == -1) break;
				ResetOther();
				Draw();
				WaitKey(DX.KEY_INPUT_S);
				while(true){
					if(DX.ProcessMessage() == -1) break;
					missFlag = Update();
					Draw();
					if(missFlag) break;
					if((DX.CheckHitKey(DX.KEY_INPUT_F) != 0) || ((DX.CheckHitKey(DX.KEY_INPUT_R) != 0))) break;
				}
				if((DX.CheckHitKey(DX.KEY_INPUT_F) != 0) || ((DX.CheckHitKey(DX.KEY_INPUT_R) != 0))) break;
			}
			if(DX.CheckHitKey(DX.KEY_INPUT_F) != 0) break;
		}
		DX.DxLib_End();
	}

	/// <summary>
	/// ブロックの配置を初期化します。
	/// </summary>
	private void ResetBlock() {
		for(int i = 0; i < BLOCK_SIZE; i++) {
			block[i] = new Block(i % 10 * 64.0D + 32.0D, i / 10 * 32.0D + 16.0D, 64, 32, DX.GetColor(0x8B, 0xC3, 0x4A));
		}
	}

	/// <summary>
	/// ボール、バーの位置を初期化します。
	/// </summary>
	private void ResetOther() {
		boll = new Boll(320, 320, 4.0D, 90.0D, 10.0D);
		bar = new Bar(320, 60);
		bar.SetPositionX(320);
	}

	/// <summary>
	/// ゲームの進行をします。
	/// </summary>
	/// <returns></returns>
	private bool Update() {
		if(DX.CheckHitKey(DX.KEY_INPUT_RIGHT) != 0) {
			bar.Move(4.0D);
		}
		if(DX.CheckHitKey(DX.KEY_INPUT_LEFT) != 0) {
			bar.Move(-4.0D);
		}
		return boll.Move();
	}

	/// <summary>
	/// ゲームの画面を描画します。
	/// </summary>
	private void Draw() {
		DX.ClearDrawScreen();
		DX.DrawBox(0, 0, 640, 480, DX.GetColor(0xFF, 0xFF, 0xFF), 1);
		for(int i = 0; i < BLOCK_SIZE; i++) {
			if(block[i].GetFlag()) {
				int blockDrawPoint1X = (int)(block[i].GetPositionX() - (block[i].GetSizeX() / 2 - 1));
				int blockDrawPoint1Y = (int)(block[i].GetPositionY() - (block[i].GetSizeY() / 2 - 1));
				int blockDrawPoint2X = (int)(block[i].GetPositionX() + (block[i].GetSizeX() / 2 - 1));
				int blockDrawPoint2Y = (int)(block[i].GetPositionY() + (block[i].GetSizeY() / 2 - 1));
				DX.DrawBox(blockDrawPoint1X, blockDrawPoint1Y, blockDrawPoint2X, blockDrawPoint2Y, block[i].GetColor(), 1);
			}
			DX.DrawCircle((int)boll.GetPositionX(), (int)boll.GetPositionY(), (int)boll.GetSize(), DX.GetColor(0x8B, 0xC3, 0x4A), 1);
			DX.DrawBox((int)bar.GetPositionX() - 25, 420 - 5, (int)bar.GetPositionX() + 25, 420 + 5, DX.GetColor(0x8B, 0xC3, 0x4A), 1);
		}
		DX.ScreenFlip();
	}

	/// <summary>
	/// 特定のキーが押されるまで待機します。
	/// </summary>
	/// <param name="key">キーのコード</param>
	private void WaitKey(int key) {
		while(DX.WaitKey() != key) {
		}
	}
}
