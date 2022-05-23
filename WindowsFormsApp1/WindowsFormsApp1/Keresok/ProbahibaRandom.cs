using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.AllapotTer;

namespace WindowsFormsApp1.Keresok
{
    internal class ProbahibaRandom
    {
        public Operator  Ajanl(Allapot allapot)
        {
            while(true)
            {
                Random random = new Random();
                Operator op = new Operator(new Point(random.Next(Allapot.sor), random.Next(Allapot.oszlop)));
                if(op.Elofeltetel(allapot))
                {
                    return op;
                }
            }
        }

    }
}
