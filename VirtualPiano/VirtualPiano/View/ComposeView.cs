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

namespace VirtualPiano.View
{
    public partial class ComposeView : UserControl
    {
        private StaffView _staffView;
        Song song = new Song();
        Button btnAddStaff = new Button();
        int y_staff = 30;

        public ComposeView()
        {
            InitializeComponent();
            ShowFirstStaffView();
        }

        public void ShowFirstStaffView()
        {
            for (int x = 1; x <= song.GetStaffs().Count ;x++)
            {
                AddStaffView();
                if (x == song.GetStaffs().Count)
                {
                    AddStaffButton();         
                }
                y_staff += 190;
            }
           
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            btnAddStaff.Dispose();
            AddNewStaff();
        }

        public void AddNewStaff()
        {
            song.AddStaff(new Staff());
            for (int x = 1; x <= song.GetStaffs().Count; x++)
            {
                if (x == song.GetStaffs().Count)
                {
                    AddStaffView();
                    AddStaffButton();
                    y_staff += 190;
                }
            }
        }

        public void AddStaffView()
        {
            Panel panel = new Panel();
            panel.Location = new Point(500, y_staff);
            panel.Size = new Size(1300, 175);
            panel.BackColor = Color.Green;
            this.Controls.Add(panel);

            _staffView = new StaffView()
            {
                Dock = DockStyle.Fill
            };
            panel.Controls.Add(_staffView);
        }

        public void AddStaffButton()
        {
            btnAddStaff = new Button();
            btnAddStaff.Location = new Point(1070, y_staff + 180);
            this.Controls.Add(btnAddStaff);
            btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
        }
    }
}
