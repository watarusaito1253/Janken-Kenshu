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
        //出す手を決めるための乱数
        private static Random Rnd = new Random();

        public CPU(string pName):base(pName)
        {
        }

        //じゃんけんのための手を選択し、それを返す
        public override Hand SelectHand(List<Hand> hands) 
        {
            
            //Random rnd = new Random();
            int select = Rnd.Next(hands.Count);
            return hands[select];
        }
    }
}
