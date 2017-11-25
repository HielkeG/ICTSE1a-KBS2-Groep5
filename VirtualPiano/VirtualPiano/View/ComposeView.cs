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

namespace VirtualPiano.View
{
    public partial class ComposeView : UserControl
    {
        public Song Song = new Song();
        Button btnAddStaff = new Button();
        int y_staff = 140;
        internal static bool signSelected;
        internal static NoteName SelectedNoteName = NoteName.NULL;
        internal static RestName SelectedRestName = RestName.NULL;
        internal static ClefName SelectedClefName = ClefName.NULL;
        private List<Panel> staffViews = new List<Panel>();
        private bool firstStart = true;

        public ComposeView()
        {
            InitializeComponent();
            if (firstStart)
            {
                ShowFirstStaffView();
                firstStart = false;
            }
        }

        public void ShowFirstStaffView()    //Eerste notenbalk laten zien
        {
            for (int x = 1; x <= Song.GetStaffs().Count; x++)
            {
                AddStaffView(Song.GetStaffs()[x - 1]);
                if (x == Song.GetStaffs().Count)
                {
                    AddStaffButton();
                }
                y_staff += 200;
            }

        }

        public void RemoveStaffViews()
        {
            for (int i = 0; i < staffViews.Count; i++)
            {
                staffViews.ElementAt(i).Dispose();
            }
            y_staff = 140;
            Refresh();

        }

        private void btnAddStaff_Click(object sender, EventArgs e) //Notenbalk toevoegen knop
        {
            btnAddStaff.Dispose();
            AddNewStaff();
        }

        public void AddNewStaff()   //Nieuw notenbalk aan Song toevoegen
        {
            Song.AddStaff(new Staff());
            for (int x = 1; x <= Song.GetStaffs().Count; x++)
            {
                if (x == Song.GetStaffs().Count)
                {
                    AddStaffView(Song.GetStaffs()[x - 1]);
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
            staffViews.Add(panel);
            StaffView _staffView = new StaffView(staff)
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
    }
}
