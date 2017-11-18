using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Properties;

namespace VirtualPiano.Model
{
    public abstract class Sign
    {
        public Image image;
        public NoteName noteName;
        public char tone;

        public Sign(NoteName notename, char tone)
        {
            noteName = notename;
            this.tone = tone;
            if (noteName == NoteName.wholeNote) image = Resources.helenoot;
            else if (noteName == NoteName.halfNote) image = Resources.halvenoot;
            else if (noteName == NoteName.quarterNote) image = Resources.kwartnoot;
            else if (noteName == NoteName.eightNote) image = Resources.achtstenoot;
            else if (noteName == NoteName.sixteenthNote) image = Resources.zestiendenoot;

        }

        public Sign()
        {
        }
    }
}
