using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Model;
using VirtualPiano.Control;
using VirtualPiano.Properties;
using System.Media;
using System.Reflection;

namespace VirtualPiano.View
{
    public partial class ComposeView : UserControl
    {
        public Song song = new Song();
        Button btnAddStaff = new Button();
        
        int y_staff = 140;
        public static bool ConnectSelected = false;
        public static Note selectedNote1;
        public static Note selectedNote2;
        public static bool signSelected;
        public static string SelectedSign = "";
        public static bool cursorIsDown;
        private List<StaffView> staffViews = new List<StaffView>();
        private List<Panel> staffViewsPanels = new List<Panel>();
        private bool firstStart = true;
        public static System.Timers.Timer Songtimer = new System.Timers.Timer();  //Aparte timer zodat deze meerdere threads gebruikt.
        public static string instrument = "Piano";
        public static int CurrentOctave = 3;
        public static int CurrentPlayingStaff = 0;
        private static bool RunningTimer;    //boolean of de timer loopt, zodat hij niet onnodig meerdere timers start.
        public static int RedLineX;   //locatie van de rode lijn
        public int StaffCounter = 0;
        public static bool PlayingKeyboard = false;
        

        public PianoKeysController pkc1 = new PianoKeysController();
        public static PianoKeysView pkv1 = new PianoKeysView();
        public static Sign draggingSign;
        public static Panel keypanel = new Panel()
        {
            Location = new Point(600, 730),
            Size = new Size(1400, 240),
            //Location = new Point(this.ClientSize.Width / 2 - Size.Width / 2, this.ClientSize.Height / 2 - Size.Height / 2),
            Anchor = AnchorStyles.None,
            Dock = DockStyle.Bottom,
            Visible = false
        };

        public ComposeView()
        {
            Songtimer.Interval = 5;
            Songtimer.Elapsed += TimerTick;

            InitializeComponent();
            if (firstStart)
            {
                ShowFirstStaffView();
                firstStart = false;
            }
            //methodes koppelen aan het starten en stoppen vna het afspelen.
            MusicController.SongStarted += StartTimer;
            MusicController.SongStopped += StopTimer;
            menuBarView1.Song = song;
            menuBarView1.selectedSong += ChangeSong;
            menuBarView1.newSong += NewSong;
            menuBarView1.newStaffView += newStaffView;

            //piano toevoegen
            Controls.Add(PianoKeysController.pianoKeysBtn);
            pkv1.Location = new Point(35,150);
            pkv1.Visible = false;
            pkv1.Size = new Size(1400, 240);
            Controls.Add(pkv1);

            pkc1.ToggledPianoVisible += TogglePianoVisible;
            menuBarView1.togglePianoVisible += TogglePianoVisible;
            
            //voeg muziekknoppen toe en metronoom
            MusicController m1 = new MusicController(Metronome, RedLine, song);
            Controls.Add(MusicController.rewindBtn);
            Controls.Add(MusicController.playBtn);
            Controls.Add(MusicController.stopBtn);
            //voeg hover, enter, leave effecten toe op de muziekknoppen
            PianoKeysController.pianoKeysBtn.MouseEnter += new EventHandler(AllButtons_Enter);
            PianoKeysController.pianoKeysBtn.MouseHover += new EventHandler(AllButtons_Hover);
            PianoKeysController.pianoKeysBtn.MouseLeave += new EventHandler(AllButtons_Leave);
            MusicController.playBtn.MouseEnter += new EventHandler(AllButtons_Enter);
            MusicController.playBtn.MouseHover += new EventHandler(AllButtons_Hover);
            MusicController.playBtn.MouseLeave += new EventHandler(AllButtons_Leave);
            MusicController.stopBtn.MouseEnter += new EventHandler(AllButtons_Enter);
            MusicController.stopBtn.MouseHover += new EventHandler(AllButtons_Hover);
            MusicController.stopBtn.MouseLeave += new EventHandler(AllButtons_Leave);
            btnAddStaff.MouseEnter += new EventHandler(AllButtons_Enter);
            btnAddStaff.MouseHover += new EventHandler(AllButtons_Hover);
            btnAddStaff.MouseLeave += new EventHandler(AllButtons_Leave);
            

            Snelheid.Text = Metronome.Interval.ToString(); 
            DoubleBuffered = true;
        }

