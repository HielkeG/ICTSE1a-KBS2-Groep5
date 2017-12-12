using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public static OutputDevice outputDevice = OutputDevice.InstalledDevices[0];
        public static bool isPlayingSong = false;
        public static Image stop = Resources.stop;
        public static Image play = Resources.play;
        public static Image pause = Resources.pause;
        public static Image add = Resources.add;
        public static Image rewind = Resources.rewind;
        public static Image metronomeOn = Resources.metronome_on;
        public static Image metronomeOff = Resources.metronome;

        public static Button playBtn = new Button();
        public static Button stopBtn = new Button();
        public static Button rewindBtn= new Button();
        public static Button metronomeBtn = new Button();
        

        public static Timer Metronoom;
        public static Timer rodeLijn;
        public static Song song;
        public static int width = 50;
        public static int height = 50;
        public static event EventHandler SongStarted;
        public static event EventHandler SongStopped;
        private static int currentOctave = 0;
        private static string currentTone = "";
        public static bool isGestart = false;
        public static bool MetronomeTicking = false;

        public MusicController(Timer m, Timer r, Song s)
        {
            playBtn.Image = new Bitmap(Resources.play, 50, 50);
            playBtn.Location = new Point(110, 40);
            playBtn.Size = new Size(55, 55);
            playBtn.BackColor = Color.Transparent;
            playBtn.FlatStyle = FlatStyle.Flat;
            playBtn.FlatAppearance.BorderSize = 0;
            playBtn.FlatAppearance.BorderColor = Color.FromArgb(255,255,255, 0);
            playBtn.Click += PlayGeklikt;

            stopBtn.Location = new Point(170, 40);
            stopBtn.Image = new Bitmap(Resources.stop, 50, 50);
            stopBtn.Size = new Size(55, 55);
            playBtn.BackColor = Color.Transparent;
            stopBtn.FlatStyle = FlatStyle.Flat;
            stopBtn.FlatAppearance.BorderSize = 0;
            stopBtn.Click += StopGeklikt;

            metronomeBtn.Image = new Bitmap(metronomeOff, 50, 50);
            metronomeBtn.Location = new Point(1750, 40);
            metronomeBtn.Size = new Size(55, 55);
            metronomeBtn.BackColor = Color.Transparent;
            metronomeBtn.FlatStyle = FlatStyle.Flat;
            metronomeBtn.FlatAppearance.BorderSize = 0;
            metronomeBtn.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 255, 0);
            metronomeBtn.Click += MetronomeClick;

            Metronoom = m;
            rodeLijn = r;
            song = s;


            //standaard interval op 100 zetten. Zodat de bpm ook 100 is.
            Metronoom.Interval = 100;
            if (isGestart == false)
            {
                outputDevice.Open();
                MusicController.outputDevice.SendProgramChange(Channel.Channel3, Instrument.Woodblock);
            }
            isGestart = true;

        }
        
        public static void MetronomeClick(object sender, EventArgs e)
        {
            //als de metronoom afspeelt wordt hij gestopt. Anders wordt hij gestart.
            if (MetronomeTicking)
            {
                Metronoom.Stop();
                MetronomeTicking = false;
                metronomeBtn.Image = new Bitmap(metronomeOff, 50, 50);
            }
            else
            {
                Metronoom.Start();
                MetronomeTicking = true;
                metronomeBtn.Image = new Bitmap(metronomeOn, 50, 50);
            }

        }

        public static void PlaySound(int octave, string tone)
        {
                var player = new System.Windows.Media.MediaPlayer();
                try
                {
                    string filename = (tone).ToString();

                    if (tone == "Bes") { filename = "Ais"; }
                    else if (tone == "Des") { filename = "Cis"; }
                    else if (tone == "Es") { filename = "Dis"; }
                    else if (tone == "Ges") { filename = "Fis"; }
                    else if (tone == "As") { filename = "Gis"; }

                    player.Open(new Uri($@"../../Resources/Geluiden/{ComposeView.instrument}/{octave}{filename}.wav", UriKind.Relative));
                    player.Play();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
                currentOctave = octave;
                currentTone = tone;
        }

        public static void ResetLine()
        {
            playBtn.Image = new Bitmap(play, width, height);
            isPlayingSong = false;
            Metronoom.Enabled = false;
            ComposeView.CurrentPlayingStaff = 0;
            ComposeView.RedLineX = 0;
            rodeLijn.Stop();
        }

        public void PlayGeklikt(Object sender, EventArgs e)
        { 
            if (isPlayingSong == false)
            {
                playBtn.Image = new Bitmap(pause,width,height);
                isPlayingSong = true;
                //int temp = Song.getDuration();
                //Console.WriteLine(Song.getDuration());
                SongStarted(this, e);
                rodeLijn.Start();
 
                
            }
            else if (isPlayingSong)
            {
                playBtn.Image = new Bitmap(play,width,height);
                isPlayingSong = false;
                rodeLijn.Stop();
            }
        }


        public void StopGeklikt(Object sender, EventArgs e)
        {
            //wanneer de stopknop ingedrukt wordt. lijn opnieuw aan het begin zetten.
            playBtn.Image = new Bitmap(play,width,height);
            isPlayingSong = false;
            ComposeView.CurrentPlayingStaff = 0;
            ComposeView.RedLineX = 0;
            rodeLijn.Stop();
            SongStopped(this, e);
            outputDevice.SilenceAllNotes();
        }

        //metronoom bpm instellen. Leerling geeft een bpm in. Deze wordt omgezet naar milliseconden zodat de timer juist ingesteld wordt.
        public static void setMetronoom(int bpm)
        {
            int ms = 60000 / bpm;
            Metronoom.Interval = ms;
        }
    }
}
