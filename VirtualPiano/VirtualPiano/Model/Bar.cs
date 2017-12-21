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

        public int StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff staff { get; set; }
        public virtual List<Sign> Signs { get; set; }
        [Required]
        public String clefName { get; set; }
        [NotMapped]
        public int TimeSignatureAmount { get; set; }
        [NotMapped]
        public string TimeSignatureName { get; set; }
        public int Duration { get; set; } = 0;
        public bool hasChanged;
        public bool hasPreview = false;
        public string lastClef;
        public int width = 430;
        public static int firstBarWidth;
        public int x;
        public int y = 50;
        public int height = 100;

        public Bar(int index)
        {
            if (index == 0)
            {
                width += 45; x = index * width + 10;
                firstBarWidth = width;
            }
            else x = ((index - 1) * width) + firstBarWidth;

            clefName = "G";
            Signs = new List<Sign>();
        }

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
                Add(new Rest("HalfRest", Duration * 25 + (width * barNr)));
                Add(new Rest("QuarterRest",Duration*25+(width*barNr)));
            }
            else if (Duration == 8)
            {
                Add(new Rest("HalfRest", Duration * 25 + (width * barNr)));
            }
            else if (Duration == 12)
            {
                Add(new Rest("QuarterRest", Duration * 25 + (width * barNr)));
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
            return (mouseX > x && mouseX < x + width && mouseY > y - 50 && mouseY < y + height -10);
        }
    }
}
