﻿using System;
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



            //Example05.Start(InputDevice.InstalledDevices[midiList.SelectedIndex]);
            
            midiList.Items.Clear();
            foreach (OutputDevice device in OutputDevice.InstalledDevices)
            {
                midiList.Items.Add(device.Name);
            }
            
            SelectMidi.Text = "Selecteer MIDI output";
            midiNext.Text = "Verbinden";

            if (Clicked)
            {

                //outputInt = midiList.SelectedIndex;
                //Console.WriteLine($"input int: {inputInt} output int: {outputInt}");
                //Console.WriteLine(outputMidi.Name);
                Example05.Start(InputDevice.InstalledDevices[inputInt]);
                this.Close();
            }

            Clicked = true;


        }
    }
}