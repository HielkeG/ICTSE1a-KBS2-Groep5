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
    public class MusicController
    {
        public static bool isAanHetSpelen = false;
        public static Image stop = Resources.stop;
        public static Image play = Resources.play;
        public static Image pause = Resources.pause;
        public static Image add = Resources.add;
        public static Image rewind = Resources.rewind;
        public static PictureBox playBox = new PictureBox();
        public static PictureBox stopBox = new PictureBox();
        public static PictureBox rewindBox = new PictureBox();
        public static Timer Metronoom;
        public static Timer rodeLijn;
        public static Song song;
        public static int width = 50;
        public static int height = 50;

        public MusicController(Timer m, Timer r, Song s)
        {
            rewindBox.Location = new Point(110, 30);
            rewindBox.Image = new Bitmap(rewind,width,height);
            rewindBox.SizeMode = PictureBoxSizeMode.AutoSize;

            playBox.Location = new Point(170, 30);
            playBox.Image = new Bitmap(play,width,height);
            playBox.SizeMode = PictureBoxSizeMode.AutoSize;
            playBox.Click += PlayGeklikt;


            stopBox.Location = new Point(230, 30);
            stopBox.Image = new Bitmap(stop,width,height);
            stopBox.SizeMode = PictureBoxSizeMode.AutoSize;
            stopBox.Click += StopGeklikt;
            Metronoom = m;
            rodeLijn = r;
            song = s;
            Metronoom.Interval = 500;
        }


        public void PlayGeklikt(Object sender, EventArgs e)
        { 
            if (isAanHetSpelen == false)
            {
                playBox.Image = new Bitmap(pause,width,height);
                isAanHetSpelen = true;
                Metronoom.Enabled = true;
                //int temp = Song.getDuration();
                //Console.WriteLine(Song.getDuration());
                song.PlaySong();
                //rodeLijn.Start();
 
                
            }
            else if (isAanHetSpelen)
            {
                playBox.Image = new Bitmap(play,width,height);
                isAanHetSpelen = false;
                Metronoom.Enabled = false;
                
                //rodeLijn.Stop();
            }
        }


        public void StopGeklikt(Object sender, EventArgs e)
        {
            playBox.Image = new Bitmap(play,width,height);
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
