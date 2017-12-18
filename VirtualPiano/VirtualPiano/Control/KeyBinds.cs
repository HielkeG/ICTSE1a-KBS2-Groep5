using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Model;
using VirtualPiano.View;

namespace VirtualPiano.Control
{
    public static class KeyBinds
    {
        public static bool isGestart = false;
        public static OutputDevice outputDevice;
        static List<Keys> keylijst = new List<Keys>();

        //alle noten gebonden aan toetsenbordtoetsen.
        public static void PressPianoKeys(KeyEventArgs e)
        {
            //kijk naar welke toets ingedrukt is en zoek bijbehorende case op.
            switch (e.KeyCode)
            {
                //octaaf 2
                case Keys.Q:
                    if (!keylijst.Contains(Keys.Q))
                     { 
                        Enum.TryParse("C" + ComposeView.CurrentOctave, out Pitch pitch);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "C");
                    ComposeView.pkv1.Invalidate();

                    if (StopwatchController.w1.IsRunning == false)
                    {
                        Note n1 = new Note("C", ComposeView.CurrentOctave);
                        StopwatchController.StartWatch(n1);
                    }
                        keylijst.Add(Keys.Q);
                    }

                    break;
                case Keys.D2:
                    if (!keylijst.Contains(Keys.D2))
                    {
                        Enum.TryParse("CSharp" + ComposeView.CurrentOctave, out Pitch pitch2);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch2, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Cis");
                    ComposeView.pkv1.Invalidate();
                    
                    keylijst.Add(Keys.D2);
                    }
            break;
                case Keys.W:
                    if (!keylijst.Contains(Keys.W))
                    {
                        Enum.TryParse("D" + ComposeView.CurrentOctave, out Pitch pitch3);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch3, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "D");
                    ComposeView.pkv1.Invalidate();
                    if (StopwatchController.watch.IsRunning == false)
                    {
                        Note n2 = new Note("D", ComposeView.CurrentOctave);
                        StopwatchController.StartWatch(n2);
                    }
                        keylijst.Add(Keys.W);
                    }
                    break;
                case Keys.D3:
                    if (!keylijst.Contains(Keys.D3))
                    {
                        Enum.TryParse("DSharp" + ComposeView.CurrentOctave, out Pitch pitch4);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch4, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Dis");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.D3);
                    }
                    break;
                case Keys.E:
                    if (!keylijst.Contains(Keys.E))
                    {
                        Enum.TryParse("E" + ComposeView.CurrentOctave, out Pitch pitch5);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch5, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "E");
                    ComposeView.pkv1.Invalidate();
                    if (StopwatchController.watch.IsRunning == false)
                    {
                        Note n3 = new Note("E", ComposeView.CurrentOctave);
                        StopwatchController.StartWatch(n3);
                    }
                        keylijst.Add(Keys.E);
                    }
                    break;
                case Keys.R:
                    if (!keylijst.Contains(Keys.R))
                    {
                        Enum.TryParse("F" + ComposeView.CurrentOctave, out Pitch pitch6);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch6, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "F");
                    ComposeView.pkv1.Invalidate();
                    if (StopwatchController.watch.IsRunning == false)
                    {
                        Note n4 = new Note("R", ComposeView.CurrentOctave);
                        StopwatchController.StartWatch(n4);
                    }
                        keylijst.Add(Keys.R);
                    }
                    break;
                case Keys.D5:
                    if (!keylijst.Contains(Keys.D5))
                    {
                        Enum.TryParse("FSharp" + ComposeView.CurrentOctave, out Pitch pitch7);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch7, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Fis");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.D5);
                    }

                    break;
                case Keys.T:
                    if (!keylijst.Contains(Keys.T))
                    {
                        Enum.TryParse("G" + ComposeView.CurrentOctave, out Pitch pitch8);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch8, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "G");
                    ComposeView.pkv1.Invalidate();
                    if (StopwatchController.watch.IsRunning == false)
                    {
                        Note n5 = new Note("G", ComposeView.CurrentOctave);
                        StopwatchController.StartWatch(n5);
                    }
                        keylijst.Add(Keys.T);
                    }
                    break;
                case Keys.D6:
                    if (!keylijst.Contains(Keys.D6))
                    {
                        Enum.TryParse("GSharp" + ComposeView.CurrentOctave, out Pitch pitch9);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch9, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Gis");
                    ComposeView.pkv1.Invalidate(); ;
                        keylijst.Add(Keys.D6);
                    }
                    break;
                case Keys.Y:
                    if (!keylijst.Contains(Keys.Y))
                    {
                        Enum.TryParse("A" + ComposeView.CurrentOctave, out Pitch pitch10);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch10, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "A");
                    ComposeView.pkv1.Invalidate();
                    if (StopwatchController.watch.IsRunning == false)
                    {
                        Note n6 = new Note("A", ComposeView.CurrentOctave);
                        StopwatchController.StartWatch(n6);
                    }
                        keylijst.Add(Keys.Y);
                    }
                    break;
                case Keys.D7:
                    if (!keylijst.Contains(Keys.D7))
                    {
                        Enum.TryParse("ASharp" + ComposeView.CurrentOctave, out Pitch pitch11);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch11, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "Ais");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.D7);
                    }
                    break;
                case Keys.U:
                    if (!keylijst.Contains(Keys.U))
                    {
                        Enum.TryParse("B" + ComposeView.CurrentOctave, out Pitch pitch12);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch12, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave, "B");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.U);
                    }
                    break;
                //octaaf 3
                case Keys.V:
                    if (!keylijst.Contains(Keys.V))
                    {
                        Enum.TryParse("C" + (ComposeView.CurrentOctave + 1), out Pitch pitch13);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch13, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "C");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.V);
                    }
                    break;
                case Keys.G:
                    if (!keylijst.Contains(Keys.G))
                    {
                        Enum.TryParse("CSharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch14);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch14, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Cis");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.G);
                    }
                    break;
                case Keys.B:
                    if (!keylijst.Contains(Keys.B))
                    {
                        Enum.TryParse("D" + (ComposeView.CurrentOctave + 1), out Pitch pitch15);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch15, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "D");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.B);
                    }
                    break;
                case Keys.H:
                    if (!keylijst.Contains(Keys.H))
                    {
                        Enum.TryParse("DSharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch16);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch16, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Dis");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.H);
                    }
                    break;
                case Keys.N:
                    if (!keylijst.Contains(Keys.N))
                    {
                        Enum.TryParse("E" + (ComposeView.CurrentOctave + 1), out Pitch pitch17);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch17, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "E");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.N);
                    }
                    break;
                case Keys.M:
                    if (!keylijst.Contains(Keys.M))
                    {
                        Enum.TryParse("F" + (ComposeView.CurrentOctave + 1), out Pitch pitch18);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch18, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "F");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.M);
                    }
                    break;
                case Keys.K:
                    if (!keylijst.Contains(Keys.K))
                    {
                        Enum.TryParse("FSharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch19);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch19, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Fis");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.K);
                    }
                    break;

                case Keys.Oemcomma:
                    if (!keylijst.Contains(Keys.Oemcomma))
                    {
                        Enum.TryParse("G" + (ComposeView.CurrentOctave + 1), out Pitch pitch20);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch20, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "G");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.Oemcomma);
                    }
                    break;
                case Keys.OemPeriod:
                    if (!keylijst.Contains(Keys.OemPeriod))
                    {
                        Enum.TryParse("A" + (ComposeView.CurrentOctave + 1), out Pitch pitch21);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch21, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "A");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.OemPeriod);
                    }
                    break;
                case Keys.L:
                    if (!keylijst.Contains(Keys.L))
                    {
                        Enum.TryParse("GSharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch22);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch22, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Gis");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.L);
                    }
                    break;
                case Keys.OemSemicolon:
                    if (!keylijst.Contains(Keys.OemSemicolon))
                    {
                        Enum.TryParse("ASharp" + (ComposeView.CurrentOctave + 1), out Pitch pitch23);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch23, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "Ais");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.OemSemicolon);
                    }
                    break;
                case Keys.OemQuestion:
                    if (!keylijst.Contains(Keys.OemQuestion))
                    {
                        Enum.TryParse("B" + (ComposeView.CurrentOctave + 1), out Pitch pitch24);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch24, 127);
                    ComposeView.pkv1.KeyPressed(ComposeView.CurrentOctave+1, "B");
                    ComposeView.pkv1.Invalidate();
                        keylijst.Add(Keys.OemQuestion);
                    }
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
                    Note n1 = new Note("C", ComposeView.CurrentOctave);
                    StopwatchController.StopWatch(n1);
                    keylijst.Remove(Keys.Q);
                    break;
                case Keys.D2:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Cis");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.D2);

                    break;
                case Keys.W:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "D");
                    ComposeView.pkv1.Invalidate();
                    Note n3 = new Note("D", ComposeView.CurrentOctave);
                    StopwatchController.StopWatch(n3);
                    keylijst.Remove(Keys.W);
                    break;
                case Keys.D3:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Dis");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.D3);
                    break;
                case Keys.E:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "E");
                    ComposeView.pkv1.Invalidate();
                    Note n5 = new Note("E", ComposeView.CurrentOctave);
                    StopwatchController.StopWatch(n5);
                    keylijst.Remove(Keys.E);
                    break;
                case Keys.R:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "F");
                    ComposeView.pkv1.Invalidate();
                    Note n6 = new Note("F", ComposeView.CurrentOctave);
                    StopwatchController.StopWatch(n6);
                    keylijst.Remove(Keys.R);
                    break;
                case Keys.D5:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Fis");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.D5);
                    break;
                case Keys.T:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "G");
                    ComposeView.pkv1.Invalidate();
                    Note n8 = new Note("G", ComposeView.CurrentOctave);
                    StopwatchController.StopWatch(n8);
                    keylijst.Remove(Keys.T);
                    break;
                case Keys.D6:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Gis");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.D6);
                    break;
                case Keys.Y:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "A");
                    ComposeView.pkv1.Invalidate();
                    Note n10 = new Note("A", ComposeView.CurrentOctave);
                    StopwatchController.StopWatch(n10);
                    keylijst.Remove(Keys.Y);
                    break;
                case Keys.D7:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "Ais");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.D7);
                    break;
                case Keys.U:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave, "B");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.U);
                    break;
                //octaaf 3
                case Keys.V:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "C");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.V);
                    break;
                case Keys.G:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Cis");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.G);
                    break;
                case Keys.B:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "D");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.B);
                    break;
                case Keys.H:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Dis");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.H);
                    break;
                case Keys.N:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "E");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.N);
                    break;
                case Keys.M:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "F");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.M);
                    break;
                case Keys.K:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Fis");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.K);
                    break;
                case Keys.Oemcomma:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "G");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.Oemcomma);
                    break;
                case Keys.OemPeriod:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "A");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.OemPeriod);
                    break;
                case Keys.L:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Gis");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.L);
                    break;
                case Keys.OemSemicolon:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "Ais");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.OemSemicolon);
                    break;
                case Keys.OemQuestion:
                    ComposeView.pkv1.KeyReleased(ComposeView.CurrentOctave+1, "B");
                    ComposeView.pkv1.Invalidate();
                    keylijst.Remove(Keys.OemQuestion);
                    break;
                default:
                    break;
            }
        }
    }
}
