using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPiano.View
{
    public partial class MenuBarView : UserControl
    {
        public MenuBarView()
        {
            InitializeComponent();
        }

        public void geluidAanuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (geluidAanuitToolStripMenuItem.Checked)
            {
                geluidAanuitToolStripMenuItem.CheckState = CheckState.Unchecked;
                Console.WriteLine("zet false");
            }
            else
            {
                geluidAanuitToolStripMenuItem.CheckState = CheckState.Checked;
                Console.WriteLine("zet false");
            }
        }
    }
}