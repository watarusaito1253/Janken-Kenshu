using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class JankenMain
    {
        static void Main()
        {
            //スタート場面を作成、表示する。賑やかしのためであり、無くても動作に影響しない
            IJankenConsole JankenStartConsole = new JankenStartConsole();
            JankenStartConsole.ShowJankenConsole();

            //じゃんけんゲームのための設定する場面を作成、表示。キーボードなどから設定するのはプレイヤー人数である
            IJankenConsole JankenConfigurationConsole = new JankenConfigurationConsole();
            JankenConfiguration JankenConfiguration = JankenConfigurationConsole.ShowJankenConsole(); 

            //じゃんけんのメイン場面、手を選択したり勝敗判定をする
            IJankenConsole JankenBattleConsole = new JankenBattleConsole(JankenConfiguration);
            JankenConfiguration = JankenBattleConsole.ShowJankenConsole();

            //戦績などを表示する場面も作成予定
            IJankenConsole JankenResultConsole = new JankenResultConsole(JankenConfiguration);
            JankenConfiguration = JankenResultConsole.ShowJankenConsole();

            //処理が全て終わっても、入力があるまで余韻を残す
            Console.ReadLine();
        }
    }
}
