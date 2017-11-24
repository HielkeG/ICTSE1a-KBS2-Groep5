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
        private Image stop = Resources.stop;
        private Image play = Resources.play;
        private Image pause = Resources.pause;
        private Image add = Resources.add;
        private Image rewind = Resources.rewind;
        private PictureBox playBox = new PictureBox();
        private PictureBox stopBox = new PictureBox();
        private PictureBox rewindBox = new PictureBox();
        private bool isAanHetSpelen = false;

        public ComposeView()
        {
            InitializeComponent();
            ShowFirstStaffView();


            rewindBox.Location = new Point(115, 30);
            rewindBox.Image = new Bitmap(rewind);
            rewindBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Controls.Add(rewindBox);

            playBox.Location = new Point(150,30);
            playBox.Image = new Bitmap(play);
            playBox.SizeMode = PictureBoxSizeMode.AutoSize;
            playBox.Click += PlayGeklikt;
            Controls.Add(playBox);

            stopBox.Location = new Point(185, 30);
            stopBox.Image = new Bitmap(stop);
            stopBox.SizeMode = PictureBoxSizeMode.AutoSize;
            Controls.Add(stopBox);
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
            btnAddStaff.Location = new Point(1800, y_staff+35);
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

            foreach(Staff staf in song.GetStaffs())
            {
                foreach(Bar bar in staf.Bars)
                {
                    bar.FlatSharp++;
                                        
                }
            }
            Refresh();
        }

        private void NoteSnapTimer_Tick(object sender, EventArgs e)
        {
            foreach (Staff staff in song.GetStaffs())
            {
                int barBegin = 250;
                int barEnd = 615;
                foreach (Bar bar in staff.Bars)
                {

                    if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin && PointToClient(Cursor.Position).Y > staff.y + 15 && PointToClient(Cursor.Position).Y < staff.y + 105)
                    {
                        int NewY = PointToClient(Cursor.Position).Y - staff.y;
                        Note newNote = StaffView.CreateNote(NewY, ComposeView.SelectedNoteName, bar.clef);
                        if (bar.CheckBarSpace(newNote) && ComposeView.SelectedNoteName != NoteName.NULL)
                        {
                            bar.Add(newNote);
                            bar.hasPreview = true;
                            Refresh();
                            bar.RemovePreview();
                        }
                    }
                    barBegin += 375;
                    barEnd += 375;
                }
            }
        }
    }
    }