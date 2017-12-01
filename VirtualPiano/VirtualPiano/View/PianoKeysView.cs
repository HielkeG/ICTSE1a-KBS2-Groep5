using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Control;
using VirtualPiano.Model;
using System.Reflection;
using System.Windows.Forms;

namespace VirtualPiano.View
{
    public partial class PianoKeysView : UserControl
    {
        List<string> KeyList = new List<string> { "C", "D", "E", "F", "G", "A", "B" };
        List<PianoKeys> PianoKeyList = new List<PianoKeys>();
        public bool showPiano = true;


        public PianoKeysView()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawKeys(e);
        }

        public void DrawKeys(PaintEventArgs e)
        {
            int x2 = 50; //pianobreedte
            int y2 = 230; // pianohoogte;
            for (int o = 1; o < 4; o++) //aantal octaven om te tekenen
            {
                for (int i = 0; i < KeyList.Count(); i++) //teken whitekeys en dan blackkeys
                {
                    if (KeyList[i] == "E" || KeyList[i] == "B")
                    {
                        WhiteKey wk = new WhiteKey(e, KeyList[i] + o, 1, 1, x2, y2);
                        PianoKeyList.Add(wk);
                    }
                    else
                    {
                        WhiteKey wk = new WhiteKey(e, KeyList[i] + o, 0, 1, x2, y2);
                        PianoKeyList.Add(wk);
                        BlackKey bk = new BlackKey(e, KeyList[i] + "#", x2 - 13, 2);
                        PianoKeyList.Add(bk);
                    }
                    x2 = x2 + 50; //pianobreedte 

                }
            }
        }

    }

    public class PianoKeys
    {
        public string keyname;

        public PianoKeys(string keyname)
        {
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
