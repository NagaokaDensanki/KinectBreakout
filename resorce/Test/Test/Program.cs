using System;
using System.Windows.Forms;
using DxLibDLL;

static class Program{


	/// <summary>
	/// プログラムはここから始まります。
	/// ゲームクラスのインスタンスを作成します。
	/// ※ゲームの本体は Game です。
	/// </summary>
    [STAThread]
    static void Main(){
		new Game();
    }


}



