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

namespace VirtualPiano.Model
{
    public enum NoteName {NULL, WholeNote, HalfNote, QuarterNote, EightNote, SixteenthNote}

    public class Note : Sign
    {
        public string tone { get; set; }
        public int octave { get; set; }
        public bool sharp;
        public bool flat;
        public Note ConnectionNote = null;
        public bool IsBeingPlayed;
        public static bool SoundEnabled = true;

        
        public Note() : base() { }

        public Note(NoteName notename, string tone, int octave) : base()
        {
            name = notename.ToString();
            this.octave = octave;
            this.tone = tone;
            if (name == NoteName.WholeNote.ToString()) { image = Resources.helenoot; duration = 16; }  //afbeelding en duratie van noot zetten afhankelijk van naam
            else if (name == NoteName.HalfNote.ToString()) { image = Resources.halvenoot; duration = 8; }
            else if (name == NoteName.QuarterNote.ToString()) { image = Resources.kwartnoot; duration = 4; }
            else if (name == NoteName.EightNote.ToString()) { image = Resources.achtstenoot; duration = 2; }
            else if (name == NoteName.SixteenthNote.ToString()) { image = Resources.zestiendenoot; duration = 1; }
        }

        public override void SetImage()
        {
            
            if (name == NoteName.WholeNote.ToString()) { image = Resources.helenoot; duration = 16; }  //afbeelding en duratie van noot zetten afhankelijk van naam
            else if (name == NoteName.HalfNote.ToString()) { image = Resources.halvenoot; duration = 8;  }
            else if (name == NoteName.QuarterNote.ToString()) { image = Resources.kwartnoot; duration = 4; }
            else if (name == NoteName.EightNote.ToString()) { image = Resources.achtstenoot; duration = 2;  }
            else if (name == NoteName.SixteenthNote.ToString()) { image = Resources.zestiendenoot; duration = 1;}
        }

