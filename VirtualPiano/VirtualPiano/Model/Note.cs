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

namespace VirtualPiano.Model
{
    public enum NoteName { wholeNote, halfNote, quarterNote, eightNote, sixteenthNote, NULL}

    public class Note : Sign
    {
        public String noteName { get; set; }
        public bool IsBeingPlayed;
        public int x { get; set; }
        public int y { get; set; }
        public static bool SoundEnabled = true;

        public string tone { get; set; }
        public int octave { get; set; }
        public Note() : base() { }

        public Note(NoteName notename, string tone, int octave) : base()
        {
            noteName = notename.ToString();
            this.octave = octave;
            this.tone = tone;
            if (noteName == NoteName.wholeNote.ToString()) { image = Resources.helenoot; duration = 16; }  //afbeelding en duratie van noot zetten afhankelijk van naam
            else if (noteName == NoteName.halfNote.ToString()) { image = Resources.halvenoot; duration = 8; }
            else if (noteName == NoteName.quarterNote.ToString()) { image = Resources.kwartnoot; duration = 4; }
            else if (noteName == NoteName.eightNote.ToString()) { image = Resources.achtstenoot; duration = 2; }
            else if (noteName == NoteName.sixteenthNote.ToString()) { image = Resources.zestiendenoot; duration = 1; }
        }

        public override void SetImage()
        {
            
            if (noteName == NoteName.wholeNote.ToString()) { image = Resources.helenoot; duration = 16; }  //afbeelding en duratie van noot zetten afhankelijk van naam
            else if (noteName == NoteName.halfNote.ToString()) { image = Resources.halvenoot; duration = 8;  }
            else if (noteName == NoteName.quarterNote.ToString()) { image = Resources.kwartnoot; duration = 4; }
            else if (noteName == NoteName.eightNote.ToString()) { image = Resources.achtstenoot; duration = 2;  }
            else if (noteName == NoteName.sixteenthNote.ToString()) { image = Resources.zestiendenoot; duration = 1;}
        }

