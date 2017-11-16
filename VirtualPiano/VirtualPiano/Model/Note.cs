using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPiano.Model
{
    public enum NoteName { wholeNote, halfNote, quarterNote, eightNote, sixteenthNote }

    public class Note : Sign
    {
        string name;
        int octave;
        int tone;

        //Sound sound;
        NoteName noteName;
        
        

    }
}
