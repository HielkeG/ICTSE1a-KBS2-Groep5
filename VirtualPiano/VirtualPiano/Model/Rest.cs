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
    public enum RestName { wholeRest, halfRest, quarterRest, eightRest, sixteenthRest, NULL }

    public class Rest : Sign
    {
        public String restName { get; set; }
        public Rest() : base() { }
        public Rest(RestName restName)
        {
            this.restName = restName.ToString();
            if (restName == RestName.wholeRest) { duration = 16; }
            else if (restName == RestName.halfRest) {duration = 8; }
            else if (restName == RestName.quarterRest) { image = Resources.KwartRust; duration = 4; }
            else if (restName == RestName.eightRest) { image = Resources.achtsterust; duration = 2; }
            else if (restName == RestName.sixteenthRest) { image = Resources.zestienderust; duration = 1; }
        }

        public override void SetImage()
        {
            if (restName == RestName.wholeRest.ToString()) { duration = 16; }
            else if (restName == RestName.halfRest.ToString()) { duration = 8; }
            else if (restName == RestName.quarterRest.ToString()) { image = Resources.KwartRust; duration = 4; }
            else if (restName == RestName.eightRest.ToString()) { image = Resources.achtsterust; duration = 2; }
            else if (restName == RestName.sixteenthRest.ToString()) { image = Resources.zestienderust; duration = 1; }
        }
    }
}
