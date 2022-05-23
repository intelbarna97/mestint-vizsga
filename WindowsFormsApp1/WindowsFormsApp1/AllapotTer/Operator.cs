using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.AllapotTer
{
    internal class Operator
    {
        private Point hova;


        public Operator(Point hova)
        {
            this.Hova = hova;
        }

        public Point Hova { get => hova; set => hova = value; }

        public bool Elofeltetel(Allapot aktualisAllapot)
        {
            return aktualisAllapot.Palya[Hova.X, Hova.Y] == null;
        }

        public Allapot Lerak(Allapot aktualisAllapot)
        {
            Allapot ujAllapot = new Allapot();
            ujAllapot.Palya = (string[,])aktualisAllapot.Palya.Clone();

            

            if(aktualisAllapot.Jatekos == Allapot.jatekosok.E)
            {
                ujAllapot.Jatekos = Allapot.jatekosok.G;
                ujAllapot.Palya[Hova.X, Hova.Y] = "E";
            }
            else
            {
                ujAllapot.Jatekos = Allapot.jatekosok.E;
                ujAllapot.Palya[Hova.X, Hova.Y] = "G";
            }

            return ujAllapot;
        }
    }
}
