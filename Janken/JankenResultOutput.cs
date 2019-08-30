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
        private StreamWriter Stream = null;
        public string Path { private set; get; }


        /*
         * パスと文字コードは決め打ち(CUIだし…)
         */
        public JankenResultOutput()
        {
            //実行ファイルのフォルダを取得
            Path = Directory.GetCurrentDirectory();
            //ファイルを区別するために、出力時間(年、月、日、時、分、秒まで)を付与する。そのための文字列
            DateTime dateTime = DateTime.Now;
            string time = "_" + dateTime.Year + "_" + dateTime.Month + "_" + dateTime.Day + "_" + dateTime.Hour + "_" + dateTime.Minute + "_" + dateTime.Second;
            //ファイル名称
            string name = System.IO.Path.DirectorySeparatorChar + "result" + time + ".CSV";
            Path += name;
            Stream st = new FileStream(Path, FileMode.Create, FileAccess.ReadWrite);
            Stream = new StreamWriter(st, Encoding.Default);
        }

        public void Close()
        {
            Stream.Close();
        }


        public void Dispose()
        {
            Close();
            Stream.Dispose();
            Stream = null;
        }

        public void Flush()
        {
            Stream.Flush();
        }

        public void OutputCSV(List<Player> players)
        {
            foreach (Player player in players)
            {
                Stream.WriteLine(player.GetResultCSV());
            }
            Flush();
        }
    }
}