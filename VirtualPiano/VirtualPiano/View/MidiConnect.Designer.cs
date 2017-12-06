﻿namespace VirtualPiano.View
{
    partial class MidiConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.midiList = new System.Windows.Forms.ListBox();
            this.midiNext = new System.Windows.Forms.Button();
            this.SelectMidi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // midiList
            // 
            this.midiList.FormattingEnabled = true;
            this.midiList.Location = new System.Drawing.Point(34, 75);
            this.midiList.Name = "midiList";
            this.midiList.Size = new System.Drawing.Size(443, 95);
            this.midiList.TabIndex = 0;
            // 
            // midiNext
            // 
            this.midiNext.Location = new System.Drawing.Point(34, 195);
            this.midiNext.Name = "midiNext";
            this.midiNext.Size = new System.Drawing.Size(75, 23);
            this.midiNext.TabIndex = 1;
            this.midiNext.Text = "Volgende";
            this.midiNext.UseVisualStyleBackColor = true;
            this.midiNext.Click += new System.EventHandler(this.midiNext_Click);
            // 
            // SelectMidi
            // 
            this.SelectMidi.AutoSize = true;
            this.SelectMidi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectMidi.Location = new System.Drawing.Point(31, 33);
            this.SelectMidi.Name = "SelectMidi";
            this.SelectMidi.Size = new System.Drawing.Size(178, 24);
            this.SelectMidi.TabIndex = 2;
            this.SelectMidi.Text = "Selecteer MIDI input";
            // 
            // MidiConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 292);
            this.Controls.Add(this.SelectMidi);
            this.Controls.Add(this.midiNext);
            this.Controls.Add(this.midiList);
            this.Name = "MidiConnect";
            this.Text = "MidiConnect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button midiNext;
        private System.Windows.Forms.Label SelectMidi;
        public System.Windows.Forms.ListBox midiList;
    }
}