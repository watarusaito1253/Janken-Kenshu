using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    /*
     * じゃんけんの場面ごとにクラスを実装するので、そのインターフェース
     */
    interface IJankenConsole
    {
        //クラスの細かい実装が変わっても、各クラスがこのメソッドを呼ぶことでその場面ごとの処理結果を表示する
        void ShowJankenConsole();
    }
}
