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
        public virtual Song Song { get; set; }
        [Key]
        public int StaffId { get; set; }
        public List<Bar> Bars { get; set; } = new List<Bar>();
        //volgorde van staffs in de song
        public int Order { get; set; }
        public int FlatSharp { get; set; }
        public static int X = 50;
        public static int Y = 0;
        public int width = 0;
        public static int height = 160;

        [NotMapped]
        public bool IsBeingPlayed { get; set; } = false;

        public Staff(int AmountOfBars)
        {
            for (int i = 0; i < AmountOfBars; i++)
            {
                Bars.Add(new Bar(i));
                width += Bars[i].Width;
            }
        }
        public Staff()
        {
            int AmountOfBars = 4;
            for (int i = 0; i < AmountOfBars; i++)
            {
                Bars.Add(new Bar(i));
                width += Bars[i].Width;
            }
        }

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

        public bool MouseInStaff(int MouseX, int MouseY)
        {
            return (MouseX > X - 50 && MouseX < X + width && MouseY > Y && MouseY < Y + height + 5);
        }
    }
}
