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
using VirtualPiano.Properties;
using VirtualPiano.View;


namespace VirtualPiano
{
    public partial class MainForm : Form
        {

        public MainForm()
        {
            InitializeComponent();
            VirtualPiano.Control.DatabaseController.InitializeDatabase();
            SetCloseButton();
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //als de gebruiker typend spelen aan heeft staan.
            if (ComposeView.PlayingKeyboard)
            {
                //toetsaanslagen opvangen.

                KeyBinds.PressPianoKeys(e);
            }

        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (ComposeView.PlayingKeyboard)
            {
                KeyBinds.ReleasePianoKeys(e);
                Refresh();
            }
        }

        private void SetCloseButton()
        {

            CloseApplication.Image = new Bitmap(Resources.close_application, 45, 30);
        }


        private void CloseApplication_MouseEnter(object sender, EventArgs e)
        {
            CloseApplication.Image = new Bitmap(Resources.close_application_over, 45, 30);
        }

        private void CloseApplication_MouseLeave(object sender, EventArgs e)
        {
            CloseApplication.Image = new Bitmap(Resources.close_application, 45, 30);
        }


        private void CloseApplication_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
