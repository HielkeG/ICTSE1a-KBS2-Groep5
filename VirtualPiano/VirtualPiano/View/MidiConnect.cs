using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VirtualPiano.View
{
    public partial class MidiConnect : Form
    {
        bool Clicked = false;
        public static int inputInt;
        public static int outputInt;

        public MidiConnect()
        {
            InitializeComponent();

            foreach (InputDevice device in InputDevice.InstalledDevices)
            {
                midiList.Items.Add(device.Name);
            }

            if (InputDevice.InstalledDevices.Count == 0)
            {
                midiNext.Enabled = false;
                midiList.Items.Add("Er is geen midi keyboard beschikbaar.");
            }
        }

        private void midiNext_Click(object sender, EventArgs e)
        {
            if (Clicked == false)
            {
                inputInt = midiList.SelectedIndex;
            }          

            midiList.Items.Clear();
            foreach (OutputDevice device in OutputDevice.InstalledDevices)
            {
                midiList.Items.Add(device.Name);
            }

            SelectMidi.Text = "Selecteer MIDI output";
            midiNext.Text = "Verbinden";

            if (Clicked)
            {
                Example05.Start(InputDevice.InstalledDevices[inputInt]);
                this.Close();
            }

            Clicked = true;


        }

        private void midiRefresh_Click(object sender, EventArgs e)
        {
            InputDevice.UpdateDevices();
            midiList.Items.Clear();
            foreach (InputDevice item in InputDevice.installedDevices)
            {
                midiList.Items.Add(item.Name);
            }
            midiNext.Enabled = true;
            if (InputDevice.installedDevices.Length == 0)
            {
                midiList.Items.Add("Er is geen midi keyboard beschikbaar.");
                midiNext.Enabled = false;
            }
        }
    }
}
