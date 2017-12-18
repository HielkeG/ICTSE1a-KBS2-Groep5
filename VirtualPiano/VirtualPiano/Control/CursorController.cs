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
        //methode die cursor verandert naar een teken

        public static Cursor ChangeCursor(string s)
        {
            Bitmap b = null;

            if (s == "WholeNote") b = Resources.helenoot_icon;
            else if (s == "HalfNote") b = Resources.halvenoot_icon;
            else if (s == "QuarterNote") b = Resources.kwartnoot_icon;
            else if (s == "EightNote") b = Resources.achtstenoot_icon;
            else if (s == "SixteenthNote") b = Resources.zestiendenoot_icon;
            else if (s == "WholeRest") b = Resources.helerust_icon;
            else if (s == "HalfRest") b = Resources.halverust_icon;
            else if (s == "QuarterRest") b = Resources.kwartrust_icon;
            else if (s == "EightRest") b = Resources.achtsterust_icon;
            else if (s == "SixteenthRest") b = Resources.zestienderust_icon;
            else if (s == "G") b = Resources.Gsleutel_icon;
            else if (s == "F") b = Resources.fsleutel_icon;
            else if (s == "Sharp") b = Resources.kruis_icon;
            else if (s == "Flat") b = Resources.Mol;
            else if (s == "Bin") b = Resources.bin;
            else if (s == "Connect1") return new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect1));
            else if (s == "Connect2") return new Cursor(new System.IO.MemoryStream(Properties.Resources.Connect2));
            else return Cursors.Default;

            b.MakeTransparent(b.GetPixel(0, 0));
            Graphics g = Graphics.FromImage(b);
            IntPtr ptr = b.GetHicon();
            Cursor cur = new System.Windows.Forms.Cursor(ptr);
            return cur;
        }
    }
}
