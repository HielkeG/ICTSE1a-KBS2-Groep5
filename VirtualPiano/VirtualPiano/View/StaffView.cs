using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Model;
using VirtualPiano.Properties;

namespace VirtualPiano.View
{
    public partial class StaffView : UserControl
    {
        public Staff staff;

        public StaffView(Staff staff)
        {
            this.staff = staff;
            InitializeComponent();  
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Drawlines(e);
            DrawBars(e);
        }

        private void Drawlines(PaintEventArgs e)
        {
            Pen penBlack = new Pen(Color.Black);
            e.Graphics.DrawLine(penBlack, 10, 30, 10, 110);
            int i = 0;
            while (i < 5)
            {
                e.Graphics.DrawLine(penBlack, 10, 30 + i * 20, 1550, 30 + i * 20);
                i++;
            }
        }

        public void DrawBars(PaintEventArgs e)
        {
            int x_bar = 425;
            ClefName latestClef = ClefName.NULL;
            foreach (Bar bar in staff.Bars)
            {
                if(bar.clef == ClefName.G && latestClef != ClefName.G)
                {
                    e.Graphics.DrawImage(Resources.gsleutel,x_bar-415,0,50,150);
                    latestClef = ClefName.G;
                }
                else if (bar.clef == ClefName.F && latestClef != ClefName.F)
                {
                    e.Graphics.DrawImage(Resources.fsleutel, x_bar-425, 25, 43, 65);
                    latestClef = ClefName.F;
                }
                else if (bar.clef == ClefName.C && latestClef != ClefName.C)
                {
                    latestClef = ClefName.C;
                }
                e.Graphics.DrawLine(new Pen(Color.Black),x_bar,30,x_bar,110);  
                x_bar += 375;
            }     
        }

    }
}
