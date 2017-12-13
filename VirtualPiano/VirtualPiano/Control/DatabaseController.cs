using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Model;

namespace VirtualPiano.Control
{
    public static class DatabaseController
    {
        //voeg een nummer toe aan de database
        /// <summary>
        /// 
        /// </summary>
        /// <param name="song"></param>
        public static void AddSong(Song song)
        {
            using (var context = new Context())
            {
                //song toevoegen aan database
                context.Configuration.LazyLoadingEnabled = false;
                context.Songs.Add(song);
                context.SaveChanges();
            }
        }

        public static void UpdateSong(Song song)
        {
            using (var context = new Context())
            {
                try
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    //origineel nummer ophalen.
                    var original = context.Songs.Where(n => n.Title == song.Title).Single();
                    //vervangende song aanmaken
                    Song replacingSong = new Song();
                    //gegevens overzetten
                    replacingSong.Title = song.Title;
                    replacingSong.Staffs = song.Staffs;
                    replacingSong.SongId = song.SongId;
                    context.Songs.Remove(original);
                    context.Songs.Add(replacingSong);
                    context.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //kijkt in de database of er al een song met dezelfde naam bestaat
        public static bool SongExists(Song song)
        {
            using(var context = new Context())
            {
                context.Configuration.LazyLoadingEnabled = false;
                foreach (var item in context.Songs)
                {
                    if (item.Title == song.Title)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static List<Song> GetSongs()
        {
            using (var context = new Context())
            {
                return context.Songs.ToList();
                
            }
        }

        public static Song FillSong(Song song)
        {
            //Wanneer een song uit de database gehaald wordt moet deze nog gevuld worden. Dat gebeurd hier.
            using(var context = new Context())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var staffs =
                    from s in context.Staffs
                    where s.SongId == song.SongId
                    select s;
                //song vullen met staffs
                song.Staffs = staffs.ToList();
                foreach (var staff in song.Staffs)
                {
                    var bars =
                        from b in context.Bars
                        where b.StaffId == staff.StaffId
                        select b;
                    //song vullen met bars
                    staff.Bars = bars.ToList();
                    foreach (var bar in staff.Bars)
                    {
                        var signs =
                            from s in context.Signs
                            where s.BarId == bar.BarId
                            select s;
                        //bar vullen met signss
                        bar.Signs = signs.ToList();
                    }
                }
                

            }
            song.OrderSigns();
            song.OrderStaffs();
            return song;
        }

        public static Song GetSong(string title)
        {
            using (var context = new Context())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var song =
                    from s in context.Songs
                    where s.Title == title
                    select s;
                return song.First();

            }

        }
        //database initializeren zodat het opstarten sneller gaat.
        public static void InitializeDatabase()
        {
            using(var context = new Context())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Database.Initialize(false);
            }
        }

        //nummer verwijderen uit de database
        public static void RemoveSong(string title)
        {
            using(var context = new Context())
            {
                //nummer opzoeken met overeenkomende titel
                var s = context.Songs.Where(n => n.Title == title).Single();
                context.Songs.Remove(s);
                context.SaveChanges();
            }
        }
    }
}
