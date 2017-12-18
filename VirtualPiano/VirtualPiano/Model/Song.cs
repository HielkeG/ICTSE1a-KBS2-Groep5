using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Control;
using VirtualPiano.View;

namespace VirtualPiano.Model
{
    public class Song
    {
        public List<Staff> Staffs { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }
        public string Composer { get; set; }
        public int FlatSharp = 0;
        private string title = "titel";
        public int Pages { get; set; }
        public string Title
        {
            get
            {
                if (title != "")
                {
                    return title;
                }
                else
                {
                    return "Geen titel";
                }
            }
            set
            {
                if (value != "")
                {
                    title = value;
                }
            }
        }
        public Song()
        {
            Staffs = new List<Staff>();
            Staffs.Add(new Staff());
            Pages = 1;

            if (MusicController.isGestart)
            {
                if (ComposeView.instrument == "Piano")
                {
                    //instrument veranderen naar piano
                    MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.AcousticGrandPiano);
                }
                else if (ComposeView.instrument == "Guitar")
                {
                    //instrument veranderen naar gitaar
                    MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.AcousticGuitarSteel);
                }
                else if (ComposeView.instrument == "Marimba")
                {
                    //instrument veranderen naar marimba
                    MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.Xylophone);
                }
                else
                {
                    //instrument standaard veranderen naar harp
                    MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.OrchestralHarp);
                }
            }
        }

        public void AddStaff(Staff s)
        {
            Staffs.Add(s);
        }

        public List<Staff> GetStaffs()
        {
            return Staffs.ToList();
        }

        public bool IsEmpty()
        {
            bool isEmpty = true;
            foreach (var staff in Staffs)
            {
                if (!staff.IsEmtpy())
                {
                    isEmpty = false;
                }
            }
            return isEmpty;
        }

        public int getDuration()
        {
            int duration = 0;
            foreach (Staff staff in Staffs)
            {
                foreach (Bar bar in staff.Bars)
                {
                    duration = duration + bar.duration;
                }
            }
            return duration; // 1 maat is 16
        }


        public async void PlayNote()
        {
            foreach (var staff in Staffs)
            {
                if (staff.IsBeingPlayed)
                {
                    if (ComposeView.RedLineX <= 425)
                    {
                        foreach (var sign in staff.Bars.ElementAt(0).Signs)
                        {
                            if (sign is Note note && note.X >= ComposeView.RedLineX + 63 && note.X <= ComposeView.RedLineX + 66)
                            {
                                Console.WriteLine(ComposeView.RedLineX);


                                //Console.WriteLine(note.X);
                                //toetsenbordkey op laten lichten
                                ComposeView.pkv1.KeyPressed(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                //pitch ophalen uit de note
                                string parsedPitch = note.Tone.ToString() + note.Octave.ToString();
                                //string parsen naar pitch
                                if (parsedPitch.Length == 4)
                                {
                                    parsedPitch = note.Tone.First() + "Sharp" + note.Octave;
                                }
                                Enum.TryParse(parsedPitch, out Pitch pitch);
                                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                await PutTaskDelay(75);
                                //outputDevice.SendNoteOff(Channel.Channel1, pitch, 127);
                                //toets oplichtne na 75 milliseconden wachten
                                ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();

                                break;
                            }
                        }
                    }
                    else if (ComposeView.RedLineX > 425 && ComposeView.RedLineX <= 850)
                    {
                        foreach (var sign in staff.Bars.ElementAt(1).Signs)
                        {
                            if (sign is Note note && note.X >= ComposeView.RedLineX + 63 && note.X <= ComposeView.RedLineX + 66)
                            {
                                Console.WriteLine(ComposeView.RedLineX);
                                //toetsenbordkey op laten lichten

                                ComposeView.pkv1.KeyPressed(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                //note.PlaySound();
                                string pitchTemp = note.Tone.ToString() + note.Octave.ToString();
                                Enum.TryParse(pitchTemp, out Pitch pitch);
                                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                await PutTaskDelay(75);
                                ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                break;
                            }
                        }
                    }
                    else if (ComposeView.RedLineX > 850 && ComposeView.RedLineX <= 1275)
                    {
                        foreach (var sign in staff.Bars.ElementAt(2).Signs)
                        {
                            if (sign is Note note && note.X >= ComposeView.RedLineX + 63 && note.X <= ComposeView.RedLineX + 66)
                            {
                                Console.WriteLine(ComposeView.RedLineX);
                                //toetsenbordkey op laten lichten

                                ComposeView.pkv1.KeyPressed(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                //note.PlaySound();
                                string pitchTemp = note.Tone.ToString() + note.Octave.ToString();
                                Enum.TryParse(pitchTemp, out Pitch pitch);
                                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                await PutTaskDelay(75);
                                ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                break;
                            }
                        }
                    }
                    else if (ComposeView.RedLineX > 1275)
                    {
                        foreach (var sign in staff.Bars.ElementAt(3).Signs)
                        {
                            if (sign is Note note && note.X >= ComposeView.RedLineX + 63 && note.X <= ComposeView.RedLineX + 66)
                            {
                                Console.WriteLine(ComposeView.RedLineX);
                                //toetsenbordkey op laten lichten

                                ComposeView.pkv1.KeyPressed(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                //note.PlaySound();
                                string pitchTemp = note.Tone.ToString() + note.Octave.ToString();
                                Enum.TryParse(pitchTemp, out Pitch pitch);
                                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                await PutTaskDelay(75);
                                ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void ChangeSharpFlat(int Flatsharp)
        {
            foreach (Staff staff in Staffs)
            {
                foreach (Bar bar in staff.Bars)
                {
                    foreach (Sign sign in bar.Signs)
                    {
                        if (sign is Note note)
                        {
                            if (note.flat == false && note.sharp == false)
                            {
                                if (note.Tone == "Fis") { note.Tone = "F"; }
                                if (note.Tone == "Cis") { note.Tone = "C"; }
                                if (note.Tone == "Gis") { note.Tone = "G"; }
                                if (note.Tone == "Dis") { note.Tone = "D"; }
                                if (note.Tone == "Ais") { note.Tone = "A"; }
                                if (note.Tone == "Bes") { note.Tone = "B"; }
                                if (note.Tone == "Es") { note.Tone = "E"; }
                                if (note.Tone == "As") { note.Tone = "A"; }
                                if (note.Tone == "Des") { note.Tone = "D"; }
                                if (note.Tone == "Ges") { note.Tone = "G"; }


                                if (Flatsharp >= 1) { if (note.Tone == "F") { note.Tone = "Fis"; } }
                                if (Flatsharp >= 2) { if (note.Tone == "C") { note.Tone = "Cis"; } }
                                if (Flatsharp >= 3) { if (note.Tone == "G") { note.Tone = "Gis"; } }
                                if (Flatsharp >= 4) { if (note.Tone == "D") { note.Tone = "Dis"; } }
                                if (Flatsharp >= 5) { if (note.Tone == "A") { note.Tone = "Ais"; } }

                                if (Flatsharp <= -1) { if (note.Tone == "B") { note.Tone = "Bes"; } }
                                if (Flatsharp <= -2) { if (note.Tone == "E") { note.Tone = "Es"; } }
                                if (Flatsharp <= -3) { if (note.Tone == "A") { note.Tone = "As"; } }
                                if (Flatsharp <= -4) { if (note.Tone == "D") { note.Tone = "Des"; } }
                                if (Flatsharp <= -5) { if (note.Tone == "G") { note.Tone = "Ges"; } }
                            }
                        }
                    }
                }
            }
        }

        async Task PutTaskDelay(int delay)
        {
            await Task.Delay(delay);
        }

        public void SetStaffs(List<Staff> staffs)
        {
            Staffs = staffs;
        }

        public void OrderSigns()
        {
            foreach (var staff in Staffs)
            {
                foreach (var bar in staff.Bars)
                {
                    IEnumerable<Sign> signs = bar.Signs.OrderBy(sign => sign.X);
                    bar.Signs = signs.ToList();
                }
            }
        }

        public void OrderStaffs()
        {
            IEnumerable<Staff> orderedStaffs = Staffs.OrderBy(staff => staff.Order);
            Staffs = orderedStaffs.ToList();
        }



    }
}
       
