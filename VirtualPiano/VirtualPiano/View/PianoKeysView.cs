using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Model;
using System.Reflection;
using System.Windows.Forms;

namespace VirtualPiano.View
{
    public partial class PianoKeysView : UserControl
    {
        List<string> KeyList = new List<string> { "C", "D", "E", "F", "G", "A", "B" };
        List<PianoKeys> PianoKeyList = new List<PianoKeys>();

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
}
