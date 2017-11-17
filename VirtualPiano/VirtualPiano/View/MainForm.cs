using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.View;


namespace VirtualPiano
{
    public partial class MainForm : Form
        {
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void formContent_Load(object sender, EventArgs e)
        {

        }
        //public void StartOver()
        //{
        //    formContent.Controls.Remove(_mainView);
        //    _mainView.Dispose();

        //    ShowStartView();
        //}

    }
}
