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
        List<Note> notenbalk = new List<Note>();
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
                if(bar.clef == ClefName.G && latestClef != ClefName.G)
                {
                    e.Graphics.DrawImage(Resources.gsleutel,x_bar-420, 6, 60, 110);
                    latestClef = ClefName.G;
                }
                else if (bar.clef == ClefName.F && latestClef != ClefName.F)
                {
                    e.Graphics.DrawImage(Resources.fsleutel, x_bar-425, 25, 43, 65);
                    latestClef = ClefName.F;
                }
                else if (bar.clef == ClefName.C && latestClef != ClefName.C)
                {
                    latestClef = ClefName.C;
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
                        int Ynotelocation = 0;
                        if (note.tone == 'A') Ynotelocation = 4;
                        else if(note.tone == 'B') Ynotelocation = -3;
                        else if(note.tone == 'C') Ynotelocation = -11;
                        else if(note.tone == 'D') Ynotelocation = -19;
                        else if(note.tone == 'E') Ynotelocation = -26;
                        else if(note.tone == 'F') Ynotelocation = -34;
                        else if(note.tone == 'G') Ynotelocation = 10;

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
                char tone = ' ';
                ChangeCursor();
                if (PointToClient(Cursor.Position).Y < 31 && PointToClient(Cursor.Position).Y >= 23) tone = 'F';
                if (PointToClient(Cursor.Position).Y < 40 && PointToClient(Cursor.Position).Y >= 31) tone = 'E';
                if (PointToClient(Cursor.Position).Y < 48 && PointToClient(Cursor.Position).Y >= 40) tone = 'D';
                if (PointToClient(Cursor.Position).Y < 55 && PointToClient(Cursor.Position).Y >= 48) tone = 'C';
                if (PointToClient(Cursor.Position).Y < 63 && PointToClient(Cursor.Position).Y >= 55) tone = 'B'; 
                if (PointToClient(Cursor.Position).Y < 72 && PointToClient(Cursor.Position).Y >= 63) tone = 'A'; 
                if (PointToClient(Cursor.Position).Y < 78 && PointToClient(Cursor.Position).Y >= 72 ) tone = 'G';
                int barBegin =  50;
                int barEnd = 425;
                foreach(Bar bar in staff.Bars)
                {
                    if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin )
                    {
                        Note newNote = new Note(ComposeView.tempNotename, tone);
                        Rest newRest = new Rest(ComposeView.tempRestName);

                        Console.WriteLine(bar.CheckBarSpace(newNote));

                       if (bar.CheckBarSpace(newNote) && ComposeView.tempNotename != NoteName.NULL) bar.Add(newNote);
                       if(bar.CheckBarSpace(newRest) && ComposeView.tempRestName != RestName.NULL) bar.Add(newRest);
                    }
                    barBegin += 375;
                    barEnd += 375;
                }
                Invalidate();
                ComposeView.tempBool = false;
                ComposeView.tempNotename = NoteName.NULL;
            }
        }

        private void ChangeCursor()
        {
            Cursor = Cursors.Default;
        }

        private void StaffView_MouseEnter(object sender, EventArgs e)
        {
            Cursor = CursorController.ChangeCursor(ComposeView.tempNotename);
        }
    }
}
