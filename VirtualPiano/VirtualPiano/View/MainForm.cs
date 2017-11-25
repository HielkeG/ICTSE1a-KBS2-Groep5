using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Control;
using VirtualPiano.View;


namespace VirtualPiano
{
    public partial class MainForm : Form
        {
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            menuBarView1.Song = formContent.Song;
            menuBarView1.selectedSong += ChangeSong;
            DatabaseController.InitializeDatabase();
        }

        //song veranderen op het moment dat het event selectedsong uitgevoerd wordt.
        private void ChangeSong(object sender, EventArgs e)
        {
            formContent.Song = menuBarView1.Song;
            TitelBox.Text = menuBarView1.Song.Title;
            //oorspronkelijke notenbalken verwijderen.
            formContent.RemoveStaffViews();
            foreach (var item in formContent.Song.Staffs)
            {
                formContent.AddStaffView(item);
                
            }
        }

        //public void StartOver()
        //{
        //    formContent.Controls.Remove(_mainView);
        //    _mainView.Dispose();

        //    ShowStartView();
        //}

    }
}
