using System;
using System.IO;
using System.Media;
using VirtualPiano.Properties;

namespace VirtualPiano.Model
{
    public enum NoteName { wholeNote, halfNote, quarterNote, eightNote, sixteenthNote, NULL}

    public class Note : Sign
    {
        public int octave;
        public char tone;        
        public NoteName noteName;
        public bool IsBeingPlayed;
        public int x;
        public int y;

        public Note(NoteName notename, char tone, int octave) : base()
        {
            noteName = notename;
            this.octave = octave;
            this.tone = tone;
            if (noteName == NoteName.wholeNote) { image = Resources.helenoot; duration = 16; }  //afbeelding en duratie van noot zetten afhankelijk van naam
            else if (noteName == NoteName.halfNote) { image = Resources.halvenoot; duration = 8; }
            else if (noteName == NoteName.quarterNote) { image = Resources.kwartnoot; duration = 4; }
            else if (noteName == NoteName.eightNote) { image = Resources.achtstenoot; duration = 2; }
            else if (noteName == NoteName.sixteenthNote) { image = Resources.zestiendenoot; duration = 1; }
        }

        public void PlaySound()
        {
            object O = Properties.Resources.ResourceManager.GetObject($"Piano{octave}{tone}");
            var s = (Stream)O;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(s);
            snd.Play();
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
            }
        }
    }
}
