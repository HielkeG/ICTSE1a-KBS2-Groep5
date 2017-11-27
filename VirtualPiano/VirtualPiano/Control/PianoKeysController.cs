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
        public static Image showpiano = Resources.showpiano;
        public static Image close = Resources.close;
        public static PictureBox pianoKeysBox = new PictureBox();
        public static int width = 50;
        public static int height = 50;

        public bool showPiano = true;

        public PianoKeysController()
        {
            pianoKeysBox.Location = new Point(290, 30);
            pianoKeysBox.Image = new Bitmap(showpiano, width, height);
            pianoKeysBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pianoKeysBox.Click += pianoKeysBox_Geklikt;


        }

        public void pianoKeysBox_Geklikt(Object sender, EventArgs e)
        {
            if (showPiano == true)
            {
               
                pianoKeysBox.Image = new Bitmap(close, width, height);
                showPiano = false;
            }
            else
            {
                pianoKeysBox.Image = new Bitmap(showpiano, width, height);
                showPiano = true;
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
}
