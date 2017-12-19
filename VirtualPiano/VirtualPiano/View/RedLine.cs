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
            Visible = false;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (ComposeView.RedLineX >= 362 && ComposeView.RedLineX <= 368)
            {
                ComposeView.RedLineX = 390;
            }
            if (ComposeView.RedLineX >= 793 && ComposeView.RedLineX <= 798)
            {
                ComposeView.RedLineX = 822;
            }
            if (ComposeView.RedLineX >= 1222 && ComposeView.RedLineX <= 1228)
            {
                ComposeView.RedLineX = 1250;
            }
            base.OnPaint(e);

            e.Graphics.DrawLine(penRed, new Point(65 + ComposeView.RedLineX, 50), new Point(65 + ComposeView.RedLineX, 110));
            

        }
    }
}
