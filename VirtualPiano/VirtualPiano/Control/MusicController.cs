using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Properties;
using VirtualPiano.View;

namespace VirtualPiano.Control
{
    public class MusicController
    {
        private bool isAanHetSpelen = false;
        public static Image stop = Resources.stop;
        public static Image play = Resources.play;
        public static Image pause = Resources.pause;
        public static Image add = Resources.add;
        public static Image rewind = Resources.rewind;
        public static PictureBox playBox = new PictureBox();
        public static PictureBox stopBox = new PictureBox();
        public static PictureBox rewindBox = new PictureBox();
        public static Timer Metronoom;


        public MusicController(Timer m)
        {
            rewindBox.Location = new Point(115, 30);
            rewindBox.Image = new Bitmap(rewind);
            rewindBox.SizeMode = PictureBoxSizeMode.AutoSize;


            playBox.Location = new Point(150, 30);
            playBox.Image = new Bitmap(play);
            playBox.SizeMode = PictureBoxSizeMode.AutoSize;
            playBox.Click += PlayGeklikt;


            stopBox.Location = new Point(185, 30);
            stopBox.Image = new Bitmap(stop);
            stopBox.SizeMode = PictureBoxSizeMode.AutoSize;
            stopBox.Click += StopGeklikt;
            Metronoom = m;
            Metronoom.Interval = 500;
        }


        public void PlayGeklikt(Object sender, EventArgs e)
        {

            if (isAanHetSpelen == false)
            {
                playBox.Image = new Bitmap(pause);
                isAanHetSpelen = true;
                Metronoom.Enabled = true;
            }
            else if (isAanHetSpelen)
            {
                playBox.Image = new Bitmap(play);
                isAanHetSpelen = false;
                Metronoom.Enabled = false;
            }
        }


        public void StopGeklikt(Object sender, EventArgs e)
        {
            playBox.Image = new Bitmap(play);
            isAanHetSpelen = false;
            Metronoom.Enabled = false;
        }

        public static void setMetronoom(int snelheid)
        {
            if (snelheid < 100)
            {
                Metronoom.Interval = 100;
            }
            else
            {
                Metronoom.Interval = snelheid;
            }
        }
    }
}
