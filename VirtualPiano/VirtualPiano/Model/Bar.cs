using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPiano.Model
{
    public enum ClefName { G, F, C , NULL}

    public class Bar
    {
        public List<Sign> Notes;
        public ClefName clef;
        public int TimeSignatureAmount;
        public NoteName TimeSignatureName;

        public Bar()
        {
            clef = ClefName.G;
            Notes = new List<Sign>();
            Notes.Add(new Note(NoteName.quarterNote, 'A'));
            
        }
    }
}
