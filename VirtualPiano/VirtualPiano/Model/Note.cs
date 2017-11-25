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
        public String noteName;
        public bool IsBeingPlayed;
        public int FlatSharp = 0;
        public int x;
        public int y;
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

        public Note(int y, NoteName tempNotename, ClefName clef, int Flatsharp)
        {
           
            noteName = tempNotename;


            if (clef == ClefName.G)
            {
                

                if (y < 16 && y >= 8) { tone = 'A'; octave = 4; }
                if (y < 25 && y >= 16) { tone = 'G'; octave = 4; }
                if (y < 33 && y >= 25) { tone = 'F'; octave = 4; }
                if (y < 41 && y >= 33) { tone = 'E'; octave = 4; }
                if (y < 48 && y >= 41) { tone = 'D'; octave = 4; }
                if (y < 55 && y >= 48) { tone = 'C'; octave = 4; }
                if (y < 63 && y >= 55) { tone = 'B'; octave = 3; }
                if (y < 72 && y >= 63) { tone = 'A'; octave = 3; }
                if (y < 78 && y >= 72) { tone = 'G'; octave = 3; }
                if (y < 86 && y >= 78) { tone = 'F'; octave = 3; }
                if (y < 94 && y >= 86) { tone = 'E'; octave = 3; }
                if (y < 100 && y >= 94) { tone = 'D'; octave = 3; }
                if (y < 107 && y >= 100) { tone = 'C'; octave = 3; }

            }
            if (clef == ClefName.F)
            {
                if (y < 16 && y >= 8) { tone = 'C'; octave = 3; }
                if (y < 25 && y >= 16) { tone = 'B'; octave = 2; }
                if (y < 33 && y >= 25) { tone = 'A'; octave = 2; }
                if (y < 41 && y >= 33) { tone = 'G'; octave = 2; }
                if (y < 48 && y >= 41) { tone = 'F'; octave = 2; }
                if (y < 55 && y >= 48) { tone = 'E'; octave = 2; }
                if (y < 63 && y >= 55) { tone = 'D'; octave = 2; }
                if (y < 72 && y >= 63) { tone = 'C'; octave = 2; }
                if (y < 78 && y >= 72) { tone = 'B'; octave = 1; }
                if (y < 86 && y >= 78) { tone = 'A'; octave = 1; }
                if (y < 94 && y >= 86) { tone = 'G'; octave = 1; }
                if (y < 100 && y >= 94) { tone = 'F'; octave = 1; }
                if (y < 107 && y >= 100) { tone = 'E'; octave = 1; }

                
                
            }
            if (Flatsharp >= 1) { if (tone == 'F') { FlatSharp = 1; } }
            if (Flatsharp >= 2) { if (tone == 'C') { FlatSharp = 1; } }
            if (Flatsharp >= 3) { if (tone == 'G') { FlatSharp = 1; } }
            if (Flatsharp >= 4) { if (tone == 'D') { FlatSharp = 1; } }
            if (Flatsharp >= 5) { if (tone == 'A') { FlatSharp = 1; } }
            if (Flatsharp >= 6) { if (tone == 'E') { FlatSharp = 1; } }
            if (Flatsharp >= 7) { if (tone == 'B') { FlatSharp = 1; } }

            if (Flatsharp <= -1) { if (tone == 'B') { FlatSharp = -1; } }
            if (Flatsharp <= -2) { if (tone == 'E') { FlatSharp = -1; } }
            if (Flatsharp <= -3) { if (tone == 'A') { FlatSharp = -1; } }
            if (Flatsharp <= -4) { if (tone == 'D') { FlatSharp = -1; } }
            if (Flatsharp <= -5) { if (tone == 'G') { FlatSharp = -1; } }
            if (Flatsharp <= -6) { if (tone == 'C') { FlatSharp = -1; } }
            if (Flatsharp <= -7) { if (tone == 'F') { FlatSharp = -1; } }

            if (noteName == NoteName.wholeNote) { image = Resources.helenoot; duration = 16; }  //afbeelding en duratie van noot zetten, afhankelijk van naam
            else if (noteName == NoteName.halfNote) { image = Resources.halvenoot; duration = 8; }
            else if (noteName == NoteName.quarterNote) { image = Resources.kwartnoot; duration = 4; }
            else if (noteName == NoteName.eightNote) { image = Resources.achtstenoot; duration = 2; }
            else if (noteName == NoteName.sixteenthNote) { image = Resources.zestiendenoot; duration = 1; }
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
                        if (tone == 'A') { filename = "Ais"; }
                        if (tone == 'B') { filename = "C"; }
                        if (tone == 'C') { filename = "Cis"; }
                        if (tone == 'D') { filename = "Dis"; }
                        if (tone == 'E') { filename = "F"; }
                        if (tone == 'F') { filename = "Fis"; }
                        if (tone == 'G') { filename = "Gis"; }
                    }
                    if (FlatSharp == -1)
                    {
                        if (tone == 'A') { filename = "Gis"; }
                        if (tone == 'B') { filename = "Ais"; }
                        if (tone == 'C') { filename = "B"; }
                        if (tone == 'D') { filename = "Cis"; }
                        if (tone == 'E') { filename = "Dis"; }
                        if (tone == 'F') { filename = "E"; }
                        if (tone == 'G') { filename = "Fis"; }
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

        public void SetY(ClefName clefname)
        {
            if (clefname == ClefName.G)
            {
                if (tone == 'C' && octave == 3) y=  40;
                if (tone == 'D' && octave == 3) y =  33;
                if (tone == 'E' && octave == 3) y =  26;
                else if (tone == 'F' && octave == 3) y =  19;
                else if (tone == 'G' && octave == 3) y =  10;
                else if (tone == 'A' && octave == 3) y =  4;
                else if (tone == 'B' && octave == 3) y =  -3;
                else if (tone == 'C' && octave == 4) y =  -11;
                else if (tone == 'D' && octave == 4) y =  -19;
                else if (tone == 'E' && octave == 4) y =  -26;
                else if (tone == 'F' && octave == 4) y =  -34;
                else if (tone == 'G' && octave == 4) y =  -42;
                else if (tone == 'A' && octave == 4) y = -54;
            }

            if (clefname == ClefName.F)
            {
                if (tone == 'E' && octave == 1) y =  40;
                if (tone == 'F' && octave == 1) y =  33;
                if (tone == 'G' && octave == 1) y =  26;
                else if (tone == 'A' && octave == 1) y =  19;
                else if (tone == 'B' && octave == 1) y =  10;
                else if (tone == 'C' && octave == 2) y =  4;
                else if (tone == 'D' && octave == 2) y =  -3;
                else if (tone == 'E' && octave == 2) y =  -11;
                else if (tone == 'F' && octave == 2) y =  -19;
                else if (tone == 'G' && octave == 2) y =  -26;
                else if (tone == 'A' && octave == 2) y =  -34;
                else if (tone == 'B' && octave == 2) y =  -42;
                else if (tone == 'C' && octave == 3) y = -54;
            }
        }
    }
}
