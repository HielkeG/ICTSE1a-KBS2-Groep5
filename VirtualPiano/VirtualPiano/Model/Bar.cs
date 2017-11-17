using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPiano.Model
{
    public enum ClefName { G, F, C }

    public class Bar
    {
        public List<Sign> Notes;
        public ClefName clef;
        public int TimeSignatureAmount;
        public NoteName TimneSignatureName;

        public Bar()
        {
            Notes = new List<Sign>();
        }

        public Bar(ClefName clef)
        {
            Notes = new List<Sign>();
            this.clef = clef;
        }
        

    }
}
