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
        internal static bool signSelected;
        internal static int FlatSharp = 0;
        public static string SelectedSign = null;
        internal static string SelectedSharpFlat = null;
        private List<StaffView> staffViews = new List<StaffView>();
        private bool firstStart = true;
        //timer die de x van de rode lijn verhoogt en noten afspeelt. 
        //Aparte timer zodat deze meerdere threads gebruikt.
        public static System.Timers.Timer Songtimer = new System.Timers.Timer();
        //huide nummer van afgespeelde staff. Zodat de rode lijn hier overheen loopt.
        public static string instrument = "Piano";

        public static int CurrentPlayingStaff = 0;
        //boolean of de timer loopt, zodat hij niet onnodig meerdere timers start.
        private static bool RunningTimer;
        //locatie van de rode lijn
        public static int RedLineX;
        public int StaffCounter = 0;

        public PianoKeysController pkc1 = new PianoKeysController();
        public static PianoKeysView pkv1 = new PianoKeysView();
        public static Panel keypanel = new Panel()
        {
            Location = new Point(190, 730),
            Size = new Size(1400, 250),
            Dock = DockStyle.Bottom,
            Visible = true
        };

        public ComposeView()
        {
            Songtimer.Interval = 5;
            Songtimer.Elapsed +=  TimerTick;
            
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

            Controls.Add(PianoKeysController.pianoKeysBox);
            Controls.Add(keypanel);
            keypanel.Controls.Add(pkv1);


            MusicController m1 = new MusicController(Metronome, RedLine, song);
            Controls.Add(MusicController.rewindBox);
            Controls.Add(MusicController.playBox);
            Controls.Add(MusicController.stopBox);
            Snelheid.Text = Metronome.Interval.ToString();
            DoubleBuffered = true;
        }

        //song veranderen op het moment dat het event selectedsong uitgevoerd wordt.
        private void ChangeSong(object sender, EventArgs e)
        {
            MusicController.song = menuBarView1.Song;
            TitelBox.Text = menuBarView1.Song.Title;
            //oorspronkelijke notenbalken verwijderen.
            SetLoadedSong(menuBarView1.Song);

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
            foreach (var item in Controls)
            {
                if (item.GetType() == typeof(Panel))
                {
                    Panel panel = (Panel)item;
                    if (panel.Name == "staff")
                    {
                        panel.Dispose();
                    }
                }
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
                if (item == song.GetStaffs().Last())
                {
                    AddStaffButton();
                }
                y_staff += 200;
            }
            Refresh();
        }

        private void btnAddStaff_Click(object sender, EventArgs e) //Notenbalk toevoegen knop
        {
            StaffCounter++;
            btnAddStaff.Dispose();
            AddNewStaff();
            
        }

        public void AddNewStaff()   //Nieuw notenbalk aan Song toevoegen
        {
            Staff newStaff = new Staff();
            newStaff.y = y_staff;
            song.AddStaff(newStaff);
            foreach (Staff staff in song.GetStaffs())
            {
                if (staff == song.GetStaffs().Last())
                {
                    AddStaffView(staff);
                    if(StaffCounter < 2)AddStaffButton();
                    y_staff += 190;
                }
            }
        }

        public void AddStaffView(Staff staff)   //nieuwe notenbalkpanel maken en vullen
        {
            Panel panel = new Panel();
            panel.Location = new Point(100, y_staff);
            panel.Name = "staff";

            panel.Size = new Size(1800, 150);
            Controls.Add(panel);
            StaffView _staffView = new StaffView(staff, FlatSharp)
            {
                Dock = DockStyle.None
            };
            staffViews.Add(_staffView);
            panel.Controls.Add(_staffView);

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

        private void ComposeView_MouseEnter(object sender, EventArgs e)
        {
            if (signSelected == false)
            {
                Cursor = Cursors.Default;
            }
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

        public void Metronoom_Tick(object sender, EventArgs e) { }


        private void Sharp_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "Sharp";
            Cursor = CursorController.ChangeCursor("Sharp");
        }

        private void Flat_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedSign = "Flat";
            Cursor = CursorController.ChangeCursor("Flat");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e);
        }

        public void Draw(PaintEventArgs e) //WIP
        {
            Pen p1 = new Pen(Color.White, 2);
            Pen p2 = new Pen(Color.Black, 8);
            SolidBrush s1 = new SolidBrush(Color.White);
            SolidBrush s2 = new SolidBrush(Color.Black);

            //for (int i = 0; i < tempint; i++)
            //{
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
            song.Title = TitelBox.Text;
            Size size = TextRenderer.MeasureText(TitelBox.Text, TitelBox.Font);
            TitelBox.Size = size;
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
                if(item != staffViews.First())
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
            btnAddStaff.Dispose();
            AddNewStaff();
        }

        private void ComposeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Cursor = Cursors.Default;
                signSelected = false;
                SelectedSign = null;
                ConnectSelected = false;
                Invalidate();
            }

        }

        private void Connect_Click(object sender, EventArgs e)
        {
            SelectedSign = null;
            signSelected = true;
            ConnectSelected = true;
            Cursor = CursorController.ChangeCursor("Connect");
        }

     
    }
}