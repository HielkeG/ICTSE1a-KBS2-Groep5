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
        public static Cursor cursor = Cursors.Default;
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
            DrawBars(e);
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
            string latestClef = "";

            Pen penBlack = new Pen(Color.Black);
            e.Graphics.DrawLine(penBlack, 10, 50, 10, 110);  //Eerste verticale lijn

            foreach (Bar bar in staff.Bars) // Elke bar in de notenbalk wordt langsgegaan
            {

                for (int i = 0; i < 5; i++) //5 horizontale lijnen per bar
                {
                    e.Graphics.DrawLine(penBlack, bar.x, bar.y + i * 15, bar.x + bar.width, bar.y + i * 15);
                }

                // -----Sleutels tekenen------
                if (staff.Bars.First() == bar) //Bij eerste maat: sleutel groter tekenen en kruizen/mollen tekenen
                {
                    //De sleutels worden alleen getekent als de sleutel niet hetzelfde is als de vorige
                    if (bar.clefName == "G" && latestClef != "G") { e.Graphics.DrawImage(Resources.gsleutel, bar.x - 10, 26, 60, 110); latestClef = "G"; }
                    else if (bar.clefName == "F" && latestClef != "F") { e.Graphics.DrawImage(Resources.fsleutel, bar.x - 10, -19, 88, 185); latestClef = "F"; }


                    //-----Kruizen / Mollen --------
                    //Hieronder worden de kruizen en de mollen getekent. afhankelijk van het aantal
                    if (song.FlatSharp >= 1) { e.Graphics.DrawImage(Resources.kruis_icon, bar.x + 35, 30, 30, 40); }
                    if (song.FlatSharp >= 2) { e.Graphics.DrawImage(Resources.kruis_icon, bar.x + 50, 53, 30, 40); }
                    if (song.FlatSharp >= 3) { e.Graphics.DrawImage(Resources.kruis_icon, bar.x + 50, 25, 30, 40); }
                    if (song.FlatSharp >= 4) { e.Graphics.DrawImage(Resources.kruis_icon, bar.x + 29, 47, 30, 40); }
                    if (song.FlatSharp >= 5) { e.Graphics.DrawImage(Resources.kruis_icon, bar.x + 35, 65, 30, 40); }

                    if (song.FlatSharp <= -1) { e.Graphics.DrawImage(Resources.mol_icon, bar.x + 35, 52, 30, 40); }
                    if (song.FlatSharp <= -2) { e.Graphics.DrawImage(Resources.mol_icon, bar.x + 50, 28, 30, 40); }
                    if (song.FlatSharp <= -3) { e.Graphics.DrawImage(Resources.mol_icon, bar.x + 50, 59, 30, 40); }
                    if (song.FlatSharp <= -4) { e.Graphics.DrawImage(Resources.mol_icon, bar.x + 29, 36, 30, 40); }
                    if (song.FlatSharp <= -5) { e.Graphics.DrawImage(Resources.mol_icon, bar.x + 35, 67, 30, 40); }
                }
                else
                {
                    //----Sleutels----
                    if (bar.clefName == "G" && latestClef != "G") { e.Graphics.DrawImage(Resources.gsleutel, bar.x + 5, 43, 40, 83); latestClef = "G"; }
                    else if (bar.clefName == "F" && latestClef != "F") { e.Graphics.DrawImage(Resources.fsleutel, bar.x - 18, -5, 77, 155); latestClef = "F"; }
                }

                //--- Maatstrepen-----
                e.Graphics.DrawLine(new Pen(Color.Black), bar.x + bar.width, 50, bar.x + bar.width, 110); //per maat verticale lijn tekenen
                if (bar.Duration == 16)
                {
                    barColor = Color.Green;     //als maat vol is: groene lijn, anders: rood
                    fullBar++;
                }

                else barColor = Color.Red;

                e.Graphics.DrawLine(new Pen(barColor, 5), bar.x, 145, bar.x + bar.width, 145);
                if (fullBar == ComposeView.AmountOfBars)
                {
                    e.Graphics.DrawLine(new Pen(Color.LightGray, 5), 10, 145, staff.width, 145);
                }

                // Hieronder worden de noten en rusten getekent
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

                        if (note.isBeingMoved == false)
                        {
                            //Kruis of Mol tekenen
                            if (note.Sharp == true) { e.Graphics.DrawImage(Resources.kruis_icon, note.X + 15, Ynotelocation + 40, 30, 40); }
                            else if (note.Flat == true) { e.Graphics.DrawImage(Resources.mol_icon, note.X + 15, Ynotelocation + 40, 30, 40); }
                        }
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
            }
        }

        private async void StaffView_MouseUp(object sender, MouseEventArgs e)
        {
            if (ComposeView.draggingSign != null)
            {
                if (ComposeView.draggingSign.Name == "WholeNote") ComposeView.draggingSign.Image = Resources.helenoot;
                else if (ComposeView.draggingSign.Name == "HalfNote") ComposeView.draggingSign.Image = Resources.halvenoot;
                else if (ComposeView.draggingSign.Name == "QuarterNote") ComposeView.draggingSign.Image = Resources.kwartnoot;
                else if (ComposeView.draggingSign.Name == "EightNote") ComposeView.draggingSign.Image = Resources.achtstenoot;
                else if (ComposeView.draggingSign.Name == "SixteenthNote") ComposeView.draggingSign.Image = Resources.zestiendenoot;
                CursorController.ChangeCursor("default");
                await PutTaskDelay(100);
                ComposeView.draggingSign = null;
            }
            if (ComposeView.draggingSharp is Note note)
            {
                note.isBeingMoved = false;

                CursorController.ChangeCursor("default");
                await PutTaskDelay(500);
                ComposeView.draggingSharp = null;
            }
            ComposeView.cursorIsDown = false;
        }


        private void StaffView_MouseEnter(object sender, EventArgs e)
        {
            Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
            Console.WriteLine(ComposeView.SelectedSign);
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
            bool noteSet = false;
            int MouseX = PointToClient(Cursor.Position).X;
            int MouseY = PointToClient(Cursor.Position).Y;

            foreach (Bar bar in staff.Bars)
            {

                if (bar.MouseInBar(MouseX, MouseY))
                {
                    SetClefCursor(bar);

                    if (ComposeView.SelectedSign != "")
                    {
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
                                            bar.hasPreview = true;
                                            break;
                                        }
                                    }
                                }
                            }

                            if (noteSet == false && bar.Duration < 16)
                            {
                                newNote = new Note(bar.Duration * 25 + (bar.width * staff.Bars.IndexOf(bar)), PointToClient(Cursor.Position).Y, notename, bar.clefName, song.FlatSharp);
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

                            Rest newRest = new Rest(rest, bar.Duration * 25 + (bar.width * staff.Bars.IndexOf(bar)));
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
                                barContentColor = Color.FromArgb(255, 200, 200, 200);
                                bar.hasPreview = true;
                            }
                        }
                    }
                }
            }
            if (!staff.MouseInStaff(MouseX, MouseY) && ComposeView.draggingSign == null) Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
            Invalidate();
            Update();

            foreach (Bar bar in staff.Bars)
            {
                if (bar.hasPreview)
                {
                    bar.RemovePreview(ComposeView.SelectedSign);
                    Cursor = CursorController.ChangeCursor("default");
                }
                else if (bar.MouseInBar(MouseX, MouseY) && bar.Duration == 16 && ComposeView.draggingSign == null) Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
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
                                if (ComposeView.SoundEnabled) note.PlaySound();
                                ComposeView.pkv1.KeyPressed(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                                await PutTaskDelay(75);
                                ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                                ComposeView.pkv1.Invalidate();
                            }

                            //Als de muis na 200 miliseconden nog steeds ingedrukt is, wordt het teken verslepen
                            await PutTaskDelay(200);
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
                        //Als de muislocatie links van de muis is
                        if (sign.IsLocation(MouseX + 20, MouseY))
                        {
                            //Als de noot een mol of een kruis heeft
                            if (sign is Note note && (note.Flat == true || note.Sharp == true))
                            {
                                await PutTaskDelay(200);
                                //Als na 200 milseconde de muis nog steeds ingedrukt is, wordt de mol/kruis verslepen
                                if (ComposeView.cursorIsDown == true)
                                {
                                    note.isBeingMoved = true;
                                    ComposeView.draggingSharp = sign;
                                    Cursor = CursorController.ChangeCursor(ComposeView.draggingSharp.Name);

                                    Invalidate();
                                }
                            }
                        }
                        //Als de muisklik kleiner is dan 40 (aan het begin van de staff)
                        if (MouseX < 40)
                        {
                            await PutTaskDelay(300);
                            if (ComposeView.cursorIsDown == true)
                            {
                                if (song.FlatSharp < 0)
                                {
                                    ComposeView.SelectedSign = "BeginFlat";
                                    Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
                                }
                                else if (song.FlatSharp > 0)
                                {
                                    ComposeView.SelectedSign = "BeginSharp";
                                    Cursor = CursorController.ChangeCursor(ComposeView.SelectedSign);
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

                    //----------Sharp / Flat-------------

                    //Kruizen en Mollen toevoegen aan het begin
                    if (MouseX < 50 && ComposeView.SelectedSign == "Sharp")
                    {
                        if (song.FlatSharp >= 0)
                        {
                            song.FlatSharp++;
                            song.SetSharpFlat();
                        }
                        else
                        {
                            MessageBox.Show("Er kan geen kruis toegevoed worden, omdat het lied al mollen bevat. Als u toch een kruis wilt toevoegen, dient u eerst de mollen te verwijderen");
                        }


                    }
                    if (MouseX < 50 && ComposeView.SelectedSign == "Flat")
                    {
                        if (song.FlatSharp <= 0)
                        {
                            song.FlatSharp--;
                            song.SetSharpFlat();
                        }
                        else
                        {
                            MessageBox.Show("Er kan geen mol toegevoed worden, omdat het lied al kruizen bevat. Als u toch een mol wilt toevoegen, dient u eerst de kruizen te verwijderen");
                        }

                    }

                    foreach (Bar bar in staff.Bars)
                    {

                        //Als de positie van de muis binnen de positie van de maat valt. (bar = maat)
                        if (bar.MouseInBar(MouseX, MouseY))
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
                                    newNote = new Note(bar.Duration * 25 + (bar.width * staff.Bars.IndexOf(bar)), PointToClient(Cursor.Position).Y, notename, bar.clefName, song.FlatSharp);
                                    if (bar.CheckBarSpace(newNote) && notename != null) bar.Add(newNote);  //note toevoegen als er ruimte is
                                }

                            }
                            // -----Rest-----
                            else if (ComposeView.SelectedSign.Contains("Rest"))
                            {
                                string rest = ComposeView.SelectedSign;
                                Rest newRest = new Rest(rest, bar.Duration * 25 + (bar.width * staff.Bars.IndexOf(bar)));
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
                                                CursorController.ChangeCursor("default");

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
                                        }
                                        else if (ComposeView.SelectedSign == "Flat")
                                        {
                                            note.SetFlat();
                                        }

                                        ComposeView.pkv1.KeyReleased(note.Octave, note.Tone);
                                        ComposeView.pkv1.Invalidate();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //Als er met de rechtermuisknop geklikt is
            else if (e.Button == MouseButtons.Right)
            {

                //Als er geen teken geselecteerd is
                if (ComposeView.SelectedSign == "")
                {
                    foreach (Bar bar in staff.Bars)
                    {
                        //Als de positie van de muis overeenkomt met de bar/maat
                        if (bar.MouseInBar(MouseX, MouseY))
                        {
                            if (bar.Signs.Count > 0)
                            {
                                bar.RemoveSign(bar.Signs[bar.Signs.Count() - 1]);   //Laatste noot verwijderen
                            }
                        }
                    }
                }
                ComposeView.SelectedSign = "";
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

