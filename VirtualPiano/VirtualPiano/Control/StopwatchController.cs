using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Model;
using VirtualPiano.View;

namespace VirtualPiano.Control
{
    public static class StopwatchController
    {
        public static Song Song { get; set; }
        public static Stopwatch watch = new Stopwatch();
        public static Stopwatch w1 = new Stopwatch();
        public static Stopwatch w2 = new Stopwatch();
        public static Stopwatch w3 = new Stopwatch();
        public static Stopwatch w4 = new Stopwatch();
        public static Stopwatch w5 = new Stopwatch();
        public static event EventHandler OnFullStaff;
        public static int CurrentComposingStaff;
        static Note NoteToAdd;
        public static List<ConnectWatch> connect = new List<ConnectWatch>();

        public static void StartWatch(Note note)
        {
            //indrukken
            //kijken welke stopwatch vrij is
            //voeg pitch + stopwatch toe aan lijst
            //stopwatch in gebruik

            //loslaten
            //als logelaten noot overeenkomt met noot in lijst
            //stopwatch stoppen
            //noot toevoegen
            // stopwatch niet in gebruik
            if (w1.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w1, note));
                w1.Start();
            }
            else if (w2.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w2, note));
                w2.Start();
            }
            else if (w3.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w3, note));
                w3.Start();
            }
            else if (w4.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w4, note));
                w4.Start();
            }
            else if (w5.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w5, note));
                w5.Start();
            }

        }

        public static void StopWatch(Note note)
        {
            foreach (ConnectWatch a in connect)
            {
                if (a.note.Tone == note.Tone && a.note.Octave == note.Octave && a.watch.IsRunning == true)
                {
                    a.watch.Stop();
                    NoteToAdd = note;

                    if (NoteToAdd.Tone.First() == 'C' && NoteToAdd.Octave == 5) NoteToAdd.Y = -43;
                    else if (NoteToAdd.Tone.First() == 'D' && NoteToAdd.Octave == 4) NoteToAdd.Y = -36;
                    else if (NoteToAdd.Tone.First() == 'A' && NoteToAdd.Octave == 4) NoteToAdd.Y = -28;
                    else if (NoteToAdd.Tone.First() == 'G' && NoteToAdd.Octave == 4) NoteToAdd.Y = -21;
                    else if (NoteToAdd.Tone.First() == 'F' && NoteToAdd.Octave == 4) NoteToAdd.Y = -15;
                    else if (NoteToAdd.Tone.First() == 'E' && NoteToAdd.Octave == 4) NoteToAdd.Y = -7;
                    else if (NoteToAdd.Tone.First() == 'D' && NoteToAdd.Octave == 4) NoteToAdd.Y = 1;
                    else if (NoteToAdd.Tone.First() == 'C' && NoteToAdd.Octave == 4) NoteToAdd.Y = 8;
                    else if (NoteToAdd.Tone.First() == 'B' && NoteToAdd.Octave == 3) NoteToAdd.Y = 17;
                    else if (NoteToAdd.Tone.First() == 'A' && NoteToAdd.Octave == 3) NoteToAdd.Y = 24;
                    else if (NoteToAdd.Tone.First() == 'G' && NoteToAdd.Octave == 3) NoteToAdd.Y = 31;
                    else if (NoteToAdd.Tone.First() == 'F' && NoteToAdd.Octave == 3) NoteToAdd.Y = 38;
                    else if (NoteToAdd.Tone.First() == 'E' && NoteToAdd.Octave == 3) NoteToAdd.Y = 45;
                    else if (NoteToAdd.Tone.First() == 'D' && NoteToAdd.Octave == 3) NoteToAdd.Y = 53;
                    else if (NoteToAdd.Tone.First() == 'C' && NoteToAdd.Octave == 3) NoteToAdd.Y = 59;

                    if (NoteToAdd.Tone.Length == 6) NoteToAdd.Sharp = true;

                    if (a.watch.ElapsedMilliseconds > 0 && a.watch.ElapsedMilliseconds < 350)
                    {
                        note.Name = "QuarterNote";

                    }
                    else if (a.watch.ElapsedMilliseconds >= 350 && a.watch.ElapsedMilliseconds < 700)
                    {
                        note.Name = "HalfNote";
                    }
                    else if (a.watch.ElapsedMilliseconds > 700)
                    {
                        note.Name = "WholeNote";
                    }
                    NoteToAdd = note;
                    if (NoteToAdd.Name != null)
                    {
                        NoteToAdd.SetImage();
                        AddNoteToLastBar();
                    }
                    a.watch.Reset();
                    break;
                }
            }

        }

        public static void AddNoteToLastBar()
        {
            EventArgs e = new EventArgs();
            //voor elke staff 
            for (int i = 0; i < Song.Staffs.Count(); i++)
            {
                //in elke bar kijken of de noot daarin geplaatst moet worden.
                foreach (Bar bar in Song.Staffs[i].Bars)
                {
                    //als de noot past en deze staff gecomponeerd moet worden.
                    if (bar.Duration + NoteToAdd.Duration <= 16 && Song.Staffs[i] == Song.Staffs[CurrentComposingStaff])
                    {

                        NoteToAdd.X = (bar.Duration * 25 + (bar.width * Song.Staffs[i].Bars.IndexOf(bar)) + 25);

                        if (NoteToAdd.Tone.Contains("Sharp"))
                        {
                            NoteToAdd.Tone = NoteToAdd.Tone.First() + "is";
                        }
                        NoteToAdd.SetImage();
                        NoteToAdd.X = (bar.Duration * 25 + (bar.width * Song.Staffs[i].Bars.IndexOf(bar)) + 25);
                        bar.Add(NoteToAdd);
                        break;
                    }
                    else
                    {
                        //anders wordt de bar gevuld 
                        bar.FillBar(Song.Staffs[i].Bars.IndexOf(bar));
                        //als het de laatste bar is in de staffview en het de laatste staffview van de song is.
                        if (Song.Staffs[CurrentComposingStaff].Bars.IndexOf(bar) == 3)
                        {
                            //als dit de vierde bar was wordt er een nieuwe staff toegevoegd.
                            Song.Staffs[CurrentComposingStaff].ComposingStaff = false;
                            if (Song.Staffs[CurrentComposingStaff] == Song.Staffs.Last())
                            {
                                //nieuwe staffview toevoegen
                                OnFullStaff(bar, e);
                            }
                            CurrentComposingStaff++;


                            Song.Staffs[CurrentComposingStaff].ComposingStaff = true;
                        }
                    }
                }
            }
        }

    }



    public struct ConnectWatch
    {
        public Stopwatch watch;
        public Note note;

        public ConnectWatch(Stopwatch stopwatch, Note note)
        {
            this.watch = stopwatch;
            this.note = note;
        }
    }
}