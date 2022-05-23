using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.AllapotTer
{
    internal class Allapot
    {
        public static int sor = 5;
        public static int oszlop = 5;

        private string[,] palya;
        private jatekosok jatekos;

        public string[,] Palya { get => palya; set => palya = value; }
        public jatekosok Jatekos { get => jatekos; set => jatekos = value; }

        public Allapot()
        {
            this.Palya = new string[sor,oszlop];
            this.Jatekos = jatekosok.E;
        }

        public enum jatekosok
        {
            G,
            E
        }

        public string Celfeltetel()
        {

            for (int i = 1; i < sor-1; i++)
            {
                for (int j = 1; j < oszlop-1; j++)
                {
                    if(palya[i,j] != null && palya[i+1,j]== palya[i,j] && Palya[i - 1, j] == palya[i, j] && palya[i, j + 1] == palya[i, j] && palya[i , j - 1] == palya[i, j])
                    {
                        return palya[i,j];
                    }

                }

            }

            /*
            for(int i = 0; i < sor; i++)
            {
                if(palya[i,0]!=null && palya[i, 0] == palya[i, 1] && palya[i, 1] == palya[i, 2] && palya[i, 2] == palya[i, 3] && palya[i, 3] == palya[i, 4])
                {
                    return palya[i,0];
                }
            }


            for (int i = 0; i < oszlop; i++)
            {
                if (palya[0, i] != null && palya[0, i] == palya[1, i] && palya[1, i] == palya[2, i] && palya[2, i] == palya[3, i] && palya[3, i] == palya[4, i])
                {
                    return palya[0, i];
                }
            }

            if (palya[0, 0] != null && palya[0, 0] == palya[1, 1] && palya[1, 1] == palya[2, 2] && palya[2, 2] == palya[3, 3] && palya[3, 3] == palya[4, 4])
            {
                return palya[0, 0];
            }

            if (palya[0, 4] != null && palya[0, 4] == palya[1, 3] && palya[1, 3] == palya[2, 2] && palya[2, 2] == palya[3, 1] && palya[3, 1] == palya[4, 0])
            {
                return palya[0, 4];
            }

            
            */
            for (int i = 0; i < sor; i++)
            {
                for (int j = 0; j < oszlop; j++)
                {
                    if (palya[i, j] == null)
                    {
                        return null;
                    }
                }
            }
            return "Döntetlen";
        }


        public Point Heurisztika()
        {
            int maxsuly = 0;
            Point point = new Point();

            for (int i = 0; i < Allapot.sor; i++)
            {
                for (int j = 0; j < Allapot.oszlop; j++)
                {
                    int suly = 0;
                    if (palya[i, j] == null)
                    {
                        if(i<Allapot.sor-1 && palya[i+1,j]!="G")
                        {
                            suly += 2;
                        }
                        if (i > 0 && palya[i - 1, j] != "G")
                        {
                            suly += 2;
                        }
                        if (j > 0 && palya[i , j - 1] != "G")
                        {
                            suly += 2;
                        }
                        if (j < Allapot.oszlop - 1 && palya[i , j + 1] != "G")
                        {
                            suly += 2;
                        }

                        if(i == 0 || i == Allapot.sor-1 || j == 0 || j == Allapot.oszlop-1)
                        {
                            suly+=9;
                        }

                        if(i == 1 || i == Allapot.sor-2 || j == Allapot.oszlop-2 || j == 1)
                        {
                            suly++;
                        }

                        if(maxsuly <= suly)
                        {
                            maxsuly = suly;
                            point.X = i;
                            point.Y = j;
                        }
                        if(maxsuly == 4)
                        {
                            return point;
                        }
                    }
                }
            }
            
            return point;
        }
    }
}
