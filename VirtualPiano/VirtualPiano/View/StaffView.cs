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
      

        public StaffView()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Drawlines(e);
        }

        private void Drawlines(PaintEventArgs e)
        {
            Pen penBlack = new Pen(Color.Black);
            int i = 0;
            while (i < 5)
            {
                e.Graphics.DrawLine(penBlack, 10, 30 + i * 25, 1600, 30 + i * 25);
                i++;

            }
        }
    }
}
