using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Model;
using VirtualPiano.Properties;
using VirtualPiano.Control;

namespace VirtualPiano.View
{
    public partial class StaffView : UserControl
    {
        public Staff staff;
        Color barColor;


        public StaffView(Staff staff)
        {
            this.staff = staff;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Drawlines(e);
            DrawBars(e);     
        }

        private void Drawlines(PaintEventArgs e)
        {
            Pen penBlack = new Pen(Color.Black);
            e.Graphics.DrawLine(penBlack, 10, 30, 10, 90);
            int i = 0;
            while (i < 5)
            {
                e.Graphics.DrawLine(penBlack, 10, 30 + i * 15, 1550, 30 + i * 15);
                i++;
            }
        }

        public void DrawBars(PaintEventArgs e)
        {
            int x_bar = 425;
            int Xnotelocation = 20;
            ClefName latestClef = ClefName.NULL;
            foreach (Bar bar in staff.Bars)
            {
                if(staff.Bars.First() == bar)
                {
                    if (bar.clef == ClefName.G && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 420, 6, 60, 110); latestClef = ClefName.G; }
                    if (bar.clef == ClefName.F && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 425, 25, 43, 65); latestClef = ClefName.F; }
                    if (bar.clef == ClefName.C && latestClef != ClefName.C) { latestClef = ClefName.C; }
                } else
                {
                    if (bar.clef == ClefName.G && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 414, 23, 40, 83); latestClef = ClefName.G; }
                    if (bar.clef == ClefName.F && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 410, 29, 30, 41); latestClef = ClefName.F; }
                    if (bar.clef == ClefName.C && latestClef != ClefName.C) { latestClef = ClefName.C; }
                }
                
                e.Graphics.DrawLine(new Pen(Color.Black),x_bar,30,x_bar,90);

                if (bar.isFull) barColor = Color.Green;
                else barColor = Color.Red;
                e.Graphics.DrawLine(new Pen(barColor, 5), x_bar - 375, 125, x_bar, 125);
                Xnotelocation = x_bar - 400;
                
                foreach(Sign sign in bar.signs)
                {
                    if (sign is Note note)
                    {
                        int Ynotelocation = GiveYLocation(note, bar.clef);
                        e.Graphics.DrawImage(sign.image, Xnotelocation, Ynotelocation, 90, 130);

                        if (note.noteName == NoteName.wholeNote) Xnotelocation += 336;
                        else if(note.noteName == NoteName.halfNote) Xnotelocation += 168;
                        else if(note.noteName == NoteName.quarterNote) Xnotelocation += 84;
                        else if(note.noteName == NoteName.eightNote) Xnotelocation += 42;
                        else if(note.noteName == NoteName.sixteenthNote) Xnotelocation += 21;
                        
                    }
                    else if (sign is Rest rest)
                    {                    
                        if (rest.restName == RestName.wholeRest) e.Graphics.DrawImage(rest.image, Xnotelocation + 180, 25, 50, 50);
                        else if (rest.restName == RestName.halfRest) e.Graphics.DrawImage(rest.image, Xnotelocation, 31, 50, 50);
                        else if(rest.restName == RestName.quarterRest) e.Graphics.DrawImage(rest.image, Xnotelocation, 35, 40, 50);
                        else if(rest.restName == RestName.eightRest) e.Graphics.DrawImage(rest.image, Xnotelocation, 100, 10, 10);
                        else if(rest.restName == RestName.sixteenthRest) e.Graphics.DrawImage(rest.image, Xnotelocation, 100, 10, 10);

                        if (rest.restName == RestName.wholeRest) Xnotelocation += 336;
                        else if(rest.restName == RestName.halfRest) Xnotelocation += 168;
                        else if(rest.restName == RestName.quarterRest) Xnotelocation += 84;
                        else if(rest.restName == RestName.eightRest) Xnotelocation += 42;
                        else if(rest.restName == RestName.sixteenthRest) Xnotelocation += 21;
                    }
                  
                }
                x_bar += 375;
            }     
        }


        private void StaffView_MouseUp(object sender, MouseEventArgs e)
        {
            if (ComposeView.tempBool)
            {
                int barBegin =  50;
                int barEnd = 425;
                foreach(Bar bar in staff.Bars)
                {
                    if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin )
                    {
                        Note newNote = CreateNote(PointToClient(Cursor.Position).Y, ComposeView.tempNotename, bar.clef);
                        Rest newRest = new Rest(ComposeView.tempRestName);

              

                       if (bar.CheckBarSpace(newNote) && ComposeView.tempNotename != NoteName.NULL) bar.Add(newNote);
                       if (bar.CheckBarSpace(newRest) && ComposeView.tempRestName != RestName.NULL) bar.Add(newRest);
                        if (ComposeView.tempClefName == ClefName.G)
                        {
                            bar.clef = ClefName.G;
                            bar.MakeEmpty();
                            Console.WriteLine(bar.clef);
                        }
                        if (ComposeView.tempClefName == ClefName.F) {
                            bar.clef = ClefName.F;
                            bar.MakeEmpty();
                            Console.WriteLine(bar.clef);
                        }

                    }
                    barBegin += 375;
                    barEnd += 375;
                }
                Invalidate();

                SetDefaultCursor();
            }
        }
        
        private int GiveYLocation(Note note, ClefName clefname)
        {
            if(clefname == ClefName.G)
            {
                if (note.tone == 'C' && note.octave == 3) return 40;
                if (note.tone == 'D' && note.octave == 3) return 33;
                if (note.tone == 'E' && note.octave == 3) return 26;
                else if (note.tone == 'F' && note.octave == 3) return 19;
                else if (note.tone == 'G' && note.octave == 3) return 10;
                else if (note.tone == 'A' && note.octave == 3) return 4;
                else if (note.tone == 'B' && note.octave == 3) return -3;
                else if (note.tone == 'C' && note.octave == 4) return -11;
                else if (note.tone == 'D' && note.octave == 4) return -19;
                else if (note.tone == 'E' && note.octave == 4) return -26;
                else if (note.tone == 'F' && note.octave == 4) return -34;
                else if (note.tone == 'G' && note.octave == 4) return -42;
            }

            if (clefname == ClefName.F)
            {
                if (note.tone == 'E' && note.octave == 1) return 40;
                if (note.tone == 'F' && note.octave == 1) return 33;
                if (note.tone == 'G' && note.octave == 1) return 26;
                else if (note.tone == 'A' && note.octave == 1) return 19;
                else if (note.tone == 'B' && note.octave == 1) return 10;
                else if (note.tone == 'C' && note.octave == 2) return 4;
                else if (note.tone == 'D' && note.octave == 2) return -3;
                else if (note.tone == 'E' && note.octave == 2) return -11;
                else if (note.tone == 'F' && note.octave == 2) return -19;
                else if (note.tone == 'G' && note.octave == 2) return -26;
                else if (note.tone == 'A' && note.octave == 2) return -34;
                else if (note.tone == 'B' && note.octave == 2) return -42;
            }


            return 0;
        }

        private Note CreateNote(int y, NoteName tempNotename, ClefName clef)
        {
            char tone = ' ';
            int octave = 0;
            if (clef == ClefName.G)
            {
                if (y < 25 && PointToClient(Cursor.Position).Y >= 14) { tone = 'G'; octave = 4; }
                if (y < 33 && PointToClient(Cursor.Position).Y >= 25) { tone = 'F'; octave = 4; }
                if (y < 41 && PointToClient(Cursor.Position).Y >= 33) { tone = 'E'; octave = 4; }
                if (y < 48 && PointToClient(Cursor.Position).Y >= 41) { tone = 'D'; octave = 4; }
                if (y < 55 && PointToClient(Cursor.Position).Y >= 48) { tone = 'C'; octave = 4; }
                if (y < 63 && PointToClient(Cursor.Position).Y >= 55) { tone = 'B'; octave = 3; }
                if (y < 72 && PointToClient(Cursor.Position).Y >= 63) { tone = 'A'; octave = 3; }
                if (y < 78 && PointToClient(Cursor.Position).Y >= 72) { tone = 'G'; octave = 3; }
                if (y < 86 && PointToClient(Cursor.Position).Y >= 78) { tone = 'F'; octave = 3; }
                if (y < 94 && PointToClient(Cursor.Position).Y >= 86) { tone = 'E'; octave = 3; }
                if (y < 100 && PointToClient(Cursor.Position).Y >= 94) { tone = 'D'; octave = 3; }
                if (y < 107 && PointToClient(Cursor.Position).Y >= 100) { tone = 'C'; octave = 3; }

                return new Note(tempNotename, tone, octave);

            }
            if (clef == ClefName.F)
            {
                if (y < 25 && PointToClient(Cursor.Position).Y >= 14) { tone = 'B'; octave = 2; }
                if (y < 33 && PointToClient(Cursor.Position).Y >= 25) { tone = 'A'; octave = 2; }
                if (y < 41 && PointToClient(Cursor.Position).Y >= 33) { tone = 'G'; octave = 2; }
                if (y < 48 && PointToClient(Cursor.Position).Y >= 41) { tone = 'F'; octave = 2; }
                if (y < 55 && PointToClient(Cursor.Position).Y >= 48) { tone = 'E'; octave = 2; }
                if (y < 63 && PointToClient(Cursor.Position).Y >= 55) { tone = 'D'; octave = 2; }
                if (y < 72 && PointToClient(Cursor.Position).Y >= 63) { tone = 'C'; octave = 2; }
                if (y < 78 && PointToClient(Cursor.Position).Y >= 72) { tone = 'B'; octave = 1; }
                if (y < 86 && PointToClient(Cursor.Position).Y >= 78) { tone = 'A'; octave = 1; }
                if (y < 94 && PointToClient(Cursor.Position).Y >= 86) { tone = 'G'; octave = 1; }
                if (y < 100 && PointToClient(Cursor.Position).Y >= 94) { tone = 'F'; octave = 1; }
                if (y < 107 && PointToClient(Cursor.Position).Y >= 100) { tone = 'E'; octave = 1; }

                return new Note(tempNotename, tone, octave);

            }

            return new Note(tempNotename, 'A', 1);

        }
        private void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
            ComposeView.tempBool = false;
            ComposeView.tempNotename = NoteName.NULL;
            ComposeView.tempRestName = RestName.NULL;
            ComposeView.tempClefName = ClefName.NULL;
        }

        private void StaffView_MouseEnter(object sender, EventArgs e)
        {
            if (ComposeView.tempNotename != NoteName.NULL)
            {
                Cursor = CursorController.ChangeCursor(ComposeView.tempNotename);
            }
            else if(ComposeView.tempClefName != ClefName.NULL)
            {
                Cursor = CursorController.ChangeCursor(ComposeView.tempClefName);
            }
            else if(ComposeView.tempRestName != RestName.NULL)
            {
                Cursor = CursorController.ChangeCursor(ComposeView.tempRestName);
            }
        }
    }
}
