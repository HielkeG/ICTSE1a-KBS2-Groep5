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
        private Button btnAddStaff = new Button();
        public Button previousPage = new Button();
        public Button nextPage = new Button();

        public static string SelectedSymbol = ""; //Deze variable onthoud op welk symbool uit de toolbar geklikt is, zodat de juiste bewerking gedaan kan worden.
        public static Sign draggingSign; //Deze variable onthoud welke noot aan het slepen is, zodat deze noot bijvoorbeeld verwijderd kan worden.
        public static Sign draggingSharp; //Deze variabele onthoud van welke noot het kruis of mol wordt verslepen.
        public static bool ConnectSelected = false; //Deze boolean onthoud of het verbindsymbool uit de toolbar is aangeklikt.
        public static Note selectedNote1; //Deze variable onthoud welke noot geselecteerd is voor het koppelen
        public static Note selectedNote2; //Deze variable onthoud welke noot geselecteerd is voor het koppelen.
        public static Cursor cursor = Cursors.Default;
        public static bool cursorIsDown; //Deze variable onthoud of de muis is ingedrukt of niet
        public static System.Timers.Timer Songtimer = new System.Timers.Timer();  //Aparte timer zodat deze meerdere threads gebruikt.
        public static string instrument = "Piano"; //Deze variable onthoudt welk instrument geselecteerd is.
        public static int CurrentOctave = 3;
        public static int CurrentPlayingStaff = 0;
        public static int RedLineX = -60;   //locatie van de rode lijn
        public static bool PlayingKeyboard = false;
        public static bool SoundEnabled = true;
        public static PianoKeysController pkc1 = new PianoKeysController();
        public static PianoKeysView pkv1 = new PianoKeysView();
        private MusicController m1;
        public static int AmountOfBars = 4;
        public static Panel keypanel = new Panel()
        {
            Location = new Point(600, 730),
            Size = new Size(1400, 240),
            //Location = new Point(this.ClientSize.Width / 2 - Size.Width / 2, this.ClientSize.Height / 2 - Size.Height / 2),
            Anchor = AnchorStyles.None,
            Dock = DockStyle.Bottom,
            Visible = false
        };
        private List<StaffView> staffViews = new List<StaffView>();
        private List<Panel> staffViewsPanels = new List<Panel>();
        private bool firstStart = true;
        private static bool RunningTimer;    //boolean of de timer loopt, zodat hij niet onnodig meerdere timers start.
        private int CurrentPage = 1;
        private int y_staff = 140;
        private int RecordCount;
        private ToolTip PreviousTip = new ToolTip();
        private ToolTip NextTip = new ToolTip();
        private Label RecordLabel = new Label();



        public ComposeView()
        {
            NextTip.InitialDelay = 0;
            PreviousTip.InitialDelay = 0;
            Songtimer.Interval = 5;
            Songtimer.Elapsed += TimerTick;
            AddStaffButton();
            SetPageButtons();

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
            menuBarView1.newStaffView += NewStaffView;

            //piano toevoegen
            Controls.Add(PianoKeysController.pianoKeysBtn);
            pkv1.Location = new Point(35, 150);
            pkv1.Visible = false;
            pkv1.Size = new Size(1400, 240);
            Controls.Add(pkv1);

            pkc1.ToggledPianoVisible += TogglePianoVisible;
            menuBarView1.togglePianoVisible += TogglePianoVisible;

            //voeg muziekknoppen toe en metronoom
            m1 = new MusicController(Metronome, RedLine, song);
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

            MusicController.metronomeBtn.MouseEnter += new EventHandler(AllButtons_Enter);
            MusicController.metronomeBtn.MouseHover += new EventHandler(AllButtons_Hover);
            MusicController.metronomeBtn.MouseLeave += new EventHandler(AllButtons_Leave);


            MusicController.recordBtn.MouseEnter += new EventHandler(AllButtons_Enter);
            MusicController.recordBtn.MouseHover += new EventHandler(AllButtons_Hover);
            MusicController.recordBtn.MouseLeave += new EventHandler(AllButtons_Leave);
            MusicController.ToggledPianoVisible += TogglePianoVisible;
            MusicController.StartRecord += StartRecord;



            btnAddStaff.MouseEnter += new EventHandler(AllButtons_Enter);
            btnAddStaff.MouseHover += new EventHandler(AllButtons_Hover);
            btnAddStaff.MouseLeave += new EventHandler(AllButtons_Leave);
            nextPage.MouseEnter += new EventHandler(AllButtons_Enter);
            nextPage.MouseHover += new EventHandler(AllButtons_Hover);
            nextPage.MouseLeave += new EventHandler(AllButtons_Leave);
            previousPage.MouseEnter += new EventHandler(AllButtons_Enter);
            previousPage.MouseHover += new EventHandler(AllButtons_Hover);
            previousPage.MouseLeave += new EventHandler(AllButtons_Leave);

            StopwatchController.OnFullStaff += NewStaffView;


            Snelheid.Text = Metronome.Interval.ToString();
            DoubleBuffered = true;
        }

        //methodes voor effecten op Buttons
        public void AllButtons_Enter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Image = BitmapController.ColorReplace(btn.Image, 30, Color.LightGray, Color.White);
        }
        public void AllButtons_Hover(object sender, EventArgs e)
        {
            //gebruiker _Hover voor tooltips etc.
        }
        public void AllButtons_Down(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //btn.Image = BitmapController.ColorReplace(btn.Image, 30, Color.White, Color.DarkGray);
            btn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);



        }
        public void AllButtons_Leave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Image = BitmapController.ColorReplace(btn.Image, 30, Color.White, Color.LightGray);

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

        public void StartRecord(object sender, EventArgs e)
        {
            MusicController.outputDevice.SendNoteOn(Channel.Channel3, Pitch.C3, 127);
            RecordLabel.Visible = true;
            RecordLabel.Font = new Font("Microsoft Sans Serif", 50);
            RecordLabel.Location = new Point((this.Width / 2) - 100, 100);
            RecordLabel.TextAlign = ContentAlignment.MiddleCenter;
            RecordLabel.Height = 65;
            RecordLabel.Width = 200;
            RecordLabel.BackColor = Color.Transparent;
            Controls.Add(RecordLabel);
            RecordLabel.BringToFront();
            RecordLabel.Text = "3";
            RecordTimer.Start();

        }

        //Deze methode zet de piano aan en uit
        private void TogglePianoVisible(object sender, EventArgs e)
        {
            //Als de piano zichtbaar is, wordt de piano uit gezet
            if (keypanel.Visible)
            {
                keypanel.Visible = false;
                pkv1.Visible = false;
                menuBarView1.KeyboardVisible.CheckState = CheckState.Unchecked;
                pkc1.ChangeImage();
                PlayingKeyboard = false;
            }
            //Als de piano uit staat, wordt de piano aan gezet
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
            StopwatchController.Song = song;
            StopwatchController.CurrentComposingStaff = 0;
            CurrentPlayingStaff = 0;
            //isrecording op true zetten zodat het daarna altijd op false gezet wordt.
            MusicController.isRecording = true;
            EventArgs e = new EventArgs();
            //recordclick zorgt ervoor dat isrecording geswitcht wordt, nu wordt recording dus uitgezet
            m1.RecordClick(this, e);
            ShowFirstStaffView();
            TitelBox.Text = "Titel";
            CurrentPage = 1;
            btnAddStaff.Visible = true;
            ActiveControl = TitelBox;
            TitelBox.ForeColor = Color.Silver;
            TitelBox_MouseMove(new object(), new MouseEventArgs(new MouseButtons(), 0, 0, 0, 0));
            Invalidate();
        }

        public void SetLoadedSong(Song newSong) // nummer laden uit database
        {

            RemoveStaffViews();
            CurrentPlayingStaff = 0;
            song = newSong;
            RedLineX = -60;
            CurrentPage = 1;
            //isrecording op true zetten zodat het daarna altijd op false gezet wordt.
            MusicController.isRecording = true;
            EventArgs e = new EventArgs();
            m1.RecordClick(this, e);
            TitelBox.ForeColor = Color.Black;
            StopwatchController.CurrentComposingStaff = 0;
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
                y_staff += 200;


            }
            Refresh();
        }

        private void BtnAddStaff_Click(object sender, EventArgs e) //Notenbalk toevoegen knop
        {
            AddNewStaff();
        }

        //luistert naar event uit menubar, zodat een nieuwe staff toegevoegd wordt.
        private void NewStaffView(object sender, EventArgs e)
        {
            AddNewStaff();
        }

        public void AddNewStaff()   //Nieuw notenbalk aan Song toevoegen
        {
            if (CurrentPage * 3 - 2 == staffViewsPanels.Count)
            {
                Staff newStaff = new Staff(AmountOfBars)
                {
                    Order = staffViews.Count() + 1
                };
                song.AddStaff(newStaff);
                AddStaffView(newStaff);
                y_staff += 200;
            }
            else if (CurrentPage * 3 - 1 == staffViewsPanels.Count)
            {
                Staff newStaff = new Staff(AmountOfBars)
                {
                    Order = staffViews.Count() + 1
                };
                song.AddStaff(newStaff);
                AddStaffView(newStaff);
                y_staff += 200;
            }
            else if (y_staff == 140)
            {
                Staff newStaff = new Staff(AmountOfBars)
                {
                    Order = staffViews.Count() + 1
                };
                song.AddStaff(newStaff);
                AddStaffView(newStaff);
                y_staff += 200;
            }
            else if (CurrentPage * 3 == staffViewsPanels.Count)
            {

                EventArgs e = new EventArgs();
                NextPage_Click(this, e);
            }
            else
            {
                MessageBox.Show("Kan geen notenbalk toevoegen. Ga naar de laatste pagina.", "Fout", MessageBoxButtons.OK);
            }
        }

        public void AddStaffView(Staff staff)   //nieuwe notenbalkpanel maken en vullen
        {
            Panel panel = new Panel
            {
                Location = new Point(100, y_staff),
                Name = "staff",
                Size = new Size(1800, 150)
            };
            StaffView _staffView = new StaffView(staff, song)
            {
                Dock = DockStyle.None
            };
            staffViews.Add(_staffView);
            staffViewsPanels.Add(panel);
            panel.Controls.Add(_staffView);
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }
            this.Invoke(new Action(() => { Controls.Add(panel); }));




        }

        public void AddStaffButton()        //nieuwe "notenbalk toevoegen" knop toevoegen
        {
            btnAddStaff.Image = Resources.add_material;
            btnAddStaff.Location = new Point(1815, 950);
            btnAddStaff.Size = new Size(100, 100);
            btnAddStaff.BackColor = Color.Transparent;
            btnAddStaff.FlatStyle = FlatStyle.Flat;
            btnAddStaff.FlatAppearance.BorderSize = 0;
            btnAddStaff.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnAddStaff.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.Controls.Add(btnAddStaff);
            btnAddStaff.Click += new System.EventHandler(this.BtnAddStaff_Click);
        }
        public void SetPageButtons()
        {
            previousPage.Image = new Bitmap(Resources.up_arrow, 56, 56);
            previousPage.Location = new Point(1836, 810);
            previousPage.Size = new Size(56, 56);
            previousPage.BackColor = Color.Transparent;
            previousPage.FlatStyle = FlatStyle.Flat;
            previousPage.FlatAppearance.BorderSize = 0;
            previousPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            previousPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            previousPage.Click += PreviousPage_Click;
            Controls.Add(previousPage);

            nextPage.Image = new Bitmap(Resources.down_arrow, 56, 56);
            nextPage.Location = new Point(1836, 895);
            nextPage.Size = new Size(56, 56);
            nextPage.BackColor = Color.Transparent;
            nextPage.FlatStyle = FlatStyle.Flat;
            nextPage.FlatAppearance.BorderSize = 0;
            nextPage.FlatAppearance.MouseDownBackColor = Color.Transparent;
            nextPage.FlatAppearance.MouseOverBackColor = Color.Transparent;
            nextPage.Click += NextPage_Click;
            Controls.Add(nextPage);
        }
        // Volgende pagina
        private void NextPage_Click(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }

            //Als de huidige pagina niet helemaal gevuld is
            if (!(CurrentPage * 3 - 1 == staffViewsPanels.Count || CurrentPage * 3 - 2 == staffViewsPanels.Count))
            {
                //Alle Staffviews uitzetten
                foreach (Panel panel in staffViewsPanels)
                {
                    this.Invoke(new Action(() => { panel.Visible = false ; }));
                    //panel.Visible = false;
                }

                //Als de huidige pagina de laatste pagina is
                if (staffViewsPanels.Count == CurrentPage * 3)
                {
                    //Nieuwe pagina toevoegen en nieuwe staffview toevoegen
                    song.Pages++;
                    //Locatie wordt weer op 140 gezet
                    y_staff = 140;
                    AddNewStaff();
                }

                //Hudige pagina wordt verhoogt
                CurrentPage++;

                //CurrentPageLabel.Text = CurrentPage.ToString();
                this.Invoke(new Action(() => { CurrentPageLabel.Text = CurrentPage.ToString(); }));

                //Alle staffviews van de huidige pagina worden getoond
                foreach (Panel panel in staffViewsPanels)
                {
                    if (staffViewsPanels.IndexOf(panel) + 1 >= CurrentPage * 3 - 2 && staffViewsPanels.IndexOf(panel) + 1 <= CurrentPage * 3)
                    {
                        //panel.Visible = true;
                        this.Invoke(new Action(() => { panel.Visible = true; }));

                    }
                }
            }
            else
            {
                NextTip.Show("Er staan nog geen drie notenbalken op deze pagina.", nextPage, 4000);
            }
        }

        //Vorige pagina
        private void PreviousPage_Click(object sender, EventArgs e)
        {
            //Als de huidige pagina groter is dan 1
            if (CurrentPage > 1)
            {
                //Alle Staffviews uitzetten
                foreach (Panel panel in staffViewsPanels)
                {
                    panel.Visible = false;
                }
                //Huidige pagina verlagen
                CurrentPage--;
                CurrentPageLabel.Text = CurrentPage.ToString();
                CurrentPageLabel.TextAlign = ContentAlignment.MiddleCenter;

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

        private void FullNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "WholeNote";                             //de bijbehorende naam van de noot.       
            Cursor = CursorController.ChangeCursor(SelectedSymbol);   //de cursor veranderen naar de gewenste afbeelding.
        }

        private void HalfNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "HalfNote";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void QuarterNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "QuarterNote";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void EightNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "EightNote";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void SixteenthNote_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "SixteenthNote";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void FullRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "WholeRest";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void HalfRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "HalfRest";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void QuarterRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "QuarterRest";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void GKey_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "G";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void FKey_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "F";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void EightRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "EightRest";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void SixteenthRest_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "SixteenthRest";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void Sharp_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "Sharp";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void Flat_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedSymbol = "Flat";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            SelectedSymbol = "Connect1";
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
            ComposeView.selectedNote1 = null;
            ComposeView.selectedNote2 = null;

        }

        private void Bin_Click(object sender, EventArgs e)
        {
            if (SelectedSymbol != "")
            {
                SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                if (SoundEnabled) sound.Play();
                SelectedSymbol = "";
                Cursor = CursorController.ChangeCursor(SelectedSymbol);
            }

            if (selectedNote1 != null || SelectedSymbol == "Connect2")
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
            Cursor = CursorController.ChangeCursor(SelectedSymbol);
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
            int.TryParse(Snelheid.Text.ToString(), result: out int isNumber);
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
                if (RedLineX >= 1620)
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
                        song.Staffs[0].IsBeingPlayed = true;
                        MusicController.isPlayingSong = false;
                        MusicController.ResetLine();
                    }
                    if (CurrentPlayingStaff % 3 == 0)
                    {
                        if (CurrentPlayingStaff / 3 == CurrentPage)
                        {
                            EventArgs ev = new EventArgs();
                            NextPage_Click(this, ev);
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
                SelectedSymbol = "";
                Cursor = CursorController.ChangeCursor(SelectedSymbol);
                Invalidate();

            }
            if (e.Button == MouseButtons.Right)
            {
                SelectedSymbol = "";
                Cursor = CursorController.ChangeCursor(SelectedSymbol);
                ConnectSelected = false;
                Invalidate();
            }
        }

        //Deze methode wordt aangeroepen wanneer de muis binnenkomt bij de bin
        private void Bin_MouseEnter(object sender, EventArgs e)
        {
            bool signdeleted = false;
            //Wanneer er niks uit de toolbar geselecteerd is
            if (SelectedSymbol == "")
            {
                for (int staff = 0; staff < song.Staffs.Count(); staff++)
                {
                    for (int bar = 0; bar < song.Staffs[staff].Bars.Count(); bar++)
                    {
                        if (song.Staffs[staff].Bars[bar].Signs.Contains(draggingSign))
                        {
                            //Alle signs langsgaan
                            for (int sign = 0; sign < song.Staffs[staff].Bars[bar].Signs.Count(); sign++)
                            {
                                //Als er een sign gelijk is aan draggingSign
                                if (song.Staffs[staff].Bars[bar].Signs[sign] == draggingSign)
                                {
                                    //Sign verwijderen
                                    song.Staffs[staff].Bars[bar].RemoveSign(draggingSign);
                                    //Geluid afspelen
                                    SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                                    if (ComposeView.SoundEnabled) sound.Play();
                                    //Normale cursor
                                    Cursor = CursorController.ChangeCursor(SelectedSymbol);
                                    signdeleted = true;
                                }
                                if (signdeleted == true)
                                {
                                    if (!(song.Staffs[staff].Bars[bar].Signs.Count() - 1 < sign))
                                    {
                                        song.Staffs[staff].Bars[bar].Signs[sign].X -= draggingSign.Duration * 25;
                                    }
                                }


                            }
                        }
                    }
                }
                // --- Mol / Kruis verwijderen ---
                draggingSign = null;
                if (draggingSharp != null)
                {
                    if (draggingSharp is Note note)
                    {
                        note.SetNatural();
                        SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                        sound.Play();
                        Cursor = CursorController.ChangeCursor(SelectedSymbol);
                        draggingSharp = null;
                        note.isBeingMoved = false;

                    }
                }
            }
            if (SelectedSymbol == "BeginFlat")
            {
                song.FlatSharp++;
                SelectedSymbol = "";
                SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                sound.Play();
                song.SetSharpFlat();
            }
            else if (SelectedSymbol == "BeginSharp")
            {
                song.FlatSharp--;
                SelectedSymbol = "";
                SoundPlayer sound = new SoundPlayer(Resources.BinSound);
                sound.Play();
                song.SetSharpFlat();
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
            TitelBox.ForeColor = Color.Black;
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
                if (speed <= 300 && speed > 0)
                {
                    MusicController.setMetronoom(speed);
                    metroTip.RemoveAll();
                }
                else
                {
                    //ander wordt de tooltip laten zien.
                    metroTip.Show("Snelheid moet tussen 0 en 300 liggen.", MetronomeSpeed);
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

        private void RecordTimer_Tick(object sender, EventArgs e)
        {
            RecordCount++;
            //System.Media.SystemSounds.Beep.Play();
            if (RecordCount == 1)
            {
                MusicController.outputDevice.SendNoteOn(Channel.Channel3, Pitch.C3, 127);
                RecordLabel.Text = "2";
            }
            else if (RecordCount == 2)
            {
                MusicController.outputDevice.SendNoteOn(Channel.Channel3, Pitch.C3, 127);
                RecordLabel.Text = "1";
            }
            else if (RecordCount == 3)
            {
                MusicController.outputDevice.SendNoteOn(Channel.Channel3, Pitch.C3, 127);
                RecordLabel.Text = "Start!";
                MusicController.isRecording = true;
            }

            //RecordLabel.Visible = false;
            if (RecordCount == 4)
            {
                RecordCount = 0;
                RecordTimer.Stop();
                RecordLabel.Visible = false;
                MusicController.recordingStarted = false;

            }
        }
        private void TitelBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (TitelBox.Focused)
            {
                if (TitelBox.ForeColor == Color.Silver) TitelBox.Text = "";
            }
        }

        private void ComposeView_MouseMove(object sender, MouseEventArgs e)
        {
            if (!TitelBox.Focused)
            {
                if (TitelBox.ForeColor == Color.Silver || TitelBox.Text == "")
                {
                    TitelBox.Text = "Titel";
                    TitelBox.ForeColor = Color.Silver;
                }
            }
        }

        private void ComposeView_Load(object sender, EventArgs e)
        {
            ActiveControl = TitelBox;
            TitelBox_MouseMove(sender, new MouseEventArgs(new MouseButtons(), 0, 0, 0, 0));
        }
    }
}