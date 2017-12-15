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
            bar.Add(new Note(12, 10, "HalfNote", "A", 2));
            bar.Add(new Note(10, 12, "HalfNote", "B", 2));
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
            bar.Add(new Note(10, 9, "HalfNote", "A", 2));

            //Assert
            Assert.AreEqual(1, bar.Signs.Count);
        }

        [TestMethod]
        public void DoAddOneHalfNoteAndTwoQuarterNotes_WhenBarIsEmpty()
        {
            //Arrange
            Bar bar = new Bar();

            //Act
            bar.Add(new Note(10, 20, "HalfNote", "A", 2));
            bar.Add(new Note(10, 34, "QuarterNote", "C", 2));
            bar.Add(new Note(10, 27, "QuarterNote", "A", 2));

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
            Assert.AreEqual(Expect, bar.CheckBarSpace(new Note(10, 25, "WholeNote", "A", 2)));
        }


        [TestMethod]
        public void DoCheckBarSpaceWithWHalfNote_WhenBarhasThreeQuarterNotes()
        {
            //Arrange
            Bar bar = new Bar();
            bar.Add(new Note(20, 35, "QuarterNote", "C", 2));
            bar.Add(new Note(22, 47, "QuarterNote", "A", 2));
            bar.Add(new Note(24, 45, "QuarterNote", "B", 2));

            //Act
            bool Expect = false;

            //Assert
            Assert.AreEqual(Expect, bar.CheckBarSpace(new Note(25, 67, "HalfNote", "A", 2)));
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

        [TestMethod]
        public void ChangeMetronomeBPM()
        {
            //arrange
            int bpm = 120;
            MusicController.setMetronoom(0);

            //act
            MusicController.setMetronoom(bpm);

            //assert
            Assert.AreEqual(60000 / 120, MusicController.Metronoom.Interval);
        }

        [TestMethod]
        public void NoteFlip_WhenNoteisNotFlipped()
        {
            //arrange
            Note note = new Note(20, 35, "QuarterNote", "C", 2);
            note.flip();

            //act
            bool verwachting = true;

            //assert
            Assert.AreEqual(note.flipped, verwachting);
        }


        [TestMethod]
        public void NoteUnFlip_WhenNoteisFlipped()
        {
            //arrange
            Note note = new Note(-12, -35, "QuarterNote", "C", 2);
            note.unflip();

            //act
            bool verwachting = false;

            //assert
            Assert.AreEqual(note.flipped, verwachting);
        }

        [TestMethod]
        public void SetSharpWhenNoteisA()
        {
            //arrange
            Note note = new Note(-12, 32, "QuarterNote", "G", 5);
            note.SetSharp();

            //act
            string verwachting = "Ais";

            //assert
            Assert.AreEqual(note.Tone, verwachting);
        }

        [TestMethod]
        public void SetFlatWhenNoteisAis()
        {
            //arrange
            Note note = new Note(-12, 32, "QuarterNote", "G", 5);
            note.SetSharp();
            note.SetFlat();

            //act
            string verwachting = "As";

            //assert
            Assert.AreEqual(note.Tone, verwachting);
        }

    }
}
