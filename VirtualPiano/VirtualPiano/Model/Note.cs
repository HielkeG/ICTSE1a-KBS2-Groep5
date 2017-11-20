using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Properties;

namespace VirtualPiano.Model
{
    public enum NoteName { wholeNote, halfNote, quarterNote, eightNote, sixteenthNote }

    public class Note : Sign
    {
        public int octave;
        public char tone;        
        public NoteName noteName;

        public Note(NoteName notename, char tone, int octave) : base()
        {
            noteName = notename;
            this.octave = octave;
            this.tone = tone;
            if (noteName == NoteName.wholeNote) image = Resources.helenoot;
            else if (noteName == NoteName.halfNote) image = Resources.halvenoot;
            else if (noteName == NoteName.quarterNote) image = Resources.kwartnoot;
            else if (noteName == NoteName.eightNote) image = Resources.achtstenoot;
            else if (noteName == NoteName.sixteenthNote) image = Resources.zestiendenoot;
            
        }

        public Note(NoteName notename, char tone) : base()
        {
            noteName = notename;
            this.tone = tone;
            if (noteName == NoteName.wholeNote) image = Resources.helenoot;
            else if (noteName == NoteName.halfNote) image = Resources.halvenoot;
            else if (noteName == NoteName.quarterNote) image = Resources.kwartnoot;
            else if (noteName == NoteName.eightNote) image = Resources.achtstenoot;
            else if (noteName == NoteName.sixteenthNote) image = Resources.zestiendenoot;

        }
    }
}
