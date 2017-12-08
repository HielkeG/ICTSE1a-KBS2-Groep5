using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Control;

namespace VirtualPiano.View
{
    public partial class MidiSettings : Form
    {
        public MidiSettings()
        {
            InitializeComponent();

        }

        private void midiVelocity_Click(object sender, EventArgs e)
        {

        }

        private void midiDisconnect_Click(object sender, EventArgs e)
        {
            if (MusicController.outputDevice.IsOpen)
                labelOutput.Text = $"Output device: {MusicController.outputDevice.Name}";
        }
    }
}
