using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.View;
using System.Windows.Forms;

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
                Console.WriteLine("geluid uit");
                //mute
            }
            else
            {
                mbv.geluidAanuitToolStripMenuItem.CheckState = CheckState.Checked;
                Console.WriteLine("geluid aan");
                //unmute
            }
        }


    }

}