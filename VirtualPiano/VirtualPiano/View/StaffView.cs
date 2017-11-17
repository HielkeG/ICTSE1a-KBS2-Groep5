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
                x_bar += 375;
            }     
        }


        private void StaffView_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine(PointToClient(Cursor.Position).Y);
            if (ComposeView.tempBool)
            {
                Note note = new Note() { };
                
                note.X = PointToClient(Cursor.Position).X;
                note.Y = PointToClient(Cursor.Position).Y;
                notenbalk.Add(note);
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
