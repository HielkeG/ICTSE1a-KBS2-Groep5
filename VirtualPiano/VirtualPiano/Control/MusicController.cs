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
        public static Image recordstart = new Bitmap(Resources.record_start, 50, 50);
        public static Image recordstop = new Bitmap(Resources.record_stop, 50, 50);
        public static Bitmap metronomeOn1 = new Bitmap(Resources.metronome_on1, 50, 50);
        public static Bitmap metronomeOn2 = new Bitmap(Resources.metronome_on2, 50, 50);
        public static Bitmap metronomeOff1 = new Bitmap(Resources.metronome_off1, 50, 50);
        public static Bitmap metronomeOff2 = new Bitmap(Resources.metronome_off2, 50, 50);

        public static Button playBtn = new Button();
        public static Button stopBtn = new Button();
        public static Button rewindBtn = new Button();
        public static Button metronomeBtn = new Button();
        public static Button recordBtn = new Button();

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
        public static bool isRecording = false;

        public MusicController(Timer m, Timer r, Song s)
        {
            playBtn.Name = "PlayBtn";
            playBtn.Image = new Bitmap(Resources.play, 50, 50);
            playBtn.Location = new Point(110, 35);
            playBtn.Size = new Size(55, 55);
            playBtn.BackColor = Color.Transparent;
            playBtn.FlatStyle = FlatStyle.Flat;
            playBtn.FlatAppearance.BorderSize = 0;
            playBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            playBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            playBtn.Click += PlayGeklikt;

            stopBtn.Name = "StopBtn";
            stopBtn.Location = new Point(170, 35);
            stopBtn.Image = new Bitmap(Resources.stop, 50, 50);
            stopBtn.Size = new Size(55, 55);
            stopBtn.FlatStyle = FlatStyle.Flat;
            stopBtn.FlatAppearance.BorderSize = 0;
            stopBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            stopBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            stopBtn.Click += StopGeklikt;

            recordBtn.Name = "RecordBtn";
            recordBtn.Image = recordstart;
            recordBtn.Location = new Point(230, 35);
            recordBtn.Size = new Size(55, 55);
            recordBtn.BackColor = Color.Transparent;
            recordBtn.FlatStyle = FlatStyle.Flat;
            recordBtn.FlatAppearance.BorderSize = 0;
            recordBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            recordBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            recordBtn.Click += RecordClick;

            metronomeBtn.Name = "MetronomeBtn";
            metronomeBtn.Image = metronomeOff1;
            metronomeBtn.Location = new Point(1750, 35);
            metronomeBtn.Size = new Size(55, 55);
            metronomeBtn.BackColor = Color.Transparent;
            metronomeBtn.FlatStyle = FlatStyle.Flat;
            metronomeBtn.FlatAppearance.BorderSize = 0;
            metronomeBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            metronomeBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
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

        private void RecordClick(object sender, EventArgs e)
        {
            if (isRecording)
            {
                recordBtn.Image = recordstart;
                recordBtn.Image = BitmapController.ColorReplace(recordBtn.Image, 30, Color.White, Color.LightGray);
                isRecording = false;
            }
            else
            {
                recordBtn.Image = recordstop;
                recordBtn.Image = BitmapController.ColorReplace(recordBtn.Image, 30, Color.White, Color.LightGray);
                isRecording = true;
            }
        }

        public static void MetronomeClick(object sender, EventArgs e)
        {
            //als de metronoom afspeelt wordt hij gestopt. Anders wordt hij gestart.
            if (MetronomeTicking)
            {
                Metronoom.Stop();
                MetronomeTicking = false;
                if (metronomeBtn.Image == metronomeOn1) metronomeBtn.Image = metronomeOff1;
                else metronomeBtn.Image = metronomeOff2;
            }
            else
            {
                Metronoom.Start();
                MetronomeTicking = true;
                if (metronomeBtn.Image == metronomeOff1) metronomeBtn.Image = metronomeOn1;
                else metronomeBtn.Image = metronomeOn2;
            }
        }

        public static void ResetLine()
        {
            playBtn.Image = new Bitmap(play, width, height);
            isPlayingSong = false;
            Metronoom.Enabled = false;
            ComposeView.CurrentPlayingStaff = 0;
            ComposeView.RedLineX = -25;
            rodeLijn.Stop();
        }

        public void PlayGeklikt(Object sender, EventArgs e)
        {
            if (isPlayingSong == false)
            {
                playBtn.Image = new Bitmap(pause, width, height);
                playBtn.Image = BitmapController.ColorReplace(playBtn.Image, 30, Color.White, Color.LightGray);
                isPlayingSong = true;
                SongStarted(this, e);
                rodeLijn.Start();
            }
            else if (isPlayingSong)
            {
                playBtn.Image = new Bitmap(play, width, height);
                playBtn.Image = BitmapController.ColorReplace(playBtn.Image, 30, Color.White, Color.LightGray);
                isPlayingSong = false;
                rodeLijn.Stop();
            }
        }

        public void StopGeklikt(Object sender, EventArgs e)
        {
            //wanneer de stopknop ingedrukt wordt. lijn opnieuw aan het begin zetten.
            playBtn.Image = new Bitmap(play, width, height);
            isPlayingSong = false;
            ComposeView.CurrentPlayingStaff = 0;
            ComposeView.RedLineX = -60;
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
