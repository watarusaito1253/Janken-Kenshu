using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{
    class Rock :Hand
    {
        public Rock()
        {
            DisplayName = "グー";
            DisplayAA = "　　　　　/｣｣｣｣" + Environment.NewLine + "　　　 　｜っ丿" + Environment.NewLine + "　 ∧_∧ / ／" + Environment.NewLine + "　( ･ω･)／";
        }
    }
}
