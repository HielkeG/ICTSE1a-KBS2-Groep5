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

        public void DrawBars(PaintEventArgs e) //Deze methode tekent de maten inclusief de noten en de sleutels
        {
            int x_bar = 425;
            int Xnotelocation = 20;
            ClefName latestClef = ClefName.NULL;
            foreach (Bar bar in staff.Bars) // Elke bar in de notenbalk wordt langsgegaan
            {
                //Sleutels tekenen
                if(staff.Bars.First() == bar) //Bij eerste maat: sleutel groter tekenen
                {
                    //De sleutels worden alleen getekent als de sleutel niet hetzelfde is als de vorige
                    if (bar.clef == ClefName.G && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 420, 6, 60, 110); latestClef = ClefName.G; }
                    if (bar.clef == ClefName.F && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 430, -39, 88, 185); latestClef = ClefName.F; }
                    if (bar.clef == ClefName.C && latestClef != ClefName.C) { latestClef = ClefName.C; }
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
                    if (bar.clef == ClefName.G && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 414, 23, 40, 83); latestClef = ClefName.G; }
                    if (bar.clef == ClefName.F && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 440, -25, 77, 155); latestClef = ClefName.F; }
                    if (bar.clef == ClefName.C && latestClef != ClefName.C) { latestClef = ClefName.C; }
                }
                //fcgdaeb
                //beadg
               

                e.Graphics.DrawLine(new Pen(Color.Black),x_bar,30,x_bar,90); //per maat verticale lijn tekenen

                if (bar.isFull) barColor = Color.Green;     //als maat vol is: groene lijn, anders: rood
                else barColor = Color.Red;
                e.Graphics.DrawLine(new Pen(barColor, 5), x_bar - 375, 125, x_bar, 125);   
                Xnotelocation = x_bar - 400; // De x-coördinaat van het einde van de maat
                
                foreach(Sign sign in bar.signs)
                {
                    if (sign is Note note) 
                    {
                        note.SetY(bar.clef);
                        int Ynotelocation = note.y; 
                        e.Graphics.DrawImage(sign.image, Xnotelocation, Ynotelocation, 90, 130);
                        note.SetX(Xnotelocation);

                        if (note.noteName == NoteName.wholeNote) Xnotelocation += 336; 
                        else if(note.noteName == NoteName.halfNote) Xnotelocation += 168; //De volgende noot wordt getekent op een afstand van 168
                        else if(note.noteName == NoteName.quarterNote) Xnotelocation += 84;
                        else if(note.noteName == NoteName.eightNote) Xnotelocation += 42;
                        else if(note.noteName == NoteName.sixteenthNote) Xnotelocation += 21;
                        
                    }
                    else if (sign is Rest rest)
                    {
                        if (rest.restName == RestName.wholeRest) { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Xnotelocation + 180, 46, 20, 10)); }
                        else if (rest.restName == RestName.halfRest) { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Xnotelocation + 110, 51, 20, 10)); }


                        else if (rest.restName == RestName.quarterRest) e.Graphics.DrawImage(rest.image, Xnotelocation + 60, 30, 50, 61);
                        else if (rest.restName == RestName.eightRest) e.Graphics.DrawImage(rest.image, Xnotelocation + 30, 0, 65, 115);
                        else if (rest.restName == RestName.sixteenthRest) e.Graphics.DrawImage(rest.image, Xnotelocation + 30, 0, 65, 115);

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


        private void StaffView_MouseUp(object sender, MouseEventArgs e) //als linkermuisknop niet meer wordt ingedrukt
        {
            if (ComposeView.signSelected)
            {

                int barBegin = 50;
                int barEnd = 425;
                int countto4 = 1;
                foreach (Bar bar in staff.Bars)
                {
                    if (ComposeView.FlatSharp == 1) { bar.FlatSharp++; }
                    if (ComposeView.FlatSharp == -1) { bar.FlatSharp--; }
                    if (countto4 == 4)
                    {
                        ComposeView.FlatSharp = 0;
                    }
                    
                    if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                    {
                        
                        //Note newNote = CreateNote(PointToClient(Cursor.Position).Y, ComposeView.SelectedNoteName, bar.clef);
                        Note newNote = new Note(PointToClient(Cursor.Position).Y, ComposeView.SelectedNoteName, bar.clef, bar.FlatSharp);
                        Rest newRest = new Rest(ComposeView.SelectedRestName);

                        if (bar.CheckBarSpace(newNote) && ComposeView.SelectedNoteName != NoteName.NULL) bar.Add(newNote);  //note toevoegen als er ruimte is
                        if (bar.CheckBarSpace(newRest) && ComposeView.SelectedRestName != RestName.NULL) bar.Add(newRest);  //rust toevoegen als er ruimt is
                        if (ComposeView.SelectedClefName == ClefName.G)
                        {
                            bar.clef = ClefName.G;
                            bar.MakeEmpty();
                        }
                        if (ComposeView.SelectedClefName == ClefName.F)
                        {
                            bar.clef = ClefName.F;
                            bar.MakeEmpty();
                        }
                    }
                    barBegin += 375;
                    barEnd += 375;
                    countto4++;
                }
                Invalidate();
                SetDefaultCursor();
            }
            else {
                foreach(Bar bar in staff.Bars)
                {
                    foreach(Sign sign in bar.signs)
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
            //wanneer de muis dit gebied binnenkomt controleren hoe de variabelen staan en zo de cursor veranderen.
            if (ComposeView.SelectedNoteName != NoteName.NULL)
            {
                Cursor = CursorController.ChangeCursor(ComposeView.SelectedNoteName);
            }
            else if(ComposeView.SelectedClefName != ClefName.NULL)
            {
                Cursor = CursorController.ChangeCursor(ComposeView.SelectedClefName);
            }
            else if (ComposeView.SelectedRestName != RestName.NULL)
            {
                Cursor = CursorController.ChangeCursor(ComposeView.SelectedRestName);
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