        //methodes voor effecten op Buttons
        public void AllButtons_Enter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, Color.Black);
        }
        public void AllButtons_Hover(object sender, EventArgs e)
        {
            //gebruiker _Hover voor tooltips etc.
        }
        public void AllButtons_Down(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, Color.Black);
        }
        public void AllButtons_Leave(object sender, EventArgs e)
        {
        }


        //song veranderen op het moment dat het event selectedsong uitgevoerd wordt.
        private void ChangeSong(object sender, EventArgs e)
        {
            MusicController.song = menuBarView1.Song;
            TitelBox.Text = menuBarView1.Song.Title;
            //oorspronkelijke notenbalken verwijderen.
            SetLoadedSong(menuBarView1.Song);
        }

        private void TogglePianoVisible(object sender, EventArgs e)
        {
            if (keypanel.Visible)
            {
                keypanel.Visible = false;
                pkv1.Visible = false;
                menuBarView1.ToonToolstrip.CheckState = CheckState.Unchecked;
                pkc1.ChangeImage();
                Note.SoundEnabled = false;
                PlayingKeyboard = false;
            }
            else
            {
                keypanel.Visible = true;
                pkv1.Visible = true;
                menuBarView1.ToonToolstrip.CheckState = CheckState.Checked;
                pkc1.ChangeImage();
                Note.SoundEnabled = true;
                PlayingKeyboard = true;
            }
        }

        private void NewSong(object sender, EventArgs e)
        {
            SetNewSong();
        }

        public void ShowFirstStaffView()    //Eerste notenbalk laten zien
        {
            foreach (Staff staff in song.GetStaffs())
            {
                staff.y = y_staff;
                AddStaffView(staff);
                if (staff == song.GetStaffs().First())
                {
                    staff.IsBeingPlayed = true;
                }
                if (staff == song.GetStaffs().Last())
                {
                    AddStaffButton();
                }
                y_staff += 200;
            }

        }

        private void RemoveStaffViews()//alle staffviews weghalen
        {
            foreach (var item in staffViews)
            {
                item.Dispose();
            }
            foreach (var item in staffViewsPanels)
            {
                item.Dispose();
            }
            staffViews.Clear();
            btnAddStaff.Dispose();
            y_staff = 140;
            Refresh();
        }

        public void SetNewSong()
        {
            RemoveStaffViews();
            song = new Song();
            MusicController.song = song;
            CurrentPlayingStaff = 0;
            ShowFirstStaffView();
        }

        public void SetLoadedSong(Song newSong) // nummer laden uit database
        {
            RemoveStaffViews();
            CurrentPlayingStaff = 0;
            song = newSong;
            RedLineX = 0;

            foreach (var item in song.GetStaffs())
            {
                AddStaffView(item);
                if (item == song.GetStaffs().First())
                {
                    item.IsBeingPlayed = true;
                }
                if (item == song.GetStaffs().Last()&&staffViews.Count<=2)
                {
                    AddStaffButton();
                }
                y_staff += 200;
            }
            Refresh();
        }

        private void btnAddStaff_Click(object sender, EventArgs e) //Notenbalk toevoegen knop
        {
            btnAddStaff.Dispose();
            AddNewStaff();

        }

        public void AddNewStaff()   //Nieuw notenbalk aan Song toevoegen
        {
            Staff newStaff = new Staff();
            newStaff.y = y_staff;
            song.AddStaff(newStaff);
            AddStaffView(newStaff);
            if (staffViews.Count <= 2)
            {
                AddStaffButton();
            }
            y_staff += 190;

        }

        public void AddStaffView(Staff staff)   //nieuwe notenbalkpanel maken en vullen
        {
            Panel panel = new Panel();
            panel.Location = new Point(100, y_staff);
            panel.Name = "staff";
            panel.Size = new Size(1800, 150);
            StaffView _staffView = new StaffView(staff, song)
            {
                Dock = DockStyle.None
            };
            staffViews.Add(_staffView);
            staffViewsPanels.Add(panel);
            panel.Controls.Add(_staffView);
            Controls.Add(panel);
        }

        public void AddStaffButton()        //nieuwe "notenbalk toevoegen" knop toevoegen
        {
            btnAddStaff = new Button();
            btnAddStaff.Image = new Bitmap(Resources.add, 50, 50);
            btnAddStaff.Location = new Point(977, y_staff + 160);
            btnAddStaff.Size = new Size(55, 55);
            btnAddStaff.BackColor = Color.Transparent;
            btnAddStaff.FlatStyle = FlatStyle.Flat;
            btnAddStaff.FlatAppearance.BorderSize = 0;
            btnAddStaff.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnAddStaff.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.Controls.Add(btnAddStaff);
            btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
        }


        private void FullNote_MouseDown(object sender, MouseEventArgs e)
        {
            //deze code is voor alle mousedown events hetzelfde.
            //boolean om aan te geven dat een noot geslepen wordt.
            signSelected = true;
            //de bijbehorende naam van de noot.
            SelectedSign = "WholeNote";
            //de cursor veranderen naar de gewenste afbeelding.
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void HalfNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "HalfNote";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void QuarterNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "QuarterNote";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void EightNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "EightNote";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void SixteenthNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "SixteenthNote";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void FullRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "WholeRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);

        }

        private void HalfRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "HalfRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);

        }

        private void QuarterRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "QuarterRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void GKey_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "G";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void FKey_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "F";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void EightRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "EightRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void SixteenthRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "SixteenthRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void Sharp_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "Sharp";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void Flat_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "Flat";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if(selectedNote1 == null)
            {
                SelectedSign = "Connect1";
                signSelected = true;
                Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect1));
            } else if (selectedNote1 != null)
            {
                SelectedSign = "Connect2";
                signSelected = true;
                Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect2));
            }
            

        }

        private void Bin_Click(object sender, EventArgs e)
        {
            if (signSelected == false)
            {
                SelectedSign = "Bin";
                signSelected = true;
                Cursor = CursorController.ChangeCursor(SelectedSign);
            }
            else
            {
                SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                sound.Play();
                Cursor = Cursors.Default;
                signSelected = false;
                SelectedSign = "";
            }
            if(selectedNote1 != null || SelectedSign == "Connect2")
            {
                selectedNote1 = null;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e);
        }

        private void ComposeView_MouseEnter(object sender, EventArgs e)
        {
            if (signSelected == false) Cursor = Cursors.Default;
            if(SelectedSign == "Connect2")
            {
                Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect2));
            }
        }

        public void Draw(PaintEventArgs e) //WIP
        {
            Pen p1 = new Pen(Color.White, 2);
            Pen p2 = new Pen(Color.Black, 8);
            SolidBrush s1 = new SolidBrush(Color.White);
            SolidBrush s2 = new SolidBrush(Color.Black);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (ComposeView.RedLineX == 1450)
            {
                e.Graphics.DrawLine(p2, new Point(400, 10), new Point(400 + RedLineX, 10));
            }
        }


        private void Snelheid_TextChanged(object sender, EventArgs e)
        {
            int isNumber = 0;
            int.TryParse(Snelheid.Text.ToString(), out isNumber);
            if (isNumber != 0)
            {
                int interval = Int32.Parse(Snelheid.Text);
                MusicController.setMetronoom(interval);
            }

        }

        //methode die alle staffviews invalidate. Zodat de rode lijn beweegt.
        private void RedLine_Tick(object sender, EventArgs e)
        {
            if (MusicController.isPlayingSong)
            {

                InvalidateRedLine();
                //als het nummer afspeelt de redline verplaatsen met 4 pixels.
                if (RedLineX >= 1700)
                {
                    //als de lijn het einde van een staff bereikt. De lijn verplaatsen naar de volgende staff
                    RedLineX = 0;
                    if (song.Staffs[CurrentPlayingStaff] != song.Staffs.Last())
                    {
                        song.Staffs[CurrentPlayingStaff].IsBeingPlayed = false;
                        //rodeLijn.Stop();
                        staffViews[CurrentPlayingStaff].redLine.Visible = false;
                        CurrentPlayingStaff++;
                        song.Staffs[CurrentPlayingStaff].IsBeingPlayed = true;
                        staffViews[CurrentPlayingStaff].redLine.Visible = true;

                    }
                    else
                    {
                        song.Staffs[CurrentPlayingStaff].IsBeingPlayed = false;
                        staffViews.ElementAt(CurrentPlayingStaff).redLine.Visible = false;
                        staffViews.ElementAt(0).redLine.Visible = true;
                        song.Staffs[0].IsBeingPlayed = true;
                        MusicController.isPlayingSong = false;
                        MusicController.ResetLine();
                    }


                }
            }
        }

        private void TitelBox_TextChanged(object sender, EventArgs e)
        {
            if (TitelBox.Text != "")
            {
                song.Title = TitelBox.Text;
                Size size = TextRenderer.MeasureText(TitelBox.Text, TitelBox.Font);
                TitelBox.Size = size;
            }
            else
            {
                song.Title = " ";
            }
        }

        //timer starten, reageert op songstarted in MusicController
        public void StartTimer(object sender, EventArgs e)
        {
            if (RunningTimer == false)
            {
                RunningTimer = true;
                Songtimer.Start();
                RedLine.Start();
            }
        }


        private void TimerTick(object sender, EventArgs e)
        {
            if (MusicController.isPlayingSong)
            {
                RedLineX = RedLineX + 4;

                song.PlayNote();
            }
        }


        public void StopTimer(object sender, EventArgs e)
        {

            Songtimer.Stop();
            RedLine.Stop();

            foreach (var item in staffViews)
            {
                if (item != staffViews.First())
                {
                    item.staff.IsBeingPlayed = false;
                }
                else
                {
                    item.staff.IsBeingPlayed = true;
                }
                item.redLine.Enabled = false;
            }
            CurrentPlayingStaff = 0;
            RunningTimer = false;
            Refresh();

        }

        private void InvalidateRedLine()
        {
            staffViews.ElementAt(CurrentPlayingStaff).InvalidateRedLine();

        }

        //luistert naar event uit menubar, zodat een nieuwe staff toegevoegd wordt.
        private void newStaffView(object sender, EventArgs e)
        {
            if (staffViews.Count < 3)
            {
                btnAddStaff.Dispose();
                AddNewStaff();
            }
            else
            {
                MessageBox.Show("Er zijn al 3 notenbalken.","Fout",MessageBoxButtons.OK);
            }
            
        }

        private void ComposeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (cursorIsDown)
            {
                cursorIsDown = false;
                Cursor = Cursors.Default;
                signSelected = false;

                Invalidate();

            }
            if (e.Button == MouseButtons.Right)
            {
                Cursor = Cursors.Default;
                signSelected = false;
                SelectedSign = "";
                ConnectSelected = false;
                Invalidate();
            }

        }

        public void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
        }

        private void Bin_MouseEnter(object sender, EventArgs e)
        {
            if (signSelected == false)
            {


                for (int staff = 0; staff < song.Staffs.Count(); staff++)
                {
                    for (int bar = 0; bar < song.Staffs[staff].Bars.Count(); bar++)
                    {
                        for (int sign = 0; sign < song.Staffs[staff].Bars[bar].Signs.Count(); sign++)
                        {
                            if (song.Staffs[staff].Bars[bar].Signs[sign] == draggingSign)
                            {
                                song.Staffs[staff].Bars[bar].RemoveSign(draggingSign);
                                SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                                sound.Play();
                                Cursor = Cursors.Default;

                            }
                        }
                    }
                }
                draggingSign = null;
            }
        }

        private void Bin_MouseMove(object sender, MouseEventArgs e)
        {
            Bin.Image = Resources.bin_open;
        }

        private void Bin_MouseLeave(object sender, EventArgs e)
        {
            Bin.Image = Resources.bin;
        }

        private void TitelBox_Enter(object sender, EventArgs e)
        {
            //wanneer de gebruiker een titel typt wordt het geluid uitgezet. Zodat de gebruiker niet ongewild geluid maakt.
            PlayingKeyboard = false;
        }

        private void TitelBox_Leave(object sender, EventArgs e)
        {
            PlayingKeyboard = true;
        }

        private void TitelBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                TitelBox.Enabled = false;
                TitelBox.Enabled = true;
            }
        }

        private void menuBarView1_Load(object sender, EventArgs e)
        {

        }
    }
}