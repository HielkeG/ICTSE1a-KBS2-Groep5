﻿using System;
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
        public static Button previousPage = new Button();
        public static Button nextPage = new Button();
        private ToolTip PreviousTip = new ToolTip();
        private ToolTip NextTip = new ToolTip();
        int y_staff = 140;
        public static bool ConnectSelected = false;
        public static Note selectedNote1;
        public static Note selectedNote2;
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
        public static int RedLineX = -60;   //locatie van de rode lijn
        public static bool PlayingKeyboard = false;
        public PianoKeysController pkc1 = new PianoKeysController();
        public static PianoKeysView pkv1 = new PianoKeysView();
        public static Sign draggingSign;
        public static Sign draggingSharp;
        public static Panel keypanel = new Panel()
        {
            Location = new Point(600, 730),
            Size = new Size(1400, 240),
            //Location = new Point(this.ClientSize.Width / 2 - Size.Width / 2, this.ClientSize.Height / 2 - Size.Height / 2),
            Anchor = AnchorStyles.None,
            Dock = DockStyle.Bottom,
            Visible = false
        };
        private int CurrentPage = 1;

        public ComposeView()
        {
            NextTip.InitialDelay = 0;

            PreviousTip.InitialDelay = 0;

            Songtimer.Interval = 5;
            Songtimer.Elapsed += TimerTick;

            AddStaffButton();
            setPageButtons();


            InitializeComponent();
            if (firstStart)
            {
                ShowFirstStaffView();
                firstStart = false;
            }
            //methodes koppelen aan het starten en stoppen vna het afspelen.
            MusicController.SongStarted += StartTimer;
            MusicController.SongStopped += StopTimer;
            StopwatchController.Song = song;
            menuBarView1.Song = song;
            menuBarView1.selectedSong += ChangeSong;
            menuBarView1.newSong += NewSong;
            menuBarView1.newStaffView += newStaffView;

            //piano toevoegen
            Controls.Add(PianoKeysController.pianoKeysBtn);
            pkv1.Location = new Point(35, 150);
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
            Controls.Add(MusicController.metronomeBtn);
            Controls.Add(MusicController.recordBtn);

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
            MusicController.recordBtn.MouseEnter += new EventHandler(AllButtons_Enter);
            MusicController.recordBtn.MouseHover += new EventHandler(AllButtons_Hover);
            MusicController.recordBtn.MouseLeave += new EventHandler(AllButtons_Leave);

            btnAddStaff.MouseEnter += new EventHandler(AllButtons_Enter);
            btnAddStaff.MouseHover += new EventHandler(AllButtons_Hover);
            btnAddStaff.MouseLeave += new EventHandler(AllButtons_Leave);
            nextPage.MouseEnter += new EventHandler(AllButtons_Enter);
            nextPage.MouseHover += new EventHandler(AllButtons_Hover);
            nextPage.MouseLeave += new EventHandler(AllButtons_Leave);
            previousPage.MouseEnter += new EventHandler(AllButtons_Enter);
            previousPage.MouseHover += new EventHandler(AllButtons_Hover);
            previousPage.MouseLeave += new EventHandler(AllButtons_Leave);

            StopwatchController.OnFullStaff += newStaffView;


            Snelheid.Text = Metronome.Interval.ToString();
            DoubleBuffered = true;
        }

        //methodes voor effecten op Buttons
        public void AllButtons_Enter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Image = BitmapController.ColorReplace(btn.Image, 30, Color.White, Color.LightGray);
        }
        public void AllButtons_Hover(object sender, EventArgs e)
        {
            //gebruiker _Hover voor tooltips etc.
        }
        public void AllButtons_Down(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
        }
        public void AllButtons_Leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Image = BitmapController.ColorReplace(btn.Image, 30, Color.LightGray, Color.White);
        }


        //song veranderen op het moment dat het event selectedsong uitgevoerd wordt.
        private void ChangeSong(object sender, EventArgs e)
        {
            MusicController.song = menuBarView1.Song;
            StopwatchController.Song = menuBarView1.Song;
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
                menuBarView1.KeyboardVisible.CheckState = CheckState.Unchecked;
                pkc1.ChangeImage();
                PlayingKeyboard = false;
            }
            else
            {
                keypanel.Visible = true;
                pkv1.Visible = true;
                menuBarView1.KeyboardVisible.CheckState = CheckState.Checked;
                pkc1.ChangeImage();
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
                staff.Y = y_staff;
                staff.Order = staffViews.Count() + 1;
                AddStaffView(staff);
                if (staff == song.GetStaffs().First())
                {
                    staff.IsBeingPlayed = true;
                }
                if (staff == song.GetStaffs().Last())
                {

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
            staffViewsPanels.Clear();
            staffViews.Clear();
            y_staff = 140;
            Refresh();
        }

        public void SetNewSong()
        {
            RemoveStaffViews();
            song = new Song();
            MusicController.song = song;
            menuBarView1.Song = song;
            CurrentPlayingStaff = 0;
            ShowFirstStaffView();
            TitelBox.Text = "Titel";
            CurrentPage = 1;
            btnAddStaff.Visible = true;
            btnAddStaff.Location = new Point(btnAddStaff.Location.X, y_staff - 40);
            Invalidate();
        }

        public void SetLoadedSong(Song newSong) // nummer laden uit database
        {

            RemoveStaffViews();
            CurrentPlayingStaff = 0;
            song = newSong;
            RedLineX = -60;
            CurrentPage = 1;
            CurrentPageLabel.Text = CurrentPage.ToString();
            btnAddStaff.Visible = true;
            foreach (var item in song.GetStaffs())
            {
                if ((song.GetStaffs().IndexOf(item) + 1) % 3 == 1)
                {
                    y_staff = 140;
                }
                AddStaffView(item);
                if (item == song.GetStaffs().First())
                {
                    item.IsBeingPlayed = true;
                }
                if (item == song.GetStaffs().Last() && staffViews.Count <= 2)
                {
                    btnAddStaff.Visible = true;
                    btnAddStaff.Location = new Point(btnAddStaff.Location.X, y_staff + 160);
                }
                else
                {
                    btnAddStaff.Visible = false;
                }
                y_staff += 200;


            }
            Refresh();
        }

        private void btnAddStaff_Click(object sender, EventArgs e) //Notenbalk toevoegen knop
        {
            AddNewStaff();
        }

        //luistert naar event uit menubar, zodat een nieuwe staff toegevoegd wordt.
        private void newStaffView(object sender, EventArgs e)
        {
            AddNewStaff();
        }

        public void AddNewStaff()   //Nieuw notenbalk aan Song toevoegen
        {
            if (CurrentPage * 3 - 2 == staffViewsPanels.Count)
            {
                Staff newStaff = new Staff();
                newStaff.Y = y_staff;
                newStaff.Order = staffViews.Count() + 1;
                song.AddStaff(newStaff);
                AddStaffView(newStaff);
                y_staff += 200;
                btnAddStaff.Location = new Point(977, newStaff.Y + 160);
            }
            else if (CurrentPage * 3 - 1 == staffViewsPanels.Count)
            {
                Staff newStaff = new Staff();
                newStaff.Y = y_staff;
                newStaff.Order = staffViews.Count() + 1;
                song.AddStaff(newStaff);
                AddStaffView(newStaff);
                y_staff += 200;
                btnAddStaff.Visible = false;
            }
            else if (y_staff == 140)
            {
                Staff newStaff = new Staff();
                newStaff.Y = y_staff;
                newStaff.Order = staffViews.Count() + 1;
                song.AddStaff(newStaff);
                AddStaffView(newStaff);
                y_staff += 200;
                btnAddStaff.Visible = false;
            }
            else if (CurrentPage * 3 == staffViewsPanels.Count)
            {

                EventArgs e = new EventArgs();
                nextPage_Click(this, e);
            }
            else
            {
                MessageBox.Show("Kan geen notenbalk toevoegen. Ga naar de laatste pagina.", "Fout", MessageBoxButtons.OK);
            }
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
            SelectedSign = "WholeNote";                             //de bijbehorende naam van de noot.       
            Cursor = CursorController.ChangeCursor(SelectedSign);   //de cursor veranderen naar de gewenste afbeelding.
        }

        private void HalfNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "HalfNote";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void QuarterNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "QuarterNote";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void EightNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "EightNote";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void SixteenthNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "SixteenthNote";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void FullRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "WholeRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void HalfRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "HalfRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void QuarterRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "QuarterRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void GKey_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "G";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void FKey_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "F";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void EightRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "EightRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void SixteenthRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "SixteenthRest";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void Sharp_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "Sharp";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void Flat_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSign = "Flat";
            Cursor = CursorController.ChangeCursor(SelectedSign);
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            SelectedSign = "Connect1";
            Cursor = CursorController.ChangeCursor(SelectedSign);
            ComposeView.selectedNote1 = null;
            ComposeView.selectedNote2 = null;

        }

        private void Bin_Click(object sender, EventArgs e)
        {
            if (SelectedSign != "")
            {
                SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                sound.Play();
                Cursor = Cursors.Default;
                SelectedSign = "";
            }

            if (selectedNote1 != null || SelectedSign == "Connect2")
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
            if (SelectedSign == "") Cursor = Cursors.Default;
            else if (SelectedSign == "Connect2") Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect2));
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


        private void RedLine_Tick(object sender, EventArgs e)    //methode die alle staffviews invalidate. Zodat de rode lijn beweegt.
        {
            if (MusicController.isPlayingSong)
            {
                InvalidateRedLine();
                //als het nummer afspeelt de redline verplaatsen met 4 pixels.
                if (RedLineX >= 1700)
                {
                    //als de lijn het einde van een staff bereikt. De lijn verplaatsen naar de volgende staff
                    RedLineX = -60;
                    if (song.Staffs[CurrentPlayingStaff] != song.Staffs.Last())
                    {
                        song.Staffs[CurrentPlayingStaff].IsBeingPlayed = false;
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
                    if (CurrentPlayingStaff % 3 == 0)
                    {
                        if (CurrentPlayingStaff / 3 == CurrentPage)
                        {
                            EventArgs ev = new EventArgs();
                            nextPage_Click(this, ev);
                        }
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

                song.PlayNote();
                RedLineX = RedLineX + 4;
            }
        }


        public void StopTimer(object sender, EventArgs e)
        {

            Songtimer.Stop();
            RedLine.Stop();

            foreach (var item in staffViews)
            {
                //als het niet de eerste staffview is wordt de staff niet afgespeeld en is de lijn niet zichtbaar.
                if (item != staffViews.First())
                {
                    item.staff.IsBeingPlayed = false;
                    item.redLine.Visible = false;
                }
                else
                {
                    //anders wordt de lijn wel afgespeeld en de lijn getoond.
                    item.staff.IsBeingPlayed = true;
                    item.redLine.Visible = false;
                }
            }

            CurrentPlayingStaff = 0;
            RunningTimer = false;
            Refresh();

        }

        private void InvalidateRedLine()
        {
            staffViews.ElementAt(CurrentPlayingStaff).InvalidateRedLine();
        }

        private void ComposeView_MouseUp(object sender, MouseEventArgs e)
        {
            if (cursorIsDown)
            {
                cursorIsDown = false;
                Cursor = Cursors.Default;
                SelectedSign = "";
                Invalidate();

            }
            if (e.Button == MouseButtons.Right)
            {
                Cursor = Cursors.Default;
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
            if (SelectedSign == "")
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
                if(draggingSharp != null)
                {
                    if(draggingSharp is Note note)
                    {
                        note.SetNatural();
                        SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                        sound.Play();
                        Cursor = Cursors.Default;
                        draggingSharp = null;
                    }
                }
                
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
            PlayingKeyboard = false;    //wanneer de gebruiker een titel typt wordt het geluid uitgezet. Zodat de gebruiker niet ongewild geluid maakt.
        }

        private void TitelBox_Leave(object sender, EventArgs e)
        {
            PlayingKeyboard = true;
        }

        private void TitelBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TitelBox.Enabled = false;
                TitelBox.Enabled = true;
            }
        }

        //bpm veranderen
        private void MetronomeSpeed_TextChanged(object sender, EventArgs e)
        {

            if (Int32.TryParse(MetronomeSpeed.Text, out int speed))
            {

                //als de snelheid tussen 0 en 500 ligt wordt het aangepast.
                if (speed <= 60000 && speed > 0)
                {
                    MusicController.setMetronoom(speed);
                    metroTip.RemoveAll();
                }
                else
                {
                    //ander wordt de tooltip laten zien.
                    metroTip.Show("Snelheid moet tussen 0 en 60000 liggen.", MetronomeSpeed);
                }
            }
            else
            {
                metroTip.Show("U kunt hier alleen getallen invoeren", MetronomeSpeed);
            }
        }

        private void Metronome_Tick(object sender, EventArgs e)
        {
            //geluid op channel3 met woodblock instrument
            MusicController.outputDevice.SendNoteOn(Channel.Channel3, Pitch.C3, 127);
            if (MusicController.metronomeBtn.Image == MusicController.metronomeOn1)
            {
                MusicController.metronomeBtn.Image = MusicController.metronomeOn2;
             }
            else
            {
                MusicController.metronomeBtn.Image = MusicController.metronomeOn1;
             }
        }

        // Volgende pagina
        private void nextPage_Click(object sender, EventArgs e)
        {
            //Als de huidige pagina niet helemaal gevuld is
            if (!(CurrentPage * 3 - 1 == staffViewsPanels.Count || CurrentPage * 3 - 2 == staffViewsPanels.Count))
            {
                //Alle Staffviews uitzetten
                foreach (Panel panel in staffViewsPanels)
                {
                    panel.Visible = false;
                }

                //Als de huidige pagina de laatste pagina is
                if (staffViewsPanels.Count == CurrentPage * 3)
                {
                    //Nieuwe pagina toevoegen en nieuwe staffview toevoegen
                    song.Pages++;
                    //Locatie wordt weer op 140 gezet
                    y_staff = 140;
                    btnAddStaff.Location = new Point(977, y_staff + 160);
                    AddNewStaff();
                    btnAddStaff.Visible = true;
                }
                else if (staffViewsPanels.Count == CurrentPage * 3 + 1) btnAddStaff.Visible = true;
                else if (staffViewsPanels.Count == CurrentPage * 3 + 2) btnAddStaff.Visible = true;

                //Hudige pagina wordt verhoogt
                CurrentPage++;
                CurrentPageLabel.Text = CurrentPage.ToString();
                if (CurrentPage == 10)
                {
                    CurrentPageLabel.Location = new Point(1735, 955);
                    previousPage.Location = new Point(1690, 957);
                }
                //Alle staffviews van de huidige pagina worden getoond
                foreach (Panel panel in staffViewsPanels)
                {
                    if (staffViewsPanels.IndexOf(panel) + 1 >= CurrentPage * 3 - 2 && staffViewsPanels.IndexOf(panel) + 1 <= CurrentPage * 3)
                    {

                        panel.Visible = true;
                    }
                }
            }
            else
            {
                NextTip.Show("Er staan nog geen drie notenbalken op deze pagina.", nextPage, 4000);
            }
        }

        //Vorige pagina
        private void previousPage_Click(object sender, EventArgs e)
        {
            //Als de huidige pagina groter is dan 1
            if (CurrentPage > 1)
            {
                //Alle Staffviews uitzetten
                btnAddStaff.Visible = false;
                foreach (Panel panel in staffViewsPanels)
                {
                    panel.Visible = false;
                }
                //Huidige pagina verlagen
                CurrentPage--;
                CurrentPageLabel.Text = CurrentPage.ToString();

                if (CurrentPage == 9)
                {
                    CurrentPageLabel.Location = new Point(1765, 955);
                    previousPage.Location = new Point(1720, 957);
                }

                //Alle staffviews van de huidige pagina worden getoond
                foreach (Panel panel in staffViewsPanels)
                {
                    if (staffViewsPanels.IndexOf(panel) + 1 >= CurrentPage * 3 - 2 && staffViewsPanels.IndexOf(panel) + 1 <= CurrentPage * 3)
                    {
                        panel.Visible = true;
                    }
                }
            }
            else
            {
                PreviousTip.Show("Kan niet naar de vorige pagina gaan.", previousPage, 4000);
            }
        }

        public void setPageButtons()
        {
            previousPage.Image = new Bitmap(Resources.lastPage, 50, 50);
            previousPage.Location = new Point(1720, 957);
            previousPage.Size = new Size(55, 55);
            previousPage.BackColor = Color.Transparent;
            previousPage.FlatStyle = FlatStyle.Flat;
            previousPage.FlatAppearance.BorderSize = 0;
            previousPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            previousPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            previousPage.Click += previousPage_Click;
            Controls.Add(previousPage);

            nextPage.Image = new Bitmap(Resources.nextPage, 50, 50);
            nextPage.Location = new Point(1809, 957);
            nextPage.Size = new Size(55, 55);
            nextPage.BackColor = Color.Transparent;
            nextPage.FlatStyle = FlatStyle.Flat;
            nextPage.FlatAppearance.BorderSize = 0;
            nextPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            nextPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            nextPage.Click += nextPage_Click;
            Controls.Add(nextPage);
        }

    }
}