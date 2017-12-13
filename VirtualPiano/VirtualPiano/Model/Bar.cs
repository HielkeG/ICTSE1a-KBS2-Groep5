﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Properties;

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
        public int length = 430;

        public Bar()
        {
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

        public void RemovePreview()
        {
            try
            {
                Duration = Duration - Signs.Last().Duration;
                Signs.RemoveAt(Signs.Count() - 1);
                hasPreview = false;
            }
            catch (Exception) { }
        }

        public void RemoveSign(Sign sign)
        {
            Signs.Remove(sign);
            Duration -= sign.Duration;
            if(sign is Note note)
            {
                if(note.ConnectionNote != null)
                {
                    note.ConnectionNote.ConnectionNote = null;
                    if(note.Name == "SixteenthNote"){
                        note.ConnectionNote.Image = Resources.zestiendenoot;
                    }
                    if (note.Name =="EightNote")
                    {
                        note.ConnectionNote.Image = Resources.achtstenoot;
                    }
                    note.ConnectionNote = null;

                }
            }
        }

        public void AddPreviewClef(string PreviewClef)
        {
            clefName = PreviewClef;
        }
    }
}
