using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Janken
{
    /*
     * じゃんけんゲームの結果を出力するクラス
     */
    class JankenResultOutput : IDisposable
    {
        private StreamWriter stream = null;
        public string path { private set; get; }


        /*
         * パスと文字コードは決め打ち(CUIだし…)
         */
        public JankenResultOutput()
        {
            //実行ファイルのフォルダを取得
            path = Directory.GetCurrentDirectory();
            //ファイルを区別するために、出力時間(年、月、日、時、分、秒まで)を付与する。そのための文字列
            DateTime dateTime = DateTime.Now;
            string time = "_" + dateTime.Year + "_" + dateTime.Month + "_" + dateTime.Day + "_" + dateTime.Hour + "_" + dateTime.Minute + "_" + dateTime.Second;
            //ファイル名称
            string name = Path.DirectorySeparatorChar + "result" + time + ".CSV";
            path += name;
            Stream st = new FileStream(path,FileMode.Create,FileAccess.ReadWrite);
            stream = new StreamWriter(st, Encoding.Default);
        }

        public void Close()
        {
            stream.Close();
        }


        public void Dispose()
        {
            Close();
            stream.Dispose();
            stream = null;
        }

        public void Flush()
        {
            stream.Flush();
        }

        public void OutputCSV(List<Player> players)
        {
            foreach (Player player in players)
            {
                stream.WriteLine(player.getResultCSV());
            }
            Flush();
        }
    }
}
