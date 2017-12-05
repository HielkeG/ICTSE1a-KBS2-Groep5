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
            DatabaseController.InitializeDatabase();
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //als de gebruiker typend spelen aan heeft staan.
            if (MenuBarView.IsPlayingKeyboard)
            {
                //toetsaanslagen opvangen.
                KeyBinds.PressPianoKeys(e);

            }

        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (MenuBarView.IsPlayingKeyboard)
            {
                KeyBinds.ReleasePianoKeys(e);
            }
        }
    }
}
