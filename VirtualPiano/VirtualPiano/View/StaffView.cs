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

namespace VirtualPiano.View
{
    public partial class StaffView : UserControl
    {
        public Staff staff;
        List<Note> notenbalk = new List<Note>();


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

                Xnotelocation = x_bar - 400;
                foreach(Sign sign in bar.Notes)
                {
                    if (sign is Note note)
                    {
                        int Ynotelocation = 0;
                        if (note.tone == 'A') Ynotelocation = 4;
                        if (note.tone == 'B') Ynotelocation = -3;
                        if (note.tone == 'C') Ynotelocation = -11;
                        if (note.tone == 'D') Ynotelocation = -19;
                        if (note.tone == 'E') Ynotelocation = -26;
                        if (note.tone == 'F') Ynotelocation = -34;
                        if (note.tone == 'G') Ynotelocation = 10;

                        e.Graphics.DrawImage(sign.image, Xnotelocation, Ynotelocation, 90, 130);
                        if (note.noteName == NoteName.wholeNote) Xnotelocation += 336;
                        if (note.noteName == NoteName.halfNote) Xnotelocation += 168;
                        if (note.noteName == NoteName.quarterNote) Xnotelocation += 84;
                        if (note.noteName == NoteName.eightNote) Xnotelocation += 42;
                        if (note.noteName == NoteName.sixteenthNote) Xnotelocation += 21;
                        
                    }
                    else if (sign is Rest rest)
                    {

                    }
                    
                }
                x_bar += 375;
            }     
        }


        private void StaffView_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine(PointToClient(Cursor.Position).Y);
            if (ComposeView.tempBool)
            {                
                char tone = 'E';
                Console.WriteLine(PointToClient(Cursor.Position).Y);

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
                    if(PointToClient(Cursor.Position).X < barEnd  && PointToClient(Cursor.Position).X > barBegin)
                    bar.Notes.Add(new Note(ComposeView.tempNotenaam, tone));
                    barBegin += 375;
                    barEnd += 375;
                }

                Invalidate();
                ComposeView.tempBool = false;
            }
        }

    }
}
