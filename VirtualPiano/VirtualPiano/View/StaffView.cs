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

        public StaffView(Staff staff, int flatsharp)
        {
            this.staff = staff;
            foreach (Bar bar in staff.Bars)
            {
                bar.FlatSharp = flatsharp;
            }
            SetImage();
            InitializeComponent();
            
        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Drawlines(e);
            DrawBars(e);     
        }

        private void Drawlines(PaintEventArgs e)    //Lijnen van notenbalk tekenen
        {
            Pen penBlack = new Pen(Color.Black);
            e.Graphics.DrawLine(penBlack, 10, 30, 10, 90);  //Eerste verticale lijn
            int i = 0;
            while (i < 5) //5 horizontale lijnen
            {
                e.Graphics.DrawLine(penBlack, 10, 30 + i * 15, 1550, 30 + i * 15);
                i++;
            }
        }

        public void SetImage()
        {
            foreach (var bar in staff.Bars)
            {
                foreach (var sign in bar.Signs)
                {
                    sign.SetImage();
                }
            }
            Refresh();
        }

        public void DrawBars(PaintEventArgs e) //Deze methode tekent de maten inclusief de noten en de sleutels
        {
            int fullBar = 0;
            int x_bar = 425;
            int Xnotelocation = 20;
            ClefName latestClef = ClefName.NULL;
            foreach (Bar bar in staff.Bars) // Elke bar in de notenbalk wordt langsgegaan
            {
                //Sleutels tekenen
                if(staff.Bars.First() == bar) //Bij eerste maat: sleutel groter tekenen
                {
                    //De sleutels worden alleen getekent als de sleutel niet hetzelfde is als de vorige
                    if (bar.clef == ClefName.G.ToString() && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 420, 6, 60, 110); latestClef = ClefName.G; }
                    if (bar.clef == ClefName.F.ToString() && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 430, -39, 88, 185); latestClef = ClefName.F; }
                    if (bar.clef == ClefName.C.ToString() && latestClef != ClefName.C) { latestClef = ClefName.C; }
                    if (bar.FlatSharp >= 1) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 380, 10, 30, 40); }
                    if (bar.FlatSharp >= 2) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 365, 33, 30, 40); }
                    if (bar.FlatSharp >= 3) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 365, 5, 30, 40); }
                    if (bar.FlatSharp >= 4) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 386, 27, 30, 40); }
                    if (bar.FlatSharp >= 5) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 380, 45, 30, 40); }

                    if (bar.FlatSharp <= -1) { e.Graphics.DrawImage(Resources.Mol, x_bar - 380, 32, 30, 40); }
                    if (bar.FlatSharp <= -2) { e.Graphics.DrawImage(Resources.Mol, x_bar - 365, 8, 30, 40); }
                    if (bar.FlatSharp <= -3) { e.Graphics.DrawImage(Resources.Mol, x_bar - 365, 39, 30, 40); }
                    if (bar.FlatSharp <= -4) { e.Graphics.DrawImage(Resources.Mol, x_bar - 386, 16, 30, 40); }
                    if (bar.FlatSharp <= -5) { e.Graphics.DrawImage(Resources.Mol, x_bar - 380, 47, 30, 40); }
                } else 
                {
                    if (bar.clef == ClefName.G.ToString() && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 414, 23, 40, 83); latestClef = ClefName.G; }
                    if (bar.clef == ClefName.F.ToString() && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 440, -25, 77, 155); latestClef = ClefName.F; }
                    if (bar.clef == ClefName.C.ToString() && latestClef != ClefName.C) { latestClef = ClefName.C; }
                }
               

                e.Graphics.DrawLine(new Pen(Color.Black),x_bar,30,x_bar,90); //per maat verticale lijn tekenen
                if (bar.isFull)
                {
                    barColor = Color.Green;     //als maat vol is: groene lijn, anders: rood
                    fullBar++;
                }

                else
                {
                    barColor = Color.Red;
                }
                e.Graphics.DrawLine(new Pen(barColor, 5), x_bar - 375, 125, x_bar, 125);   
                Xnotelocation = x_bar - 400; // De x-coördinaat van het einde van de maat
                if (fullBar == 4)
                {
                    e.Graphics.DrawLine(new Pen(Color.WhiteSmoke, 5), 10, 125, 1550, 125);
                }
                foreach (Sign sign in bar.Signs)
                {
                    if (sign is Note note) 
                    {
                        note.SetY(bar.clef.ToString());
                        int Ynotelocation = note.y; 
                        e.Graphics.DrawImage(sign.image, Xnotelocation, Ynotelocation, 90, 130);
                        note.SetX(Xnotelocation);

                        if (note.noteName == NoteName.wholeNote.ToString()) Xnotelocation += 336; 
                        else if(note.noteName == NoteName.halfNote.ToString()) Xnotelocation += 168; //De volgende noot wordt getekent op een afstand van 168
                        else if(note.noteName == NoteName.quarterNote.ToString()) Xnotelocation += 84;
                        else if(note.noteName == NoteName.eightNote.ToString()) Xnotelocation += 42;
                        else if(note.noteName == NoteName.sixteenthNote.ToString()) Xnotelocation += 21;
                        
                    }
                    else if (sign is Rest rest)
                    {
                        if (rest.restName == RestName.wholeRest.ToString()) { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Xnotelocation + 180, 46, 20, 10)); }
                        else if (rest.restName == RestName.halfRest.ToString()) { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Xnotelocation + 110, 51, 20, 10)); }


                        else if (rest.restName == RestName.quarterRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 60, 30, 50, 61);
                        else if (rest.restName == RestName.eightRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 30, 0, 65, 115);
                        else if (rest.restName == RestName.sixteenthRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 30, 0, 65, 115);

                        if (rest.restName == RestName.wholeRest.ToString()) Xnotelocation += 336;
                        else if(rest.restName == RestName.halfRest.ToString()) Xnotelocation += 168;
                        else if(rest.restName == RestName.quarterRest.ToString()) Xnotelocation += 84;
                        else if(rest.restName == RestName.eightRest.ToString()) Xnotelocation += 42;
                        else if(rest.restName == RestName.sixteenthRest.ToString()) Xnotelocation += 21;
                    }
                }
                x_bar += 375; 
            }
        }

        private void MouseActions(object sender, MouseEventArgs e) //als linkermuisknop niet meer wordt ingedrukt
        {

            if (e.Button == MouseButtons.Left)
            {
                if (ComposeView.signSelected)
                {
                    int barBegin = 50;
                    int barEnd = 425;

                    foreach (Bar bar in staff.Bars)
                    {
                        if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                        {
                            Note newNote = new Note(PointToClient(Cursor.Position).Y, ComposeView.SelectedNoteName, bar.clef, bar.FlatSharp);
                            Rest newRest = new Rest(ComposeView.SelectedRestName);

                            if (bar.CheckBarSpace(newNote) && ComposeView.SelectedNoteName != NoteName.NULL) bar.Add(newNote);  //note toevoegen als er ruimte is
                            else if (bar.CheckBarSpace(newRest) && ComposeView.SelectedRestName != RestName.NULL) bar.Add(newRest);  //rust toevoegen als er ruimte is
                            if (ComposeView.SelectedClefName == ClefName.G)
                            {
                                bar.clef = ClefName.G.ToString();
                                bar.MakeEmpty();
                            }
                            if (ComposeView.SelectedClefName == ClefName.F)
                            {
                                bar.clef = ClefName.F.ToString();
                                bar.MakeEmpty();
                            }
                        }
                        barBegin += 375;
                        barEnd += 375;
                    }
                    Invalidate();
                    SetDefaultCursor();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    foreach (Bar bar in staff.Bars)
                    {
                        foreach (Sign sign in bar.Signs)
                        {
                            if (sign is Note note)
                            {
                                if (note.x - 10 < PointToClient(Cursor.Position).X && note.x + 10 > PointToClient(Cursor.Position).X && note.y - 10 < PointToClient(Cursor.Position).Y - 63 && note.y + 10 > PointToClient(Cursor.Position).Y - 63)
                                {
                                    note.PlaySound();
                                }
                            }
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                int barBegin = 50;
                int barEnd = 425;

                foreach (Bar bar in staff.Bars)
                {
                    if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                    {
                        if (bar.Signs.Count > 0)
                        {
                            bar.duration = bar.duration - bar.Signs.Last().duration;
                            bar.Signs.RemoveAt(bar.Signs.Count() - 1);
                            bar.isFull = false;
                        }
                    }
                    barBegin += 375;
                    barEnd += 375;
                }
            }
            Invalidate();
        }    

        public static Note CreateNote(int y, NoteName tempNotename, string clef) //Geeft een noot op basis van y-coordinaat, nootnaam en muzieksleutel.
        {
            string tone = " ";
            int octave = 0;
            
            if (clef == ClefName.G.ToString())
            {
                if (y < 25 && y >= 14) { tone = "G"; octave = 4; }
                if (y < 33 && y >= 25) { tone = "F"; octave = 4; }
                if (y < 41 && y >= 33) { tone = "E"; octave = 4; }
                if (y < 48 && y >= 41) { tone = "D"; octave = 4; }
                if (y < 55 && y >= 48) { tone = "C"; octave = 4; }
                if (y < 63 && y >= 55) { tone = "B"; octave = 3; }
                if (y < 72 && y >= 63) { tone = "A"; octave = 3; }
                if (y < 78 && y >= 72) { tone = "G"; octave = 3; }
                if (y < 86 && y >= 78) { tone = "F"; octave = 3; }
                if (y < 94 && y >= 86) { tone = "E"; octave = 3; }
                if (y < 100 && y >= 94) { tone = "D"; octave = 3; }
                if (y < 107 && y >= 100) { tone = "C"; octave = 3; }

                return new Note(tempNotename, tone, octave);

            }
            if (clef == ClefName.F.ToString())
            {
                if (y < 25 && y >= 14) { tone = "B"; octave = 2; }
                if (y < 33 && y >= 25) { tone = "A"; octave = 2; }
                if (y < 41 && y >= 33) { tone = "G"; octave = 2; }
                if (y < 48 && y >= 41) { tone = "F"; octave = 2; }
                if (y < 55 && y >= 48) { tone = "E"; octave = 2; }
                if (y < 63 && y >= 55) { tone = "D"; octave = 2; }
                if (y < 72 && y >= 63) { tone = "C"; octave = 2; }
                if (y < 78 && y >= 72) { tone = "B"; octave = 1; }
                if (y < 86 && y >= 78) { tone = "A"; octave = 1; }
                if (y < 94 && y >= 86) { tone = "G"; octave = 1; }
                if (y < 100 && y >= 94) { tone = "F"; octave = 1; }
                if (y < 107 && y >= 100) { tone = "E"; octave = 1; }

                return new Note(tempNotename, tone, octave);
            }

            return null;

        }
        //methode die de cursor op default zet en alle booleans op null zet.
        private void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
            ComposeView.signSelected = false;
            ComposeView.SelectedNoteName = NoteName.NULL;
            ComposeView.SelectedRestName = RestName.NULL;
            ComposeView.SelectedClefName = ClefName.NULL;
        }

        private void StaffView_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
