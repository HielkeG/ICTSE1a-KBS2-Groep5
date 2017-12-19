using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Linq;

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
        public RedLine redLine;
        public Song song;
        public int fullBar { get; set; }
        Color barColor;

        public bool ShowClefCursor = true;
        public static Color barContentColor = Color.Black;

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
            string latestClef = "";
            foreach (Bar bar in staff.Bars) // Elke bar in de notenbalk wordt langsgegaan
            {
                // -----Sleutels tekenen------
                if (staff.Bars.First() == bar) //Bij eerste maat: sleutel groter tekenen en kruizen/mollen tekenen
                {
                    //De sleutels worden alleen getekent als de sleutel niet hetzelfde is als de vorige
                    if (bar.clefName == "G" && latestClef != "G") { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 485, 26, 60, 110); latestClef = "G"; }
                    else if (bar.clefName == "F" && latestClef != "F") { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 483, -19, 88, 185); latestClef = "F"; }

                    //-----Kruizen / Mollen --------
                    //Hieronder worden de kruizen en de mollen getekent. afhankelijk van het aantal
                    if (song.FlatSharp >= 1) { e.Graphics.DrawImage(Resources.kruis_icon, x_bar - 420, 30, 30, 40); }
                    if (song.FlatSharp >= 2) { e.Graphics.DrawImage(Resources.kruis_icon, x_bar - 405, 53, 30, 40); }
                    if (song.FlatSharp >= 3) { e.Graphics.DrawImage(Resources.kruis_icon, x_bar - 405, 25, 30, 40); }
                    if (song.FlatSharp >= 4) { e.Graphics.DrawImage(Resources.kruis_icon, x_bar - 426, 47, 30, 40); }
                    if (song.FlatSharp >= 5) { e.Graphics.DrawImage(Resources.kruis_icon, x_bar - 420, 65, 30, 40); }

                    if (song.FlatSharp <= -1) { e.Graphics.DrawImage(Resources.mol_icon, x_bar - 420, 52, 30, 40); }
                    if (song.FlatSharp <= -2) { e.Graphics.DrawImage(Resources.mol_icon, x_bar - 405, 28, 30, 40); }
                    if (song.FlatSharp <= -3) { e.Graphics.DrawImage(Resources.mol_icon, x_bar - 405, 59, 30, 40); }
                    if (song.FlatSharp <= -4) { e.Graphics.DrawImage(Resources.mol_icon, x_bar - 426, 36, 30, 40); }
                    if (song.FlatSharp <= -5) { e.Graphics.DrawImage(Resources.mol_icon, x_bar - 420, 67, 30, 40); }
                }
                else
                {
                    //----Sleutels----
                    if (bar.clefName == "G" && latestClef != "G") { e.Graphics.DrawImage(Resources.gsleutel, x_bar - 470, 43, 40, 83); latestClef = "G"; }
                    else if (bar.clefName == "F" && latestClef != "F") { e.Graphics.DrawImage(Resources.fsleutel, x_bar - 493, -5, 77, 155); latestClef = "F"; }
                }

                //--- Maatstrepen-----
                e.Graphics.DrawLine(new Pen(Color.Black), x_bar, 50, x_bar, 110); //per maat verticale lijn tekenen
                if (bar.Duration == 16)
                {
                    barColor = Color.Green;     //als maat vol is: groene lijn, anders: rood
                    fullBar++;
                }

                else
                {
                    barColor = Color.Red;
                }
                e.Graphics.DrawLine(new Pen(barColor, 5), x_bar - 430, 145, x_bar, 145);
                if (fullBar == 4)
                {
                    e.Graphics.DrawLine(new Pen(Color.WhiteSmoke, 5), 10, 145, 1765, 145);
                }

                // Hier worden de noten en rusten getekent
                foreach (Sign sign in bar.Signs)
                {
                    //------Noten------
                    if (sign is Note note)
                    {
                        //----Verbindingslijn-----
                        if (note.ConnectionNote != null)     //noten die aan elkaar zitten tekenen
                        {
                            if (note.Name == "EightNote")
                            {
                                e.Graphics.DrawLine(new Pen(barContentColor, 6), note.X + 58, note.Y + 15, note.ConnectionNote.X + 59, note.ConnectionNote.Y + 15);
                            }
                            else
                            {
                                e.Graphics.DrawLine(new Pen(barContentColor, 5), note.X + 58, note.Y + 15, note.ConnectionNote.X + 59, note.ConnectionNote.Y + 15);
                                e.Graphics.DrawLine(new Pen(barContentColor, 5), note.X + 58, note.Y + 23, note.ConnectionNote.X + 59, note.ConnectionNote.Y + 23);
                            }

                        }

                        int Ynotelocation = note.Y;

                        //Als de noten te hoog of te heel laag zijn voor de notenbalk, worden er hulplijnen getkent.
                        if (note.Y <= -25) { e.Graphics.DrawLine(new Pen(barContentColor, 2), note.X + 30, 36, note.X + 70, 36); }
                        if (note.Y <= -40) { e.Graphics.DrawLine(new Pen(barContentColor, 2), note.X + 30, 22, note.X + 70, 22); }
                        else if (note.Y >= 55) { e.Graphics.DrawLine(new Pen(barContentColor, 2), note.X + 30, 124, note.X + 70, 124); }

                        //Noot tekenen
                        e.Graphics.DrawImage(sign.Image, note.X, Ynotelocation, 90, 130);
                        if (note.Sharp == true) { e.Graphics.DrawImage(Resources.kruis_icon, note.X + 15, Ynotelocation + 40, 30, 40);}
                        else if (note.Flat == true) { e.Graphics.DrawImage(Resources.mol_icon, note.X + 15, Ynotelocation + 40, 30, 40); }
                    }

                    //Rust tekenen
                    else if (sign is Rest rest)
                    {
                        if (rest.Name == "WholeRest") { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(rest.X + 220, 66, 20, 10)); }
                        else if (rest.Name == "HalfRest") { e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(rest.X + 115, 71, 20, 10)); }
                        else if (rest.Name == "QuarterRest") e.Graphics.DrawImage(rest.Image, rest.X + 60, 50, 50, 61);
                        else if (rest.Name == "EightRest") e.Graphics.DrawImage(rest.Image, rest.X + 30, 20, 65, 115);
                        else if (rest.Name == "SixteenthRest") e.Graphics.DrawImage(rest.Image, rest.X + 50, 20, 65, 115);
                    }
                }
                x_bar += 430;
            }
        }

        private void StaffView_MouseUp(object sender, MouseEventArgs e)
        {
            if (ComposeView.draggingSign != null)
            {
                if (ComposeView.draggingSign.Name == "WholeNote") ComposeView.draggingSign.Image = Resources.helenoot;
                else if (ComposeView.draggingSign.Name == "HalfNote") ComposeView.draggingSign.Image = Resources.halvenoot;
                else if (ComposeView.draggingSign.Name == "QuarterNote") ComposeView.draggingSign.Image = Resources.kwartnoot;
                else if (ComposeView.draggingSign.Name == "EightNote") ComposeView.draggingSign.Image = Resources.achtstenoot;
                else if (ComposeView.draggingSign.Name == "SixteenthNote") ComposeView.draggingSign.Image = Resources.zestiendenoot;
            }
            ComposeView.cursorIsDown = false;
        }

        //methode die de cursor op default zet en alle booleans op null zet.
        private void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
        }


        private void StaffView_MouseEnter(object sender, EventArgs e)
        {
            //Standaard cursor zetten voor noten en rusten
            if (ComposeView.SelectedSign == "Sharp" || ComposeView.SelectedSign == "Flat" || ComposeView.SelectedSign == "Connect") Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
            else SetDefaultCursor(); 

            if (ComposeView.SelectedSign == "Connect1")
            {
                Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
            }
            if (ComposeView.SelectedSign == "Connect2")
            {
                Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
            }
        }

        private void SetClefCursor(Bar bar)
        {
            if (bar.clefName == ComposeView.SelectedSign)
            {
                Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
            }
        }

        private void StaffView_MouseMove(object sender, MouseEventArgs e)
        {
            //------Preview tonen--------
            int barBegin = 50;
            int barEnd = 475;
            bool noteSet = false;
            int MouseX = PointToClient(Cursor.Position).X;
            int MouseY = PointToClient(Cursor.Position).Y;

           
            foreach (Bar bar in staff.Bars)
            {
                if (ComposeView.SelectedSign != "")
                {
                    if (MouseX < barEnd && MouseX > barBegin)
                    {
                        SetClefCursor(bar);


                        // ------Note-----
                        if (ComposeView.SelectedSign.Contains("Note"))
                        {
                            string notename = ComposeView.SelectedSign;
                            Note newNote;
                            for (int i = 0; i < bar.Signs.Count(); i++)
                            {
                                Sign sign = bar.Signs[i];

                                if (sign is Note note)
                                {
                                    if (note.IsLocation(MouseX))
                                    {
                                        newNote = new Note(note.X - 25, PointToClient(Cursor.Position).Y, notename, bar.clefName, song.FlatSharp);
                                        if (note.Flipped == true || note.Y <= 0)
                                        {
                                            newNote.flip();
                                        }
                                        else
                                        {
                                            newNote.unflip();
                                        }
                                        if (note.Duration >= newNote.Duration)
                                        {
                                            newNote.Duration = 0;
                                            if (bar.CheckBarSpace(newNote) && notename != null) bar.Add(newNote);  //note toevoegen als er ruimte is
                                            noteSet = true;
                                            SetDefaultCursor();
                                            bar.hasPreview = true;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (noteSet == false && bar.Duration < 16)
                            {
                                newNote = new Note(bar.Duration * 25 + (bar.length * staff.Bars.IndexOf(bar)), PointToClient(Cursor.Position).Y, notename, bar.clefName, song.FlatSharp);
                                if (bar.CheckBarSpace(newNote) && notename != null)
                                {
                                    
                                    bar.Add(newNote);
                                    bar.hasPreview = true;
                                }
                            }


                            //note toevoegen als er ruimte is

                        }
                        // -----Rest-----
                        else if (ComposeView.SelectedSign.Contains("Rest"))
                        {
                            string rest = ComposeView.SelectedSign;

                            Rest newRest = new Rest(rest, bar.Duration * 25 + (bar.length * staff.Bars.IndexOf(bar)));
                            if (bar.CheckBarSpace(newRest) && rest != null)
                            {
                                bar.Add(newRest);
                                bar.hasPreview = true;
                            }
                            //rest toevoegen als er ruimte is
                        }

                        //-----Clef----
                        else if (ComposeView.SelectedSign == "G" || ComposeView.SelectedSign == "F")
                        {
                            if (bar.clefName != ComposeView.SelectedSign)
                            {
                                string Clef = ComposeView.SelectedSign;
                                bar.lastClef = bar.clefName;
                                bar.clefName = Clef;
                                bar.makeSignsGray();
                                barContentColor = Color.FromArgb(255,200,200,200);
                                bar.hasPreview = true;
                            }

                        }
                    }
                }
                barBegin += 430;
                barEnd += 430;
            }
            Invalidate();
            Update();

            int barBegin2 = 50;
            int barEnd2 = 474; 
            foreach (Bar bar in staff.Bars)
            {
                if (bar.hasPreview)
                {
                    bar.RemovePreview(ComposeView.SelectedSign);
                    SetDefaultCursor();
                }
                else if (MouseX < barEnd2 && MouseX > barBegin2 && bar.Duration == 16) Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
                barBegin2 += 430;
                barEnd2 += 430;
            }
        }

        //-----Methode wordt aangeroepen als een muisklik ingedrukt wordt
        private async void StaffView_MouseDown(object sender, MouseEventArgs e)
        {
            int MouseX = PointToClient(Cursor.Position).X;
            int MouseY = PointToClient(Cursor.Position).Y;

            ComposeView.cursorIsDown = true;
            //Wanneer geen teken geselcteerds is en wanneer de linkermuisknop ingedrukt is
            if (ComposeView.SelectedSign == "" && e.Button == MouseButtons.Left)
            {
                foreach (Bar bar in staff.Bars)
                {
                    for (int i = 0; i < bar.Signs.Count(); i++)
                    {
                        Sign sign = bar.Signs[i];

                        //Als er een coordinaat van een teken overeenkomt met de coordinatie van de muis
                        if (sign.IsLocation(MouseX, MouseY))
                        {
                            //Als het een noot is, wordt de noot afgespeeld
                            if (sign is Note note)
                            {
                                note.PlaySound();
                                ComposeView.pkv1.KeyPressed(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                await PutTaskDelay(75);
                                ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                            }

                            //Als de muis na 300 miliseconden nog steeds ingedrukt is, wordt het teken verslepen
                            await PutTaskDelay(300);
                            if (ComposeView.cursorIsDown == true)
                            {
                                //De cursor veranderd in de aangeklikte noot
                                Cursor = CursorController.ChangeCursor(sign.Name);
                                ComposeView.SelectedSign = "";
                                sign.Image = Resources.blank;
                                ComposeView.draggingSign = sign;
                                Invalidate();
                            }
                        }
                        if (sign.IsLocation(MouseX + 20, MouseY))
                        {
                            if (sign is Note note && (note.Flat == true || note.Sharp == true))
                            {
                                await PutTaskDelay(300);
                                if (ComposeView.cursorIsDown == true)
                                {
                                    if(note.Sharp == true)
                                    {
                                        Cursor = CursorController.ChangeCursor("Sharp");
                                    }
                                     else if (note.Flat == true)
                                    {
                                        Cursor = CursorController.ChangeCursor("Flat");
                                    }

                                    ComposeView.draggingSharp = sign;
                                    
                                    Invalidate();
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void StaffView_MouseClick(object sender, MouseEventArgs e)
        {
            int MouseX = PointToClient(Cursor.Position).X;
            int MouseY = PointToClient(Cursor.Position).Y;
            bool noteSet = false; //Deze boolean wordt op true gezet als er een noot onder een andere noot wordt toegevoegd, zo wordt voorkomen dat er niet 2 noten toegevoegd worden.

            //Als er met de linkermuisknop geklikt is
            if (e.Button == MouseButtons.Left)
            {
                //Als er een teken geselecteerd is
                if (ComposeView.SelectedSign != "")
                {
                    int barBegin = 45;
                    int barEnd = 475;

                    //----------Sharp / Flat-------------

                    //Kruizen en Mollen toevoegen aan het begin
                    if (MouseX < 50 && ComposeView.SelectedSign == "Sharp")
                    {
                        if (song.FlatSharp < 0) { song.FlatSharp = 0; }
                        song.FlatSharp++;
                        song.ChangeSharpFlat(song.FlatSharp);
                    }
                    if (MouseX < 50 && ComposeView.SelectedSign == "Flat")
                    {
                        if (song.FlatSharp > 0) { song.FlatSharp = 0; }
                        song.FlatSharp--;
                        song.ChangeSharpFlat(song.FlatSharp);
                    }

                    foreach (Bar bar in staff.Bars)
                    {

                        //Als de positie van de muis binnen de positie van de maat valt. (bar = maat)
                        if (MouseX < barEnd && MouseX > barBegin)
                        {
                            // ----------Note-----------
                            if (ComposeView.SelectedSign.Contains("Note"))
                            {
                                string notename = ComposeView.SelectedSign;
                                Note newNote;

                                // -- Noten onder elkaar -----
                                for (int i = 0; i < bar.Signs.Count(); i++)
                                {
                                    Sign sign = bar.Signs[i];

                                    if (sign is Note note)
                                    {
                                        //Als er een noot op dezelfde X-as staat als de X-as van de muisklik
                                        if (note.IsLocation(MouseX))
                                        {

                                            newNote = new Note(note.X - 25, PointToClient(Cursor.Position).Y, notename, bar.clefName, song.FlatSharp);
                                            //Als de noot op de kop staat, moet ook deze noot op de kop staan
                                            if (note.Y <= 0 || note.Flipped == true)
                                            {
                                                newNote.flip();
                                            }
                                            else
                                            {
                                                newNote.unflip();
                                            }
                                            //Als de noot kleiner of gelijk is aan de noot waarmee het vergelijkt
                                            if (note.Duration >= newNote.Duration)
                                            {
                                                newNote.Duration = 0;
                                                bar.Add(newNote);  //note toevoegen 
                                                noteSet = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                //----Normale noot toevoegen -----
                                //Als er nog geen noot toegevoegd is aan een andere noot
                                if (noteSet == false)
                                {
                                    newNote = new Note(bar.Duration * 25 + (bar.length * staff.Bars.IndexOf(bar)), PointToClient(Cursor.Position).Y, notename, bar.clefName, song.FlatSharp);
                                    if (bar.CheckBarSpace(newNote) && notename != null) bar.Add(newNote);  //note toevoegen als er ruimte is
                                }

                            }
                            // -----Rest-----
                            else if (ComposeView.SelectedSign.Contains("Rest"))
                            {
                                string rest = ComposeView.SelectedSign;
                                Rest newRest = new Rest(rest, bar.Duration * 25 + (bar.length * staff.Bars.IndexOf(bar)));
                                if (bar.CheckBarSpace(newRest) && rest != null) bar.Add(newRest);  //rest toevoegen als er ruimte is
                            }
                            // -----Clef----
                            else if (ComposeView.SelectedSign == "G" || ComposeView.SelectedSign == "F")
                            {
                                if (bar.clefName != ComposeView.SelectedSign)
                                {
                                    string Clef = ComposeView.SelectedSign;
                                    bar.clefName = Clef;
                                    bar.MakeEmpty();
                                }
                            }

                            foreach (Sign sign in bar.Signs)
                            {
                                if (sign is Note note)
                                {
                                    if (note.IsLocation(MouseX, MouseY))
                                    {
                                        // -------Connect------  

                                        // -- 1e connectiepunt
                                        if (ComposeView.SelectedSign == "Connect1")
                                        {
                                            if (note.CheckConnect())
                                            {
                                                ComposeView.selectedNote1 = note;
                                                ComposeView.SelectedSign = "Connect2";
                                                Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
                                            }
                                            else
                                            {
                                                ComposeView.SelectedSign = "";
                                                ConnectError.Active = true;
                                                ConnectError.Show("Deze noot kan niet verbonden worden", this);
                                                await PutTaskDelay(2000);
                                                ConnectError.Active = false;
                                            }
                                        }

                                        // -- 2e connectiepunt
                                        else if (ComposeView.SelectedSign == "Connect2")
                                        {
                                            if (note.CheckConnect() && bar.Signs.Contains(ComposeView.selectedNote1))
                                            {
                                                //Als de twee noten naast elkaar staan
                                                int index1 = bar.Signs.IndexOf(ComposeView.selectedNote1);
                                                int index2 = bar.Signs.IndexOf(note);

                                                if ((index1 - index2 == 1 || index1 - index2 == -1) && note.Name == ComposeView.selectedNote1.Name)
                                                {
                                                    ComposeView.selectedNote2 = note;
                                                    //Noten met elkaar verbinden
                                                    ComposeView.selectedNote1.MakeConnection(ComposeView.selectedNote2);
                                                    ComposeView.SelectedSign = "";
                                                }
                                                else
                                                {
                                                    ComposeView.SelectedSign = "";
                                                    ConnectError.Active = true;
                                                    ConnectError.Show("Deze noot kan niet verbonden worden met de vorige noot", this);
                                                    await PutTaskDelay(2000);
                                                    ConnectError.Active = false;
                                                }
                                                SetDefaultCursor();

                                            }
                                            else
                                            {
                                                ComposeView.SelectedSign = "";
                                                ConnectError.Active = true;
                                                ConnectError.Show("Deze noot kan niet verbonden worden met de vorige noot", this);
                                                await PutTaskDelay(2000);
                                                ConnectError.Active = false;
                                            }
                                        }

                                        // ----- Sharp / Flat --------
                                        if (ComposeView.SelectedSign == "Sharp")
                                        {
                                            note.SetSharp();
                                            Console.WriteLine("SetSharp");
                                        }
                                        else if (ComposeView.SelectedSign == "Flat")
                                        {
                                            note.SetFlat();
                                            Console.WriteLine("SetFlat");
                                        }

                                        ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                                        ComposeView.pkv1.Invalidate();
                                    }
                                }
                            }
                        }
                        barBegin += 430;
                        barEnd += 430;
                    }
                }
            }
            //Als er met de rechtermuisknop geklikt is
            else if (e.Button == MouseButtons.Right)
            {
                int barBegin = 50;
                int barEnd = 475;

                //Als er geen teken geselecteerd is
                if (ComposeView.SelectedSign == "")
                {
                    foreach (Bar bar in staff.Bars)
                    {
                        //Als de positie van de muis overeenkomt met de bar/maat
                        if (MouseX < barEnd && MouseX > barBegin)
                        {
                            if (bar.Signs.Count > 0)
                            {
                                bar.RemoveSign(bar.Signs[bar.Signs.Count() - 1]);   //Laatste noot verwijderen
                            }
                        }
                        barBegin += 430;
                        barEnd += 430;
                    }
                }
            }
            Invalidate();
        }

        //Deze methode zorgt voor een wachttijd in de methode. De applicatie kan ondertussen wel verder gaan
        async Task PutTaskDelay(int delay)
        {
            await Task.Delay(delay);
        }

        private void StaffView_MouseLeave(object sender, EventArgs e)
        {
            foreach (Bar bar in staff.Bars)
            {
                if (bar.hasPreview) bar.RemovePreview(ComposeView.SelectedSign);
                Invalidate();
            }

        }
    }

}

