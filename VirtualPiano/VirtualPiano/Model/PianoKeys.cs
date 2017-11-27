using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPiano.Model
{
    public class PianoKeys
    {
        public string keyname;

        public PianoKeys(string keyname)
        {
            this.keyname = keyname;
        }
    }

    public class WhiteKey : PianoKeys
    {
        Pen penBlack = new Pen(Color.Black, 2);
        SolidBrush brushBlack = new SolidBrush(Color.Black);

        private Font f = new Font("Times New Roman", 24, FontStyle.Regular, GraphicsUnit.Pixel);

        //teken een vierkant voor de witte toets met nootletter erin
        public WhiteKey(PaintEventArgs e, string wname, int x1, int y1, int x2, int y2) : base(wname)
        {
            e.Graphics.DrawString(wname, f, brushBlack, new PointF(x2 - 40, 200));
            e.Graphics.DrawRectangle(penBlack, x1, y1, x2, y2);
        }
    }

    public class BlackKey : PianoKeys
    {
        Pen penWhite = new Pen(Color.White, 2);
        SolidBrush brushWhite = new SolidBrush(Color.White);
        SolidBrush brushBlack = new SolidBrush(Color.Black);

        private Font f = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);

        //teken een vierkant voor de witte toets met nootletter erin
        public BlackKey(PaintEventArgs e, string bname, int x1, int y1) : base(bname)
        {
            Rectangle rect = new Rectangle(x1, y1, 26, 150);
            e.Graphics.FillRectangle(brushBlack, rect);
            e.Graphics.DrawString(bname, f, brushWhite, new PointF(x1 + 1, 10));
        }

    }

}

