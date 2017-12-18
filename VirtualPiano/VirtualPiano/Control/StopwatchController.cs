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
        static Note tempNote;
        public static List<ConnectWatch> connect = new List<ConnectWatch>();

        public static void StartWatch(Note note)
        {
            //indrukken
            //kijken welke stopwatch vrij is
            // voeg pitch + stopwatch toe aan lijst
            //stopwatch in gebruik

            //loslaten
            //als logelaten noot overeenkomt met noot in lijst
            //stopwatch stoppen
            //noot toevoegen
            // stopwatch niet in gebruik
            if(w1.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w1, note));
                w1.Start();
            } else if(w2.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w2, note));
                w2.Start();
            } else if(w3.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w3, note));
                w3.Start();
            } else if(w4.IsRunning == false)
            {
                connect.Add(new ConnectWatch(w4, note));
                w4.Start();
            } else if(w5.IsRunning == false)
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
                    tempNote = note;
                    
                    if (tempNote.Tone == "C" && tempNote.Octave == 5) tempNote.Y = -43;
                    else if (tempNote.Tone == "B" && tempNote.Octave == 4) tempNote.Y = -36;
                    else if (tempNote.Tone == "A" && tempNote.Octave == 4) tempNote.Y = -28;
                    else if (tempNote.Tone == "G" && tempNote.Octave == 4) tempNote.Y = -21;
                    else if (tempNote.Tone == "F" && tempNote.Octave == 4) tempNote.Y = -15;
                    else if (tempNote.Tone == "E" && tempNote.Octave == 4) tempNote.Y = -7;
                    else if (tempNote.Tone == "D" && tempNote.Octave == 4) tempNote.Y = 1;
                    else if (tempNote.Tone == "C" && tempNote.Octave == 4) tempNote.Y = 8;
                    else if (tempNote.Tone == "B" && tempNote.Octave == 3) tempNote.Y = 17;
                    else if (tempNote.Tone == "A" && tempNote.Octave == 3) tempNote.Y = 24;
                    else if (tempNote.Tone == "G" && tempNote.Octave == 3) tempNote.Y = 31;
                    else if (tempNote.Tone == "F" && tempNote.Octave == 3) tempNote.Y = 38;
                    else if (tempNote.Tone == "E" && tempNote.Octave == 3) tempNote.Y = 45;
                    else if (tempNote.Tone == "D" && tempNote.Octave == 3) tempNote.Y = 53;
                    else if (tempNote.Tone == "C" && tempNote.Octave == 3) tempNote.Y = 59;
                                        
                    if (a.watch.ElapsedMilliseconds > 0 && a.watch.ElapsedMilliseconds < 350)
                    {
                        Console.WriteLine("kwart noot");
                        note.Name = "QuarterNote";
                        tempNote = note;
                        tempNote.SetImage();
                        AddNoteToLastBar();
                    }
                    else if (a.watch.ElapsedMilliseconds >= 350 && a.watch.ElapsedMilliseconds < 700)
                    {
                        Console.WriteLine("halve noot");
                        note.Name = "HalfNote";
                        tempNote = note;
                        tempNote.SetImage();
                        AddNoteToLastBar();
                    }
                    else if(a.watch.ElapsedMilliseconds > 700) 
                    {
                        Console.WriteLine("hele noot");
                        note.Name = "WholeNote";
                        tempNote = note;
                        tempNote.SetImage();
                        AddNoteToLastBar();
                    }
                    a.watch.Reset();
                }
            }
        }
          

        public static int currentBar = 0;
        public static int currentStaff = 0;
        public static void AddNoteToLastBar()
        {
            EventArgs e = new EventArgs();

            for (int i = 0; i < Song.Staffs.Count(); i++)
            {
                foreach (Bar bar in Song.Staffs[i].Bars)
                {                    
                    if (Song.Staffs[i].Bars.IndexOf(bar) >= currentBar && Song.Staffs.IndexOf(Song.Staffs[i]) >= currentStaff)
                    {
                        if(bar.Duration + tempNote.Duration <= 16)
                        {
                            tempNote.X = (bar.Duration * 25 + (bar.length * Song.Staffs[i].Bars.IndexOf(bar))+25);
                            bar.Add(tempNote);
                            break;
                        }
                        else
                        {
                            bar.FillBar();
                            if (Song.Staffs[i].Bars.IndexOf(bar) == 3 && Song.Staffs.Count() == Song.Staffs.IndexOf(Song.Staffs[i]) + 1)
                            {
                                OnFullStaff(bar,e);
                            }                            
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
