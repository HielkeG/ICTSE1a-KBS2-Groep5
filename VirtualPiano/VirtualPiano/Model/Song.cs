﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public  int FlatSharp = 0;
        private string title = "titel";
        public string Title
        {
            get
            {
                if(title != "")
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

            if (MusicController.isGestart)
            {
                if (ComposeView.instrument == "Piano")
                {
                    MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.AcousticGrandPiano);
                }
                else if (ComposeView.instrument == "Guitar")
                {
                    MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.AcousticGuitarSteel);
                }
                else if (ComposeView.instrument == "Marimba")
                {
                    MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.Xylophone);
                }
                else
                {
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
                            if (sign is Note note && note.x >= ComposeView.RedLineX + 63 && note.x <= ComposeView.RedLineX + 67)
                            {
                                //toetsenbordkey op laten lichten
                                ComposeView.pkv1.KeyPressed(note.octave, note.tone);
                                ComposeView.pkv1.Invalidate();
                                //note.PlaySound();
                                string pitchTemp = note.tone.ToString() + note.octave.ToString();                                
                                Enum.TryParse(pitchTemp, out Pitch pitch);

                                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                await PutTaskDelay(75);
                                //outputDevice.SendNoteOff(Channel.Channel1, pitch, 127);
                                ComposeView.pkv1.KeyReleased(note.octave, note.tone);
                                ComposeView.pkv1.Invalidate();
                                break;
                            }
                        }
                    }
                    else if(ComposeView.RedLineX > 425 && ComposeView.RedLineX <= 850)
                    {
                        foreach (var sign in staff.Bars.ElementAt(1).Signs)
                        {
                            if (sign is Note note && note.x >= ComposeView.RedLineX + 63 && note.x <= ComposeView.RedLineX + 67)
                            {
                                //toetsenbordkey op laten lichten

                                ComposeView.pkv1.KeyPressed(note.octave, note.tone);
                                ComposeView.pkv1.Invalidate();
                                //note.PlaySound();
                                string pitchTemp = note.tone.ToString() + note.octave.ToString();
                                Enum.TryParse(pitchTemp, out Pitch pitch);
                                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                await PutTaskDelay(75);
                                ComposeView.pkv1.KeyReleased(note.octave, note.tone);
                                ComposeView.pkv1.Invalidate();
                                break;
                            }
                        }
                    }
                    else if (ComposeView.RedLineX > 850 && ComposeView.RedLineX <= 1275)
                    {
                        foreach (var sign in staff.Bars.ElementAt(2).Signs)
                        {
                            if (sign is Note note && note.x >= ComposeView.RedLineX + 63 && note.x <= ComposeView.RedLineX + 67)
                            {
                                //toetsenbordkey op laten lichten

                                ComposeView.pkv1.KeyPressed(note.octave, note.tone);
                                ComposeView.pkv1.Invalidate();
                                //note.PlaySound();
                                string pitchTemp = note.tone.ToString() + note.octave.ToString();
                                Enum.TryParse(pitchTemp, out Pitch pitch);
                                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                await PutTaskDelay(75);
                                ComposeView.pkv1.KeyReleased(note.octave, note.tone);
                                ComposeView.pkv1.Invalidate();
                                break;
                            }
                        }
                    }
                    else if (ComposeView.RedLineX > 1275)
                    {
                        foreach (var sign in staff.Bars.ElementAt(3).Signs)
                        {
                            if (sign is Note note && note.x >= ComposeView.RedLineX + 63 && note.x <= ComposeView.RedLineX + 67)
                            {
                                //toetsenbordkey op laten lichten

                                ComposeView.pkv1.KeyPressed(note.octave, note.tone);
                                ComposeView.pkv1.Invalidate();
                                //note.PlaySound();
                                string pitchTemp = note.tone.ToString() + note.octave.ToString();
                                Enum.TryParse(pitchTemp, out Pitch pitch);
                                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
                                await PutTaskDelay(75);
                                ComposeView.pkv1.KeyReleased(note.octave, note.tone);
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
            foreach(Staff staff in Staffs)
            {
                foreach (Bar bar in staff.Bars)
                {
                    foreach (Sign sign in bar.Signs)
                    {
                        if (sign is Note note)
                        {
                            if (note.flat == false && note.sharp == false)
                            {
                                if (note.tone == "Fis") { note.tone = "F"; }
                                if (note.tone == "Cis") { note.tone = "C"; }
                                if (note.tone == "Gis") { note.tone = "G"; }
                                if (note.tone == "Dis") { note.tone = "D"; }
                                if (note.tone == "Ais") { note.tone = "A"; }
                                if (note.tone == "Bes") { note.tone = "B"; }
                                if (note.tone == "Es") { note.tone = "E"; }
                                if (note.tone == "As") { note.tone = "A"; }
                                if (note.tone == "Des") { note.tone = "D"; }
                                if (note.tone == "Ges") { note.tone = "G"; }


                                if (Flatsharp >= 1) { if (note.tone == "F") { note.tone = "Fis"; } }
                                if (Flatsharp >= 2) { if (note.tone == "C") { note.tone = "Cis"; } }
                                if (Flatsharp >= 3) { if (note.tone == "G") { note.tone = "Gis"; } }
                                if (Flatsharp >= 4) { if (note.tone == "D") { note.tone = "Dis"; } }
                                if (Flatsharp >= 5) { if (note.tone == "A") { note.tone = "Ais"; } }

                                if (Flatsharp <= -1) { if (note.tone == "B") { note.tone = "Bes"; } }
                                if (Flatsharp <= -2) { if (note.tone == "E") { note.tone = "Es"; } }
                                if (Flatsharp <= -3) { if (note.tone == "A") { note.tone = "As"; } }
                                if (Flatsharp <= -4) { if (note.tone == "D") { note.tone = "Des"; } }
                                if (Flatsharp <= -5) { if (note.tone == "G") { note.tone = "Ges"; } }
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
                    IEnumerable<Sign> signs = bar.Signs.OrderBy(sign => sign.x);
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
