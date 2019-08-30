using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * じゃんけんの設定(じゃんけんで使用する手の種類や、プレイヤーの数など)を決定、保持する
     */
    class JankenConfiguration
    {
        //じゃんけんで使用する手を保持する
        public List<Hand> Hands;
        //humanとCPUを別に保持する必要もそんなにないので、まとめて保持する
        public List<Player> AllPlayers;

        public JankenConfiguration(int humanCount, int CPUCount)
        {

            AllPlayers = new List<Player>();

            for (int i = 0; i < humanCount; i++)
            {
                AllPlayers.Add(new Human("Human" + i));
            }

            for (int i = 0; i < CPUCount; i++)
            {
                AllPlayers.Add(new CPU("CPU" + i));
            }
            //じゃんけんのために、それぞれの手の相性を設定する
            SetHandWinLose();
            //確認のために、プレイヤーの人数を表示する
            ShowConfigurationDetail();
        }



        private void SetHandWinLose()
        {
            Hands = new List<Hand>();
            Hand rock = new Rock();
            Hand paper = new Paper();
            Hand scissors = new Scissors();

            Hands.Add(rock);
            Hands.Add(paper);
            Hands.Add(scissors);

            rock.setWinLostRelationship(rock, BattaleResult.Draw);
            rock.setWinLostRelationship(paper, BattaleResult.Lose);
            rock.setWinLostRelationship(scissors, BattaleResult.Win);

            paper.setWinLostRelationship(rock, BattaleResult.Win);
            paper.setWinLostRelationship(paper, BattaleResult.Draw);
            paper.setWinLostRelationship(scissors, BattaleResult.Lose);

            scissors.setWinLostRelationship(rock, BattaleResult.Lose);
            scissors.setWinLostRelationship(paper, BattaleResult.Win);
            scissors.setWinLostRelationship(scissors, BattaleResult.Draw);

            //ゲームを成り立たせるために、それぞれの手が全ての手と相性が設定されているかを確認する、ダメならエラー終了
            foreach (Hand hand in Hands)
            {
                if (!hand.IsSetAllRelationship(Hands))
                {
                    Exception e = new Exception(Hand.WarningRelationship);
                    Console.WriteLine(e.ToString());
                    Console.ReadLine();
                    throw e;

                }
            }
        }

        public void ShowConfigurationDetail()
        {
            //いきなりhumanとCPUそれぞれの数が必要だが,この処理はそんなに使用しない想定である
            int humanCount = 0;
            int CPUCount = 0;
            foreach (Player player in AllPlayers)
            {
                if (player is Human)
                {
                    humanCount++;
                }
                else if (player is CPU)
                {
                    CPUCount++;
                }
            }
            Console.WriteLine("人間:" + humanCount + "人 CPU:" + CPUCount + "人");
        }

    }
}