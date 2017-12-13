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

    public class Rest : Sign
    {

        public Rest() : base() { }

        public Rest(string name)
        {
            this.name = name;
            if (name == "WholeRest") { duration = 16; }
            else if (name == "HalfRest") { duration = 8; }
            else if (name == "QuarterRest") { image = Resources.KwartRust; duration = 4; }
            else if (name == "EightRest") { image = Resources.achtsterust; duration = 2; }
            else if (name == "SixteenthRest") { image = Resources.zestienderust; duration = 1; }
        }

        public override bool IsLocation(int y, int x)
        {
            return (this.x - 10 < x && this.x + 10 > x && this.y - 10 < y - 63 && this.y + 10 > y - 63);
        }

    }
}
