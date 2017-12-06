using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPiano.Model
{
    public enum ClefName { NULL, G, F}

    public class Bar
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BarId { get; set; }

        public int StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff staff { get; set; }
        public virtual List<Sign> Signs { get; set; }
        [Required]
        public String clef { get; set; }
        [NotMapped]
        public int TimeSignatureAmount { get; set; }
        [NotMapped]
        public NoteName TimeSignatureName { get; set; }
        public int duration { get; set; } = 0;
        public bool hasChanged;
        internal bool hasPreview = false;

        public Bar()
        {
            clef = ClefName.G.ToString();
            Signs = new List<Sign>();
        }

        public bool CheckBarSpace(Sign sign)    //kijken of er ruimte in de maat is voor nieuw teken
        {
            if (duration + sign.duration > 16) return false;
            else return true;
        }

        public void Add(Sign sign)
        {
            Signs.Add(sign);
            duration += sign.duration;
        }

        public void MakeEmpty() //Lijst van tekens leegmaken
        {
            Signs = new List<Sign>();
            duration = 0;
        }

        public void RemovePreview()
        {
            try
            {
                duration = duration - Signs.Last().duration;
                Signs.RemoveAt(Signs.Count() - 1);
                hasPreview = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        public void RemoveSign(Sign sign)
        {
            Signs.Remove(sign);
            duration -= sign.duration;
        }
    }
}
