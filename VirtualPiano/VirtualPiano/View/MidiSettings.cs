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
        public static bool Touch;
        private ListBox originalList = new ListBox();
        private bool createdBackup = false;
        public MidiSettings()
        {
            InitializeComponent();

            foreach (Instrument i in Enum.GetValues(typeof(Instrument)))
            {
                midiInstruments.Items.Add(i);
            }
        }

        private void CreateOriginalList()
        {
            foreach (var item in midiInstruments.Items)
            {
                originalList.Items.Add(item);
            }
        }

        private void checkTouch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTouch.Checked)
            {
                Touch = true;
            }
            else
            {
                Touch = false;
            }
        }

        private void instrumentFilter_TextChanged(object sender, EventArgs e)
        {
            ListBox toReturn = new ListBox();
            if (!createdBackup)
            {
                //backup van de originele lijst maken zodat de methode altijd beschikking heeft tot de volledige lijst.
                CreateOriginalList();
                createdBackup = true;
            }
            foreach (Instrument item in originalList.Items)
            {
                string tempItem = item.ToString().ToLower();
                if (tempItem.Contains(instrumentFilter.Text))
                {
                    toReturn.Items.Add(item);
                }
            }
            midiInstruments.Items.Clear();
            foreach (var item in toReturn.Items)
            {
                midiInstruments.Items.Add(item);

            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            MidiPlay.CurrentInstrument = (Instrument)midiInstruments.SelectedItem;
        }

        private void MidiSettings_Load(object sender, EventArgs e)
        {
            if (MidiConnect.IsConnected)
            {
                labelOutput.Text = $"Output device: {MusicController.outputDevice.Name}";
                labelInput.Text = $"Input device: {InputDevice.InstalledDevices[MidiConnect.inputInt].Name.ToString()}";
                labelOutput.Visible = true;
            } else
            {
                labelInput.Text = "Geen keyboard verbonden";
                labelOutput.Visible = false;
            }
        }
    }
}
    

