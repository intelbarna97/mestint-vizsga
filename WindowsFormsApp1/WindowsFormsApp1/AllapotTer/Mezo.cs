﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.AllapotTer
{
    internal class Mezo : Button
    {
        Point pont;

        public Point Pont { get => pont; set => pont = value; }

        public Mezo(int x, int y)
        {
            this.Pont = new Point(x, y);
            this.Size = new Size(100,100);
            this.Font = new Font(this.Font.FontFamily, 20, FontStyle.Bold);
        }
    }
}
