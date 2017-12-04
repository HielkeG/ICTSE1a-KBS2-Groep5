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
        public String restName { get; set; }
        public Rest() : base() { }
        public Rest(RestName restName)
        {
            this.restName = restName.ToString();
            if (restName == RestName.WholeRest) { duration = 16; }
            else if (restName == RestName.HalfRest) {duration = 8; }
            else if (restName == RestName.QuarterRest) { image = Resources.KwartRust; duration = 4; }
            else if (restName == RestName.EightRest) { image = Resources.achtsterust; duration = 2; }
            else if (restName == RestName.SixteenthRest) { image = Resources.zestienderust; duration = 1; }
        }

        public override void SetImage()
        {
            if (restName == RestName.WholeRest.ToString()) { duration = 16; }
            else if (restName == RestName.HalfRest.ToString()) { duration = 8; }
            else if (restName == RestName.QuarterRest.ToString()) { image = Resources.KwartRust; duration = 4; }
            else if (restName == RestName.EightRest.ToString()) { image = Resources.achtsterust; duration = 2; }
            else if (restName == RestName.SixteenthRest.ToString()) { image = Resources.zestienderust; duration = 1; }
        }
    }
}
