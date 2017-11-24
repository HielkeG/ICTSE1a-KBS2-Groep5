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

namespace VirtualPiano.View
{
    public partial class ComposeView : UserControl
    {
        Song song = new Song();
        Button btnAddStaff = new Button();
        int y_staff = 140;
        internal static bool signSelected;
        internal static int FlatSharp = 0;
        internal static NoteName SelectedNoteName = NoteName.NULL;
        internal static RestName SelectedRestName = RestName.NULL;
        internal static ClefName SelectedClefName = ClefName.NULL;
        int tempint;

        public ComposeView()
        {
            InitializeComponent();
            ShowFirstStaffView();


            MusicController m1 = new MusicController(Metronoom, rodeLijn);
            Controls.Add(MusicController.rewindBox);
            Controls.Add(MusicController.playBox);
            Controls.Add(MusicController.stopBox);
            Snelheid.Text = Metronoom.Interval.ToString();
            DoubleBuffered = true;

        }

        public void ShowFirstStaffView()    //Eerste notenbalk laten zien
        {
            for (int x = 1; x <= song.GetStaffs().Count; x++)
            {
                AddStaffView(song.GetStaffs()[x - 1]);
                if (x == song.GetStaffs().Count)
                {
                    AddStaffButton();
                }
                y_staff += 200;
            }

        }

        public void PlayGeklikt(Object sender, EventArgs e)
        {
            
            if (isAanHetSpelen == false)
            {
                playBox.Image = new Bitmap(play);
                isAanHetSpelen = true;
            }
            else if (isAanHetSpelen)
            {
                playBox.Image = new Bitmap(pause);
                isAanHetSpelen = false;
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e) //Notenbalk toevoegen knop
        {
            btnAddStaff.Dispose();
            AddNewStaff();
        }

        public void AddNewStaff()   //Nieuw notenbalk aan song toevoegen
        {
            song.AddStaff(new Staff());
            for (int x = 1; x <= song.GetStaffs().Count; x++)
            {
                if (x == song.GetStaffs().Count)
                {
                    AddStaffView(song.GetStaffs()[x - 1]);
                    AddStaffButton();
                    y_staff += 190;
                }
            }
        }

        public void AddStaffView(Staff staff)   //nieuwe notenbalkpanel maken en vullen
        {
            Panel panel = new Panel();
            panel.Location = new Point(190, y_staff);
            panel.Size = new Size(1600, 150);
            Controls.Add(panel);
            StaffView _staffView = new StaffView(staff, FlatSharp)
            {
                Dock = DockStyle.None
            };
            panel.Controls.Add(_staffView);
        }

        public void AddStaffButton()        //nieuwe "notenbalk toevoegen" knop toevoegen
        {
            btnAddStaff = new RoundButton();
            //btnAddStaff.Location = new Point(970, y_staff + 170);
            btnAddStaff.Location = new Point(1800, y_staff + 35);
            btnAddStaff.Size = new Size(50, 50);
            btnAddStaff.Text = "+";
            btnAddStaff.ForeColor = Color.White;
            btnAddStaff.BackColor = Color.Black;
            btnAddStaff.Font = new Font(Font.FontFamily, 20);
            btnAddStaff.TabStop = false;
            btnAddStaff.FlatStyle = FlatStyle.Flat;
            btnAddStaff.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnAddStaff);
            btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            btnAddStaff.MouseEnter += OnMouseEnterButtonAddStaff;
            btnAddStaff.MouseLeave += OnMouseLeaveButtonAddStaff;
        }

        private void OnMouseEnterButtonAddStaff(object sender, EventArgs e)
        {
            btnAddStaff.BackColor = Color.White;
            btnAddStaff.ForeColor = Color.Black;
        }
        private void OnMouseLeaveButtonAddStaff(object sender, EventArgs e)
        {
            btnAddStaff.BackColor = Color.Black;
            btnAddStaff.ForeColor = Color.White;
        }

        private void FullNote_MouseDown(object sender, MouseEventArgs e)
        {
            //deze code is voor alle mousedown events hetzelfde.
            //boolean om aan te geven dat een noot geslepen wordt.
            signSelected = true;
            //de bijbehorende naam van de noot.
            SelectedNoteName = NoteName.wholeNote;
            //de cursor veranderen naar de gewenste afbeelding.
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void HalfNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedNoteName = NoteName.halfNote;
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void QuarterNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedNoteName = NoteName.quarterNote;
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void EightNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedNoteName = NoteName.eightNote;
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void SixteenthNote_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedNoteName = NoteName.sixteenthNote;
            Cursor = CursorController.ChangeCursor(SelectedNoteName);
        }

        private void FullRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedRestName = RestName.wholeRest;
            Cursor = CursorController.ChangeCursor(SelectedRestName);

        }

        private void HalfRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedRestName = RestName.halfRest;
            Cursor = CursorController.ChangeCursor(SelectedRestName);

        }

        private void QuarterRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedRestName = RestName.quarterRest;
            Cursor = CursorController.ChangeCursor(SelectedRestName);
        }

        private void GKey_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedClefName = ClefName.G;
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
            Cursor = CursorController.ChangeCursor(SelectedRestName);
        }

        private void SixteenthRest_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            SelectedRestName = RestName.sixteenthRest;
            Cursor = CursorController.ChangeCursor(SelectedRestName);
        }

        private void Flat_Click(object sender, EventArgs e)
        {
            song.PlaySong();
            signSelected = true;
            FlatSharp--;

        public void Metronoom_Tick(object sender, EventArgs e)
        {
            //SystemSounds.Beep.Play();
            //tempint++;
            Invalidate();
            foreach (Staff staf in song.GetStaffs())
            {
                foreach (Bar bar in staf.Bars)
                {
                    bar.FlatSharp--;
                }
            }
            Refresh();
        }

        private void Sharp_MouseDown(object sender, MouseEventArgs e)
        {
            signSelected = true;
            FlatSharp++;

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

            int temp = Song.getDuration();
            Console.WriteLine(rodeLijn.Interval);
            tempint++;
            Invalidate();



            if (tempint >= Song.getDuration() * 25)
            {
                rodeLijn.Stop();
            }
        }
    }
}
