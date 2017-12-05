using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualPiano.Model;
using VirtualPiano.Control;
using System.Collections.Generic;
using System.Linq;
using VirtualPiano.View;


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
            bar.Add(new Note(NoteName.HalfNote, "A", 2));
            bar.Add(new Note(NoteName.HalfNote, "B", 2));
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
            bar.Add(new Note(NoteName.HalfNote, "A", 2));

            //Assert
            Assert.AreEqual(1, bar.Signs.Count);            
        }

        [TestMethod]
        public void DoAddOneHalfNoteAndTwoQuarterNotes_WhenBarIsEmpty()
        {
            //Arrange
            Bar bar = new Bar();

            //Act
            bar.Add(new Note(NoteName.HalfNote, "A", 2));
            bar.Add(new Note(NoteName.QuarterNote, "C", 2));
            bar.Add(new Note(NoteName.QuarterNote, "A", 2));

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
            Assert.AreEqual(Expect, bar.CheckBarSpace(new Note(NoteName.WholeNote, "A", 2)));
        }


        [TestMethod]
        public void DoCheckBarSpaceWithWHalfNote_WhenBarhasThreeQuarterNotes()
        {
            //Arrange
            Bar bar = new Bar();
            bar.Add(new Note(NoteName.QuarterNote, "C", 2));
            bar.Add(new Note(NoteName.QuarterNote, "A", 2));
            bar.Add(new Note(NoteName.QuarterNote, "B", 2));

            //Act
            bool Expect = false;

            //Assert
            Assert.AreEqual(Expect, bar.CheckBarSpace(new Note(NoteName.HalfNote, "A", 2)));
        }


        [TestMethod]
        public void ChangeInstrument_FromPianoToGuitar()
        {
            //Arrange
            MenuBarController mbc = new MenuBarController();
            ComposeView.instrument = "Piano";

            //Act
            mbc.ChangeInstrument(new MenuBarView(), "Gitaar");

            //Assert
            Assert.AreEqual("Guitar", ComposeView.instrument);
        }


    }
}
