using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Model;

namespace VirtualPiano.Control
{
    public static class CursorController
    {
        public static Cursor ChangeCursor(string name)
        {
            if (name == "achtstenoot")
            {
                Bitmap b = new Bitmap(Properties.Resources.achtstenoot_cur);
                b.MakeTransparent(b.GetPixel(0, 0));

                Graphics g = Graphics.FromImage(b);

                IntPtr ptr = b.GetHicon();

                Cursor cur = new System.Windows.Forms.Cursor(ptr);

                return cur;
            }
            else
            {
                return null;
            }
        }


    }
}
