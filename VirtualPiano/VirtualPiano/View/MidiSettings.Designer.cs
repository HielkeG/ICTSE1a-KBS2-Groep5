namespace VirtualPiano.View
{
    partial class MidiSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MidiSettings));
            this.labelInput = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.checkTouch = new System.Windows.Forms.CheckBox();
            this.midiInstruments = new System.Windows.Forms.ListBox();
            this.instrumentFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(13, 13);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(31, 13);
            this.labelInput.TabIndex = 3;
            this.labelInput.Text = "Input";
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(13, 30);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(39, 13);
            this.labelOutput.TabIndex = 4;
            this.labelOutput.Text = "Output";
            // 
            // checkTouch
            // 
            this.checkTouch.AutoSize = true;
            this.checkTouch.Location = new System.Drawing.Point(18, 55);
            this.checkTouch.Name = "checkTouch";
            this.checkTouch.Size = new System.Drawing.Size(57, 17);
            this.checkTouch.TabIndex = 5;
            this.checkTouch.Text = "Touch";
            this.checkTouch.UseVisualStyleBackColor = true;
            this.checkTouch.CheckedChanged += new System.EventHandler(this.checkTouch_CheckedChanged);
            // 
            // midiInstruments
            // 
            this.midiInstruments.FormattingEnabled = true;
            this.midiInstruments.Location = new System.Drawing.Point(12, 78);
            this.midiInstruments.Name = "midiInstruments";
            this.midiInstruments.Size = new System.Drawing.Size(260, 329);
            this.midiInstruments.TabIndex = 6;
            // 
            // instrumentFilter
            // 
            this.instrumentFilter.Location = new System.Drawing.Point(50, 416);
            this.instrumentFilter.Name = "instrumentFilter";
            this.instrumentFilter.Size = new System.Drawing.Size(100, 20);
            this.instrumentFilter.TabIndex = 7;
            this.instrumentFilter.TextChanged += new System.EventHandler(this.instrumentFilter_TextChanged);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilter.Location = new System.Drawing.Point(15, 419);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(29, 13);
            this.labelFilter.TabIndex = 8;
            this.labelFilter.Text = "Filter";
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(197, 414);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 9;
            this.buttonApply.Text = "Toepassen";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // MidiSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 450);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.instrumentFilter);
            this.Controls.Add(this.midiInstruments);
            this.Controls.Add(this.checkTouch);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MidiSettings";
            this.Text = "Instellingen";
            this.Load += new System.EventHandler(this.MidiSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelInput;
        public System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.CheckBox checkTouch;
        private System.Windows.Forms.ListBox midiInstruments;
        private System.Windows.Forms.TextBox instrumentFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Button buttonApply;
    }
}