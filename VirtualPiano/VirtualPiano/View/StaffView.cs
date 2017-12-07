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
        public Song song;
        
        Color barColor;


        public StaffView(Staff staff, Song song)
        {
            this.staff = staff;
            this.song = song;
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
                if (staff.Bars.First() == bar) //Bij eerste maat: sleutel groter tekenen en kruizen/mollen tekenen
                {
                    //De sleutels worden alleen getekent als de sleutel niet hetzelfde is als de vorige
                    if (bar.clef == ClefName.G.ToString() && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 470, 26, 60, 110); latestClef = ClefName.G; }
                    else if (bar.clef == ClefName.F.ToString() && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 483, -19, 88, 185); latestClef = ClefName.F; }

                    //Hieronder worden de kruizen en de mollen getekent. afhankelijk van het aantal
                    if (song.FlatSharp >= 1) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 420, 30, 30, 40); }
                    if (song.FlatSharp >= 2) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 405, 53, 30, 40); }
                    if (song.FlatSharp >= 3) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 405, 25, 30, 40); }
                    if (song.FlatSharp >= 4) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 426, 47, 30, 40); }
                    if (song.FlatSharp >= 5) { e.Graphics.DrawImage(Resources.Kruis, x_bar - 420, 65, 30, 40); }

                    if (song.FlatSharp <= -1) { e.Graphics.DrawImage(Resources.Mol, x_bar - 420, 52, 30, 40); }
                    if (song.FlatSharp <= -2) { e.Graphics.DrawImage(Resources.Mol, x_bar - 405, 28, 30, 40); }
                    if (song.FlatSharp <= -3) { e.Graphics.DrawImage(Resources.Mol, x_bar - 405, 59, 30, 40); }
                    if (song.FlatSharp <= -4) { e.Graphics.DrawImage(Resources.Mol, x_bar - 426, 36, 30, 40); }
                    if (song.FlatSharp <= -5) { e.Graphics.DrawImage(Resources.Mol, x_bar - 420, 67, 30, 40); }
                }
                else
                {
                    if (bar.clef == ClefName.G.ToString() && latestClef != ClefName.G) { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 470, 43, 40, 83); latestClef = ClefName.G; }
                    else if (bar.clef == ClefName.F.ToString() && latestClef != ClefName.F) { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 493, -5, 77, 155); latestClef = ClefName.F; }
                }

                e.Graphics.DrawLine(new Pen(Color.Black), x_bar, 50, x_bar, 110); //per maat verticale lijn tekenen
                if (bar.duration == 16)
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
                    if (sign is Note note)
                    {

                        if (note.ConnectionNote != null)     //noten die aan elkaar zitten tekenen
                        {
                            if(note.name == NoteName.EightNote.ToString())
                            {
                                e.Graphics.DrawLine(new Pen(Color.Black, 6), note.x + 8, note.y + 15, note.ConnectionNote.x + 10, note.ConnectionNote.y + 15);
                            } else
                            {
                                e.Graphics.DrawLine(new Pen(Color.Black, 5), note.x + 8, note.y + 15, note.ConnectionNote.x + 10, note.ConnectionNote.y + 15);
                                e.Graphics.DrawLine(new Pen(Color.Black, 5), note.x + 8, note.y + 23, note.ConnectionNote.x + 10, note.ConnectionNote.y + 23);
                            }
                            
                        }

                        int Ynotelocation = note.y;

                        //Als de noten te hoog of te heel laag zijn voor de notenbalk, worden er hulplijnen getkent.
                        if (note.y <= -25) { e.Graphics.DrawLine(new Pen(Color.Black, 2), Xnotelocation + 30, 36, Xnotelocation + 70, 36); }
                        if (note.y <= -40) { e.Graphics.DrawLine(new Pen(Color.Black, 2), Xnotelocation + 30, 22, Xnotelocation + 70, 22); }
                        else if (note.y >= 55) { e.Graphics.DrawLine(new Pen(Color.Black, 2), Xnotelocation + 30, 124, Xnotelocation + 70, 124); }


                        e.Graphics.DrawImage(sign.image, Xnotelocation, Ynotelocation, 90, 130);
                        if (note.sharp == true) { e.Graphics.DrawImage(Resources.Kruis, Xnotelocation + 15, Ynotelocation + 40, 30, 40); }
                        else if (note.flat == true) { e.Graphics.DrawImage(Resources.Mol, Xnotelocation + 15, Ynotelocation + 40, 30, 40); }
                        note.SetX(Xnotelocation);

                        // De volgende noot wordt getekent op een afstand afhankelijk van de lengte van deze noot
                        if (note.name == NoteName.WholeNote.ToString()) Xnotelocation += 400;
                        else if (note.name == NoteName.HalfNote.ToString()) Xnotelocation += 200; //De volgende noot wordt getekent op een afstand van 200
                        else if (note.name == NoteName.QuarterNote.ToString()) Xnotelocation += 100;
                        else if (note.name == NoteName.EightNote.ToString()) Xnotelocation += 50;
                        else if (note.name == NoteName.SixteenthNote.ToString()) Xnotelocation += 25;

                    }
                    else if (sign is Rest rest)
                    {
                        if (rest.name == RestName.WholeRest.ToString()) { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Xnotelocation + 220, 66, 20, 10)); }
                        else if (rest.name == RestName.HalfRest.ToString()) { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(Xnotelocation + 115, 71, 20, 10)); }
                        else if (rest.name == RestName.QuarterRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 60, 50, 50, 61);
                        else if (rest.name == RestName.EightRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 30, 20, 65, 115);
                        else if (rest.name == RestName.SixteenthRest.ToString()) e.Graphics.DrawImage(rest.image, Xnotelocation + 50, 20, 65, 115);

                        // De volgende noot wordt getekent op een afstand afhankelijk van de lengte van deze rust
                        if (rest.name == RestName.WholeRest.ToString()) Xnotelocation += 400;
                        else if (rest.name == RestName.HalfRest.ToString()) Xnotelocation += 200;
                        else if (rest.name == RestName.QuarterRest.ToString()) Xnotelocation += 100;
                        else if (rest.name == RestName.EightRest.ToString()) Xnotelocation += 50;
                        else if (rest.name == RestName.SixteenthRest.ToString()) Xnotelocation += 25;
                    }
                }
                x_bar += 430;
            }
        }

        private void StaffView_MouseUp(object sender, MouseEventArgs e)
        {
            if (ComposeView.draggingSign != null)
            {
                if (ComposeView.draggingSign.name == NoteName.WholeNote.ToString()) { ComposeView.draggingSign.image = Resources.helenoot; }
                else if (ComposeView.draggingSign.name == NoteName.HalfNote.ToString()) { ComposeView.draggingSign.image = Resources.halvenoot; }
                else if (ComposeView.draggingSign.name == NoteName.QuarterNote.ToString()) { ComposeView.draggingSign.image = Resources.kwartnoot; }
                else if (ComposeView.draggingSign.name == NoteName.EightNote.ToString()) { ComposeView.draggingSign.image = Resources.achtstenoot; }
                else if (ComposeView.draggingSign.name == NoteName.SixteenthNote.ToString()) { ComposeView.draggingSign.image = Resources.zestiendenoot; }
            }
            ComposeView.cursorIsDown = false;
            Console.WriteLine(ComposeView.SelectedSign);
            if(ComposeView.SelectedSign != "Connect1" && ComposeView.SelectedSign != "Connect2")
            {
              SetDefaultCursor();
              ComposeView.SelectedSign = "";
            }
            
        }

        //methode die de cursor op default zet en alle booleans op null zet.
        private void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
        }

       
        private void StaffView_MouseEnter(object sender, EventArgs e)
        {
            //Standaard cursor zetten voor noten en rusten
            if (ComposeView.SelectedSign == "G" || ComposeView.SelectedSign == "F" || ComposeView.SelectedSign == "Sharp" || ComposeView.SelectedSign == "Flat" || ComposeView.SelectedSign == "Connect" || ComposeView.SelectedSign == "Bin") Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
            else { SetDefaultCursor(); }
            
            if (ComposeView.SelectedSign == "Connect1")
            {
                Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect1));
            }
            if (ComposeView.SelectedSign == "Connect2")
            {
                Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect2));
            }
        }

       

        private void StaffView_MouseMove(object sender, MouseEventArgs e)
        {
            //------Preview tonen--------
            int barBegin = 50;
            int barEnd = 475;

            foreach (Bar bar in staff.Bars)
            {

                if (bar.duration < 16 && ComposeView.signSelected)
                {
                    if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                    {
                        int Y = PointToClient(Cursor.Position).Y;

                        // ------Note-----
                        if (ComposeView.SelectedSign.Contains("Note"))
                        {
                            NoteName EnumNote = (NoteName)Enum.Parse(typeof(NoteName), ComposeView.SelectedSign);
                            Note newNote = new Note(PointToClient(Cursor.Position).Y, EnumNote, bar.clef, song.FlatSharp);
                            if (bar.CheckBarSpace(newNote) && EnumNote != NoteName.NULL)
                            {
                                bar.Add(newNote);
                                bar.hasPreview = true;
                            }  //note toevoegen als er ruimte is
                        }
                        // -----Rest-----
                        else if (ComposeView.SelectedSign.Contains("Rest"))
                        {
                            RestName EnumRest = (RestName)Enum.Parse(typeof(RestName), ComposeView.SelectedSign);
                            Rest newRest = new Rest(EnumRest);
                            if (bar.CheckBarSpace(newRest) && EnumRest != RestName.NULL)
                            {
                                bar.Add(newRest);
                                bar.hasPreview = true;
                            }
                            //rest toevoegen als er ruimte is
                        }
                        // -----Clef----
                        //else if (ComposeView.SelectedSign == "G" || ComposeView.SelectedSign == "F")
                        //{
                        //    ClefName EnumClef = (ClefName)Enum.Parse(typeof(ClefName), ComposeView.SelectedSign);

                        //    if (EnumClef == ClefName.G)
                        //    {
                        //        bar.clef = ClefName.G.ToString();
                        //        bar.MakeEmpty();
                        //    }
                        //    if (EnumClef == ClefName.F)
                        //    {
                        //        bar.clef = ClefName.F.ToString();
                        //        bar.MakeEmpty();
                        //    }
                        //}
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

        //-----Methode wordt aangeroepen als een muisklik ingedrukt wordt
        private async void StaffView_MouseDown(object sender, MouseEventArgs e)
        {
            ComposeView.cursorIsDown = true;
            //Wanneer geen teken geselcteerds is en wanneer de linkermuisknop ingedrukt is
            if (ComposeView.signSelected == false && e.Button == MouseButtons.Left)
            {
                foreach (Bar bar in staff.Bars)
                {
                    for (int i = 0; i < bar.Signs.Count(); i++)
                    {
                        Sign sign = bar.Signs[i];

                        //Als er een coordinaat van een teken overeenkomt met de coordinatie van de muis
                        if (sign.IsLocation(PointToClient(Cursor.Position).Y, PointToClient(Cursor.Position).X))
                        {
                            //Als het een noot is, wordt de noot afgespeeld
                            if (sign is Note note)
                            {
                                note.PlaySound();
                            }

                            //Als de muis na 300 miliseconden nog steeds ingedrukt is, wordt het teken verslepen
                            await PutTaskDelay(300);
                            if (ComposeView.cursorIsDown == true)
                            {
                                //De cursor veranderd in de aangeklikte noot
                                Cursor = CursorController.ChangeCursor(sign.name);
                                ComposeView.SelectedSign = sign.name;
                                sign.image = Resources.blank;
                                ComposeView.draggingSign = sign;
                                Console.WriteLine(ComposeView.draggingSign.name);
                                Invalidate();
                            }
                        }
                    }
                }
            }
        }

        private void StaffView_MouseClick(object sender, MouseEventArgs e)
        {

            //Als er met de linkermuisknop geklikt is
            if (e.Button == MouseButtons.Left)
            {
                //Als er een teken geselecteerd is
                if (ComposeView.signSelected)
                {

                    int barBegin = 45;
                    int barEnd = 475;

                    //Kruizen en Mollen toevoegen aan het begin
                    if (PointToClient(Cursor.Position).X < 100 && ComposeView.SelectedSign == "Sharp")
                    {
                        if (song.FlatSharp < 0) { song.FlatSharp = 0; }
                        song.FlatSharp++;
                        song.ChangeSharpFlat(song.FlatSharp);
                    }
                    if (PointToClient(Cursor.Position).X < 100 && ComposeView.SelectedSign == "Flat")
                    {
                        if (song.FlatSharp > 0) { song.FlatSharp = 0; }
                        song.FlatSharp--;
                        song.ChangeSharpFlat(song.FlatSharp);
                    }


                    foreach (Bar bar in staff.Bars)
                    {

                        //Als de positie van de muis binnen de positie van de maat valt. (bar = maat)
                        if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                        {

                            // ------Note-----
                            if (ComposeView.SelectedSign.Contains("Note"))
                            {
                                NoteName EnumNote = (NoteName)Enum.Parse(typeof(NoteName), ComposeView.SelectedSign);
                                Note newNote = new Note(PointToClient(Cursor.Position).Y, EnumNote, bar.clef, song.FlatSharp);
                                if (bar.CheckBarSpace(newNote) && EnumNote != NoteName.NULL) bar.Add(newNote);  //note toevoegen als er ruimte is
                            }
                            // -----Rest-----
                            else if (ComposeView.SelectedSign.Contains("Rest"))
                            {
                                RestName EnumRest = (RestName)Enum.Parse(typeof(RestName), ComposeView.SelectedSign);
                                Rest newRest = new Rest(EnumRest);
                                if (bar.CheckBarSpace(newRest) && EnumRest != RestName.NULL) bar.Add(newRest);  //rest toevoegen als er ruimte is
                            }
                            // -----Clef----
                            else if (ComposeView.SelectedSign == "G" || ComposeView.SelectedSign == "F")
                            {
                                ClefName EnumClef = (ClefName)Enum.Parse(typeof(ClefName), ComposeView.SelectedSign);

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
                            }

                            foreach (Sign sign in bar.Signs)
                            {
                                if (sign is Note note)
                                {
                                    // -------Connect------
                                    if (ComposeView.SelectedSign == "Connect2")
                                    {
                                        if (note.IsLocation(PointToClient(Cursor.Position).Y, PointToClient(Cursor.Position).X) && note.ConnectionNote == null && note != ComposeView.selectedNote1)
                                        {
                                           if (note.ConnectionNote == null && bar.Signs.Contains(ComposeView.selectedNote1))
                                            {
                                                int index1 = bar.Signs.IndexOf(ComposeView.selectedNote1);
                                                int index2 = bar.Signs.IndexOf(note);
                                                if ((index1 - index2 == 1 || index1 - index2 == -1) && note.name == ComposeView.selectedNote1.name)
                                                {
                                                    ComposeView.selectedNote2 = note;
                                                }
                                            }
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
                                            SetDefaultCursor();
                                            ComposeView.SelectedSign = "";
                                        }
                                        
                                    }
                                    if (ComposeView.SelectedSign == "Connect1")
                                    {
                                        if (note.IsLocation(PointToClient(Cursor.Position).Y, PointToClient(Cursor.Position).X) && note.ConnectionNote == null && ( note.name == NoteName.EightNote.ToString() || note.name == NoteName.SixteenthNote.ToString()) && note != ComposeView.selectedNote1)
                                        {
                                            ComposeView.selectedNote1 = note;
                                            ComposeView.SelectedSign = "Connect2";
                                            Cursor = new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect2));
                                            Invalidate();
                                        }
                                    }

                                    // ----- Sharp / Flat --------
                                    if (ComposeView.SelectedSign == "Sharp" || ComposeView.SelectedSign == "Flat")
                                    {
                                        if (note.IsLocation(PointToClient(Cursor.Position).Y, PointToClient(Cursor.Position).X))
                                        {
                                            if (ComposeView.SelectedSign == "Sharp")
                                            {
                                                note.SetSharp();
                                            }
                                            if (ComposeView.SelectedSign == "Flat")
                                            {
                                                note.SetFlat();
                                            }
                                        }
                                    }
                                    // ------Bin------
                                    if (ComposeView.SelectedSign == "Bin")
                                    {
                                        if (note.IsLocation(PointToClient(Cursor.Position).Y, PointToClient(Cursor.Position).X))
                                        {
                                            if (note.flat == true || note.sharp == true)
                                            {
                                                note.flat = false;
                                                note.sharp = false;
                                            }

                                        }
                                    }
                                    ComposeView.pkv1.KeyReleased(note.octave, note.tone);
                                    ComposeView.pkv1.Invalidate();
                                }
                            }
                        }
                        barBegin += 430;
                        barEnd += 430;
                    }
                }
            }
            //Als er met de rechetrmuisknop geklikt is
            else if (e.Button == MouseButtons.Right)
            {
                int barBegin = 50;
                int barEnd = 475;

                //Als er geen teken geselecteerd is
                if (!ComposeView.signSelected)
                {
                    foreach (Bar bar in staff.Bars)
                    {
                        //Als de positie van de muis overeenkomt met de bar/maat
                        if (PointToClient(Cursor.Position).X < barEnd && PointToClient(Cursor.Position).X > barBegin)
                        {
                            if (bar.Signs.Count > 0)
                            {//Laatste noot verwijderen
                                bar.RemoveSign(bar.Signs[bar.Signs.Count() - 1]);
                            }
                        }
                        barBegin += 430;
                        barEnd += 430;
                    }
                }

                //Als er een teken geselecteerd is, wordt alles op null/false gezet
                ComposeView.signSelected = false;
                ComposeView.SelectedSign = "";
                ComposeView.selectedNote1 = null;
                ComposeView.selectedNote2 = null;
            }
            if(ComposeView.SelectedSign == "Connect1" || ComposeView.SelectedSign == "Connect2")
            {

            } else
            {
                ComposeView.signSelected = false;
                ComposeView.SelectedSign = "";
                
            }
            Invalidate();

        }

        async Task PutTaskDelay(int delay)
        {
            await Task.Delay(delay);
        }

    }

}

