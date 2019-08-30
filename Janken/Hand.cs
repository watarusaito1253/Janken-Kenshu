using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * じゃんけんの手の基底となるクラス
     * それぞれの手との相性や、コンソールに表示する内容などを保持する
     */
    abstract class Hand
    {
        //それぞれのじゃんけんの手とそれに関する相性
        protected Dictionary<Hand, int> WinLostRelationships;
        public static string WarningRelationship = "ゲームの設定が不足しています。それぞれの手の相性設定をご確認ください。(キーを押すと終了します）";
        public string DisplayName { get; set; }
        public string DisplayAA { get; set; }

        public Hand()
        {
            WinLostRelationships = new Dictionary<Hand, int>();
        }

        public void setWinLostRelationship(Hand hand, int winLostRelation)
        {
            WinLostRelationships.Add(hand, winLostRelation);
        }

        //勝敗判定のために、この手が引数で与えられた手に対して勝ち、負け、引分などの結果を返す
        public int GetWinLostRelationship(Hand hand)
        {
            if (WinLostRelationships.ContainsKey(hand))
            {
                return WinLostRelationships[hand];
            }
            else throw new Exception(WarningRelationship);//設定されていない手が呼ばれた場合、ゲームが成り立たないのでエラーを返す   
        }

        //設定に不備がないか、じゃんけんの手の相性が全て設定されているかを判定する
        public Boolean IsSetAllRelationship(List<Hand> hands)
        {
            int countOfRelationship = 0;
            foreach (Hand hand in hands)
            {
                if (WinLostRelationships.ContainsKey(hand))
                {
                    countOfRelationship++;
                }
            }
            //この手がゲームで使用する手全てと相性が設定されていない場合、ゲームが成り立たないのでfalseを返す
            return countOfRelationship == hands.Count;
        }
    }
}