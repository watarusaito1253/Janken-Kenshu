using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Janken;

namespace JankenUnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        [System.Diagnostics.Conditional("LOCAL_DEBUG")]
        [Description("CPUのみの対戦テスト")]
        public void TestMain()
        {
            Console.SetIn(new StreamReader("consoleinput.txt"));
            //Console.WriteLine(new System.IO.StringReader("../../consoleinput.txt").ToString());
            JankenMain.Main();
        }
    }
}
