﻿namespace VirtualPiano.View
{
    partial class PianoKeysView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PianoTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // PianoKeysView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "PianoKeysView";
            this.Size = new System.Drawing.Size(1037, 211);
            this.PianoTooltip.SetToolTip(this, "Begin met typen om te spelen. Raadpleeg de handleiding om de toetsindeling te zie" +
        "n.");
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip PianoTooltip;
    }
}
