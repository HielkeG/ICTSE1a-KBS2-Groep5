using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Model;

namespace VirtualPiano.Control
{
    public class Context : DbContext
    {
        public Context() : base() { }

        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Bar> Bars { get; set; }
        public virtual DbSet<Sign> Signs { get; set; }
        public virtual DbSet<Rest> Rests { get; set; }
        public virtual DbSet<Note> Notes { get; set; }

    }


}
