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
        public static int inputInt;
        public static int outputInt;
        public static bool IsConnected = false;

        public MidiConnect()
        {
            InitializeComponent();
            //lijst vullen met apparaten
            foreach (InputDevice device in InputDevice.InstalledDevices)
            {
                midiList.Items.Add(device.Name);
            }

            if (InputDevice.InstalledDevices.Count == 0)
            {
                midiNext.Enabled = false;
                midiList.Items.Add("Er is geen midi keyboard beschikbaar.");
            }

            if (IsConnected)
            {
                midiDisconnect.Enabled = true;
            }
            else
            {
                midiDisconnect.Enabled = false;
            }
        }

        private void midiNext_Click(object sender, EventArgs e)
        {
            //outputscherm openen
            if (IsConnected == false)
            {
                inputInt = midiList.SelectedIndex;
                MidiPlay.Start(InputDevice.InstalledDevices[inputInt]);
                this.Close();

                string message = "Keyboard is verbonden";
                string caption = InputDevice.InstalledDevices[inputInt].Name.ToString();
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                IsConnected = true;
                midiDisconnect.Enabled = true;
                midiRefresh.Enabled = false;
            }     
            
            if(IsConnected == false)
            {
                midiNext.Enabled = true;
            } else
            {
                midiNext.Enabled = false;
            }
        }

        //midi apparatenlijst verversen.
        private void midiRefresh_Click(object sender, EventArgs e)
        {
            //nieuwe apparaten opzoeken
            InputDevice.UpdateDevices();
            //lijst leegmaken en opnieuw vullen
            midiList.Items.Clear();
            foreach (InputDevice item in InputDevice.installedDevices)
            {
                midiList.Items.Add(item.Name);
            }
            if (InputDevice.installedDevices.Length == 0)
            {
                midiList.Items.Add("Er is geen midi keyboard beschikbaar.");
            }
        }

        private void midiDisconnect_Click(object sender, EventArgs e)
        {
            string message = "Verbinding is verbroken";
            string caption = InputDevice.InstalledDevices[inputInt].Name.ToString();
            MidiPlay.Stop(InputDevice.InstalledDevices[inputInt]);
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            IsConnected = false;
            midiDisconnect.Enabled = false;
            midiNext.Enabled = true;
            midiRefresh.Enabled = true;
            this.Close();            
        }
    }
}
