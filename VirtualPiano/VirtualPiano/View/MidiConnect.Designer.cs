namespace VirtualPiano.View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidiConnect));
            this.midiList = new System.Windows.Forms.ListBox();
            this.midiNext = new System.Windows.Forms.Button();
            this.SelectMidi = new System.Windows.Forms.Label();
            this.midiRefresh = new System.Windows.Forms.Button();
            this.midiDisconnect = new System.Windows.Forms.Button();
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
            this.midiNext.Text = "Verbinden";
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
            // midiRefresh
            // 
            this.midiRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.midiRefresh.Location = new System.Drawing.Point(485, 107);
            this.midiRefresh.Name = "midiRefresh";
            this.midiRefresh.Size = new System.Drawing.Size(75, 23);
            this.midiRefresh.TabIndex = 3;
            this.midiRefresh.Text = "Verversen";
            this.midiRefresh.UseVisualStyleBackColor = false;
            this.midiRefresh.Click += new System.EventHandler(this.midiRefresh_Click);
            // 
            // midiDisconnect
            // 
            this.midiDisconnect.Location = new System.Drawing.Point(440, 195);
            this.midiDisconnect.Name = "midiDisconnect";
            this.midiDisconnect.Size = new System.Drawing.Size(120, 23);
            this.midiDisconnect.TabIndex = 4;
            this.midiDisconnect.Text = "Verbinding verbreken";
            this.midiDisconnect.UseVisualStyleBackColor = true;
            this.midiDisconnect.Click += new System.EventHandler(this.midiDisconnect_Click);
            // 
            // MidiConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 241);
            this.Controls.Add(this.midiDisconnect);
            this.Controls.Add(this.midiRefresh);
            this.Controls.Add(this.SelectMidi);
            this.Controls.Add(this.midiNext);
            this.Controls.Add(this.midiList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MidiConnect";
            this.Text = "Midi keyboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button midiNext;
        private System.Windows.Forms.Label SelectMidi;
        public System.Windows.Forms.ListBox midiList;
        private System.Windows.Forms.Button midiRefresh;
        private System.Windows.Forms.Button midiDisconnect;
    }
}