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
        public int FlatSharp {get; set;}
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
            FlatSharp = 0;

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
                    MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.Banjo);
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
            int Duration = 0;
            foreach (Staff staff in Staffs)
            {
                foreach (Bar bar in staff.Bars)
                {
                    Duration = Duration + bar.Duration;
                }
            }
            return Duration; // 1 volle maat is 16
        }


        public async void PlayNote()
        {
            try
            {
                foreach (var staff in Staffs)
                {
                    if (staff.IsBeingPlayed)
                    {
                        List<Note> keyNotes = new List<Note>();
                        foreach (Bar bar in staff.Bars)
                        {
                            foreach (Sign sign in bar.Signs)
                            {
                                //Als de rode lijn een noot raakt
                                if (sign is Note note && note.X >= ComposeView.RedLineX + 63 && note.X <= ComposeView.RedLineX + 66)
                                {
                                    //Pianotoets oplichten
                                    keyNotes.Add(note);
                                    ComposeView.pkv1.KeyPressed(note.Octave, note.Tone);
                                    ComposeView.pkv1.Invalidate();

                                    //Noot afspelen
                                    string pitchTemp = note.Tone.ToString() + note.Octave.ToString();
                                    if (pitchTemp.Contains("is") && ComposeView.SoundEnabled)
                                    {
                                        Enum.TryParse(note.Tone.First().ToString() + "Sharp" + note.Octave.ToString(), out Pitch pitch);
                                        MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                    }
                                    else if (pitchTemp.Contains("As") && ComposeView.SoundEnabled)
                                    {
                                        Enum.TryParse("GSharp" + note.Octave.ToString(), out Pitch pitch);
                                        MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                    }
                                    else if (pitchTemp.Contains("Bes") && ComposeView.SoundEnabled)
                                    {
                                        Enum.TryParse("ASharp" + note.Octave.ToString(), out Pitch pitch);
                                        MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                    }
                                    else if (pitchTemp.Contains("Des") && ComposeView.SoundEnabled)
                                    {
                                        Enum.TryParse("CSharp" + note.Octave.ToString(), out Pitch pitch);
                                        MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                    }
                                    else if (pitchTemp.Contains("Es") && ComposeView.SoundEnabled)
                                    {
                                        Enum.TryParse("DSharp" + note.Octave.ToString(), out Pitch pitch);
                                        MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                    }
                                    else if (pitchTemp.Contains("Gs") && ComposeView.SoundEnabled)
                                    {
                                        Enum.TryParse("FSharp" + note.Octave.ToString(), out Pitch pitch);
                                        MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                    }
                                    else if(ComposeView.SoundEnabled)
                                    {
                                        Enum.TryParse(pitchTemp, out Pitch pitch);
                                        MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                    }
                                }
                            }
                        }
                        await PutTaskDelay(200);
                        foreach (Note note in keyNotes)
                        {
                            //Pianotoetsen niet meer oplichten
                            ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                            ComposeView.pkv1.Invalidate();
                        }
                    }
                }
            }
            catch (Exception){ }
        }

        public void SetSharpFlat()
        {
            foreach (Staff staff in Staffs)
            {
                foreach (Bar bar in staff.Bars)
                {
                    foreach (Sign sign in bar.Signs)
                    {
                        if (sign is Note note)
                        {
                            if (note.Flat == false && note.Sharp == false)
                            {
                                //Alle tonen naar de stamtoon zetten
                                if (note.Tone == "Fis") { note.Tone = "F"; }
                                else if (note.Tone == "Cis") { note.Tone = "C"; }
                                else if (note.Tone == "Gis") { note.Tone = "G"; }
                                else if (note.Tone == "Dis") { note.Tone = "D"; }
                                else if (note.Tone == "Ais") { note.Tone = "A"; }
                                else if (note.Tone == "Bes") { note.Tone = "B"; }
                                else if (note.Tone == "Es") { note.Tone = "E"; }
                                else if (note.Tone == "As") { note.Tone = "A"; }
                                else if (note.Tone == "Des") { note.Tone = "D"; }
                                else if (note.Tone == "Ges") { note.Tone = "G"; }

                                //Afhankelijk van het aantal kruizen/mollen de toon verhogen
                                if (FlatSharp >= 1) { if (note.Tone == "F") { note.Tone = "Fis"; } }
                                if (FlatSharp >= 2) { if (note.Tone == "C") { note.Tone = "Cis"; } }
                                if (FlatSharp >= 3) { if (note.Tone == "G") { note.Tone = "Gis"; } }
                                if (FlatSharp >= 4) { if (note.Tone == "D") { note.Tone = "Dis"; } }
                                if (FlatSharp >= 5) { if (note.Tone == "A") { note.Tone = "Ais"; } }

                                if (FlatSharp <= -1) { if (note.Tone == "B") { note.Tone = "Bes"; } }
                                if (FlatSharp <= -2) { if (note.Tone == "E") { note.Tone = "Es"; } }
                                if (FlatSharp <= -3) { if (note.Tone == "A") { note.Tone = "As"; } }
                                if (FlatSharp <= -4) { if (note.Tone == "D") { note.Tone = "Des"; } }
                                if (FlatSharp <= -5) { if (note.Tone == "G") { note.Tone = "Ges"; } }
                            }
                        }
                    }
                }
            }
        }

        //Deze methode zorgt voor een wachttijd tijdens een methode, de rest van de applicatie gaat wel gewoon door
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
