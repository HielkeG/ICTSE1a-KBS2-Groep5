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
    public abstract class Sign
    {
        [Key]
        public int SignId { get; set; }
        public int BarId { get; set; }
        [ForeignKey("BarId")]
        public virtual Bar bar { get; set; } = null;
        [NotMapped]
        public Image image { get; set; }
        [NotMapped]
        public int duration { get; set; }
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public abstract void SetImage();
        public abstract bool IsLocation(int x, int y);
    }
}