        public Note(int y, NoteName tempNotename, string clef, int Flatsharp) :base()
        {
            noteName = tempNotename.ToString();


            if (clef == ClefName.G.ToString())
            {
                if (y < 23) { tone = "C"; octave = 5; }
                if (y >= 23 && y < 31) { tone = "B"; octave = 4; }
                if (y >= 31 && y < 38) { tone = "A"; octave = 4; }
                if (y >= 38 && y < 46) { tone = "G"; octave = 4; }
                if (y >= 46 && y < 53) { tone = "F"; octave = 4; }
                if (y >= 53 && y < 60) { tone = "E"; octave = 4; }
                if (y >= 60 && y < 68) { tone = "D"; octave = 4; }
                if (y >= 68 && y < 75) { tone = "C"; octave = 4; }
                if (y >= 75  && y < 83) { tone = "B"; octave = 3; }
                if (y >= 83 && y < 91) { tone = "A"; octave = 3; }
                if (y >= 91 && y < 98) { tone = "G"; octave = 3; }
                if (y >= 98 && y < 106 ) { tone = "F"; octave = 3; }
                if (y >= 106 && y < 113) { tone = "E"; octave = 3; }
                if (y >= 113 && y < 121) { tone = "D"; octave = 3; }
                if (y >= 121) { tone = "C"; octave = 3; }
            }
            if (clef == ClefName.F.ToString())
            {
                if (y < 23) { tone = "E"; octave = 3; }
                if (y >= 23 && y < 31) { tone = "D"; octave = 3; }
                if (y >= 31 && y < 38) { tone = "C"; octave = 3; }
                if (y >= 38 && y < 46) { tone = "B"; octave = 2; }
                if (y >= 46 && y < 53) { tone = "A"; octave = 2; }
                if (y >= 53 && y < 60) { tone = "G"; octave = 2; }
                if (y >= 60 && y < 68) { tone = "F"; octave = 2; }
                if (y >= 68 && y < 75) { tone = "E"; octave = 2; }
                if (y >= 75 && y < 83) { tone = "D"; octave = 2; }
                if (y >= 83 && y < 91) { tone = "C"; octave = 2; }
                if (y >= 91 && y < 98) { tone = "B"; octave = 1; }
                if (y >= 98 && y < 106) { tone = "A"; octave = 1; }
                if (y >= 106 && y < 113) { tone = "G"; octave = 1; }
                if (y >= 113 && y < 121) { tone = "F"; octave = 1; }
                if (y >= 121) { tone = "E"; octave = 1; }
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

            if (noteName == NoteName.wholeNote.ToString()) { image = Resources.helenoot; duration = 16; }  //afbeelding en duratie van noot zetten, afhankelijk van naam
            else if (noteName == NoteName.halfNote.ToString()) { if (y <= 53) { image = Resources.halvenootflipped; } else { image = Resources.halvenoot; } duration = 8; }
            else if (noteName == NoteName.quarterNote.ToString()) { if (y <= 53) { image = Resources.kwartnootflipped; } else { image = Resources.kwartnoot; } duration = 4; }
            else if (noteName == NoteName.eightNote.ToString()) { if (y <= 53) { image = Resources.achtstenootflipped; } else { image = Resources.achtstenoot; } duration = 2; }
            else if (noteName == NoteName.sixteenthNote.ToString()) { if (y <= 53) { image = Resources.zestiendenootflipped; } else { image = Resources.zestiendenoot; } duration = 1; }
        }

        public void PlaySound()
        {
            if (SoundEnabled) {
                var player = new System.Windows.Media.MediaPlayer();
                try
                {
                    string filename = (tone).ToString();
                    
                        if (tone == "Bes") { filename = "Ais"; }
                        if (tone == "Des") { filename = "Cis"; }
                        if (tone == "Es") { filename = "Dis"; }
                        if (tone == "Ges") { filename = "Fis"; }
                        if (tone == "As") { filename = "Gis"; }

                    player.Open(new Uri($@"../../Resources/Geluiden/Piano/Piano{octave}{filename}.wav", UriKind.Relative));
                    player.Play();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File not found");
                }
            }
        }

        public void SetX(int x)
        {
            this.x = x + 50;
        }

        public void SetY(string clefname)
        {
            if (clefname == ClefName.G.ToString())
            {
                if ((tone == "C" || tone == "Cis") && octave == 3) y = 59;
                else if ((tone == "D" || tone == "Dis" || tone == "Des") && octave == 3) y = 53;
                else if ((tone == "E" || tone == "Es" )&& octave == 3) y = 45;
                else if ((tone == "F" || tone == "Fis") && octave == 3) y = 38;
                else if ((tone == "G" || tone == "Gis" || tone == "Ges") && octave == 3) y = 31;
                else if ((tone == "A" || tone == "Ais" || tone == "As") && octave == 3) y = 24;
                else if ((tone == "B" || tone == "Bes") && octave == 3) y = 17;
                else if ((tone == "C" || tone == "Cis") && octave == 4) y = 8;
                else if ((tone == "D" || tone == "Dis" || tone == "Des") && octave == 4) y = 1;
                else if ((tone == "E" || tone == "Es" ) && octave == 4) y = -7;
                else if ((tone == "F" || tone == "Fis") && octave == 4) y = -15;
                else if ((tone == "G" || tone == "Gis" || tone == "Ges") && octave == 4) y = -21;
                else if ((tone == "A" || tone == "Ais" || tone == "As") && octave == 4) y = -28;
                else if ((tone == "B" || tone == "Bes") && octave == 4) y = -36;
                else if ((tone == "C" || tone == "Cis") && octave == 5) y = -43;
            }

            if (clefname == ClefName.F.ToString())
            {
                if ((tone == "E" || tone == "Es") && octave == 1) y =  60;
                else if ((tone == "F" || tone == "Fis") && octave == 1) y =  53;
                else if ((tone == "G" || tone == "Gis" || tone == "Ges") && octave == 1) y =  45;
                else if ((tone == "A" || tone == "Ais" || tone == "As") && octave == 1) y =  38;
                else if ((tone == "B" || tone == "Bes") && octave == 1) y =  31;
                else if ((tone == "C" || tone == "Cis") && octave == 2) y =  24;
                else if ((tone == "D" || tone == "Dis" || tone == "Des") && octave == 2) y =  17;
                else if ((tone == "E" || tone == "Es") && octave == 2) y =  8;
                else if ((tone == "F" || tone == "Fis") && octave == 2) y =  1;
                else if ((tone == "G" || tone == "Gis" || tone == "Ges") && octave == 2) y =  -7;
                else if ((tone == "A" || tone == "Ais" || tone == "As") && octave == 2) y =  -15;
                else if ((tone == "B" || tone == "Bes") && octave == 2) y =  -21;
                else if ((tone == "C" || tone == "Cis") && octave == 3) y = -27;
                else if ((tone == "D" || tone == "Dis" || tone == "Des") && octave == 3) y = -34;
                else if ((tone == "E" || tone == "Es") && octave == 3) y = -41;
            }
        }
    }
}
