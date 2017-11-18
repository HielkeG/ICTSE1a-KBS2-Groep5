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
            DrawSigns(e);     
        }

        private void Drawlines(PaintEventArgs e)
        {
            Pen penBlack = new Pen(Color.Black);
            e.Graphics.DrawLine(penBlack, 10, 30, 10, 110);
            int i = 0;
            while (i < 5)
            {
                e.Graphics.DrawLine(penBlack, 10, 30 + i * 20, 1550, 30 + i * 20);
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
                    e.Graphics.DrawImage(Resources.gsleutel,x_bar-415,0,50,150);
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
                e.Graphics.DrawLine(new Pen(Color.Black),x_bar,30,x_bar,110);

                Xnotelocation = x_bar - 400;
                foreach(Sign sign in bar.Notes)
                {
                    int Ynotelocation = 0;
                    if (sign.tone == 'A'){ Ynotelocation = 17; }
                    if (sign.tone == 'B') { Ynotelocation = 5; }
                    if (sign.tone == 'C') { Ynotelocation = -5; }
                    if (sign.tone == 'D') { Ynotelocation = -15; }
                    if (sign.tone == 'E') { Ynotelocation = 47; }
                    if (sign.tone == 'F') { Ynotelocation = 37; }
                    if (sign.tone == 'G') { Ynotelocation = 27; }

                    e.Graphics.DrawImage(sign.image, Xnotelocation, Ynotelocation, 90, 130);
                    if(sign.noteName == NoteName.wholeNote) {Xnotelocation += 336; }
                    if (sign.noteName == NoteName.halfNote) { Xnotelocation += 168; }
                    if (sign.noteName == NoteName.quarterNote){ Xnotelocation += 84;}
                    if (sign.noteName == NoteName.eightNote){Xnotelocation += 42;}
                    if (sign.noteName == NoteName.sixteenthNote){ Xnotelocation += 21; }
                }
                x_bar += 375;
            }     
        }


        private void StaffView_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine(PointToClient(Cursor.Position).Y);
            if (ComposeView.tempBool)
            {                
                char tone = 'A';

                if (PointToClient(Cursor.Position).Y < 105 && PointToClient(Cursor.Position).Y >= 95) { tone = 'F'; }
                if (PointToClient(Cursor.Position).Y < 45 && PointToClient(Cursor.Position).Y >= 35) { tone = 'E'; }
                if (PointToClient(Cursor.Position).Y < 55 && PointToClient(Cursor.Position).Y >= 45) { tone = 'D'; }
                if (PointToClient(Cursor.Position).Y < 65 && PointToClient(Cursor.Position).Y >= 55) { tone = 'C'; }
                if (PointToClient(Cursor.Position).Y < 75 && PointToClient(Cursor.Position).Y >= 65) { tone = 'B'; }
                if (PointToClient(Cursor.Position).Y < 85 && PointToClient(Cursor.Position).Y >= 75) { tone = 'A'; }
                if (PointToClient(Cursor.Position).Y < 95 && PointToClient(Cursor.Position).Y >= 85 ) {tone = 'G';}
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

        public void DrawSigns(PaintEventArgs e)
        {
            foreach (Note noot in notenbalk)
            {
                if (noot.Y < 35) noot.Y = 30;
                else if (noot.Y < 40) noot.Y = 40;
                else if (noot.Y < 50) noot.Y = 45;
                else if (noot.Y < 60) noot.Y = 55;
                else if (noot.Y < 70) noot.Y = 65;
                else if (noot.Y < 80) noot.Y = 75;
                else if (noot.Y < 90)noot.Y = 85;
                else if (noot.Y < 100) noot.Y = 95;
                else if (noot.Y < 110) noot.Y = 105;
                else if (noot.Y < 120) noot.Y = 115;
                else if (noot.Y < 130)noot.Y = 125;
                else if (noot.Y < 140) noot.Y = 135;

                e.Graphics.DrawImage(noot.image, noot.X - noot.image.Width / 2, noot.Y - noot.image.Height / 2);
            }
        }
    }
}
