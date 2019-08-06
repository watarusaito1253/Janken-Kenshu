using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * じゃんけんの手の選択、勝敗判定、結果表示までを行う
     */
    class JankenBattleConsole : IJankenConsole
    {
        private JankenConfiguration JankenConfiguration;

        public JankenBattleConsole(JankenConfiguration JankenConfiguration)
        {
            this.JankenConfiguration = JankenConfiguration;
        }

        public JankenConfiguration ShowJankenConsole()
        {
            Boolean continueGame = true;
            while (continueGame)
            {
                //じゃんけんのために手を選択する
                AllSetPlayerHand();
                //味気ないので、細かにメッセージを表示
                Console.WriteLine("全てのプレイヤーが手を選択しました");
                ShowHorizontalLine();
                //じゃんけんの勝敗判定
                AllPlayerBattle();
                //結果だけだと寂しいので、それぞれの手を表示
                ShowSelectAllHand();
                //結果は必要
                ShowBattleResult();
                //ゲームを続けるか判定する
                continueGame = isContinueGame();
            }

            return JankenConfiguration;
        }

        private void AllSetPlayerHand()
        {
            foreach (Player player in JankenConfiguration.AllPlayers)
            {
                player.PlayerHand =  player.SelectHand(JankenConfiguration.Hands);
            }
        }

        private void AllPlayerBattle()
        {
            foreach (Player player in JankenConfiguration.AllPlayers)
            {
                try
                {
                    player.BattaleResults.Add(player.DoBattle(player, JankenConfiguration.AllPlayers));
                }
                catch (Exception e)//じゃんけんの手の相性設定などに不備がある場合、ゲームが成り立たないのでエラー終了
                {
                    Console.WriteLine(e.ToString());
                    Console.ReadLine();
                    throw e;
                }
            }
        }

        private void ShowBattleResult()
        {
            foreach (Player player in JankenConfiguration.AllPlayers)
            {
                Console.WriteLine(player.PlayerName + ":" +  player.BattaleResults.Last().getBattaleResultMessage());
            }
            ShowHorizontalLine();
        }

        private void ShowSelectAllHand()
        {
            foreach (Player player in JankenConfiguration.AllPlayers)
            {
                Console.WriteLine(player.PlayerName + ":" + player.PlayerHand.DisplayName);
                Console.WriteLine(player.PlayerHand.DisplayAA);
            }
            ShowHorizontalLine();
        }

        private void ShowHorizontalLine()
        {
            Console.WriteLine("----------------------------------------------");
        }

        private Boolean isContinueGame()
        {
            Console.WriteLine("続ける場合は1を入力してください(やめる場合は1以外を入力してください)");
            try
            {
                return int.Parse(Console.ReadLine()) == 1;
            }
            catch (Exception)//文字などの1以外の入力は続行の意思なしとみなし、falseを返す
            {
                return false;
            }
        }


    }
}
