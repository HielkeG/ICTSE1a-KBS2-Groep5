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
        //alle noten gebonden aan toetsenbordtoetsen.
        public static void PianoKeys(KeyEventArgs e)
        {
            //kijk naar welke toets ingedrukt is en zoek bijbehorende case op.
            switch (e.KeyCode)
            {
                //octaaf 3
                
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
                //octaaf 4
                case Keys.V:
                    MusicController.PlaySound(4, "C");
                    break;
                case Keys.G:
                    MusicController.PlaySound(4, "Cis");
                    break;
                case Keys.B:
                    MusicController.PlaySound(4, "D");
                    break;
                case Keys.H:
                    MusicController.PlaySound(4, "Dis");
                    break;
                case Keys.N:
                    MusicController.PlaySound(4, "E");
                    break;
                case Keys.M:
                    MusicController.PlaySound(4, "F");
                    break;
                case Keys.K:
                    MusicController.PlaySound(4, "Fis");
                    break;
                case Keys.Oemcomma:
                    MusicController.PlaySound(4, "G");
                    break;
                case Keys.OemPeriod:
                    MusicController.PlaySound(4, "A");
                    break;
                case Keys.L:
                    MusicController.PlaySound(4, "Gis");
                    break;
                case Keys.OemSemicolon:
                    MusicController.PlaySound(4, "Ais");
                    break;
                case Keys.OemQuestion:
                    MusicController.PlaySound(4, "B");
                    break;
                default:
                    break;
            }
        }
    }
}
