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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.midiVelocity = new System.Windows.Forms.Label();
            this.midiDisconnect = new System.Windows.Forms.Button();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(168, 147);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 0;
            // 
            // midiVelocity
            // 
            this.midiVelocity.AutoSize = true;
            this.midiVelocity.Location = new System.Drawing.Point(13, 147);
            this.midiVelocity.Name = "midiVelocity";
            this.midiVelocity.Size = new System.Drawing.Size(69, 13);
            this.midiVelocity.TabIndex = 1;
            this.midiVelocity.Text = "Gevoeligheid";
            this.midiVelocity.Click += new System.EventHandler(this.midiVelocity_Click);
            // 
            // midiDisconnect
            // 
            this.midiDisconnect.Location = new System.Drawing.Point(130, 103);
            this.midiDisconnect.Name = "midiDisconnect";
            this.midiDisconnect.Size = new System.Drawing.Size(142, 23);
            this.midiDisconnect.TabIndex = 2;
            this.midiDisconnect.Text = "Verbinding verbreken";
            this.midiDisconnect.UseVisualStyleBackColor = true;
            this.midiDisconnect.Click += new System.EventHandler(this.midiDisconnect_Click);
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
            // MidiSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.midiDisconnect);
            this.Controls.Add(this.midiVelocity);
            this.Controls.Add(this.trackBar1);
            this.Name = "MidiSettings";
            this.Text = "MidiSettings";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label midiVelocity;
        private System.Windows.Forms.Button midiDisconnect;
        public System.Windows.Forms.Label labelInput;
        public System.Windows.Forms.Label labelOutput;
    }
}