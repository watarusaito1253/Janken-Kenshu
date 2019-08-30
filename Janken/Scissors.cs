using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Janken
{

    class Scissors : Hand
    {
        public Scissors()
        {
            DisplayName = "チョキ";
            DisplayAA = "　　　　　(Ｖ)" + Environment.NewLine + "　　　 　 /ｱE)" + Environment.NewLine + "　 ∧_∧ / ／" + Environment.NewLine + "　( ･ω･)／";
        }
    }
}