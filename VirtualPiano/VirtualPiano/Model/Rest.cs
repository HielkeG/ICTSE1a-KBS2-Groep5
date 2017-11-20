using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Properties;

namespace VirtualPiano.Model
{
    public enum RestName { wholeRest, halfRest, quarterRest, eightRest, sixteenthRest}

    public class Rest : Sign
    {
        public RestName restName;
        

        public Rest()
        {
            if (restName == RestName.wholeRest) image = Resources.HeleRust;
            else if (restName == RestName.halfRest) image = Resources.HalveRust;
            else if (restName == RestName.quarterRest) image = Resources.KwartRust;
            else if (restName == RestName.eightRest) image = null;
            else if (restName == RestName.sixteenthRest) image = null;
        }
    }
}
