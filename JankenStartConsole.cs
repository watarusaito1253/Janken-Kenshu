using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class JankenStartConsole : IJankenConsole
    {
        private static string StartExplanation = "じゃんけんゲームを開始します";
        //private static string EndJankenStart = "何かキーを押してください";

        /*
         * じゃんけんのスタート画面、賑やかしのためであり、これにこだわる時間があるか・・・
         */
        public JankenConfiguration ShowJankenConsole()
        {
            Console.WriteLine(StartExplanation);

            return null;
        }
    }
}
