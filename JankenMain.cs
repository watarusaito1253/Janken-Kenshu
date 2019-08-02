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
            //じゃんけんゲームのための設定を作成する、今回は1vs1で決め打ちだが、設定するための場面も作成予定
            JankenConfiguration JankenConfiguration = new JankenConfiguration(1,1);
            //じゃんけんのメイン場面、手を選択したり勝敗判定をする
            IJankenConsole JankenBattleConsole = new JankenBattleConsole(JankenConfiguration);
            JankenBattleConsole.ShowJankenConsole();
            //戦績などを表示する場面も作成予定

            //処理が全て終わっても、入力があるまで余韻を残す
            Console.ReadLine();

        }
    }
}
