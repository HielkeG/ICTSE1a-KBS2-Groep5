using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPiano.Model
{
    public enum RestName { wholeRest, halfRest, quarterRest, eightRest, sixteenthRest}

    public class Rest : Sign
    {
        RestName restName;

    }
}
