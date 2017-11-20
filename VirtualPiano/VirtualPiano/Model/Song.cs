using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPiano.Model
{
    public class Song
    {
        private List<Staff> staffs;

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
    }
}
