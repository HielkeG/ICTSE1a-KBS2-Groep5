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
        public int octave { get; set; }
        public char tone { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Image image;
        public NoteName noteName;

        public Note()
        {
            if (noteName == NoteName.wholeNote) image = Resources.helenoot;
            else if (noteName == NoteName.halfNote) image = Resources.halvenoot;
            else if (noteName == NoteName.quarterNote) image = Resources.kwartnoot;
            else if (noteName == NoteName.eightNote) image = Resources.achtstenoot;
            else if (noteName == NoteName.sixteenthNote) image = Resources.zestiendenoot;
        }

        public Note(NoteName n)
        {
            noteName = n;
            if (noteName == NoteName.wholeNote) image = Resources.helenoot;
            else if (noteName == NoteName.halfNote) image = Resources.halvenoot;
            else if (noteName == NoteName.quarterNote) image = Resources.kwartnoot;
            else if (noteName == NoteName.eightNote) image = Resources.achtstenoot;
            else if (noteName == NoteName.sixteenthNote) image = Resources.zestiendenoot;
        }

        public Note(NoteName n, char tone ) : base(n, tone)
        {
            noteName = n;
            this.tone = tone;
            if (noteName == NoteName.wholeNote) image = Resources.helenoot;
            else if (noteName == NoteName.halfNote) image = Resources.halvenoot;
            else if (noteName == NoteName.quarterNote) image = Resources.kwartnoot;
            else if (noteName == NoteName.eightNote) image = Resources.achtstenoot;
            else if (noteName == NoteName.sixteenthNote) image = Resources.zestiendenoot;
        }



    }
}
