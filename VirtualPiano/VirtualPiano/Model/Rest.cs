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
    public enum RestName {NULL, WholeRest, HalfRest, QuarterRest, EightRest, SixteenthRest}

    public class Rest : Sign
    {
        


        public Rest() : base() { }
        public Rest(RestName restName)
        {
            this.name = restName.ToString();
            if (restName == RestName.WholeRest) { duration = 16; }
            else if (restName == RestName.HalfRest) {duration = 8; }
            else if (restName == RestName.QuarterRest) { image = Resources.KwartRust; duration = 4; }
            else if (restName == RestName.EightRest) { image = Resources.achtsterust; duration = 2; }
            else if (restName == RestName.SixteenthRest) { image = Resources.zestienderust; duration = 1; }
        }

        public override void SetImage()
        {
            if (name == RestName.WholeRest.ToString()) { duration = 16; }
            else if (name == RestName.HalfRest.ToString()) { duration = 8; }
            else if (name == RestName.QuarterRest.ToString()) { image = Resources.KwartRust; duration = 4; }
            else if (name == RestName.EightRest.ToString()) { image = Resources.achtsterust; duration = 2; }
            else if (name == RestName.SixteenthRest.ToString()) { image = Resources.zestienderust; duration = 1; }
        }

        public override bool IsLocation(int y, int x)
        {
            return (this.x - 10 < x && this.x + 10 > x && this.y - 10 < y - 63 && this.y + 10 > y - 63);
        }

    }
}
