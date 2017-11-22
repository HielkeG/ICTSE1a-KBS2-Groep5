using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Model;
using VirtualPiano.Properties;

namespace VirtualPiano.Control
{
    public static class CursorController
    {
        //methode die cursor verandert naar een Noot.
        //deze klasse bevat 3 overrides voor de methode.
        public static Cursor ChangeCursor(NoteName name)
        {
            //afbeelding aanmaken
            Bitmap b = null;
            //kijken welke afbeelding de noot moet zijn.
            switch (name)
            {
                case NoteName.wholeNote:
                    b = Resources.helenoot_icon;
                    break;

                case NoteName.halfNote:
                    b = Resources.halvenoot_cur;
                    break;
                case NoteName.quarterNote:
                    b = Resources.kwartnoot_cur;
                    break;
                case NoteName.eightNote:
                    b = Resources.achtstenoot_cur;
                    break;
                case NoteName.sixteenthNote:
                    b = Resources.zestiendenoot_cur;
                    break;
            }
            //afbeelding instellen.
            b.MakeTransparent(b.GetPixel(0, 0));
            Graphics g = Graphics.FromImage(b);
            IntPtr ptr = b.GetHicon();
            Cursor cur = new System.Windows.Forms.Cursor(ptr);
            return cur;
        }

        public static Cursor ChangeCursor(ClefName name)
        {
            Bitmap b = null;
            switch (name)
            {
                case ClefName.F:
                    b = Resources.fsleutel_icon;
                    break;
                case ClefName.G:
                    b = Resources.Gsleutel_icon;
                    break;

            }
            b.MakeTransparent(b.GetPixel(0, 0));
            Graphics g = Graphics.FromImage(b);
            IntPtr ptr = b.GetHicon();
            Cursor cur = new System.Windows.Forms.Cursor(ptr);
            return cur;
        }

        public static Cursor ChangeCursor(RestName name)
        {
            Bitmap b = null;
            switch (name)
            {
                case RestName.wholeRest:
                    b = Resources.helerust_icon;
                    break;
                case RestName.halfRest:
                    b = Resources.halverust_icon;
                    break;
                case RestName.quarterRest:
                    b = Resources.kwartrust_icon;
                    break;
                case RestName.eightRest:
                    b = Resources.achtsterust_icon;
                    break;
                case RestName.sixteenthRest:
                    b = Resources.zestienderust_icon;
                    break;

            }
            b.MakeTransparent(b.GetPixel(0, 0));
            Graphics g = Graphics.FromImage(b);
            IntPtr ptr = b.GetHicon();
            Cursor cur = new System.Windows.Forms.Cursor(ptr);
            return cur;
        }
    }
}
