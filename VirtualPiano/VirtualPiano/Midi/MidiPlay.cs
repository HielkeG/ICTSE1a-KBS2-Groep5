// Copyright (c) 2009, Tom Lokovic
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
//     * Redistributions of source code must retain the above copyright notice,
//       this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Threading;
using System.Collections.Generic;
using VirtualPiano.View;
using VirtualPiano.Control;
using System.Linq;
using System.Text.RegularExpressions;

namespace VirtualPiano
{    
    public class MidiPlay 
    {

            public MidiPlay()
        {
        }

        public class Summarizer
        {

            public Summarizer(InputDevice inputDevice)
            {
                this.inputDevice = inputDevice;
                pitchesPressed = new Dictionary<Pitch, bool>();
                inputDevice.NoteOn += new InputDevice.NoteOnHandler(this.NoteOn);
                inputDevice.NoteOff += new InputDevice.NoteOffHandler(this.NoteOff);
            }
        
            private void PrintStatus()
            {

                List<Pitch> pitches = new List<Pitch>(pitchesPressed.Keys);
                pitches.Sort();

                Console.Write("Notes: ");
                for (int i = 0; i < pitches.Count; ++i)
                {
                    Pitch pitch = pitches[i];
                    if (i > 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write("{0}", pitch.NotePreferringSharps());
                    if (pitch.NotePreferringSharps() != pitch.NotePreferringFlats())
                    {
                        Console.Write(" or {0}", pitch.NotePreferringFlats());
                    }
                    Console.WriteLine(pitch.Octave());
                    Console.WriteLine(pitch.GetHashCode());

                }
                Console.WriteLine();
                // Print the currently held down chord.
                List<Chord> chords = Chord.FindMatchingChords(pitches);
                Console.Write("Chords: ");
                for (int i = 0; i < chords.Count; ++i)
                {
                    Chord chord = chords[i];
                    if (i > 0)
                    {
                        Console.Write(", ");
                    }
                    Console.Write("{0}", chord);
                }
                Console.WriteLine(); 
            }

            public void NoteOn(NoteOnMessage msg)
            {
                lock (this)
                {
                    MusicController.outputDevice.SendProgramChange(Channel.Channel2, Instrument.Lead1Square);
                    MusicController.outputDevice.SendNoteOn(Channel.Channel2, msg.Pitch, 127);
                    string currentTone = msg.Pitch.ToString();
                    char n = currentTone.FirstOrDefault();
                    string resultString = Regex.Match(currentTone, @"\d+").Value;
                    int o = Int32.Parse(resultString);
                    if (currentTone.Length == 7)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(n.ToString()).Append("#");
                        ComposeView.pkv1.KeyPressed(o, sb.ToString());
                    } else
                    {
                        ComposeView.pkv1.KeyPressed(o, n.ToString());
                    }

                    ComposeView.pkv1.Invalidate();
                    Console.WriteLine(msg.Pitch);
                    pitchesPressed[msg.Pitch] = true;
                    //PrintStatus();
                    //Console.WriteLine(msg.Velocity);                    
                }
            }

            public void NoteOff(NoteOffMessage msg)
            {
                lock (this)
                {
                    MusicController.outputDevice.SendNoteOff(Channel.Channel2, msg.Pitch, 80);
                    pitchesPressed.Remove(msg.Pitch);
                    string currentTone = msg.Pitch.ToString();
                    char n = currentTone.FirstOrDefault();
                    string resultString = Regex.Match(currentTone, @"\d+").Value;
                    int o = Int32.Parse(resultString);
                    if (currentTone.Length == 7)
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append(n.ToString()).Append("#");
                        ComposeView.pkv1.KeyReleased(o, sb.ToString());
                    }
                    else
                    {
                        ComposeView.pkv1.KeyReleased(o, n.ToString());
                    }
                    ComposeView.pkv1.Invalidate();
                    //PrintStatus();
                }
            }

            private InputDevice inputDevice;
            private Dictionary<Pitch, bool> pitchesPressed;
        }

        public static void Start(InputDevice input)
        {           
            InputDevice inputDevice = input;
            inputDevice.Open();
            inputDevice.StartReceiving(null);
            Summarizer summarizer = new Summarizer(inputDevice);




            //inputDevice.StopReceiving();
            //inputDevice.Close();

            //inputDevice.RemoveAllEventHandlers();

        }
    }
}
