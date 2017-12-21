using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Control;
using VirtualPiano.Properties;
using VirtualPiano.View;

namespace VirtualPiano.Model
{

    public class Bar
    {
        [Key]
        public int BarId { get; set; }
        [Required]
        public String clefName { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff staff { get; set; }
        public int StaffId { get; set; }
        public virtual List<Sign> Signs { get; set; }
        public int Width { get; set; } = 430;
        public static int FirstBarWidth { get; set; }
        public int X { get; set; }
        public int Y { get; set; } = 50;
        public int Height { get; set; } = 100;
        [NotMapped]
        public int TimeSignatureAmount { get; set; }
        [NotMapped]
        public string TimeSignatureName { get; set; }
        public int Duration { get; set; } = 0;
        public bool hasChanged;
        public bool hasPreview = false;
        public string lastClef;
        

        public Bar(int index)
        {
            if (index == 0)
            {
                Width += 45; X = index * Width + 10;
                FirstBarWidth = Width;
            }
            else X = ((index - 1) * Width) + FirstBarWidth;

            clefName = "G";
            Signs = new List<Sign>();
        }

        public Bar()
        { }

            public bool CheckBarSpace(Sign sign)    //kijken of er ruimte in de maat is voor nieuw teken
        {
            if (Duration + sign.Duration > 16) return false;
            else return true;
        }

        public void Add(Sign sign)
        {
            Signs.Add(sign);
            Duration += sign.Duration;
        }

        public void MakeEmpty() //Lijst van tekens leegmaken
        {
            Signs = new List<Sign>();
            Duration = 0;
        }

        public void RemovePreview(string sign)
        {
            if (sign.Contains("G") || sign.Contains("F"))
            {
                clefName = lastClef;
                foreach (Sign sign2 in Signs)
                {
                    sign2.SetImage();
                    StaffView.barContentColor = Color.Black;
                }
            }
            else
            {
                try
                {
                    Duration = Duration - Signs.Last().Duration;
                    Signs.RemoveAt(Signs.Count() - 1);
                }
                catch (Exception) { }
            }
            hasPreview = false;
        }

        public void RemoveSign(Sign sign)
        {
            Signs.Remove(sign);
            Duration -= sign.Duration;
            if (sign is Note note)
            {
                if (note.ConnectionNote != null)
                {
                    note.ConnectionNote.ConnectionNote = null;
                    if (note.Name == "SixteenthNote")
                    {
                        note.ConnectionNote.Image = Resources.zestiendenoot;
                    }
                    if (note.Name == "EightNote")
                    {
                        note.ConnectionNote.Image = Resources.achtstenoot;
                    }
                    note.ConnectionNote = null;

                }
            }
        }

        public void FillBar(int barNr)
        {

            if (Duration == 4)
            {
                Add(new Rest("HalfRest", Duration * 25 + (Width * barNr)));
                Add(new Rest("QuarterRest",Duration*25+(Width*barNr)));
            }
            else if (Duration == 8)
            {
                Add(new Rest("HalfRest", Duration * 25 + (Width * barNr)));
            }
            else if (Duration == 12)
            {
                Add(new Rest("QuarterRest", Duration * 25 + (Width * barNr)));
            }
        }

        public void AddPreviewClef(string PreviewClef)
        {
            clefName = PreviewClef;
        }

        public void makeSignsGray()
        {
            for (int i = 0; i < Signs.Count(); i++)
            {
                Bitmap newBitmap = new Bitmap(Signs[i].Image);
                newBitmap = BitmapController.ColorTint(newBitmap, 0.50F, 0.50F, 0.50F);
                newBitmap = BitmapController.SetImageOpacity(newBitmap, 0.4F);
                Signs[i].Image = newBitmap;
            }
        }
        

        public bool MouseInBar(int mouseX, int mouseY)
        {
            return (mouseX > X && mouseX < X + Width && mouseY > Y - 50 && mouseY < Y + Height -10);
        }
    }
}
