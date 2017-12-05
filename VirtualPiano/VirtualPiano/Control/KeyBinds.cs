using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.View;

namespace VirtualPiano.Control
{
    public static class KeyBinds
    {
        //alle noten gebonden aan toetsenbordtoetsen.
        public static void PressPianoKeys(KeyEventArgs e)
        {
            //kijk naar welke toets ingedrukt is en zoek bijbehorende case op.
            switch (e.KeyCode)
            {
                //octaaf 2
                
                case Keys.Q:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "C");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "C");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D2:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "Cis");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "C#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.W:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "D");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "D");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D3:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "Dis");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "D#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.E:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "E");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "E");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.R:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "F");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "F");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D5:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "Fis");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "F#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.T:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "G");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "G");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D6:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "Gis");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "G#");
                    ComposeView.pkv1.Invalidate(); ;
                    break;
                case Keys.Y:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "A");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "A");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D7:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "Ais");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "A#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.U:
                    MusicController.PlaySound(ComposeView.CurrentOctave, "B");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "B");
                    ComposeView.pkv1.Invalidate();
                    break;
                //octaaf 3
                case Keys.V:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "C");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "C");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.G:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "Cis");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "C#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.B:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "D");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "D");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.H:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "Dis");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "D#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.N:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "E");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "E");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.M:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "F");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "F");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.K:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "Fis");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "F#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.Oemcomma:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "G");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "G");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemPeriod:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "A");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "A");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.L:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "Gis");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "G#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemSemicolon:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "Ais");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "A#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemQuestion:
                    MusicController.PlaySound(ComposeView.CurrentOctave+1, "B");
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "B");
                    ComposeView.pkv1.Invalidate();
                    break;
                default:
                    break;
            }
        }

        public static void UnpressPianoKeys(KeyEventArgs e)
        {
            //kijk naar welke toets ingedrukt is en zoek bijbehorende case op.
            switch (e.KeyCode)
            {
                //octaaf 2

                case Keys.Q:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "C");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D2:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "C#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.W:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "D");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D3:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "D#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.E:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "E");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.R:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "F");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D5:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "F#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.T:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "G");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D6:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "G#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.Y:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "A");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D7:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "A#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.U:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave, "B");
                    ComposeView.pkv1.Invalidate();
                    break;
                //octaaf 3
                case Keys.V:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "C");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.G:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "C#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.B:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "D");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.H:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "D#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.N:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "E");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.M:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "F");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.K:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "F#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.Oemcomma:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "G");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemPeriod:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "A");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.L:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "G#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemSemicolon:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "A#");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemQuestion:
                    ComposeView.pkv1.KeyUnpressed(ComposeView.CurrentOctave+1, "B");
                    ComposeView.pkv1.Invalidate();
                    break;
                default:
                    break;
            }
        }
    }
}
