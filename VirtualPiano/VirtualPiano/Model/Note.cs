using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using VirtualPiano.Properties;
using VirtualPiano.View;
using VirtualPiano.Control;

namespace VirtualPiano.Model
{

    public class Note : Sign
    {
        public string Tone { get; set; }
        public int Octave { get; set; }
        public bool Sharp { get; set; }
        public bool Flat { get; set; }
        public bool Flipped { get; set; }
        public Note ConnectionNote = null;
        public bool IsBeingPlayed;
        public bool isBeingMoved = false;
        
        public Note() : base() { }

        public Note(string tone, int octave)
        {
            this.Tone = tone;
            this.Octave = octave;
        }

        public Note(int x, int y, string tempNotename, string clef, int Flatsharp) :base()
        {
            Flipped = false;
            Name = tempNotename;
            X = x + 25;

            if (clef == "G")
            {
                if (y < 23) { Tone = "C"; Octave = 5; this.Y = -43; }
                else if (y >= 23 && y < 31) { Tone = "B"; Octave = 4; this.Y = -36; }
                else if (y >= 31 && y < 38) { Tone = "A"; Octave = 4; this.Y = -28; }
                else if (y >= 38 && y < 46) { Tone = "G"; Octave = 4; this.Y = -21; }
                else if (y >= 46 && y < 53) { Tone = "F"; Octave = 4; this.Y = -15; }
                else if (y >= 53 && y < 60) { Tone = "E"; Octave = 4; this.Y = -7; }
                else if (y >= 60 && y < 68) { Tone = "D"; Octave = 4; this.Y = 1;  }
                else if (y >= 68 && y < 75) { Tone = "C"; Octave = 4; this.Y = 8; }
                else if (y >= 75  && y < 83) { Tone = "B"; Octave = 3; this.Y = 17; }
                else if (y >= 83 && y < 91) { Tone = "A"; Octave = 3; this.Y = 24; }
                else if (y >= 91 && y < 98) { Tone = "G"; Octave = 3; this.Y = 31;  }
                else if (y >= 98 && y < 106 ) { Tone = "F"; Octave = 3; this.Y = 38; }
                else if (y >= 106 && y < 113) { Tone = "E"; Octave = 3; this.Y = 45; }
                else if (y >= 113 && y < 121) { Tone = "D"; Octave = 3; this.Y = 53; }
                else if (y >= 121) { Tone = "C"; Octave = 3; this.Y = 59; }
            }
            else if (clef == "F")
            {
                if (y < 23) { Tone = "E"; Octave = 3; this.Y = -41 ; }
                else if (y >= 23 && y < 31) { Tone = "D"; Octave = 3; this.Y = -34; }
                else if (y >= 31 && y < 38) { Tone = "C"; Octave = 3; this.Y =  -27; }
                else if (y >= 38 && y < 46) { Tone = "B"; Octave = 2; this.Y = -21 ; }
                else if (y >= 46 && y < 53) { Tone = "A"; Octave = 2; this.Y = -15; }
                else if (y >= 53 && y < 60) { Tone = "G"; Octave = 2; this.Y = -7; }
                else if (y >= 60 && y < 68) { Tone = "F"; Octave = 2; this.Y = 1; }
                else if (y >= 68 && y < 75) { Tone = "E"; Octave = 2; this.Y = 8; }
                else if (y >= 75 && y < 83) { Tone = "D"; Octave = 2; this.Y = 17; }
                else if (y >= 83 && y < 91) { Tone = "C"; Octave = 2; this.Y = 24; }
                else if (y >= 91 && y < 98) { Tone = "B"; Octave = 1; this.Y = 31; }
                else if (y >= 98 && y < 106) { Tone = "A"; Octave = 1; this.Y = 38; }
                else if (y >= 106 && y < 113) { Tone = "G"; Octave = 1; this.Y = 45; }
                else if (y >= 113 && y < 121) { Tone = "F"; Octave = 1; this.Y = 53; }
                else if (y >= 121) { Tone = "E"; Octave = 1; this.Y = 59; }
            }

            if (Flatsharp >= 1) { if (Tone == "F") { Tone = "Fis"; } }
            if (Flatsharp >= 2) { if (Tone == "C") { Tone = "Cis"; } }
            if (Flatsharp >= 3) { if (Tone == "G") { Tone = "Gis"; } }
            if (Flatsharp >= 4) { if (Tone == "D") { Tone = "Dis"; } }
            if (Flatsharp >= 5) { if (Tone == "A") { Tone = "Ais"; } }

            if (Flatsharp <= -1) { if (Tone == "B") { Tone = "Bes"; } }
            if (Flatsharp <= -2) { if (Tone == "E") { Tone = "Es"; } }
            if (Flatsharp <= -3) { if (Tone == "A") { Tone = "As"; } }
            if (Flatsharp <= -4) { if (Tone == "D") { Tone = "Des"; } }
            if (Flatsharp <= -5) { if (Tone == "G") { Tone = "Ges"; } }

            SetImage();
        }


