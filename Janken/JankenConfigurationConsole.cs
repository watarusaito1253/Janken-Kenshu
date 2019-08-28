using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * JankenConfigurationの設定場面のためのクラス
     */
    class JankenConfigurationConsole : IJankenConsole
    {
        //設定値の上限
       
        private static int MaxHumanNumber = 5;
        private static int MaxCPUNumber = 20;
        private static int MaxPlayerNumber = MaxHumanNumber + MaxCPUNumber;
        private static int MinPlayerNumber = 2;

       
        public JankenConfiguration JankenConfiguration { get; set; }

       
        public JankenConfigurationConsole()
        {

        }

        public JankenConfiguration ShowJankenConsole()
        {
            string promptInputHumanCount = "プレイヤー(人間)の数を入力してください(最大" + MaxHumanNumber + "人以下)";
            string promptInputCPUCount = "プレイヤー(CPU)の数を入力してください(最大" + MaxCPUNumber + "人以下)";
            string warningInputOfTotal = "プレイヤー(人間+CPU)の合計は" + MinPlayerNumber + "～" + MaxPlayerNumber + "人以下となるように入力してください";
           
            int humanCount = 0;
            int CPUCount = 0;

            while (humanCount + CPUCount < MinPlayerNumber || MaxPlayerNumber < humanCount + CPUCount)
            {
                Console.WriteLine(warningInputOfTotal);
                humanCount = GetCount(MaxHumanNumber, promptInputHumanCount);
                CPUCount = GetCount(MaxCPUNumber, promptInputCPUCount);
            }
            return new JankenConfiguration(humanCount, CPUCount);
        }

        private int GetCount(int maxNumber, string promptInput)
        {
            string warningInput = "表示された整数値以下を入力してください";
            int count = -1;

            while (count < 0 || maxNumber < count)
            {
                Console.WriteLine(promptInput);
                try
                {
                    count = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine(warningInput);
                }
            }
            return count;
        }
    }
}