        public Note(int y, NoteName tempNotename, string clef, int Flatsharp) :base()
        {
            name = tempNotename.ToString();


            if (clef == ClefName.G.ToString())
            {
                if (y < 23) { tone = "C"; octave = 5; this.y = -43; }
                else if (y >= 23 && y < 31) { tone = "B"; octave = 4; this.y = -36; }
                else if (y >= 31 && y < 38) { tone = "A"; octave = 4; this.y = -28; }
                else if (y >= 38 && y < 46) { tone = "G"; octave = 4; this.y = -21; }
                else if (y >= 46 && y < 53) { tone = "F"; octave = 4; this.y = -15; }
                else if (y >= 53 && y < 60) { tone = "E"; octave = 4; this.y = -7; }
                else if (y >= 60 && y < 68) { tone = "D"; octave = 4; this.y = 1;  }
                else if (y >= 68 && y < 75) { tone = "C"; octave = 4; this.y = 8; }
                else if (y >= 75  && y < 83) { tone = "B"; octave = 3; this.y = 17; }
                else if (y >= 83 && y < 91) { tone = "A"; octave = 3; this.y = 24; }
                else if (y >= 91 && y < 98) { tone = "G"; octave = 3; this.y = 31;  }
                else if (y >= 98 && y < 106 ) { tone = "F"; octave = 3; this.y = 38; }
                else if (y >= 106 && y < 113) { tone = "E"; octave = 3; this.y = 45; }
                else if (y >= 113 && y < 121) { tone = "D"; octave = 3; this.y = 53; }
                else if (y >= 121) { tone = "C"; octave = 3; this.y = 59; }
            }
            else if (clef == ClefName.F.ToString())
            {
                if (y < 23) { tone = "E"; octave = 3; this.y = -41 ; }
                else if (y >= 23 && y < 31) { tone = "D"; octave = 3; this.y = -34; }
                else if (y >= 31 && y < 38) { tone = "C"; octave = 3; this.y =  -27; }
                else if (y >= 38 && y < 46) { tone = "B"; octave = 2; this.y = -21 ; }
                else if (y >= 46 && y < 53) { tone = "A"; octave = 2; this.y = -15; }
                else if (y >= 53 && y < 60) { tone = "G"; octave = 2; this.y = -7; }
                else if (y >= 60 && y < 68) { tone = "F"; octave = 2; this.y = 1; }
                else if (y >= 68 && y < 75) { tone = "E"; octave = 2; this.y = 8; }
                else if (y >= 75 && y < 83) { tone = "D"; octave = 2; this.y = 17; }
                else if (y >= 83 && y < 91) { tone = "C"; octave = 2; this.y = 24; }
                else if (y >= 91 && y < 98) { tone = "B"; octave = 1; this.y = 31; }
                else if (y >= 98 && y < 106) { tone = "A"; octave = 1; this.y = 38; }
                else if (y >= 106 && y < 113) { tone = "G"; octave = 1; this.y = 45; }
                else if (y >= 113 && y < 121) { tone = "F"; octave = 1; this.y = 53; }
                else if (y >= 121) { tone = "E"; octave = 1; this.y = 59; }
            }

            if (Flatsharp >= 1) { if (tone == "F") { tone = "Fis"; } }
            if (Flatsharp >= 2) { if (tone == "C") { tone = "Cis"; } }
            if (Flatsharp >= 3) { if (tone == "G") { tone = "Gis"; } }
            if (Flatsharp >= 4) { if (tone == "D") { tone = "Dis"; } }
            if (Flatsharp >= 5) { if (tone == "A") { tone = "Ais"; } }

            if (Flatsharp <= -1) { if (tone == "B") { tone = "Bes"; } }
            if (Flatsharp <= -2) { if (tone == "E") { tone = "Es"; } }
            if (Flatsharp <= -3) { if (tone == "A") { tone = "As"; } }
            if (Flatsharp <= -4) { if (tone == "D") { tone = "Des"; } }
            if (Flatsharp <= -5) { if (tone == "G") { tone = "Ges"; } }

            if (name == NoteName.WholeNote.ToString()) { image = Resources.helenoot; duration = 16; }  //afbeelding en duratie van noot zetten, afhankelijk van naam
            else if (name == NoteName.HalfNote.ToString()) { if (y <= 52) { image = Resources.halvenootflipped; } else { image = Resources.halvenoot; } duration = 8; }
            else if (name == NoteName.QuarterNote.ToString()) { if (y <= 52) { image = Resources.kwartnootflipped; } else { image = Resources.kwartnoot; } duration = 4; }
            else if (name == NoteName.EightNote.ToString()) { if (y <= 52) { image = Resources.achtstenootflipped; } else { image = Resources.achtstenoot; } duration = 2; }
            else if (name == NoteName.SixteenthNote.ToString()) { if (y <= 52) { image = Resources.zestiendenootflipped; } else { image = Resources.zestiendenoot; } duration = 1; }
        }

        public void PlaySound()
        {
            if (SoundEnabled) {
                var player = new System.Windows.Media.MediaPlayer();
                try
                {
                    string filename = (tone).ToString();
                    
                        if (tone == "Bes") { filename = "Ais"; }
                        else if (tone == "Des") { filename = "Cis"; }
                        else if (tone == "Es") { filename = "Dis"; }
                        else if (tone == "Ges") { filename = "Fis"; }
                        else if (tone == "As") { filename = "Gis"; }

                    player.Open(new Uri($@"../../Resources/Geluiden/{ComposeView.instrument}/{octave}{filename}.wav", UriKind.Relative));
                    player.Play();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
            }
        }

        public override bool IsLocation(int y, int x)
        {
            return (this.x - 10 < x && this.x + 10 > x && this.y - 10 < y - 63 && this.y + 10 > y - 63);
        }

        public void SetX(int x)
        {
            this.x = x + 50;
        }

        public void SetSharp()
        {
            sharp = true;
            flat = false;
            { if (tone == "F" || tone == "Fes") { tone = "Fis"; } }
            { if (tone == "C") { tone = "Cis"; } }
            { if (tone == "G" || tone == "Ges") { tone = "Gis"; } }
            { if (tone == "D" || tone == "Des") { tone = "Dis"; } }
            { if (tone == "A" || tone == "As") { tone = "Ais"; } }

            
        }

        public void SetFlat()
        {
            sharp = false;
            flat = true;
            { if (tone == "B") { tone = "Bes"; } }
            { if (tone == "E") { tone = "Es"; } }
            { if (tone == "A" || tone == "Ais") { tone = "As"; } }
            { if (tone == "D" || tone == "Dis") { tone = "Des"; } }
            { if (tone == "G" || tone == "Gis") { tone = "Ges"; } }
        }
    }
}
