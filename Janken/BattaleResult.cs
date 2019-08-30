using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * じゃんけんの勝敗を表現するクラス
     */
    class BattaleResult
    {
        public static int Win = 0;
        public static int Lose = 1;
        public static int Draw = 2;
        private static string WinMessage = "勝利!";
        private static string LoseMessage = "敗北…";
        private static string DrawMessage = "引分";
        //じゃんけんの勝敗毎に生成される想定のためコンストラクタからのみ値を代入するようにプライベート
        public int Result { get; private set; }


        public BattaleResult(int result)
        {
            this.Result = result;
        }

        public string getBattaleResultMessage()
        {
            if (Result == Win)
            {
                return WinMessage;
            }
            else if (Result == Lose)
            {
                return LoseMessage;
            }
            else if (Result == Draw)
            {
                return DrawMessage;
            }
            else
            {
                return "不正な結果";//万が一設定以外の値でもあっても、現状動作に影響を及ぼさない(戦績などもまだ)ので、メッセージ表示のみ
            }
        }
    }
}