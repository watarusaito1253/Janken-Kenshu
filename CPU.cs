using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * 特にキーボードなどから入力せずに手を選択するプレイヤーをCPUと定義
     */
    class CPU : Player
    {
        public CPU(string PlayerName):base(PlayerName){}

        //じゃんけんのための手を選択し、それを返す
        public override Hand SelectHand(List<Hand> hands) 
        {
            Random rnd = new Random();
            for (int i = 0; i < 100000000; i++)
            {

            }
            int select = rnd.Next(hands.Count);
            return hands[select];
        }
    }
}
