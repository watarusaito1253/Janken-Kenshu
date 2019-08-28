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
        //戦績用　
        public int PlayerWinCount { get; protected set; }
        public int PlayerLoseCount { get; protected set; }
        public int PlayerDrawCount { get; protected set; }

        //戦績のためにリストで今までの結果全てを保持する
        public List<BattaleResult> BattaleResults;

        public Player(string pName)
        {
            this.PlayerName = pName;
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
                    result = PlayerHand.GetWinLostRelationship(enemy.PlayerHand);
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


        //戦績のために勝敗結果をまとめて返す
        public string GetCalcPlayerResult()
        {
            double winRate = 0.0;
            double loseRate = 0.0;
            double drawRate = 0.0;
            winRate = Math.Round(PlayerWinCount / (double)BattaleResults.Count * 100.0);
            loseRate = Math.Round(PlayerLoseCount / (double)BattaleResults.Count * 100.0);
            drawRate = Math.Round(PlayerDrawCount / (double)BattaleResults.Count * 100.0);
            return PlayerName + "の戦績 勝利:" + PlayerWinCount + "回 敗北:" + PlayerLoseCount + "回 引分:" + PlayerDrawCount + "回 " + "勝率:" + winRate + "% 敗率:" + loseRate + "% 引率:" + drawRate + "%";
        }

        //戦績出力のために、CSV形式で結果を返す
        public string GetResultCSV()
        {
            return GetType() + "," + PlayerName + "," + PlayerWinCount + "," + PlayerLoseCount + "," + PlayerDrawCount;
        }

    }
}
