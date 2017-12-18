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
        public virtual Bar Bar { get; set; } = null;
        [NotMapped]
        public Image Image { get; set; }
        [NotMapped]
        public int Duration { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public abstract bool IsLocation(int x, int y);
        public abstract void SetImage();
    }
}
