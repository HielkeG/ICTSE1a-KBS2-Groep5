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
        public static Image openpiano = Resources.showpiano_material;
        public static Image close = Resources.close_material;
        public static Button pianoKeysBtn = new Button();
        public event EventHandler ToggledPianoVisible;

        public PianoKeysController()
        {
            pianoKeysBtn.Image = openpiano;
            pianoKeysBtn.Location = new Point(1800, 20);
            pianoKeysBtn.Size = new Size(80, 80);
            pianoKeysBtn.BackColor = Color.Transparent;
            pianoKeysBtn.FlatStyle = FlatStyle.Flat;
            pianoKeysBtn.FlatAppearance.BorderSize = 0;
            pianoKeysBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            pianoKeysBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;

            pianoKeysBtn.Click += pianoKeysBox_MouseClick;
        }

        public void pianoKeysBox_MouseClick(Object sender, EventArgs e)
        {
            if (ComposeView.keypanel.Visible) ToggledPianoVisible(this, e);
            else ToggledPianoVisible(this, e);
        }

        public void ChangeImage()
        {
            if (ComposeView.keypanel.Visible == false)
            {
                pianoKeysBtn.Image = openpiano;
                pianoKeysBtn.Image = BitmapController.ColorReplace(pianoKeysBtn.Image, 30, Color.White, Color.LightGray);
            }
            else
            {
                pianoKeysBtn.Image = close;
                pianoKeysBtn.Image = BitmapController.ColorReplace(pianoKeysBtn.Image, 30, Color.White, Color.LightGray);

            }
        }
    }
}
