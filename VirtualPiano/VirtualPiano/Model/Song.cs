using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPiano.Model
{
    public class Song
    {
        public static ICollection<Staff> Staffs { get; set; }

        public int FlatSharp;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }
        public string Composer { get; set; }
        private string title = "titel";
        public string Title
        {
            get
            {
                if(title != "")
                {
                    return title;
                }
                else
                {
                    return "Geen titel";
                }
            }
            set
            {
                if (value != "")
                {
                    title = value;
                }
            }
        }
        public Song()
        {

                Staffs = new List<Staff>();
                Staffs.Add(new Staff());
            

        }

        public void AddStaff(Staff s)
        {
            Staffs.Add(s);
        }

        public List<Staff> GetStaffs()
        {
            return Staffs.ToList();
        }

        public bool IsEmpty()
        {
            bool isEmpty = true;
            foreach (var staff in Staffs)
            {
                if (!staff.IsEmtpy())
                {
                    isEmpty = false;
                }
            }
            return isEmpty;
        }

        public static int getDuration()
        {
            int duration = 0;
            foreach (Staff staff in staffs)
            {
                foreach (Bar bar in staff.Bars)
                {
                    duration = duration + bar.duration;
                }
            }
            return duration; // 1 maat is 16
        }

        public async void PlaySong()
        {
            for(int i = 0; i < staffs.Count(); i++)
            {
                for(int b = 0; b <  staffs[i].Bars.Count();b++)
                {
                    for(int c = 0; c< staffs[i].Bars[b].signs.Count();c++)
                    {
                        if(staffs[i].Bars[b].signs[c] is Note note)
                        {
                            note.PlaySound();
                            await PutTaskDelay(note.duration * 120);
                            
                        }

                        else if (staffs[i].Bars[b].signs[c] is Rest rest)
                        {
                            await PutTaskDelay(rest.duration * 120);

                        }
                    }
                }
            }
        }

        async Task PutTaskDelay(int delay)
        {
            await Task.Delay(delay);
        }
        

    }
}
