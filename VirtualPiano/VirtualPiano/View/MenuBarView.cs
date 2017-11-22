using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Control;
using System.Windows.Forms;

namespace VirtualPiano.View
{
    public partial class MenuBarView : UserControl
    {
        MenuBarController mbc = new MenuBarController();

        public MenuBarView()
        {
            InitializeComponent();
        }

        public void GeluidAanUit(object sender, EventArgs e)
        {
            mbc.SoundToggle(this);
        }
    }
}