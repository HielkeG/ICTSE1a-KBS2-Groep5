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
            e.Graphics.DrawLine(penBlack, 10, 30, 10, 130);
            int i = 0;
            while (i < 5)
            {
               
      
                e.Graphics.DrawLine(penBlack, 10, 30 + i * 25, 1600, 30 + i * 25);
                i++;

            }
        }

        public void DrawBars(PaintEventArgs e)
        {
            int x_bar = 363;
            foreach (Bar bar in staff.Bars)
            {
                e.Graphics.DrawLine(new Pen(Color.Black),x_bar,30,x_bar,130);  
                x_bar += 312;
            }
            
        }
    }
}
