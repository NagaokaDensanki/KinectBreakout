using System;

class Block{

	private int color;

    private double posX;
    private double posY;
	private double sizeX;
	private double sizeY;

    private bool flag;

	/// <summary>
	/// 新しくブロックを作成します。
	/// </summary>
	/// <param name="positionX">ブロックのX座標</param>
	/// <param name="positionY">ブロックのY座標</param>
	/// <param name="sizeX">ブロックのX軸方向の大きさ</param>
	/// <param name="sizeY">ブロックのY軸方向の大きさ</param>
	/// <param name="color">ブロックの色</param>
	public Block(double positionX, double positionY, double sizeX, double sizeY, int color){
		flag = true;
		posX = positionX;
		posY = positionY;
		this.sizeX = sizeX;
		this.sizeY = sizeY;
		this.color = color;
	}

	/// <summary>
	/// 位置を設定します。
	/// </summary>
	/// <param name="x">新しく指定するX成分の位置</param>
	/// <param name="y">新しく指定するY成分の位置</param>
	public void SetPotiton(double x, double y){
		posX = x;
		posY = y;
	}

	/// <summary>
	/// X成分の位置を取得します。
	/// </summary>
	/// <returns>
	/// X成分の位置を返します。
	/// </returns>
	public double GetPositionX() {
		return posX;
	}

	/// <summary>
	/// Y成分の位置を取得します。
	/// </summary>
	/// <returns>
	/// Y成分の位置を返します。
	/// </returns>
	public double GetPositionY() {
		return posY;
	}

	/// <summary>
	/// X軸方向の大きさを取得します。
	/// </summary>
	/// <returns>
	/// X軸方向の大きさを返します。
	/// </returns>
	public double GetSizeX() {
		return sizeX;
	}

	/// <summary>
	/// Y軸方向の大きさを取得します。
	/// </summary>
	/// <returns>
	/// Y軸方向の大きさを返します。
	/// </returns>
	public double GetSizeY() {
		return sizeY;
	}

	/// <summary>
	/// フラグを取得します。
	/// </summary>
	/// <returns>
	/// フラグを返します。
	/// </returns>
	public bool GetFlag() {
		return flag;
	}

	/// <summary>
	/// ブロックの色を取得します。
	/// </summary>
	/// <returns>
	/// ブロックの色を返します。
	/// </returns>
	public int GetColor() {
		return color;
	}

	/// <summary>
	/// ブロックが破壊される時に呼び出します。
	/// </summary>
	public void Break(){
		flag = false;
	}
}
