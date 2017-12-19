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

        //methode die toets op laat lichten en toevoegt aan notenbalk. Tone voor de toon, key voor de aangeslagen toets en octaveplus voor welke octaaf aangeslagen wordt.
        public static void AddKey(string tone,Keys key,int octavePlus)
        {
            Enum.TryParse(tone + (ComposeView.CurrentOctave+octavePlus), out Pitch pitch);
            MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);

            if (StopwatchController.watch.IsRunning == false)
            {
                Note n1 = new Note(tone, (ComposeView.CurrentOctave+octavePlus));
                StopwatchController.StartWatch(n1);
            }

            if (pitch.ToString().Length == 7)
            {
                if (tone.Contains("Sharp"))
                {
                    tone = tone.First() + "is";
                }
            }
            ComposeView.pkv1.KeyPressed((ComposeView.CurrentOctave + octavePlus), tone);
            ComposeView.pkv1.Invalidate();

            keylijst.Add(key);
        }

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
                        AddKey("C",Keys.Q,0);
                    }

                    break;
                case Keys.D2:
                    if (!keylijst.Contains(Keys.D2))
                    {
                        AddKey("CSharp", Keys.D2, 0);
                    }


                    break;
                case Keys.W:
                    if (!keylijst.Contains(Keys.W))
                    {
                        AddKey("D",Keys.W, 0);
                    }
                    break;
                case Keys.D3:
                    if (!keylijst.Contains(Keys.D3))
                    {
                        AddKey("DSharp", Keys.D3, 0);
                    }
                    break;
                case Keys.E:
                    if (!keylijst.Contains(Keys.E))
                    {
                        AddKey("E", Keys.E, 0);
                    }
                    break;
                case Keys.R:
                    if (!keylijst.Contains(Keys.R))
                    {
                        AddKey("F", Keys.R, 0);
                    }
                    break;
                case Keys.D5:
                    if (!keylijst.Contains(Keys.D5))
                    {
                        AddKey("FSharp", Keys.D5, 0);
                    }
                    break;
                case Keys.T:
                    if (!keylijst.Contains(Keys.T))
                    {
                        AddKey("G", Keys.T, 0);
                    }
                    break;
                case Keys.D6:
                    if (!keylijst.Contains(Keys.D6))
                    {
                        AddKey("GSharp", Keys.D6, 0);
                    }
                    break;
                case Keys.Y:
                    if (!keylijst.Contains(Keys.Y))
                    {
                        AddKey("A", Keys.Y, 0);
                    }
                    break;
                case Keys.D7:
                    if (!keylijst.Contains(Keys.D7))
                    {
                        AddKey("ASharp", Keys.D7, 0);
                    }
                    break;
                case Keys.U:
                    if (!keylijst.Contains(Keys.U))
                    {
                        AddKey("B", Keys.U, 0);
                    }
                    break;
                //octaaf 3
                case Keys.V:
                    if (!keylijst.Contains(Keys.V))
                    {
                        AddKey("C", Keys.V, 1);
                    }
                    break;
                case Keys.G:
                    if (!keylijst.Contains(Keys.G))
                    {
                        AddKey("CSharp", Keys.G, 1);
                    }
                    break;
                case Keys.B:
                    if (!keylijst.Contains(Keys.B))
                    {
                        AddKey("D", Keys.B, 1);
                    }
                    break;
                case Keys.H:
                    if (!keylijst.Contains(Keys.H))
                    {
                        AddKey("DSharp", Keys.H, 1);
                    }
                    break;
                case Keys.N:
                    if (!keylijst.Contains(Keys.N))
                    {
                        AddKey("E", Keys.N, 1);
                    }
                    break;
                case Keys.M:
                    if (!keylijst.Contains(Keys.M))
                    {
                        AddKey("F", Keys.M, 1);
                    }
                    break;
                case Keys.K:
                    if (!keylijst.Contains(Keys.K))
                    {
                        AddKey("FSharp", Keys.K, 1);
                    }
                    break;

                case Keys.Oemcomma:
                    if (!keylijst.Contains(Keys.Oemcomma))
                    {
                        AddKey("G", Keys.Oemcomma, 1);
                    }
                    break;
                case Keys.OemPeriod:
                    if (!keylijst.Contains(Keys.OemPeriod))
                    {
                        AddKey("A", Keys.OemPeriod, 1);
                    }
                    break;
                case Keys.L:
                    if (!keylijst.Contains(Keys.L))
                    {
                        AddKey("GSharp", Keys.L, 1);
                    }
                    break;
                case Keys.OemSemicolon:
                    if (!keylijst.Contains(Keys.OemSemicolon))
                    {
                        AddKey("ASharp", Keys.OemSemicolon, 1);
                    }
                    break;
                case Keys.OemQuestion:
                    if (!keylijst.Contains(Keys.OemQuestion))
                    {
                        AddKey("B", Keys.OemQuestion, 1);
                    }
                    break;
                default:
                    break;
            }
        }

        public static void RemoveKey(string tone, Keys key, int octave)
        {
            Note n1 = new Note(tone, (ComposeView.CurrentOctave + octave));
            StopwatchController.StopWatch(n1);
            keylijst.Remove(key);
            if (tone.ToString().Length + octave.ToString().Length == 7)
            {
                if (tone.Contains("Sharp"))
                {
                    tone = tone.First() + "is";
                }
            }
            ComposeView.pkv1.KeyReleased((ComposeView.CurrentOctave + octave), tone);
            ComposeView.pkv1.Invalidate();
        }

        public static void ReleasePianoKeys(KeyEventArgs e)
        {
            //kijk naar welke toets ingedrukt is en zoek bijbehorende case op.
            switch (e.KeyCode)
            {
                //octaaf 2

                case Keys.Q:
                    RemoveKey("C", Keys.Q, 0);
                    break;
                case Keys.D2:
                    RemoveKey("CSharp", Keys.D2, 0);
                    break;
                case Keys.W:
                    RemoveKey("D", Keys.W, 0);
                    break;
                case Keys.D3:
                    RemoveKey("DSharp", Keys.D3, 0);
                    break;
                case Keys.E:
                    RemoveKey("E", Keys.E, 0);
                    break;
                case Keys.R:
                    RemoveKey("F", Keys.R, 0);
                    break;
                case Keys.D5:
                    RemoveKey("FSharp", Keys.D5, 0);
                    break;
                case Keys.T:
                    RemoveKey("G", Keys.T, 0);
                    break;
                case Keys.D6:
                    RemoveKey("GSharp", Keys.D6, 0);
                    break;
                case Keys.Y:
                    RemoveKey("A", Keys.Y, 0);
                    break;
                case Keys.D7:
                    RemoveKey("ASharp", Keys.D7, 0);
                    break;
                case Keys.U:
                    RemoveKey("B", Keys.U, 0);
                    break;
                //octaaf 3
                case Keys.V:
                    RemoveKey("C", Keys.V, 1);
                    break;
                case Keys.G:
                    RemoveKey("CSharp", Keys.V, 1);
                    break;
                case Keys.B:
                    RemoveKey("D", Keys.B, 1);
                    break;
                case Keys.H:
                    RemoveKey("DSharp", Keys.H, 1);
                    break;
                case Keys.N:
                    RemoveKey("E", Keys.N, 1);
                    break;
                case Keys.M:
                    RemoveKey("F", Keys.M, 1);
                    break;
                case Keys.K:
                    RemoveKey("FSharp", Keys.K, 1);
                    break;
                case Keys.Oemcomma:
                    RemoveKey("G", Keys.Oemcomma, 1);
                    break;
                case Keys.OemPeriod:
                    RemoveKey("A", Keys.OemPeriod, 1);
                    break;
                case Keys.L:
                    RemoveKey("GSharp", Keys.L, 1);
                    break;
                case Keys.OemSemicolon:
                    RemoveKey("ASharp", Keys.OemSemicolon, 1);
                    break;
                case Keys.OemQuestion:
                    RemoveKey("B", Keys.OemQuestion, 1);
                    break;
                default:
                    break;
            }
        }
    }
}
