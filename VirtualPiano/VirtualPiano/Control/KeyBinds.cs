using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPiano.Control
{
    public static class KeyBinds
    {
        public static void PianoKeys(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D1)
            {
                MusicController.PlaySound(1,"A");
            }
        }
    }
}
