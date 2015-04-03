using System;

class Boll{

	private double size;
	private double posX;
	private double posY;
	private double speed;
	private double angle;
	private double velocityX;
	private double velocityY;

	/// <summary>
	/// 新しくボールを作成します。
	/// </summary>
	/// <param name="positionX">ボールの初期位置のX座標</param>
	/// <param name="positionY">ボールの初期位置のY座標</param>
	/// <param name="speed">ボールの速さ</param>
	/// <param name="angle">ホールの飛ぶ角度</param>
	/// <param name="size">ホールの大きさ(半径)</param>
	public Boll(double positionX, double positionY, double speed, double angle, double size){
		SetPotiton(positionX, positionY);
		SetVelocity(speed, angle);
		this.size = size;
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
	/// 速度を設定します。
	/// </summary>
	/// <param name="speed">新しく指定する速度の大きさ</param>
	/// <param name="angle">新しく指定する速度の角度</param>
	public void SetVelocity(double speed, double angle){
		velocityX = speed * Math.Cos(angle * Math.PI / 180);
		velocityY = speed * Math.Sin(angle * Math.PI / 180);
		this.speed = speed;
		this.angle = angle;
	}

	/// <summary>
	/// 半径の長さを取得します。
	/// </summary>
	/// <returns>
	/// 半径の長さを返します。
	/// </returns>
	public double GetSize() {
		return size;
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
	/// 設定された速度を元に、ボールを移動させます。
	/// 壁に当たると自動的に跳ね返り、ミスの判定もします。
	/// </summary>
	/// <returns>
	/// ミスをしたかどうかを返します。
	/// </returns>
	public bool Move(){
		posX += velocityX;
		posY += velocityY;
		if((posX <= 0.0D) || (posX >= 640.0D)){
			velocityX *= -1.0D;
		}
		if((posY <= 0.0D)){
			velocityY *= -1.0D;
		}
        /*
		if((velocityY > 0.0D) && (Math.Abs(posY - Game.bar.GetPositionY()) < 5) && (Math.Abs(posX - Game.bar.GetPositionX()) < Game.bar.GetLength() / 2)) {
			angle = Math.Atan2(-velocityY, velocityX)+(posX - Game.bar.GetPositionX()) * 2 * Math.PI / 180.0D;
			velocityX = speed * Math.Cos(angle);
			velocityY = speed * Math.Sin(angle);
		}
         */
		for(int i = 0; i < Game.BLOCK_SIZE; i++){
			Block block = Game.block[i];
			if((block.GetFlag()) && (Math.Abs(posX - block.GetPositionX()) < block.GetSizeX() / 2 + size) && (Math.Abs(posY - block.GetPositionY()) < block.GetSizeY() / 2 + size)) {
				block.Break();
				double tempPosX = posX - velocityX;
				double tempPosY = posY - velocityY;
				if(Math.Abs(tempPosX - block.GetPositionX()) < block.GetSizeX() / 2) {
					velocityY *= -1.0D;
				}else if(Math.Abs(tempPosY - block.GetPositionY()) < block.GetSizeY() / 2) {
					velocityX *= -1.0D;
				}else{
					velocityY *= -1.0D;
					velocityX *= -1.0D;
				}
				break;
			}
		}
		if(posY >= 480.0D) {
			return true;
		}
		return false;
	}
}
