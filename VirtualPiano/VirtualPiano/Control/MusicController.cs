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
        public static bool isPlayingSong = false;
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
        public static event EventHandler SongStarted;
        public static event EventHandler SongStopped;

        public MusicController(Timer m, Timer r, Song s)
        {
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
            if (isPlayingSong == false)
            {
                playBox.Image = new Bitmap(pause,width,height);
                isPlayingSong = true;
                Metronoom.Enabled = true;
                //int temp = Song.getDuration();
                //Console.WriteLine(Song.getDuration());
                SongStarted(this, e);
                rodeLijn.Start();
 
                
            }
            else if (isPlayingSong)
            {
                playBox.Image = new Bitmap(play,width,height);
                isPlayingSong = false;
                Metronoom.Enabled = false;
                
                rodeLijn.Stop();
            }
        }


        public void StopGeklikt(Object sender, EventArgs e)
        {
            //wanneer de stopknop ingedrukt wordt. lijn opnieuw aan het begin zetten.
            playBox.Image = new Bitmap(play,width,height);
            isPlayingSong = false;
            Metronoom.Enabled = false;
            ComposeView.CurrentPlayingStaff = 0;
            ComposeView.RedLineX = 0;
            rodeLijn.Stop();
            SongStopped(this, e);
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
