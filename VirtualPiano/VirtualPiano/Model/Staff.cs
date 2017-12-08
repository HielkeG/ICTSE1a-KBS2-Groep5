using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPiano.Model
{
    public class Staff
    {
        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public virtual Song song { get; set; }
        [Key]
        public int StaffId { get; set; }
        public List<Bar> Bars { get; set; } = new List<Bar>() { new Bar(), new Bar(), new Bar(), new Bar() }; //4 maten in een notenbalk
        //volgorde van staffs in de song
        public int Order { get; set; }
        public int FlatSharp { get; set; }
        public int y { get; set; }
        [NotMapped]
        public bool IsBeingPlayed { get; set; } = false;


        public bool IsEmtpy()
        {
            bool empty = true;
            foreach (var item in Bars)
            {
                if (item.Signs.Count != 0)
                {
                    empty = false;
                }
            }
            return empty;
        }

    }
}
