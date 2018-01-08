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
        public static Image play = new Bitmap(Resources.play_material, 90, 90);
        public static Image stop = new Bitmap(Resources.stop_material, 90, 90);
        public static Image pause = new Bitmap(Resources.pause_material, 90, 90);
        public static Image rewind = new Bitmap(Resources.rewind, 90, 90);
        public static Image recordstart = new Bitmap(Resources.record_start_material, 90, 90);
        public static Image recordstop = new Bitmap(Resources.record_active_material, 90, 90);
        public static Image metronomeOn1 = new Bitmap(Resources.metronome_on_material, 90, 90);
        public static Image metronomeOn2 = new Bitmap(Resources.metronome_on_material2, 90, 90);
        public static Image metronomeOff = new Bitmap(Resources.metronome_off_material, 90, 90);

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
        public static bool isGestart = false;
        public static bool MetronomeTicking = false;
        public static bool isRecording = false;
        public static bool recordingStarted = false;
        public static event EventHandler ToggledPianoVisible;
        public static event EventHandler StartRecord;

        public MusicController(Timer m, Timer r, Song s)
        {
            playBtn.Name = "PlayBtn";
            playBtn.Image = play;
            playBtn.Size = new Size(85, 85);
            playBtn.Location = new Point(100, 20);
            playBtn.BackColor = Color.Transparent;
            playBtn.FlatStyle = FlatStyle.Flat;
            playBtn.FlatAppearance.BorderSize = 0;
            playBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            playBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            playBtn.Click += PlayClicked;

            stopBtn.Name = "StopBtn";
            stopBtn.Image = stop;
            stopBtn.Size = new Size(85, 85);
            stopBtn.Location = new Point(185, 20);
            recordBtn.BackColor = Color.Transparent;
            stopBtn.FlatStyle = FlatStyle.Flat;
            stopBtn.FlatAppearance.BorderSize = 0;
            stopBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            stopBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            stopBtn.Click += StopClicked;

            recordBtn.Name = "RecordBtn";
            recordBtn.Image = recordstart;
            recordBtn.Size = new Size(85, 85);
            recordBtn.Location = new Point(270, 20);
            recordBtn.BackColor = Color.Transparent;
            recordBtn.FlatStyle = FlatStyle.Flat;
            recordBtn.FlatAppearance.BorderSize = 0;
            recordBtn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            recordBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            recordBtn.Click += RecordClick;

            metronomeBtn.Name = "MetronomeBtn";
            metronomeBtn.Image = metronomeOff;
            metronomeBtn.Size = new Size(85, 85);
            metronomeBtn.Location = new Point(1700, 20);
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

        public void RecordClick(object sender, EventArgs e)
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
                if (!ComposeView.keypanel.Visible) { ToggledPianoVisible(this, e); }
                StartRecord(this, e);
                recordingStarted = true;
            }
        }

        public static void MetronomeClick(object sender, EventArgs e)
        {
            //als de metronoom afspeelt wordt hij gestopt. Anders wordt hij gestart.
            if (MetronomeTicking)
            {
                Metronoom.Stop();
                MetronomeTicking = false;
                if (metronomeBtn.Image == metronomeOn1) metronomeBtn.Image = metronomeOff;
                else metronomeBtn.Image = metronomeOff;
            }
            else
            {
                Metronoom.Start();
                MetronomeTicking = true;
                if (metronomeBtn.Image == metronomeOff) metronomeBtn.Image = metronomeOn1;
                else metronomeBtn.Image = metronomeOn2;
            }
        }

        public static void ResetLine()
        {
            playBtn.Image = play;
            isPlayingSong = false;
            Metronoom.Enabled = false;
            ComposeView.CurrentPlayingStaff = 0;
            ComposeView.RedLineX = -25;
            rodeLijn.Stop();
        }

        public void PlayClicked(Object sender, EventArgs e)
        {
            playBtn.FlatAppearance.BorderSize = 0;
            if (isPlayingSong == false)
            {
                playBtn.Image = pause;
                playBtn.FlatAppearance.BorderSize = 0;
                isPlayingSong = true;
                SongStarted(this, e);
                rodeLijn.Start();
            }
            else if (isPlayingSong)
            {
                playBtn.Image = play;
                isPlayingSong = false;
                rodeLijn.Stop();
            }
        }

        public void StopClicked(Object sender, EventArgs e)
        {
            //wanneer de stopknop ingedrukt wordt. lijn opnieuw aan het begin zetten.
            playBtn.Image = play;
            stopBtn.FlatAppearance.BorderSize = 0;
            isPlayingSong = false;
            ComposeView.CurrentPlayingStaff = 0;
            ComposeView.RedLineX = -60;
            rodeLijn.Stop();
            SongStopped(this, e);
            outputDevice.SilenceAllNotes();
            isRecording = false;
        }

        //metronoom bpm instellen. Leerling geeft een bpm in. Deze wordt omgezet naar milliseconden zodat de timer juist ingesteld wordt.
        public static void setMetronoom(int bpm)
        {
            int ms = 60000 / bpm;
            Metronoom.Interval = ms;
        }
    }
}
