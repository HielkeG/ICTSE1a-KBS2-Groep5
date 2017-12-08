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
        public static bool isGestart = false;
        public static OutputDevice outputDevice;
        //alle noten gebonden aan toetsenbordtoetsen.
        public static void PressPianoKeys(KeyEventArgs e)
        {

            //outputDevice = OutputDevice.InstalledDevices[0];
            //if (isGestart == false)
            //{
            //    outputDevice.Open();
            //}
            //isGestart = true;
            //kijk naar welke toets ingedrukt is en zoek bijbehorende case op.
            switch (e.KeyCode)
            {
                //octaaf 2
                case Keys.Q:
                    //outputDevice.SendProgramChange(Channel.Channel1, Instrument.AcousticGrandPiano);
                    Enum.TryParse("C" + ComposeView.CurrentOctave, out Pitch pitch);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "C");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D2:
                    Enum.TryParse("CSharp" + ComposeView.CurrentOctave, out Pitch pitch2);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch2, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Cis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.W:
                    Enum.TryParse("D" + ComposeView.CurrentOctave, out Pitch pitch3);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch3, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "D");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D3:
                    Enum.TryParse("DSharp" + ComposeView.CurrentOctave, out Pitch pitch4);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch4, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Dis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.E:
                    Enum.TryParse("E" + ComposeView.CurrentOctave, out Pitch pitch5);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch5, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "E");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.R:
                    Enum.TryParse("F" + ComposeView.CurrentOctave, out Pitch pitch6);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch6, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "F");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D5:
                    Enum.TryParse("FSharp" + ComposeView.CurrentOctave, out Pitch pitch7);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch7, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Fis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.T:
                    Enum.TryParse("G" + ComposeView.CurrentOctave, out Pitch pitch8);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch8, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "G");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D6:
                    Enum.TryParse("GSharp" + ComposeView.CurrentOctave, out Pitch pitch9);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch9, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Gis");
                    ComposeView.pkv1.Invalidate(); ;
                    break;
                case Keys.Y:
                    Enum.TryParse("A" + ComposeView.CurrentOctave, out Pitch pitch10);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch10, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "A");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D7:
                    Enum.TryParse("ASharp" + ComposeView.CurrentOctave, out Pitch pitch11);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch11, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Ais");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.U:
                    Enum.TryParse("B" + ComposeView.CurrentOctave, out Pitch pitch12);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch12, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "B");
                    ComposeView.pkv1.Invalidate();
                    break;
                //octaaf 3
                case Keys.V:
                    Enum.TryParse("C" + (ComposeView.CurrentOctave + 1), out Pitch pitch13);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch13, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "C");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.G:
                    Enum.TryParse("CSharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch14);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch14, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Cis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.B:
                    Enum.TryParse("D" + (ComposeView.CurrentOctave + 1), out Pitch pitch15);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch15, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "D");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.H:
                    Enum.TryParse("DSharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch16);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch16, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Dis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.N:
                    Enum.TryParse("E" + (ComposeView.CurrentOctave + 1), out Pitch pitch17);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch17, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "E");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.M:
                    Enum.TryParse("F" + (ComposeView.CurrentOctave + 1), out Pitch pitch18);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch18, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "F");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.K:
                    Enum.TryParse("FSharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch19);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch19, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Fis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.Oemcomma:
                    Enum.TryParse("G" + (ComposeView.CurrentOctave + 1), out Pitch pitch20);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch20, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "G");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemPeriod:
                    Enum.TryParse("A" + (ComposeView.CurrentOctave + 1), out Pitch pitch21);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch21, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "A");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.L:
                    Enum.TryParse("GSharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch22);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch22, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Gis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemSemicolon:
                    Enum.TryParse("ASharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch23);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch23, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Ais");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemQuestion:
                    Enum.TryParse("B" + (ComposeView.CurrentOctave + 1), out Pitch pitch24);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch24, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "B");
                    ComposeView.pkv1.Invalidate();
                    break;
                default:
                    break;
            }
        }

        public static void ReleasePianoKeys(KeyEventArgs e)
        {
            //kijk naar welke toets ingedrukt is en zoek bijbehorende case op.
            switch (e.KeyCode)
            {
                //octaaf 2

                case Keys.Q:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "C");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D2:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Cis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.W:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "D");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D3:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Dis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.E:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "E");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.R:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "F");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D5:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Fis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.T:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "G");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D6:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Gis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.Y:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "A");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.D7:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Ais");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.U:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "B");
                    ComposeView.pkv1.Invalidate();
                    break;
                //octaaf 3
                case Keys.V:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "C");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.G:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Cis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.B:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "D");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.H:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Dis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.N:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "E");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.M:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "F");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.K:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Fis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.Oemcomma:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "G");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemPeriod:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "A");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.L:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Gis");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemSemicolon:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Ais");
                    ComposeView.pkv1.Invalidate();
                    break;
                case Keys.OemQuestion:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "B");
                    ComposeView.pkv1.Invalidate();
                    break;
                default:
                    break;
            }
        }
    }
}
