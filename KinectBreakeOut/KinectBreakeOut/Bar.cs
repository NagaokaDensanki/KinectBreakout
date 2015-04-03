class Bar{

	private double posX;
	private double posY;
	private double length;

	/// <summary>
	/// 新しくバーを作成します。
	/// </summary>
	/// <param name="positionX">バーのX座標</param>
	/// <param name="length">バー長さ</param>
	public Bar(double positionX, double positionY, double length) {
		posX = positionX;
		posY = positionY;
		this.length = length;
	}

	/// <summary>
	/// 新しくバーを作成します。
	/// </summary>
	/// <param name="positionX">バーのX座標</param>
	/// <param name="length">バー長さ</param>
	public Bar(double positionX, double length) {
		posX = positionX;
		posY = 420;
		this.length = length;
	}

	/// <summary>
	/// 位置を設定します。
	/// </summary>
	/// <param name="x">新しく指定するX成分の位置</param>
	public void SetPositionX(double x){
		posX = x;
	}

	/// <summary>
	/// X成分の位置を取得します。
	/// </summary>
	/// <returns>
	/// X成分の位置を返します。
	/// </returns>
	public double GetPositionX(){
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
	/// バーの長さを取得します。
	/// </summary>
	/// <returns>
	/// バーの長さを返します。
	/// </returns>
	public double GetLength() {
		return length;
	}

	/// <summary>
	/// 移動します。
	/// </summary>
	/// <param name="size">移動する量</param>
	public void Move(double size){
		posX += size;
	}
}
