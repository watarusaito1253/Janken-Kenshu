using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * JankenConfigurationの設定のためのクラスだが、まだ数を1vs1で決め打ちなので未完成
     */
    class JankenConfigurationConsole : IJankenConsole
    {
        private static int MaxPlayerNumber = 10;
        private static int MaxHumanNumber = 5;
        private static int MaxCPUNumber = MaxPlayerNumber - MaxHumanNumber;

        private static string PromptInputHumanCount = "プレイヤー(人間)の数を入力してください(最大" + MaxHumanNumber + "人以下)";
        private static string PromptInputCPUCount = "プレイヤー(CPU)の数を入力してください(最大" + MaxCPUNumber + "人以下)";
        private static string WarningInputOfTotal = "プレイヤー(人間+CPU)の合計は2～" + MaxPlayerNumber + "人以下となるように入力してください";

        private JankenConfiguration JankenConfiguration;

        public JankenConfigurationConsole(JankenConfiguration JankenConfiguration)
        {
            this.JankenConfiguration = JankenConfiguration;
        }

        public void ShowJankenConsole()
        {
            
        }
    }
}
