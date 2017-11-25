﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Model;
using VirtualPiano.Control;

namespace VirtualPiano.View
{
    public partial class MenuBarView : UserControl
    {
        public Song Song { get; set; }
        public event EventHandler selectedSong;

        public MenuBarView()
        {

            InitializeComponent();
        }

        public void GeluidAanUit(object sender, EventArgs e)
        {
            if (geluidAanuitToolStripMenuItem.Checked)
            {
                geluidAanuitToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
            else
            {
                geluidAanuitToolStripMenuItem.CheckState = CheckState.Checked;
            }
        }

        private void opslaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DatabaseController.SongExists(Song))
            {
                //bericht tonen met waarschuwing dat het nummer al bestaat. Optie geven om te overschrijven
                string message = "Er bestaat al een nummer met deze titel. Wilt u het bestaande nummer overschrijven?.";
                var result = MessageBox.Show(message, "Fout", MessageBoxButtons.YesNo);
                if (result == DialogResult.OK)
                {
                    DatabaseController.AddSong(Song);
                }
            }
            else
            {
                DatabaseController.AddSong(Song);
            }
        }

        private void openenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //als de notenbalk gevuld is een fout tonen. Zodat de gebruiker niet ineens het werk kwijt is.
            if (!Song.IsEmpty())
            {
                string message = "De notenbalk is niet leeg. Het openen van een ander nummer zal de notenbalk overschrijven. Wilt u doorgaan?";
                var result = MessageBox.Show(message, "Bericht", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    List<Song> songs = DatabaseController.GetSongs();
                    DatabaseFileExplorer databaseFileExplorer = new DatabaseFileExplorer();
                    foreach (Song song in songs)
                    {
                        databaseFileExplorer.ItemsList.Items.Add(song.Title);

                    }
                    databaseFileExplorer.ShowDialog();
                    if (DialogResult.OK == databaseFileExplorer.DialogResult)
                    {
                        //song instellen en event uitvoeren zodat ook mainform weet over de verandering
                        Song = databaseFileExplorer.Song;
                        selectedSong(this, e);
                    }
                }
            }
            else
            {
                List<Song> songs = DatabaseController.GetSongs();
                DatabaseFileExplorer databaseFileExplorer = new DatabaseFileExplorer();
                foreach (Song song in songs)
                {
                    databaseFileExplorer.ItemsList.Items.Add(song.Title);

                }
                databaseFileExplorer.ShowDialog();
                if (DialogResult.OK == databaseFileExplorer.DialogResult)
                {
                    Song = databaseFileExplorer.Song;
                    selectedSong(this, e);
                }
            }
        }
    }
}