        public void PlaySound()
        {
            string pitchName = Tone.ToString() + Octave.ToString();
            if (pitchName.Contains("is"))
            {
                Enum.TryParse(Tone.First().ToString() + "Sharp" + Octave.ToString(), out Pitch pitch);
                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
            } else if (pitchName.Contains("As"))
            {
                Enum.TryParse("GSharp" + Octave.ToString(), out Pitch pitch);
                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
            }
            else if (pitchName.Contains("Bes"))
            {
                Enum.TryParse("ASharp" + Octave.ToString(), out Pitch pitch);
                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
            }
            else if (pitchName.Contains("Des"))
            {
                Enum.TryParse("CSharp" + Octave.ToString(), out Pitch pitch);
                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
            }
            else if (pitchName.Contains("Es"))
            {
                Enum.TryParse("DSharp" + Octave.ToString(), out Pitch pitch);
                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
            }
            else if (pitchName.Contains("Ges"))
            {
                Enum.TryParse("FSharp" + Octave.ToString(), out Pitch pitch);
                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
            }
            else
            {
                Enum.TryParse(pitchName, out Pitch pitch);
                MusicController.outputDevice.SendNoteOn(Channel.Channel1, pitch, 127);
            }

        }

        public override bool IsLocation(int MouseX, int MouseY)
        {
            return (X + 35 < MouseX && X + 55 > MouseX && Y - 10 < MouseY - 63 && Y + 10 > MouseY - 63);
        }

        public bool IsLocation(int MouseX)
        {
            return (X + 35 < MouseX && X + 55 > MouseX);
        }

        public void SetSharp()
        {
            Sharp = true;
            Flat = false;
            if (Tone == "F" || Tone == "Fes") { Tone = "Fis"; } 
            if (Tone == "C") { Tone = "Cis"; } 
            if (Tone == "G" || Tone == "Ges") { Tone = "Gis"; } 
            if (Tone == "D" || Tone == "Des") { Tone = "Dis"; } 
            if (Tone == "A" || Tone == "As") { Tone = "Ais"; }
            
            
        }

        public void SetFlat()
        {
            Sharp = false;
            Flat = true;
            if (Tone == "B") { Tone = "Bes"; } 
            if (Tone == "E") { Tone = "Es"; } 
            if (Tone == "A" || Tone == "Ais") { Tone = "As"; } 
            if (Tone == "D" || Tone == "Dis") { Tone = "Des"; } 
            if (Tone == "G" || Tone == "Gis") { Tone = "Ges"; } 
        }

        public void SetNatural()
        {
            Sharp = false;
            Flat = false;
            if (Tone == "As" || Tone == "Ais") { Tone = "A"; }
            if (Tone == "Bes") { Tone = "B"; }
            if (Tone == "Cis") { Tone = "C"; }
            if (Tone == "Dis" || Tone == "Des") { Tone = "D"; }
            if (Tone == "Es") { Tone = "E"; }
            if (Tone == "Fis") { Tone = "F"; }
            if (Tone == "Gis" || Tone == "Ges") { Tone = "G"; }
        }

        public bool CheckConnect()
        {
            return ConnectionNote == null && (Name == "EightNote" || Name == "SixteenthNote");
        }

        public override void SetImage()
        {
            if (ConnectionNote != null) { Image = Resources.kwartnoot; }
            else if (Name == "WholeNote") { Image = Resources.helenoot; Duration = 16; }  //afbeelding en duratie van noot zetten, afhankelijk van naam
            else if (Name == "HalfNote") { if (Y <= 0) { Image = Resources.halvenootflipped; } else { Image = Resources.halvenoot; } Duration = 8; }
            else if (Name == "QuarterNote") { if (Y <= 0) { Image = Resources.kwartnootflipped; } else { Image = Resources.kwartnoot; } Duration = 4; }
            else if (Name == "EightNote") { if (Y <= 0) { Image = Resources.achtstenootflipped; } else { Image = Resources.achtstenoot; } Duration = 2; }
            else if (Name == "SixteenthNote") { if (Y <= 0) { Image = Resources.zestiendenootflipped; } else { Image = Resources.zestiendenoot; } Duration = 1; }
            if (Flipped)
            {
                Flip();
            } 
        }

        internal void MakeConnection(Note note2)
        {
            Image = Resources.kwartnoot;
            note2.Image = Resources.kwartnoot;
            ConnectionNote = note2;
            note2.ConnectionNote = this;
            ComposeView.selectedNote1 = null;
            ComposeView.selectedNote2 = null;
        }

        public void Flip()
        {
            if (Name == "WholeNote") { Image = Resources.helenoot;} 
            else if (Name == "HalfNote") { Image = Resources.halvenootflipped; }
            else if (Name == "QuarterNote") { Image = Resources.kwartnootflipped; }
            else if (Name == "EightNote") { Image = Resources.achtstenootflipped; }
            else if (Name == "SixteenthNote") {Image = Resources.zestiendenootflipped; }
            Flipped = true;
        }
        public void Unflip()
        {
            if (Name == "WholeNote") { Image = Resources.helenoot; }
            else if (Name == "HalfNote") { Image = Resources.halvenoot; }
            else if (Name == "QuarterNote") { Image = Resources.kwartnoot; }
            else if (Name == "EightNote") { Image = Resources.achtstenoot; }
            else if (Name == "SixteenthNote") { Image = Resources.zestiendenoot; }
            Flipped = false;
        }
    }
}
