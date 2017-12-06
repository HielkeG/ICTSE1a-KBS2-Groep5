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
            //mbv.gebruikershandleidingToolStripMenuItem.Click += mbv.Gebruikershandleiding_Click;
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

        public void ChangeInstrument(MenuBarView mbv,string instrument)
        {
            if(instrument == "Piano")
            {
                mbv.pianoToolStripMenuItem.CheckState = CheckState.Checked;
                mbv.marimbaToolStripMenuItem.CheckState = CheckState.Unchecked;
                mbv.gitaarToolStripMenuItem1.CheckState = CheckState.Unchecked;
                ComposeView.instrument = "Piano";
                
            } else if( instrument == "Gitaar")
            {
                mbv.pianoToolStripMenuItem.CheckState = CheckState.Unchecked;
                mbv.marimbaToolStripMenuItem.CheckState = CheckState.Unchecked;
                mbv.gitaarToolStripMenuItem1.CheckState = CheckState.Checked;
                ComposeView.instrument = "Guitar";
            }
            else if (instrument == "Marimba")
            {
                mbv.pianoToolStripMenuItem.CheckState = CheckState.Unchecked;
                mbv.marimbaToolStripMenuItem.CheckState = CheckState.Checked;
                mbv.gitaarToolStripMenuItem1.CheckState = CheckState.Unchecked;
                ComposeView.instrument = "Marimba";
            }
        }

        public void AddStaffView()
        {
            
        }
        
        public void TogglePlayingPiano(MenuBarView mbv)
        {
            if(mbv.PlayingKeyboard.CheckState == CheckState.Checked)
            {
                MenuBarView.IsPlayingKeyboard = false;
                mbv.PlayingKeyboard.CheckState = CheckState.Unchecked;
            }
            else
            {
                MenuBarView.IsPlayingKeyboard = true;
                mbv.PlayingKeyboard.CheckState = CheckState.Checked;
            }
        }

    }

}