using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Properties;

namespace VirtualPiano.Model
{
    public enum NoteName { wholeNote, halfNote, quarterNote, eightNote, sixteenthNote, NULL}

    public class Note : Sign
    {
        public int octave;
        public char tone;        
        public NoteName noteName;

        public Note(NoteName notename, char tone) : base()
        {
            noteName = notename;
            this.tone = tone;
            if (noteName == NoteName.wholeNote) { image = Resources.helenoot; duration = 16; }
            else if (noteName == NoteName.halfNote) { image = Resources.halvenoot; duration = 8; }
            else if (noteName == NoteName.quarterNote) { image = Resources.kwartnoot; duration = 4; }
            else if (noteName == NoteName.eightNote) { image = Resources.achtstenoot; duration = 2; }
            else if (noteName == NoteName.sixteenthNote) { image = Resources.zestiendenoot; duration = 1; }
        }
    }
}
