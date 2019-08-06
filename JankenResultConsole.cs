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
            int battleCount = JankenConfiguration.AllPlayers[0].BattaleResults.Count;
            Console.WriteLine("じゃんけんゲーム" + battleCount + "回の戦績");

            foreach (Player player in JankenConfiguration.AllPlayers)
            {
                Console.WriteLine(getCalcPlayerResult(player));
            }

            return JankenConfiguration;
        }

        private string getCalcPlayerResult(Player player)
        {
            int winCount = 0;
            int loseCount = 0;
            int drawCount = 0;
            foreach (BattaleResult battaleResult in player.BattaleResults)
            {
                if(battaleResult.Result == BattaleResult.Win)
                {
                    winCount++;
                }
                else if(battaleResult.Result == BattaleResult.Lose)
                {
                    loseCount++;
                }
                else if (battaleResult.Result == BattaleResult.Draw)
                {
                    drawCount++;
                }
            }
            double winRate = 0.0;
            double loseRate = 0.0;
            double drawRate = 0.0;
            winRate = Math.Round(winCount / (double)player.BattaleResults.Count * 100.0);
            loseRate = Math.Round(loseCount / (double)player.BattaleResults.Count * 100.0);
            drawRate = Math.Round(drawCount / (double)player.BattaleResults.Count * 100.0);
            

            return player.PlayerName + "の戦績 勝利:" + winCount + "回 敗北:" + loseCount + "回 引分:" + drawCount + "回 " + "勝率:" + winRate + "% 敗率:" + loseRate + "% 引率:" + drawRate + "%";
        }
        
    }
}
