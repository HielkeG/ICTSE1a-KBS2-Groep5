﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPiano.Control;
using System.Windows.Forms;
using VirtualPiano.Model;

namespace VirtualPiano.View
{
    public partial class MenuBarView : UserControl
    {
        public Song Song { get; set; }
        public event EventHandler selectedSong;
        public event EventHandler newSong;
        public event EventHandler newStaffView;
        public event EventHandler togglePianoVisible;
        MenuBarController mbc = new MenuBarController();
        public static MidiConnect m1 = new MidiConnect();
        public static MidiSettings m2 = new MidiSettings();
        private List<HelpView> HelpViews = new List<HelpView>();
        public MenuBarView()
        {

            InitializeComponent();
        }


        private void Save_Click(object sender, EventArgs e)
        {
            if (Song.Title == " ")
            {
                MessageBox.Show("De titel is leeg. Vul een titel in.", "Fout", MessageBoxButtons.OK);
            }
            else if (DatabaseController.SongExists(Song))
            {
                //bericht tonen met waarschuwing dat het nummer al bestaat. Optie geven om te overschrijven
                string message = "Er bestaat al een nummer met deze titel. Wilt u het bestaande nummer overschrijven?.";
                var result = MessageBox.Show(message, "Fout", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DatabaseController.UpdateSong(Song);
                    MessageBoxSavedSong();
                }
            }

            else
            {
                DatabaseController.AddSong(Song);
                MessageBoxSavedSong();
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            //als de notenbalk gevuld is een fout tonen. Zodat de gebruiker niet ineens het werk kwijt is.
            if (!Song.IsEmpty())
            {
                string message = "De notenbalk is niet leeg. Het openen van een ander nummer zal de notenbalk overschrijven. Wilt u doorgaan?";
                var result = MessageBox.Show(message, "Bericht", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    List<Song> songs = VirtualPiano.Control.DatabaseController.GetSongs();
                    DatabaseFileExplorer databaseFileExplorer = new DatabaseFileExplorer();
                    foreach (Song song in songs)
                    {
                        databaseFileExplorer.ItemsList.Items.Add(song.Title);

                    }
                    databaseFileExplorer.ShowDialog();
                    if (DialogResult.OK == databaseFileExplorer.DialogResult && databaseFileExplorer.Song != null)
                    {
                        //song instellen en event uitvoeren zodat ook mainform weet over de verandering
                        Song = databaseFileExplorer.Song;
                        selectedSong(this, e);
                    }
                    else
                    {
                        MessageBox.Show("Er is geen nummer geselecteerd.", "Melding", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                List<Song> songs = VirtualPiano.Control.DatabaseController.GetSongs();
                DatabaseFileExplorer databaseFileExplorer = new DatabaseFileExplorer();
                foreach (Song song in songs)
                {
                    databaseFileExplorer.ItemsList.Items.Add(song.Title);

                }
                databaseFileExplorer.ShowDialog();
                if (DialogResult.OK == databaseFileExplorer.DialogResult && databaseFileExplorer.Song != null)
                {
                    Song = databaseFileExplorer.Song;
                    selectedSong(this, e);
                }
                else
                {
                    MessageBox.Show("Er is geen nummer geselecteerd.", "Melding", MessageBoxButtons.OK);
                }
            }
        }


        private void MessageBoxSavedSong()
        {
            MessageBox.Show("Het nummer is opgeslagen.", "Melding", MessageBoxButtons.OK);
        }

        private void NewSong_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Uw huidige nummer zal verloren gaan. Wilt u doorgaan?", "Waarschuwing", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                newSong(this, e);

            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            //zoeklijst invullen
            List<Song> songs = VirtualPiano.Control.DatabaseController.GetSongs();
            DatabaseFileRemover databaseFileRemover = new DatabaseFileRemover();
            foreach (Song song in songs)
            {
                databaseFileRemover.ItemsList.Items.Add(song.Title);

            }
            //explorer laten zien
            databaseFileRemover.ShowDialog();
            if (DialogResult.OK == databaseFileRemover.DialogResult)
            {
                //als de song niet null is wordt deze verwijderd.
                if (databaseFileRemover.Song != null)
                {
                    var result = MessageBox.Show("Weet u zeker dat u dit nummer wilt verwijderen.", "Waarschuwing", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        VirtualPiano.Control.DatabaseController.RemoveSong(databaseFileRemover.Song.Title);
                        MessageBox.Show("Het nummer is verwijderd.", "Melding", MessageBoxButtons.OK);
                    }
                }
                //anders krijgt de gebruiker een melding te zien.
                else
                {
                    MessageBox.Show("Er is geen nummer geselecteerd.", "Melding", MessageBoxButtons.OK);
                }
            }
        }

        private void Piano_Click(object sender, EventArgs e)
        {
            mbc.ChangeInstrument(this, "Piano");
            MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.AcousticGrandPiano);
        }


        private void Marimba_Click(object sender, EventArgs e)
        {
            mbc.ChangeInstrument(this, "Marimba");
            MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.Marimba);
        }

        private void Gitaar_Click(object sender, EventArgs e)
        {
            mbc.ChangeInstrument(this, "Gitaar");
            MusicController.outputDevice.SendProgramChange(Channel.Channel1, Instrument.ElectricGuitarClean);
        }

        private void AddStaffView_Click(object sender, EventArgs e)
        {
            newStaffView(this, e);
        }

        private void midiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ConnectKeyboard(object sender, EventArgs e)
        {
            m1.ShowDialog();
        }

        private void ShowKeyboard(object sender, EventArgs e)
        {

        }

        private void Visible_Click(object sender, EventArgs e)
        {
            if (ComposeView.pkv1.Visible == false)
            {
                ComposeView.pkv1.Visible = true;
                KeyboardVisible.CheckState = CheckState.Checked;
                togglePianoVisible(this, e);
            }
            else
            {
                ComposeView.pkv1.Visible = false;
                KeyboardVisible.CheckState = CheckState.Unchecked;
                togglePianoVisible(this, e);

            }
        }

        private void ToggleSound(object sender, EventArgs e)
        {
            if (SoundOnOff.Checked)
            {
                SoundOnOff.CheckState = CheckState.Unchecked;
                ComposeView.SoundEnabled = false;  //mute
            }
            else
            {
                SoundOnOff.CheckState = CheckState.Checked;
                ComposeView.SoundEnabled = true;   //unmute
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            m2.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //als er al een helpscherm bestaat wordt deze gesloten.
            foreach (var item in HelpViews)
            {
                item.Dispose();
            }
            HelpViews.Clear();
            //helpview wordt opnieuw geopend.
            HelpView help = new HelpView();
            HelpViews.Add(help);
            help.Show();
        }
    }
}