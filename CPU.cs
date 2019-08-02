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
            //CPUの数が複数人になると、多分ダメである。乱数の種が変わる前に続々と同じ乱数を取得する・・・と思われる。
            Random rnd = new Random();
            int select = rnd.Next(hands.Count);
            return hands[select];
        }
    }
}
