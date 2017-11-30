using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.View;
using System.Windows.Forms;
using VirtualPiano.Model;

namespace VirtualPiano.Control
{
    public class MenuBarController
    {

        public MenuBarController()
        {
        }

        public void SoundToggle(MenuBarView mbv)
        {
            if (mbv.geluidAanuitToolStripMenuItem.Checked)
            {
                mbv.geluidAanuitToolStripMenuItem.CheckState = CheckState.Unchecked;
                Note.SoundEnabled = false;  //mute
            }
            else
            {
                mbv.geluidAanuitToolStripMenuItem.CheckState = CheckState.Checked;
                Note.SoundEnabled = true;   //unmute
            }
        }

        public void ChangeInstrument(MenuBarView mbv, string instrument)
        {
            if(instrument == "Piano")
            {
                mbv.pianoToolStripMenuItem.CheckState = CheckState.Checked;
                mbv.gitaarToolStripMenuItem.CheckState = CheckState.Unchecked;
                ComposeView.instrument = "Piano";
                
            } else if( instrument == "Gitaar")
            {
                mbv.pianoToolStripMenuItem.CheckState = CheckState.Unchecked;
                mbv.gitaarToolStripMenuItem.CheckState = CheckState.Checked;
                ComposeView.instrument = "Guitar";
            }
        }


    }

}