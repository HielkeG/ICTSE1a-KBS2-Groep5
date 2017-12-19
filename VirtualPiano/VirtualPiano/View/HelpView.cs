using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPiano.Properties;

namespace VirtualPiano.View
{
    public partial class HelpView : Form
    {
        public HelpView()
        {
            InitializeComponent();
            Icon = Resources.logo_icon32x32;
        }

        private void ResetView(object sender, EventArgs e)
        {
            InitializeComponent();
        }
        private void CloseView(object sender,EventArgs e)
        {
            Dispose();
        }

        private void NotenbalkToevoegen_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //methode die titel, uitleg en image zet
            ShowExplain("Notenbalk toevoegen","Standaard bestaat het componeerscherm uit één notenbalk. " +
                "Dit kan uitgebreid worden door op het plus knopje onder de notenbalk te klikken. " +
                "Als op deze knop gedrukt wordt verschijnt er een nieuwe notenbalk onder de laatste. " +
                "Er kunnen maximaal x aantal notenbalken op een pagina. De notenbalk bevat vier maten.", false);
        }

        private void NotenToevoegen_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Noten toevoegen", "Een notenbalk bevat standaard geen noten. " +
                "U kunt noten toevoegen aan een notenbalk door op de gewenste noot te klikken in de toolbar. " +
                "De muisaanwijzer verandert dan in de geselecteerde noot." +
                " Vervolgens klikt u in de gewenste maat op de plek waar u de noot wilt hebben. " +
                "De noot wordt nu toegevoegd aan de maat.\n\n" +
                "Een maat heeft een standaard maataanduiding van vierkwartsmaten. " +
                "U kunt daardoor niet meer noten toevoegen als de maat vol is. " +
                "De rode lijn onder de maat verandert van kleur als de maat volledig is.", false);

        }

        private void KruisMol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Kruizen en mollen toevoegen", "U kunt kruizen en mollen toevoegen door op het # of b teken te klikken en vervolgens op de gewenste locatie op de notenbalk te klikken." +
                "Wanneer u hier klikt wordt het geselecteerde teken geplaatst. Om een teken te verwijderen beweegt u de muis over het teken heen en klikt u op de rechtermuisknop.", false);
        }

        private void SpelendComp_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Componeren met toetsenbord/keyboard", "In deze applicatie heeft u de mogelijkheid om uw toetsaanslagen op te nemen en deze om te zetten in noten. " +
                "Dit doet u door op de opnameknop te drukken zodat de opneemmodus aanstaat. Als u dan typend gaat spelen worden de noten in de notenbalk geplaatst. " +
                "U kunt hele noten, halve noten en kwart noten spelen. U kunt stoppen met opnemen door op de stopknop te drukken.", false);
        }

        private void MuziekSleutel_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Muzieksleutel wijzigen", "De standaardnotering van de maten zijn in de G-sleutel. " +
                "Als u de sleutel van een maat wilt wijzigen, klikt u op de gewenste sleutel. " +
                "Vervolgens klikt u op de maat die u wilt wijzigen. " +
                "Als er al noten in die maat zijn, worden die verwijderd.", false);
        }

        private void LiedAfsp_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Lied afspelen", "Om een lied af te spelen moet u eerst een bestaand lied maken of inladen. " +
                "Om te weten hoe u dit moet doen gaat u naar hoofdstuk 4. " +
                "Wanneer u een geldig lied klaar heeft staan klikt u op de afspeelknop. " +
                "Op dat moment begint de applicatie het lied af te spelen. " +
                "De applicatie tekent een rode lijn over de notenbalk om aan te geven waar in het lied het afspelen is.", false);
        }

        private void Typendspel_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Typend spelen", "U kunt zelf een instrument bespelen via de applicatie door het virtuele piano weer te geven. " +
                "Wanneer u dit doet kunt u door gebruik te maken van uw toetsenbord het instrument bespelen. " +
                "De toetsaanslagen worden automatisch geregistreerd. ",true);
        }

        private void MidiConnect_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Extern MIDI-keyboard", "U kunt in deze applicatie gebruik maken van uw eigen MIDI-keyboard. " +
                "U kunt uw MIDI-keyboard aansluiten door via het menu op “MIDI” te klikken en vervolgens “keyboard verbinden” te selecteren. " +
                "Het systeem opent dan een nieuw scherm waar u uw input en output selecteert. Uw input is in dit geval uw keyboard, dus selecteert u deze en klikt u op “volgende”. " +
                "Vervolgens kiest u een output, dit kan bijvoorbeeld een koptelefoon of luidspreker zijn. Wanneer u vervolgens op “volgende” klikt is het keyboard klaar voor gebruik.\n\n" +
                "Wanneer er geen keyboard zichtbaar is in de lijst of wanneer u uw keyboard later aangesloten heeft selecteert u “verversen”. " +
                "Het systeem zoekt dan opnieuw MIDI-apparaten op en toont die vervolgens in de lijst.", false);
        }

        private void Opslaan_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Lied opslaan", "U kunt een lied opslaan door links bovenin het scherm op ‘bestand’ en daarna op ‘opslaan’ te klikken. " +
                "Uw lied wordt opgeslagen met uw titel als naam. Mocht het zo zijn dat er al een lied bestaat met dezelfde titel, dan wordt u gevraagd of u het bestaande bestand wil overschrijven. " +
                "Als u dit doet wordt het bestaande bestand verwijderd en uw huidige lied opgeslagen.",false);
        }

        private void Openen_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Lied openen", "U kunt verdergaan met uw werk door een opgeslagen lied te openen. " +
                "U kunt dit doen door op bestand en dan op openen te klikken. " +
                "Er wordt dan een muziekverkenner getoond. Hierin worden alle opgeslagen liedjes uit de database getoond. " +
                "U kunt een lied opzoeken door de titel van het lied volledig of gedeeltelijk in te typen. " +
                "De verkenner toont dan alleen liedjes met overeenkomende namen. " +
                "Als u vervolgens een lied selecteert wordt de muziekverkenner gesloten en het lied getoond. ",false);
        }

        private void Verwijderen_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Lied verwijderen", "U kunt een lied verwijderen door op ‘bestand’ in de menubalk te klikken. " +
                "En vervolgens verwijderen te selecteren. " +
                "Op dat moment wordt er een muziekverkenner geopend die alle opgeslagen liedjes van de database toont. " +
                "U kunt een lied opzoeken door de titel volledig of gedeeltelijk in te typen. " +
                "Het systeem filtert dan de liedjes op deze naam. " +
                "Wanneer u een lied selecteert en op ‘verwijderen’ klikt krijgt u een bevestiging te zien. " +
                "Als u op ‘ja’ klikt wordt het lied definitief verwijderd.",false);
        }

        private void Nootsoorten_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Notensoorten", "In de muziek bestaan verschillende soorten noten: Hele noten, halve, kwarten, achtste, 1/16e enzovoort." +
                "Deze worden allemaal aangegeven met een eigen icoon. Wanneer je de muis over een noot in de toolbar houdt kan je zien welke noot dit is.",false);
        }

        private void Tonen_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Tonen", "Een toon is een bepaalde hoogte van geluid.",false);

        }

        private void Maten_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Maten", "",false);

        }

        private void MolKruis_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Mollen en kruizen", "",false);

        }

        private void Sleutels_Clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowExplain("Sleutels", "",false);
        }

        private void ShowExplain(string title, string explanation,bool image)
        {
            //maakt huidige view leeg en zet daar een helpselectedview in. 
            Controls.Clear();
            HelpSelectedView helpSelected = new HelpSelectedView(title, explanation,image);
            helpSelected.Dock = DockStyle.Fill;
            helpSelected.exiting += CloseView;
            KeyDown += CloseOnEsc;
            helpSelected.closing += ResetView;
            Controls.Add(helpSelected);

        }


        private void CloseOnEsc(Object sender, KeyEventArgs e)
        {
            //uitlegscherm wordt gesloten als er op esc wordt gedrukt vanuit dit scherm.
            if (e.KeyCode == Keys.Escape)
            {
                foreach (var item in Controls)
                {
                    if (item.GetType() == typeof(HelpSelectedView))
                    {
                        HelpSelectedView uc = (HelpSelectedView)item;
                        uc.Dispose();
                        ResetView(this, e);
                    }
                }
            }
        }


    }
}
