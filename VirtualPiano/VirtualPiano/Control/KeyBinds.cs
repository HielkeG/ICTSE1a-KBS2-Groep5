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
            switch (e.KeyCode)
            {
                case Keys.Q:
                    MusicController.PlaySound(3, "C");
                    break;
                case Keys.D2:
                    MusicController.PlaySound(3, "Cis");
                    break;
                case Keys.W:
                    MusicController.PlaySound(3, "D");
                    break;
                case Keys.D3:
                    MusicController.PlaySound(3, "Dis");
                    break;
                case Keys.E:
                    MusicController.PlaySound(3, "E");
                    break;
                case Keys.R:
                    MusicController.PlaySound(3, "F");
                    break;
                case Keys.D5:
                    MusicController.PlaySound(3, "Fis");
                    break;
                case Keys.T:
                    MusicController.PlaySound(3, "G");
                    break;
                case Keys.D6:
                    MusicController.PlaySound(3, "Gis");
                    break;
                case Keys.Y:
                    MusicController.PlaySound(3, "A");
                    break;
                case Keys.D7:
                    MusicController.PlaySound(3, "Ais");
                    break;
                case Keys.U:
                    MusicController.PlaySound(3, "B");
                    break;
                
                
                default:
                    break;
            }
        }
    }
}
