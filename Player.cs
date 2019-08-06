using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * プレイヤーとなる抽象クラス
     * humanとCPUでは、手を選択する以外は共通処理なのでこのクラスで処理する
     */
    abstract class Player
    {
        public string PlayerName {get; set;}
        public Hand PlayerHand { get; set; }
        //戦績用　後で使う
        protected int PlayerWinCount { get; set; }
        protected int PlayerLoseCount { get; set; }
        protected int PlayerDrawCount { get; set; }

        //戦績のためにリストで今までの結果全てを保持する
        public List<BattaleResult> BattaleResults;

        public Player(string PlayerName)
        {
            this.PlayerName = PlayerName;
            PlayerWinCount = 0;
            PlayerLoseCount = 0;
            PlayerDrawCount = 0;
            BattaleResults = new List<BattaleResult>();
        }

        public BattaleResult DoBattle(Player me,List<Player> allPlayer) {
            int winCount = 0;
            int lostCount = 0;
            int drawCount = 0;
            foreach (Player enemy in allPlayer)
            {
                //自分とは戦わない。自分以外とは全員と戦う
                if (enemy.Equals(me)){
                    continue;
                }
                int result;
                try
                {
                    result = PlayerHand.getWinLostRelationship(enemy.PlayerHand);
                }
                catch (Exception)
                {
                    throw;//じゃんけんに設定されていない手を返したらエラーを投げる
                }
              
                if(result == BattaleResult.Win)
                {
                    winCount++;
                }else if(result == BattaleResult.Lose)
                {
                    lostCount++;
                }else if(result == BattaleResult.Draw)
                {
                    drawCount++;
                }
            }

            
            if(winCount > 0 && lostCount == 0)//勝ちフラグがあるが、負けフラグはない=勝ち
            {
                PlayerWinCount++;
                return new BattaleResult(BattaleResult.Win);
            }else if(winCount == 0 && lostCount > 0) //負けフラグがあるが、勝ちフラグはない=負け
            {
                PlayerLoseCount++;
                return new BattaleResult(BattaleResult.Lose);
            }
            else//勝ちと負けフラグがある、または引分のみは引分
            {
                PlayerDrawCount++;
                return new BattaleResult(BattaleResult.Draw);
            }
        }

        public abstract Hand SelectHand(List<Hand> hands);
    }
}
