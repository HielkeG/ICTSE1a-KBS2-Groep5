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
        public int FlatSharp { get; set; } = 0;
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

            if (Flatsharp >= 1) { if (tone == "F") { FlatSharp = 1; } }
            if (Flatsharp >= 2) { if (tone == "C") { FlatSharp = 1; } }
            if (Flatsharp >= 3) { if (tone == "G") { FlatSharp = 1; } }
            if (Flatsharp >= 4) { if (tone == "D") { FlatSharp = 1; } }
            if (Flatsharp >= 5) { if (tone == "A") { FlatSharp = 1; } }

            if (Flatsharp <= -1) { if (tone == "B") { FlatSharp = -1; } }
            if (Flatsharp <= -2) { if (tone == "E") { FlatSharp = -1; } }
            if (Flatsharp <= -3) { if (tone == "A") { FlatSharp = -1; } }
            if (Flatsharp <= -4) { if (tone == "D") { FlatSharp = -1; } }
            if (Flatsharp <= -5) { if (tone == "G") { FlatSharp = -1; } }

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
                    if (FlatSharp == 1)
                    {
                        if (tone == "A") { filename = "Ais"; }
                        if (tone == "B") { filename = "C"; }
                        if (tone == "C") { filename = "Cis"; }
                        if (tone == "D") { filename = "Dis"; }
                        if (tone == "E") { filename = "F"; }
                        if (tone == "F") { filename = "Fis"; }
                        if (tone == "G") { filename = "Gis"; }
                    }
                    if (FlatSharp == -1)
                    {
                        if (tone == "A") { filename = "Gis"; }
                        if (tone == "B") { filename = "Ais"; }
                        if (tone == "C") { filename = "B"; }
                        if (tone == "D") { filename = "Cis"; }
                        if (tone == "E") { filename = "Dis"; }
                        if (tone == "F") { filename = "E"; }
                        if (tone == "G") { filename = "Fis"; }
                    }
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
                if (tone == "C" && octave == 3) y = 60;
                else if (tone == "D" && octave == 3) y = 53;
                else if (tone == "E" && octave == 3) y = 45;
                else if (tone == "F" && octave == 3) y = 38;
                else if (tone == "G" && octave == 3) y = 31;
                else if (tone == "A" && octave == 3) y = 24;
                else if (tone == "B" && octave == 3) y = 17;
                else if (tone == "C" && octave == 4) y = 8;
                else if (tone == "D" && octave == 4) y = 1;
                else if (tone == "E" && octave == 4) y = -7;
                else if (tone == "F" && octave == 4) y = -15;
                else if (tone == "G" && octave == 4) y = -21;
                else if (tone == "A" && octave == 4) y = -27;
                else if (tone == "B" && octave == 4) y = -34;
                else if (tone == "C" && octave == 5) y = -41;
            }

            if (clefname == ClefName.F.ToString())
            {
                if (tone == "E" && octave == 1) y =  60;
                else if (tone == "F" && octave == 1) y =  53;
                else if (tone == "G" && octave == 1) y =  45;
                else if (tone == "A" && octave == 1) y =  38;
                else if (tone == "B" && octave == 1) y =  31;
                else if (tone == "C" && octave == 2) y =  24;
                else if (tone == "D" && octave == 2) y =  17;
                else if (tone == "E" && octave == 2) y =  8;
                else if (tone == "F" && octave == 2) y =  1;
                else if (tone == "G" && octave == 2) y =  -7;
                else if (tone == "A" && octave == 2) y =  -15;
                else if (tone == "B" && octave == 2) y =  -21;
                else if (tone == "C" && octave == 3) y = -27;
                else if (tone == "D" && octave == 3) y = -34;
                else if (tone == "E" && octave == 3) y = -41;
            }
        }
    }
}
