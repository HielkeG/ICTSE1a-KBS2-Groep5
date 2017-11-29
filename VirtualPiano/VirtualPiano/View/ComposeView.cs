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
        internal static bool signSelected;
        internal static int FlatSharp = 0;
        internal static NoteName SelectedNoteName = NoteName.NULL;
        internal static RestName SelectedRestName = RestName.NULL;
        internal static ClefName SelectedClefName = ClefName.NULL;
        private List<Panel> staffViews = new List<Panel>();
        private bool firstStart = true;
        int tempint;

        public ComposeView()
        {
            InitializeComponent();
            if (firstStart)
            {
                ShowFirstStaffView();
                firstStart = false;
            }
            ShowPianoKeysView();

            MusicController m1 = new MusicController(Metronoom, rodeLijn, song);
            Controls.Add(MusicController.rewindBox);
            Controls.Add(MusicController.playBox);
            Controls.Add(MusicController.stopBox);
            Snelheid.Text = Metronoom.Interval.ToString();
            DoubleBuffered = true;
        }

        public void ShowPianoKeysView()
        {
            Panel pianokeypanel = new Panel();
            pianokeypanel.Location = new Point(400, 740);
            pianokeypanel.Size = new Size(1060, 235);
            Controls.Add(pianokeypanel);
            PianoKeysView _PianoKeysView = new PianoKeysView()
            {
                Dock = DockStyle.None
            };
            pianokeypanel.Controls.Add(_PianoKeysView);
        }

        public void ShowFirstStaffView()    //Eerste notenbalk laten zien
        {
            foreach(Staff staff in song.GetStaffs())
            {
                staff.y = y_staff;
                AddStaffView(staff);
                if (staff == song.GetStaffs().Last())
                {
                    AddStaffButton();
                }
                y_staff += 200;
            }

        }

        private void RemoveStaffViews()
        {
            for (int i = 0; i < staffViews.Count; i++)
            {
                staffViews.ElementAt(i).Dispose();
            }
            btnAddStaff.Dispose();
            y_staff = 140;
            Refresh();

        }

        public void SetNewSong()
        {
            RemoveStaffViews();
            song = new Song();
            MusicController.song = song;

            ShowFirstStaffView();
        }

        public void SetLoadedSong(Song newSong)
        {
            RemoveStaffViews();

            song = newSong;

            foreach (var item in song.GetStaffs())
            {
                AddStaffView(item);
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
                    AddStaffButton();
                    y_staff += 190;
                }
            }
        }

        public void AddStaffView(Staff staff)   //nieuwe notenbalkpanel maken en vullen
        {
            Panel panel = new Panel();
            panel.Location = new Point(100, y_staff);
            panel.Size = new Size(1800, 150);
            Controls.Add(panel);
            StaffView _staffView = new StaffView(staff, FlatSharp)
            {
                Dock = DockStyle.None
            };
            staffViews.Add(panel);
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
            SelectedNoteName = NoteName.wholeNote;
            //beide andere namen op null zetten. Wanneer de gebruiker dan een ander teken aanklikt wordt dit goed gereset. 
            SelectedRestName = RestName.NULL;
            SelectedClefName = ClefName.NULL;
            //de cursor veranderen naar de gewenste afbeelding.
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void HalfNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedNoteName = NoteName.halfNote;
            SelectedRestName = RestName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void QuarterNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedNoteName = NoteName.quarterNote;
            SelectedRestName = RestName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void EightNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedNoteName = NoteName.eightNote;
            SelectedRestName = RestName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void SixteenthNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedNoteName = NoteName.sixteenthNote;
            SelectedRestName = RestName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void FullRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedRestName = RestName.wholeRest;
            SelectedNoteName = NoteName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedRestName);

        }

        private void HalfRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedRestName = RestName.halfRest;
            SelectedNoteName = NoteName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedRestName);

        }

        private void QuarterRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedRestName = RestName.quarterRest;
            SelectedNoteName = NoteName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedRestName);
        }

        private void GKey_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedClefName = ClefName.G;
            SelectedNoteName = NoteName.NULL;
            SelectedRestName = RestName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedClefName);
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void FKey_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedClefName = ClefName.F;
            SelectedNoteName = NoteName.NULL;
            SelectedRestName = RestName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedClefName);
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
            SelectedRestName = RestName.eightRest;
            SelectedNoteName = NoteName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedRestName);
        }

        private void SixteenthRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedRestName = RestName.sixteenthRest;
            SelectedNoteName = NoteName.NULL;
            SelectedClefName = ClefName.NULL;
            Cursor = CursorController.ChangeCursor(SelectedRestName);
        }

        private void Flat_Click(object sender, EventArgs e)
        {
            if (FlatSharp > -5)
            {
                FlatSharp--;
                song.ChangeSharpFlat(FlatSharp);
                Refresh();
            }
        }

        public void Metronoom_Tick(object sender, EventArgs e) {        }


        private void Sharp_MouseDown(object sender, MouseEventArgs e)
        {
            if (FlatSharp < 5)
            {
                
                FlatSharp++;
                song.ChangeSharpFlat(FlatSharp);
                Refresh();
            }
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
            e.Graphics.DrawLine(p2, new Point(200, 10), new Point(200 + tempint, 10));
            //foreach (Staff staff in Song.staffs)
            //    {
            //        foreach (Bar bar in staff.Bars)
            //        {
            //        int temp = 0;
            //            e.Graphics.DrawLine(p2, new Point(200, 10), new Point(200, +temp*2));
            //        temp++;
            //        }
            //    }

            //}
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

        private void rodeLijn_Tick(object sender, EventArgs e)
        {

            int temp = song.getDuration();
            //Console.WriteLine(rodeLijn.Interval);
            tempint++;
            Invalidate();
            
            if (tempint >= song.getDuration() * 25)
            {
                rodeLijn.Stop();
            }
        }

        private void NoteSnapTimer_Tick(object sender, EventArgs e)
        {
            
            foreach (Staff staff in song.GetStaffs())
            {
                int barBegin = 145;
                int barEnd = 575;
                foreach (Bar bar in staff.Bars)
                {

                    if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin && PointToClient(Cursor.Position).Y > staff.y && PointToClient(Cursor.Position).Y < staff.y + 135)
                    {
                        int NewY = PointToClient(Cursor.Position).Y - staff.y;
                        Note newNote = new Note(NewY, SelectedNoteName, bar.clef.ToString(),bar.FlatSharp);
                        Rest newRest = new Rest(SelectedRestName);

                        if (bar.CheckBarSpace(newNote) && SelectedNoteName != NoteName.NULL)
                        {
                            bar.Add(newNote);
                            bar.hasPreview = true;
                            Refresh();
                            bar.RemovePreview();
                        }
                        else if (bar.CheckBarSpace(newRest) && SelectedRestName != RestName.NULL)
                        {
                                bar.clef = ClefName.G.ToString();
                                bar.Add(newRest);
                                bar.hasPreview = true;
                                Refresh();
                                bar.RemovePreview();
                        }
                    }
                    barBegin += 430;
                    barEnd += 430;
                }
            }
        }

        private void TitelBox_TextChanged(object sender, EventArgs e)
        {
            song.Title = TitelBox.Text;
            Size size = TextRenderer.MeasureText(TitelBox.Text, TitelBox.Font);
        }


    }
    }