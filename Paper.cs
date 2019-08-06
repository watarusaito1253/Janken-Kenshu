using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    
     class Paper:Hand
    {

        public Paper()
        {
            DisplayName = "パー";
            DisplayAA = "　　　　　｢｢｢h" + Environment.NewLine + "　　　 　Ｃ　ﾉ" + Environment.NewLine + "　 ∧_∧ / ／" + Environment.NewLine + "　( ･ω･)／";
        }
    }
}
