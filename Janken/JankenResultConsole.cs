using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class JankenResultConsole : IJankenConsole
    {
        private JankenConfiguration JankenConfiguration;

        public JankenResultConsole(JankenConfiguration jankenConfiguration)
        {
            this.JankenConfiguration = jankenConfiguration;
        }


        public JankenConfiguration ShowJankenConsole()
        {
            //じゃんけんゲームの総回数をプレイヤーリストの先頭から取得する
            int battleCount = JankenConfiguration.AllPlayers[0].BattaleResults.Count;
            Console.WriteLine("じゃんけんゲーム" + battleCount + "回の戦績");
            //じゃんけんゲームの結果表示のため、各プレイヤーの結果を表示するメソッド呼び出し
            foreach (Player player in JankenConfiguration.AllPlayers)
            {
                Console.WriteLine(player.getCalcPlayerResult());
            }
            //結果を出力するか、入力していもらいそれに応じて処理する
            if (isOutputResult())
            {
                JankenResultOutput jankenResultOutput = new JankenResultOutput();
                jankenResultOutput.OutputCSV(JankenConfiguration.AllPlayers);
                Console.WriteLine("結果を" + jankenResultOutput.path + "に出力しました");
            }
           

            return JankenConfiguration;
        }

      
        private Boolean isOutputResult()
        {
            Console.WriteLine("じゃんけんゲームの結果を出力しますか?(はい:1 いいえ:その他)");
            try
            {
                return int.Parse(Console.ReadLine()) == 1;
            }
            catch (Exception)//文字などの1以外の入力はノーとみなし、falseを返す
            {
                return false;
            }
        }
    }


}
