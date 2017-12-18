using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Properties;

namespace VirtualPiano.View
{
    public partial class HelpSelectedView : UserControl
    {

        public event EventHandler closing;
        public event EventHandler exiting;
        public HelpSelectedView(string title, string explanation)
        {
            InitializeComponent();
            Title.Text = title;
            Explanation.Text = explanation;
        }

        public HelpSelectedView(string title, string explanation,bool image)
        {
            InitializeComponent();
            Title.Text = title;
            Explanation.Text = explanation;
            LinkLabel imageLink = new LinkLabel();
            imageLink.AutoSize = true;
            imageLink.Location = 
                Explanation.GetPositionFromCharIndex(Explanation.TextLength);
            imageLink.Text = "Klik hier voor de afbeelding.";
            imageLink.LinkClicked += ShowImage;
            Explanation.AppendText(imageLink.Text + "   ");
            Explanation.SelectionStart = Explanation.TextLength;
            Explanation.Controls.Add(imageLink);

        }

        private void ShowImage(object sender, EventArgs e)
        {
            Form image = new Form();
            image.Resize += Rescale;
            image.Size = new Size(1000, 500);
            PictureBox pb = new PictureBox();
            pb.Image = Resources.PianoBinds;
            pb.Size = image.Size;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Icon = Resources.logo_icon32x32;
            image.Controls.Add(pb);
            image.Show();
        }

        private void Rescale(object sender, EventArgs e)
        {
            Form form = (Form)sender;
            foreach (var item in form.Controls)
            {
                PictureBox item2 = (PictureBox)item;
                item2.Size = form.Size;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            exiting(this, e);
            Dispose();            
        }

        private void ToOverview_Click(object sender, EventArgs e)
        {
            closing(this, e);
            Dispose();
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void HelpSelectedView_KeyDown(object sender, KeyEventArgs e)
        {
            ToOverview_Click(this, e);
        }
    }
}
