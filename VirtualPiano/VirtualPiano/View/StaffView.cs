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
using VirtualPiano.View;
using System.Threading;

namespace VirtualPiano.View
{
    public partial class StaffView : UserControl
    {
        public Staff staff;
        public RedLine redLine;
        Color barColor;


        public StaffView(Staff staff, int flatsharp)
        {
            this.staff = staff;
            foreach (Bar bar in staff.Bars)
            {
                bar.FlatSharp = flatsharp;
            }
            DoubleBuffered = true;
            SetImage();
            InitializeComponent();
            redLine = new RedLine();
            BringToFront();
            Controls.Add(redLine);
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
            e.Graphics.DrawLine(penBlack, 10, 50, 10, 110);  //Eerste verticale lijn
            int i = 0;
            while (i < 5) //5 horizontale lijnen
            {
                e.Graphics.DrawLine(penBlack, 10, 50 + i * 15, 1764, 50 + i * 15);
                i++;
            }
        }
        public void InvalidateRedLine()
        {
            if (staff.IsBeingPlayed)
            {
                redLine.Visible = true;
                redLine.Invalidate();

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
            int x_bar = 475;
            int Xnotelocation = 0;
            ClefName latestClef = ClefName.NULL;
            foreach (Bar bar in staff.Bars) // Elke bar in de notenbalk wordt langsgegaan
            {
                //Sleutels tekenen
                if(staff.Bars.First() == bar) //Bij eerste maat: sleutel groter tekenen en kruizen/mollen tekenen
                {
                    //De sleutels worden alleen getekent als de sleutel niet hetzelfde is als de vorige
                    if (bar.clef == ClefName.G.ToString() && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 470, 26, 60, 110); latestClef = ClefName.G; }
                    else if (bar.clef == ClefName.F.ToString() && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 483, -19, 88, 185); latestClef = ClefName.F; }

                    //Hieronder worden de kruizen en de mollen getekent. afhankelijk van het aantal
                    if (bar.FlatSharp >= 1) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 420, 30, 30, 40); }
                    if (bar.FlatSharp >= 2) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 405, 53, 30, 40); }
                    if (bar.FlatSharp >= 3) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 405, 25, 30, 40); }
                    if (bar.FlatSharp >= 4) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 426, 47, 30, 40); }
                    if (bar.FlatSharp >= 5) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 420, 65, 30, 40); }

                    if (bar.FlatSharp <= -1) { e.Graphics.DrawImage(Resources.Mol, x_bar - 420, 52, 30, 40); }
                    if (bar.FlatSharp <= -2) { e.Graphics.DrawImage(Resources.Mol, x_bar - 405, 28, 30, 40); }
                    if (bar.FlatSharp <= -3) { e.Graphics.DrawImage(Resources.Mol, x_bar - 405, 59, 30, 40); }
                    if (bar.FlatSharp <= -4) { e.Graphics.DrawImage(Resources.Mol, x_bar - 426, 36, 30, 40); }
                    if (bar.FlatSharp <= -5) { e.Graphics.DrawImage(Resources.Mol, x_bar - 420, 67, 30, 40); }
                } else 
                {
                    if (bar.clef == ClefName.G.ToString() && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 470, 43, 40, 83); latestClef = ClefName.G; }
                    else if (bar.clef == ClefName.F.ToString() && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 493, -5, 77, 155); latestClef = ClefName.F; }
                }

                e.Graphics.DrawLine(new Pen(Color.Black),x_bar,50,x_bar,110); //per maat verticale lijn tekenen
                if (bar.isFull)
                {
                    barColor = Color.Green;     //als maat vol is: groene lijn, anders: rood
                    fullBar++;
                }

                else
                {
                    barColor = Color.Red;
                }
                e.Graphics.DrawLine(new Pen(barColor, 5), x_bar - 430, 145, x_bar, 145);   
                Xnotelocation = x_bar - 450; // De x-coördinaat van het einde van de maat
                if (fullBar == 4)
                {
                    e.Graphics.DrawLine(new Pen(Color.WhiteSmoke, 5), 10, 145, 1765, 145);
                }

                // Hier worden de noten en rusten getekent
                foreach (Sign sign in bar.Signs)
                {
                    //Noten
                    if (sign is Note note) { 

                        if (note.ConnectionNote != null)     //noten die aan elkaar zitten tekenen
                        {
                            e.Graphics.DrawLine(new Pen(Color.Black, 8), note.x + 8, note.y + 15, note.ConnectionNote.x + 10, note.ConnectionNote.y + 15);
                        }

                    int Ynotelocation = note.y; 

                        //Als de noten te hoog of te heel laag zijn voor de notenbalk, worden er hulplijnen getkent.
                        if(note.y <= -25){ e.Graphics.DrawLine(new Pen(Color.Black, 2), Xnotelocation +30, 36, Xnotelocation + 70, 36);}
                        if (note.y <= - 40){ e.Graphics.DrawLine(new Pen(Color.Black, 2), Xnotelocation + 30, 22, Xnotelocation + 70, 22);}
                        else if (note.y >= 55){ e.Graphics.DrawLine(new Pen(Color.Black, 2), Xnotelocation + 30, 124, Xnotelocation + 70, 124); }


                        e.Graphics.DrawImage(sign.image, Xnotelocation, Ynotelocation, 90, 130);
                        note.SetX(Xnotelocation);

                        // De volgende noot wordt getekent op een afstand afhankelijk van de lengte van deze noot
                        if (note.noteName == NoteName.WholeNote.ToString()) Xnotelocation += 400; 
                        else if(note.noteName == NoteName.HalfNote.ToString()) Xnotelocation += 200; //De volgende noot wordt getekent op een afstand van 200
                        else if(note.noteName == NoteName.QuarterNote.ToString()) Xnotelocation += 100;
                        else if(note.noteName == NoteName.EightNote.ToString()) Xnotelocation += 50;
                        else if(note.noteName == NoteName.SixteenthNote.ToString()) Xnotelocation += 25;
                        
                    }
                    else if (sign is Rest rest)
                    {
                        if (rest.restName == RestName.WholeRest.ToString()) { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Xnotelocation + 220, 66, 20, 10)); }
                        else if (rest.restName == RestName.HalfRest.ToString()) { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Xnotelocation + 115, 71, 20, 10)); }
                        else if (rest.restName == RestName.QuarterRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 60, 50, 50, 61);
                        else if (rest.restName == RestName.EightRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 30, 20, 65, 115);
                        else if (rest.restName == RestName.SixteenthRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 50, 20, 65, 115);

                        // De volgende noot wordt getekent op een afstand afhankelijk van de lengte van deze rust
                        if (rest.restName == RestName.WholeRest.ToString()) Xnotelocation += 400;
                        else if (rest.restName == RestName.HalfRest.ToString()) Xnotelocation += 200;
                        else if (rest.restName == RestName.QuarterRest.ToString()) Xnotelocation += 100;
                        else if (rest.restName == RestName.EightRest.ToString()) Xnotelocation += 50;
                        else if (rest.restName == RestName.SixteenthRest.ToString()) Xnotelocation += 25;
                    }
                }
                x_bar += 430; 
            }
        }

        private void MouseActions(object sender, MouseEventArgs e)
        {
            //Als er met de linkermuisknop geklikt is
            if (e.Button == MouseButtons.Left)
            {
                //Als er een teken geselecteerd is
                if (ComposeView.signSelected)
                {
                    
                    int barBegin = 45;
                    int barEnd = 475;

                    foreach (Bar bar in staff.Bars)
                    {
                        if (PointToClient(Cursor.Position).X < 100 && ComposeView.SelectedSign == "Sharp")
                        {

                            Invalidate();
                            if(bar.FlatSharp < 0)
                            {
                                bar.FlatSharp = 0;
                            }
                            bar.FlatSharp ++;
                        }
                        if (PointToClient(Cursor.Position).X < 100 && ComposeView.SelectedSign == "Flat")
                        {

                            Invalidate();
                            if (bar.FlatSharp > 0)
                            {
                                bar.FlatSharp = 0;
                            }
                            bar.FlatSharp--;
                        }

                        //Als de positie van de muis binnen de positie van de maat valt. (bar = maat)
                        if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                        {
                            NoteName EnumNote = NoteName.NULL;
                            RestName EnumRest = RestName.NULL;
                            ClefName EnumClef = ClefName.NULL;

                            try
                            {
                                EnumNote = (NoteName)Enum.Parse(typeof(NoteName), ComposeView.SelectedSign);
                            }
                            catch (Exception) { }
                            try
                            {
                                EnumRest = (RestName)Enum.Parse(typeof(RestName), ComposeView.SelectedSign);
                            }
                            catch (Exception) { }
                            try
                            {
                                EnumClef = (ClefName)Enum.Parse(typeof(ClefName), ComposeView.SelectedSign);
                            }
                            catch (Exception) { }
                               
                               
                            

                            Note newNote = new Note(PointToClient(Cursor.Position).Y, EnumNote, bar.clef, bar.FlatSharp);
                            Rest newRest = new Rest(EnumRest);

                            if (bar.CheckBarSpace(newNote) && EnumNote != NoteName.NULL) bar.Add(newNote);  //note toevoegen als er ruimte is
                            else if (bar.CheckBarSpace(newRest) && EnumRest != RestName.NULL) bar.Add(newRest);  //rust toevoegen als er ruimte is
                            if (EnumClef == ClefName.G)
                            {
                                bar.clef = ClefName.G.ToString();
                                bar.MakeEmpty();
                            }
                            if (EnumClef == ClefName.F)
                            {
                                bar.clef = ClefName.F.ToString();
                                bar.MakeEmpty();
                            }

                            if (ComposeView.ConnectSelected)
                            {
                                foreach (Sign sign in bar.Signs)
                                {
                                    if (sign is Note note)
                                    {
                                        if (note.isLocation(PointToClient(Cursor.Position).Y, PointToClient(Cursor.Position).X) && note.ConnectionNote == null && note.noteName == NoteName.EightNote.ToString() && note != ComposeView.selectedNote1)
                                        {
                                            if (ComposeView.selectedNote1 == null && note.ConnectionNote == null) ComposeView.selectedNote1 = note;
                                            else if (note.ConnectionNote == null) ComposeView.selectedNote2 = note;


                                            if (ComposeView.selectedNote1 != null && ComposeView.selectedNote2 != null)
                                            {
                                                ComposeView.selectedNote1.image = Resources.kwartnoot;
                                                ComposeView.selectedNote2.image = Resources.kwartnoot;
                                                ComposeView.selectedNote1.ConnectionNote = ComposeView.selectedNote2;
                                                ComposeView.selectedNote2.ConnectionNote = ComposeView.selectedNote1;
                                                Invalidate();
                                                ComposeView.selectedNote1 = null;
                                                ComposeView.selectedNote2 = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        barBegin += 430;
                        barEnd += 430;
                    }
                    SetDefaultCursor();
                }
                //Als er geen teken geselecteerd is
                else
                {
                    foreach (Bar bar in staff.Bars)
                    {
                        foreach (Sign sign in bar.Signs)
                        {
                            if (sign is Note note)
                            {
                                //Speelt de aangeklikt noot af
                                if (note.isLocation(PointToClient(Cursor.Position).Y, PointToClient(Cursor.Position).X))
                                {
                                    ComposeView.pkv1.KeyReleased(note.octave, note.tone);
                                    ComposeView.pkv1.Invalidate();
                                    note.PlaySound();                                    
                                    break;
                                }
                                ComposeView.pkv1.KeyReleased(note.octave, note.tone);
                                ComposeView.pkv1.Invalidate();
                            }
                        }
                    }
                }
            }
            //Als er met de rechetrmuisknop geklikt is
            else if (e.Button == MouseButtons.Right)
            {
                int barBegin = 50;
                int barEnd = 475;

                if (!ComposeView.signSelected)
                {
                    foreach (Bar bar in staff.Bars)
                    {
                        //Als de positie van de muis overeenkomt met de bar/maat
                        if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                        {
                            if (bar.Signs.Count > 0)
                            {//Laatste noot verwijderen
                                bar.duration = bar.duration - bar.Signs.Last().duration;
                                bar.Signs.RemoveAt(bar.Signs.Count() - 1);
                                bar.isFull = false;
                            }
                        }
                        barBegin += 430;
                        barEnd += 430;
                    }
                }
                ComposeView.signSelected = false;
                ComposeView.SelectedSign = null;
                ComposeView.selectedNote1 = null;
                ComposeView.selectedNote2 = null;
            }
            Invalidate();
        }    

    //methode die de cursor op default zet en alle booleans op null zet.
        private void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
        }

        private void StaffView_MouseEnter(object sender, EventArgs e)
        {
            
            Cursor = Cursors.Default;
        }

        private void StaffView_MouseLeave(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void StaffView_MouseMove(object sender, MouseEventArgs e)
        {
            int barBegin = 50;
            int barEnd = 475;

                foreach (Bar bar in staff.Bars)
                {

                    if (bar.isFull == false && ComposeView.signSelected)
                    {
                        if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                        {
                            int Y = PointToClient(Cursor.Position).Y;
                        NoteName EnumNote = NoteName.NULL;
                        RestName EnumRest = RestName.NULL;
                        ClefName EnumClef = ClefName.NULL;

                        try
                        {
                            EnumNote = (NoteName)Enum.Parse(typeof(NoteName), ComposeView.SelectedSign);
                        }
                        catch (Exception) { }
                        try
                        {
                            EnumRest = (RestName)Enum.Parse(typeof(RestName), ComposeView.SelectedSign);
                        }
                        catch (Exception) { }
                        try
                        {
                            EnumClef = (ClefName)Enum.Parse(typeof(ClefName), ComposeView.SelectedSign);
                        }
                        catch (Exception) { }

                        Note newNote = new Note(Y, EnumNote, bar.clef.ToString(), bar.FlatSharp);
                            Rest newRest = new Rest(EnumRest);

                            if (bar.CheckBarSpace(newNote) && EnumNote != NoteName.NULL)
                            {
                                bar.Add(newNote);
                                bar.hasPreview = true;
                            }
                            else if (bar.CheckBarSpace(newRest) && EnumRest != RestName.NULL)
                            {
                                bar.clef = ClefName.G.ToString();
                                bar.Add(newRest);
                                bar.hasPreview = true;
                            }
                        }
                    }
                barBegin += 430;
                barEnd += 430;
            }

            Invalidate();
            Update();

            foreach (Bar bar in staff.Bars)
            {
                if (bar.hasPreview) bar.RemovePreview();
            }
        }

        private void StaffView_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Bar bar in staff.Bars)
            {
                foreach (Sign sign in bar.Signs)
                {
                    if (sign is Note note)
                    {
                        //Speelt de aangeklikt noot af
                        if (note.isLocation(PointToClient(Cursor.Position).Y, PointToClient(Cursor.Position).X))
                        {
                            ComposeView.pkv1.KeyPressed(note.octave, note.tone);
                            ComposeView.pkv1.Invalidate();
                            break;
                        }
                    }
                }
            }
        }
    }
}

