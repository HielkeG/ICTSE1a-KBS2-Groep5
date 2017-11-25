using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public String noteName { get; set; }

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

    }
}
