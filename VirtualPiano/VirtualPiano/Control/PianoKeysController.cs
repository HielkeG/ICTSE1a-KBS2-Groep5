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
        public static Image openpiano = Resources.showpiano;
        public static Image close = Resources.close;
        public static Button pianoKeysBtn = new Button();
        public event EventHandler ToggledPianoVisible;

        public PianoKeysController()
        {
            pianoKeysBtn.Image = new Bitmap(Resources.showpiano, 50, 50);
            pianoKeysBtn.Location = new Point(1815, 40);
            pianoKeysBtn.Size = new Size(55, 55);
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
            if (ComposeView.keypanel.Visible==false) pianoKeysBtn.Image = new Bitmap(Resources.showpiano, 50, 50);
            else pianoKeysBtn.Image = new Bitmap(Resources.close, 50, 50);
        }
    }
}
