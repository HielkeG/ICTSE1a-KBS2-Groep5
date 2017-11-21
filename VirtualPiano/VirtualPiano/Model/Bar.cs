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
        public List<Sign> signs;
        public ClefName clef;
        public int TimeSignatureAmount;
        public NoteName TimeSignatureName;
        public int duration = 0;
        public bool isFull = false;

        public Bar()
        {
            clef = ClefName.G;
            signs = new List<Sign>();
        }

        public bool CheckBarSpace(Sign sign)    //kijken of er ruimte in de maat is voor nieuw teken
        {
            if (duration + sign.duration > 16) return false;
            else return true;
        }

        public void Add(Sign sign)
        {
            signs.Add(sign);
            duration += sign.duration;
            if (duration == 16) isFull = true;
        }

        public void MakeEmpty() //Lijst van tekens leegmaken
        {
            signs = new List<Sign>();
            isFull = false;
            duration = 0;
        }
    }
}
