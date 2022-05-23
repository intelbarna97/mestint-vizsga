using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.AllapotTer;
using WindowsFormsApp1.Keresok;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Allapot allapot;
        private Mezo[,] palya = new Mezo[Allapot.oszlop, Allapot.sor];
        public Form1()
        {
            InitializeComponent();

            allapot = new Allapot();

            for (int i = 0; i < Allapot.sor; i++)
            {
                for (int j = 0; j < Allapot.oszlop; j++)
                {
                    Mezo mezo = new Mezo(i, j);
                    mezo.Location = new Point(i * 100, j * 100);
                    Controls.Add(mezo);
                    mezo.Click += new EventHandler(mezoClick);
                    palya[i, j] = mezo;
                }
            }
        }
        private void mezoClick(object sender, EventArgs e)
        {
            Mezo mezo = (Mezo)sender;
            Point pont = mezo.Pont;

            Operator op = new Operator(pont);
            if (op.Elofeltetel(allapot))
            {
                Kirajzol(mezo);
                allapot = op.Lerak(allapot);
                CelfeltetelVizsgalat();

                ProbahibaRandom probaHibaKereses = new ProbahibaRandom();
                Heuriszitkus heuriszitkus = new Heuriszitkus();

                Operator opGep = heuriszitkus.Ajanl(allapot);

                Mezo mezoGep = palya[opGep.Hova.X, opGep.Hova.Y];
                Kirajzol(mezoGep);
                allapot = opGep.Lerak(allapot);
                CelfeltetelVizsgalat();
            }
        }

        private void CelfeltetelVizsgalat() 
        {
            if (allapot.Celfeltetel() != null)
            {
                if(allapot.Celfeltetel() == "Döntetlen")
                {
                    MessageBox.Show(allapot.Celfeltetel());
                }
                else
                {
                    if(allapot.Celfeltetel()=="E")
                    {

                        MessageBox.Show("Nyertes Gép. ");
                    }
                    else if(allapot.Celfeltetel()=="G")
                    {
                        MessageBox.Show("Nyertes Ember. ");
                    }
                }
                this.Close();
                Application.Exit();
            }
        }
        private void Kirajzol( Mezo mezo)
        {
            mezo.Text = allapot.Jatekos.ToString();
            if(allapot.Jatekos==Allapot.jatekosok.E)
            {
                mezo.ForeColor = Color.Red;
            }
            else
            {
                mezo.ForeColor = Color.Blue;
            }
        }
    }
}
