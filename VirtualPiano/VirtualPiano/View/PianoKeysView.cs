using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Control;
using VirtualPiano.Model;
using System.Reflection;
using System.Windows.Forms;

namespace VirtualPiano.View
{
    public partial class PianoKeysView : UserControl
    {
        List<string> KeyList = new List<string> { "C", "D", "E", "F", "G", "A", "B" };
        List<PianoKey> PianoKeyList = new List<PianoKey>();
        public bool showPiano = true;

        public PianoKeysView()
        {
            DoubleBuffered = true;
            InitializeComponent();
            BackgroundImage = Properties.Resources.pianoshadow;
            BackgroundImageLayout = ImageLayout.None;
            CreateKeys();


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawWhiteKeys(e);
            DrawBlackKeys(e);
        }

        //lijst met pianokeys aanmaken.
        private void CreateKeys()
        {
                        
            for (int o = 2; o < 6; o++) //aantal octaven om te tekenen
            {
                for (int i = 0; i < KeyList.Count(); i++) //teken whitekeys en dan blackkeys
                {
                    if (KeyList[i] == "E" || KeyList[i] == "B")
                    {
                        WhiteKey wk = new WhiteKey(KeyList[i] + o);
                        PianoKeyList.Add(wk);
                    }
                    else
                    {
                        WhiteKey wk = new WhiteKey(KeyList[i] + o);
                        PianoKeyList.Add(wk);
                        BlackKey bk = new BlackKey(KeyList[i] + "is"+o);
                        PianoKeyList.Add(bk);
                    }

                }
            }
        }

        //witte tekens eerst tekenen
        public void DrawWhiteKeys(PaintEventArgs e)
        {
            int xLocation = 10;
            int PianoWidth = 50; //pianobreedte
            int PianoHeight = 229; // pianohoogte;
            //nieuwe tekenmethode
            foreach (var item in PianoKeyList)
            {
                if(item.GetType() == typeof(WhiteKey))
                {
                    //alleen de witte keys uit de lijst tekenen. naam, locatie en breedte meegeven.
                    item.DrawKey(e, item.keyname, xLocation, 11, PianoWidth, PianoHeight);
                    xLocation = xLocation + 50;
                }
            }
        }

        //alle zwarte keys later tekenen, zodat ze over de witte keys staan.
        public void DrawBlackKeys(PaintEventArgs e)
        {
            int xLocation = 10;
            int OnRow = 0;
            bool previous2 = false;
            foreach (var item in PianoKeyList)
            {
                //tekenen
                if(item.GetType()== typeof(BlackKey))
                {
                    xLocation = xLocation + 50;

                    item.DrawKey(e, item.keyname, xLocation - 13, 12, 50, 2);
                    OnRow++;
                }
                //als er twee op de vorige rij stonden en de rij ervoor niet uit 2 bestond. Whitespace ertussen plaatsen.
                if (OnRow == 2&&previous2==false)
                {
                    previous2 = true;
                    OnRow = 0;
                    xLocation = xLocation + 50;
                }
                //als er 3 op een rij staan: Whitespace, daarna weer 2 neerzetten
                else
                {
                    if (OnRow == 3)
                    {
                        OnRow = 0;
                        previous2 = false;
                        xLocation = xLocation + 50;
                    }
                }

            }
        }

        //key grijs maken.
        public void KeyPressed(int octave, string tone)
        {
            foreach (var item in PianoKeyList)
            {
                if(item.keyname == tone.ToString() + octave)
                {
                    item.isGray = true;
                    break;
                }
            }
        }
        //wanneer de key losgelaten wordt, wordt hij weer de originele kleur.
        public void KeyReleased(int octave, string tone)
        {
            foreach (var item in PianoKeyList)
            {
                if (item.keyname == tone.ToString() + octave)
                {
                    item.isGray = false;
                    break;
                }
            }
        }
    }

    public abstract class PianoKey
    {
        public string keyname;
        public bool isGray;
        public PianoKey(string k)
        {
            keyname = k;
        }
        public abstract void DrawKey(PaintEventArgs e, string name, int xLocatie, int yLocatie, int Breedte, int Hoogte);
        
    }
    public class WhiteKey : PianoKey
    {
        Pen penBlack = new Pen(Color.Black, 2);
        SolidBrush BlackBrush = new SolidBrush(Color.Black);
        SolidBrush GrayBrush = new SolidBrush(Color.Gray);

        SolidBrush WhiteBrush = new SolidBrush(Color.White);

        private Font f = new Font("Times New Roman", 24, FontStyle.Regular, GraphicsUnit.Pixel);

        public WhiteKey(string name) : base(name)  {   }

        //teken een vierkant voor de witte toets met nootletter erin
        public override void DrawKey(PaintEventArgs e, string name, int xLocation, int yLocation, int Width, int Height)
        {
            Rectangle rectangle = new Rectangle(xLocation, yLocation, Width, Height);

            //als de boolean true is wordt de key in het grijs getekend. Anders in de standaard kleur.
            if (isGray)
            {
                e.Graphics.FillRectangle(GrayBrush, rectangle);
            }
            else
            {
                e.Graphics.FillRectangle(WhiteBrush, rectangle);
            }
            //randen tekenen
            e.Graphics.DrawRectangle(penBlack, rectangle);
            //naam tekenen
            e.Graphics.DrawString(name, f, BlackBrush, new PointF(xLocation + 5, 200));

        }
    }

    public class BlackKey : PianoKey
    {
        Pen penWhite = new Pen(Color.White, 2);
        SolidBrush brushWhite = new SolidBrush(Color.White);
        SolidBrush brushBlack = new SolidBrush(Color.Black);
        SolidBrush GrayBrush = new SolidBrush(Color.Gray);

        private Font f = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);

        public BlackKey(string name) : base(name) {    }

        //teken een vierkant voor de witte toets met nootletter erin
        public override void DrawKey(PaintEventArgs e, string name, int xLocation, int yLocation, int Width, int Height)
        {
            Rectangle rectangle = new Rectangle(xLocation, yLocation, 26, 150);
            //als de boolean true is wordt de key in het grijs getekend. Anders in de standaard kleur.
            if (isGray)
            {
                e.Graphics.FillRectangle(GrayBrush, rectangle);
            }
            else
            {
                e.Graphics.FillRectangle(brushBlack, rectangle);
            }
            //naam tekenen
            e.Graphics.DrawString(name.Substring(0,2), f, brushWhite, new PointF(xLocation + 1, 10));
        }

    }

}
