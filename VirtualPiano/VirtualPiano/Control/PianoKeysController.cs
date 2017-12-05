using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Model;
using VirtualPiano.Properties;
using VirtualPiano.View;

namespace VirtualPiano.Control
{
    public class PianoKeysController
    {
        public static Image openpiano = Resources.openpiano;
        public static Image close = Resources.close;
        public static Button pianoKeysBtn = new Button();

        public PianoKeysController()
        {
            pianoKeysBtn.Image = new Bitmap(Resources.openpiano, 50, 50);
            pianoKeysBtn.Location = new Point(1815, 40);
            pianoKeysBtn.Size = new Size(55, 55);
            pianoKeysBtn.BackColor = Color.Transparent;
            pianoKeysBtn.FlatStyle = FlatStyle.Flat;
            pianoKeysBtn.FlatAppearance.BorderSize = 0;
            pianoKeysBtn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, Color.Black);

            pianoKeysBtn.Click += pianoKeysBox_MouseClick;
        }

        public void pianoKeysBox_MouseClick(Object sender, EventArgs e)
        {
            if (ComposeView.keypanel.Visible)
            {
                pianoKeysBtn.Image = new Bitmap(Resources.openpiano, 50, 50);
                ComposeView.keypanel.Visible = false;
            }
            else
            {
                pianoKeysBtn.Image = new Bitmap(Resources.close, 50, 50);
                ComposeView.keypanel.Visible = true;

            }
        }
    }


    //public void ShowPianoGeklikt(Object sender, EventArgs e)
    //{
    //    if (showPianoKeys == false)
    //    {
    //        pianoKeysBox.Image = new Bitmap(add, width, height);
    //        showPianoKeys = true;

    //    }
    //    else if (showPianoKeys)
    //    {
    //        pianoKeysBox.Image = new Bitmap(add, width, height);
    //        showPianoKeys = false;
    //    }
    //}
}
