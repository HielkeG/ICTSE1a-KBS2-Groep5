using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualPiano.Model;

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
            bar.Add(new Note(NoteName.halfNote, 'A', 2));
            bar.Add(new Note(NoteName.halfNote, 'B', 2));
            bar.MakeEmpty();


            //Act
            int Expect = 0;

            //Assert
            Assert.AreEqual(Expect, bar.signs.Count);
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
            Assert.AreEqual(Expect, bar.signs.Count);
        }

        [TestMethod]
        public void DoAddOneHalfNote_WhenBarIsEmpty()
        {
            //Arrange
            Bar bar = new Bar();

            //Act
            bar.Add(new Note(NoteName.halfNote, 'A', 2));

            //Assert
            Assert.AreEqual(1, bar.signs.Count);            
        }

        [TestMethod]
        public void DoAddOneHalfNoteAndTwoQuarterNotes_WhenBarIsEmpty()
        {
            //Arrange
            Bar bar = new Bar();

            //Act
            bar.Add(new Note(NoteName.halfNote, 'A', 2));
            bar.Add(new Note(NoteName.quarterNote, 'C', 2));
            bar.Add(new Note(NoteName.quarterNote, 'A', 2));

            //Assert
            Assert.AreEqual(3, bar.signs.Count);
        }

        [TestMethod]
        public void DoCheckBarSpaceWithWholeNote_WhenBarIsEmpty()
        {
            //Arrange
            Bar bar = new Bar();

            //Act
            bool Expect = true;

            //Assert
            Assert.AreEqual(Expect, bar.CheckBarSpace(new Note(NoteName.wholeNote, 'A', 2)));
        }


        [TestMethod]
        public void DoCheckBarSpaceWithWHalfNote_WhenBarhasThreeQuarterNotes()
        {
            //Arrange
            Bar bar = new Bar();
            bar.Add(new Note(NoteName.quarterNote, 'C', 2));
            bar.Add(new Note(NoteName.quarterNote, 'A', 2));
            bar.Add(new Note(NoteName.quarterNote, 'C', 2));

            //Act
            bool Expect = false;

            //Assert
            Assert.AreEqual(Expect, bar.CheckBarSpace(new Note(NoteName.halfNote, 'A', 2)));
        }
    }
}
