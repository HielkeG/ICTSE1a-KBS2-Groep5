﻿using System;
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
        public static Cursor ChangeCursor(NoteName name)
        {
            Bitmap b = null;
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
                    b = Resources.fsleutel;
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
                    b = Resources.HeleRust;
                    break;
                case RestName.halfRest:
                    b = Resources.HalveRust;
                    break;
                case RestName.quarterRest:
                    b = Resources.KwartRust;
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