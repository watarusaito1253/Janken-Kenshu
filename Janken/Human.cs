using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * プレイヤーの内、キーボードなどで手を選択するものをHumanクラスと定義
     */
    class Human : Player
    {
        public Human(string pName) : base(pName)
        {
        }

        //じゃんけんのための手を選択し、それを返す
        public override Hand SelectHand(List<Hand> hands)
        {
            //入力を促すために、メッセージを表示
            SayExplanation(hands);
            return hands[InputHandNumber(hands)];
        }

        private void SayExplanation(List<Hand> hands)
        {
            StringBuilder explanation = new StringBuilder("あなたの手を選択してください ");
            for (int i = 0; i < hands.Count; i++)
            {
                explanation.Append(i + ":" + hands[i].DisplayName + " ");
            }
            Console.WriteLine(explanation);
        }

        private int InputHandNumber(List<Hand> hands)
        {
            int select = 0;
            while (true)
            {
                Console.WriteLine("表示されている数値で入力してください");
                try
                {
                    select = int.Parse(Console.ReadLine());
                    if (0 < select && select < hands.Count)
                    {
                        break;
                    }
                }
                catch (Exception) //特にエラーを区別する必要がないので、一律で再入力を促す
                {
                    continue;
                }

            }

            return select;
        }
    }
}