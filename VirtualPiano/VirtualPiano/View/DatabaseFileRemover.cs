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
using VirtualPiano.Model;

namespace VirtualPiano.View
{
    public partial class DatabaseFileRemover : Form
    {
        private ListBox originalList = new ListBox();
        private bool createdBackup = false;
        public Song Song { get; set; }

        public DatabaseFileRemover()
        {
            InitializeComponent();
        }

        private void ZoekOpdracht_TextChanged(object sender, EventArgs e)
        {
            ListBox toReturn = new ListBox();
            if (!createdBackup)
            {
                //backup van de originele lijst maken zodat de methode altijd beschikking heeft tot de volledige lijst.
                CreateOriginalList();
                createdBackup = true;
            }
            foreach (string item in originalList.Items)
            {
                //tijdelijke string om te vergelijken, ook als de hoofdletters verschillen
                string tempItem = item.ToLower();
                if (tempItem.Contains(ZoekOpdracht.Text))
                {
                    toReturn.Items.Add(item);
                }
            }
            ItemsList.Items.Clear();
            foreach (var item in toReturn.Items)
            {
                ItemsList.Items.Add(item);

            }
        }

        private void CreateOriginalList()
        {
            foreach (var item in ItemsList.Items)
            {
                originalList.Items.Add(item);
            }
        }

        private void Verwijder_Click(object sender, EventArgs e)
        {
            //als de gebruiker een item heeft aangeklikt wordt het nummer geupdatet.
            if (ItemsList.SelectedItem != null)
            {
                List<Song> songs = DatabaseController.GetSongs();
                foreach (var item in songs)
                {
                    if ((string)ItemsList.SelectedItem == item.Title)
                    {
                        Song = new Song();
                        Song.Title = (string)ItemsList.SelectedItem;
                    }
                }
            }
        }
    }
}
