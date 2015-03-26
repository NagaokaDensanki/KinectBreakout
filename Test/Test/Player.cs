using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player {

	public static readonly int HEAD        = 0;
	public static readonly int CENTER      = 1;
	public static readonly int ELBOW_LEFT  = 2;
	public static readonly int HAND_LEFT   = 3;
	public static readonly int ELBOW_RIGHT = 4;
	public static readonly int HAND_RIGHT  = 5;
	public static readonly int HIP         = 6;
	public static readonly int KNEE_LEFT   = 7;
	public static readonly int FOOT_LEFT   = 8;
	public static readonly int KNEE_RIGHT  = 9;
	public static readonly int FOOT_RIGHT  = 10;

	private double[][] points = new double[11][];

	/// <summary>
	/// 関節の位置を設定します。
	/// </summary>
	/// <param name="position">要素０番にX座標、要素１番にY座標を格納した配列を渡します。</param>
	/// <param name="value">部位を示す定数を渡します。Player.[部位名]で渡してください。</param>
	public void SetPoint(double[] position, int value){
		points[value] = position;
	}

	/// <summary>
	/// 関節の位置を取得します。
	/// </summary>
	/// <param name="value">部位を示す定数を渡します。Player.[部位名]で渡してください。</param>
	/// <returns>座標の部位がX座標、Y座標の順で格納された配列を返します。</returns>
	public double[] GetPoint(int value){
		return points[value];
	}
}
