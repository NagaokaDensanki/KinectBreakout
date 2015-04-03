using System;
using DxLibDLL;

class Game{

	public static readonly int BLOCK_SIZE = 60;

	//public static Bar bar;
	public static Boll boll;
    public static Player player = new Player();
	public static Block[] block = new Block[BLOCK_SIZE];

	private bool missFlag;

	/// <summary>
	/// ゲームの本体
	/// </summary>
	public Game(){
		DX.ChangeWindowMode(1);
		if(DX.DxLib_Init() == -1){
			//Application.Exit();
		}
		DX.SetDrawScreen(DX.DX_SCREEN_BACK);

		while(DX.ProcessMessage() == 0){
			ResetBlock();
            while (DX.ProcessMessage() == 0){
				ResetOther();
				Draw();
				WaitKey(DX.KEY_INPUT_S);
                while (DX.ProcessMessage() == 0){
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
        player.SetCollection(320, 360, -120.0D);
        /*
        double[] points = new double[2];
        points[0] = 320;
        points[1] = 240;
        player.SetPoint(points, Player.HEAD);
        points[0] = 320;
        points[1] = 260;
        player.SetPoint(points, Player.CENTER);
        points[0] = 320+60;
        points[1] = 270;
        player.SetPoint(points, Player.ELBOW_LEFT);
        points[0] = 320 + 60 * 2;
        points[1] = 240;
        player.SetPoint(points, Player.HAND_LEFT);
        points[0] = 320 - 60;
        points[1] = 270;
        player.SetPoint(points, Player.ELBOW_RIGHT);
        points[0] = 320 - 60 * 2;
        points[1] = 260;
        player.SetPoint(points, Player.HAND_RIGHT);
        points[0] = 320;
        points[1] = 400;
        player.SetPoint(points, Player.HIP);
        points[0] = 320 + 10;
        points[1] = 400;
        player.SetPoint(points, Player.KNEE_LEFT);
        points[0] = 320 + 10;
        points[1] = 480;
        player.SetPoint(points, Player.FOOT_LEFT);
        points[0] = 320 + 10;
        points[1] = 480;
        player.SetPoint(points, Player.KNEE_RIGHT);
        points[0] = 320 + 10;
        points[1] = 480;
        player.SetPoint(points, Player.FOOT_RIGHT);
         * */
		//bar = new Bar(320, 60);
		//bar.SetPositionX(320);
	}

	/// <summary>
	/// ゲームの進行をします。
	/// </summary>
	/// <returns></returns>
	private bool Update() {
        /*
		if(DX.CheckHitKey(DX.KEY_INPUT_RIGHT) != 0) {
			bar.Move(4.0D);
		}
		if(DX.CheckHitKey(DX.KEY_INPUT_LEFT) != 0) {
			bar.Move(-4.0D);
		}
         */
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
            DrawPlayer();
			//DX.DrawBox((int)bar.GetPositionX() - 25, 420 - 5, (int)bar.GetPositionX() + 25, 420 + 5, DX.GetColor(0x8B, 0xC3, 0x4A), 1);
		}
		DX.ScreenFlip();
	}

    public void DrawPlayer(){
        int legColor  = DX.GetColor(0x00, 0x32, 0x6D);
        int otherColor = DX.GetColor(0x8B, 0xC3, 0x4A);
        double[][] points = {
                                player.GetPoint(Player.HEAD),
                                player.GetPoint(Player.CENTER),
                                player.GetPoint(Player.CENTER),
                                player.GetPoint(Player.ELBOW_LEFT),
                                player.GetPoint(Player.ELBOW_LEFT),
                                player.GetPoint(Player.HAND_LEFT),
                                player.GetPoint(Player.CENTER),
                                player.GetPoint(Player.ELBOW_RIGHT),
                                player.GetPoint(Player.ELBOW_RIGHT),
                                player.GetPoint(Player.HAND_RIGHT),
                                player.GetPoint(Player.CENTER),
                                player.GetPoint(Player.HIP),
                                player.GetPoint(Player.HIP),
                                player.GetPoint(Player.KNEE_LEFT),
                                player.GetPoint(Player.KNEE_LEFT),
                                player.GetPoint(Player.FOOT_LEFT),
                                player.GetPoint(Player.HIP),
                                player.GetPoint(Player.KNEE_RIGHT),
                                player.GetPoint(Player.KNEE_RIGHT),
                                player.GetPoint(Player.FOOT_RIGHT)
                     };
        for (int i = 0; i < points.Length; i += 2){
            DX.DrawLine((int)points[i][0], (int)points[i][1], (int)points[i + 1][0], (int)points[i + 1][1], (i >= 2 && i <= 8) ? legColor : otherColor, 3);
            //System.Console.WriteLine(i + " : " + points[i][0] + ", " + points[i][1] + ", " + points[i + 1][0] + ", " + points[i + 1][1]);
        }
    }

	/// <summary>
	/// 特定のキーが押されるまで待機します。
	/// </summary>
	/// <param name="key">キーのコード</param>
	private void WaitKey(int key) {
        while (DX.CheckHitKey(key) == 0 && DX.ProcessMessage() == 0){
            Draw();
        }
	}
}
