using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualPiano.Model;
using VirtualPiano.Control;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DoMakeEmpty_WhenListContainsTwoSigns()
        {
            //Arrange
            Bar bar = new Bar();
            bar.Add(new Note(NoteName.halfNote, "A", 2));
            bar.Add(new Note(NoteName.halfNote, "B", 2));
            bar.MakeEmpty();


            //Act
            int Expect = 0;

            //Assert
            Assert.AreEqual(Expect, bar.Signs.Count);
        }
        [TestMethod]
        public void DoMakeEmpty_WhenListContainsNoSigns()
        {
            //Arrange
            Bar bar = new Bar();
            bar.MakeEmpty();


            //Act
            int Expect = 0;

            //Assert
            Assert.AreEqual(Expect, bar.Signs.Count);
        }

        [TestMethod]
        public void DoAddOneHalfNote_WhenBarIsEmpty()
        {
            //Arrange
            Bar bar = new Bar();

            //Act
            bar.Add(new Note(NoteName.halfNote, "A", 2));

            //Assert
            Assert.AreEqual(1, bar.Signs.Count);            
        }

        [TestMethod]
        public void DoAddOneHalfNoteAndTwoQuarterNotes_WhenBarIsEmpty()
        {
            //Arrange
            Bar bar = new Bar();

            //Act
            bar.Add(new Note(NoteName.halfNote, "A", 2));
            bar.Add(new Note(NoteName.quarterNote, "C", 2));
            bar.Add(new Note(NoteName.quarterNote, "A", 2));

            //Assert
            Assert.AreEqual(3, bar.Signs.Count);
        }

        [TestMethod]
        public void DoCheckBarSpaceWithWholeNote_WhenBarIsEmpty()
        {
            //Arrange
            Bar bar = new Bar();

            //Act
            bool Expect = true;

            //Assert
            Assert.AreEqual(Expect, bar.CheckBarSpace(new Note(NoteName.wholeNote, "A", 2)));
        }


        [TestMethod]
        public void DoCheckBarSpaceWithWHalfNote_WhenBarhasThreeQuarterNotes()
        {
            //Arrange
            Bar bar = new Bar();
            bar.Add(new Note(NoteName.quarterNote, "C", 2));
            bar.Add(new Note(NoteName.quarterNote, "A", 2));
            bar.Add(new Note(NoteName.quarterNote, "B", 2));

            //Act
            bool Expect = false;

            //Assert
            Assert.AreEqual(Expect, bar.CheckBarSpace(new Note(NoteName.halfNote, "A", 2)));
        }

        [TestMethod]
        public void DoAddSong_WhenSongIsValidWithBars()
        {

            List<Song> songs = new List<Song>();
            Song song = new Song();
            songs.Clear();

            using (var context = new Context())
            {
                songs = context.Songs.ToList();
                foreach (var item in songs)
                {
                    context.Songs.Remove(item);
                }
                context.SaveChanges();
                context.Songs.Add(song);
                context.SaveChanges();
                songs = context.Songs.ToList();
            }

            Assert.AreEqual(1, songs.Count);
        }
        [TestMethod]
        public void GetSongFromDatabase_WhenFilled()
        {
            List<Song> songs = new List<Song>();

            using (var context = new Context())
            {
                //songs = context.Songs;   
            }
        }
    }
}
