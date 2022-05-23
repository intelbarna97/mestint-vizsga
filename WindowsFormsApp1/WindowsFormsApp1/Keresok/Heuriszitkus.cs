using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.AllapotTer;

namespace WindowsFormsApp1.Keresok
{
    internal class Heuriszitkus
    {
        public Operator Ajanl(Allapot allapot)
        {
            while(true)
            {
                Operator op = new Operator(allapot.Heurisztika());
                if (op.Elofeltetel(allapot))
                {
                    return op;
                }
            }
        }
    }
}
