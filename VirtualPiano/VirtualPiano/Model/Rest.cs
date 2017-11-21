using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Properties;

namespace VirtualPiano.Model
{
    public enum RestName { wholeRest, halfRest, quarterRest, eightRest, sixteenthRest, NULL }

    public class Rest : Sign
    {
        public RestName restName;

        public Rest(RestName restName)
        {
            this.restName = restName;
            if (restName == RestName.wholeRest) { duration = 16; }
            else if (restName == RestName.halfRest) {duration = 8; }
            else if (restName == RestName.quarterRest) { image = Resources.KwartRust; duration = 4; }
            else if (restName == RestName.eightRest) { image = Resources.achtsterust; duration = 2; }
            else if (restName == RestName.sixteenthRest) { image = Resources.zestienderust; duration = 1; }
        }

    }
}
