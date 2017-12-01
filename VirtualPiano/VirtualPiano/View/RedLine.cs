using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPiano.View
{
    public partial class RedLine : UserControl
    {
        Pen penRed = new Pen(Color.Red, 4);

        public RedLine()
        {
            InitializeComponent();            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(penRed, new Point(65 + ComposeView.RedLineX, 50), new Point(65 + ComposeView.RedLineX, 110));
    
        }
    }
}
