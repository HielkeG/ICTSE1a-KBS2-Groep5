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
            Name = name;
            SetImage();
        }

        public override void SetImage()
        {
            if (Name == "WholeRest") { Duration = 16; }
            else if (Name == "HalfRest") { Duration = 8; }
            else if (Name == "QuarterRest") { Image = Resources.KwartRust; Duration = 4; }
        }

        public override bool IsLocation(int y, int x)
        {
            return (this.X - 10 < x && this.X + 10 > x && this.Y - 10 < y - 63 && this.Y + 10 > y - 63);
        }

    }
}
