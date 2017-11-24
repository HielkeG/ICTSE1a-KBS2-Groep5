using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPiano.Model
{
    public class Song
    {
        private List<Staff> staffs;
        public int FlatSharp;

        public Song()
        {
            staffs = new List<Staff>();
            staffs.Add(new Staff());
        }

        public void AddStaff(Staff s)
        {
            staffs.Add(s);
        }

        public List<Staff> GetStaffs()
        {
            return staffs;
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
