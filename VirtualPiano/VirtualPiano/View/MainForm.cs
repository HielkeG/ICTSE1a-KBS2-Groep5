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
            private ComposeView _composeView;
        public MainForm()
        {
            InitializeComponent();
            ShowComposeView();
        }

        public void ShowComposeView()
        {
            _composeView = new ComposeView()
            {
                Dock = DockStyle.Fill
            };
            formContent.Controls.Add(_composeView);
        }

            //public void StartOver()
            //{
            //    formContent.Controls.Remove(_mainView);
            //    _mainView.Dispose();

            //    ShowStartView();
            //}

    }
}
