namespace VirtualPiano.View
{
    partial class ComposeView
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FullNote = new System.Windows.Forms.ToolStripButton();
            this.HalfNote = new System.Windows.Forms.ToolStripButton();
            this.QuarterNote = new System.Windows.Forms.ToolStripButton();
            this.EightNote = new System.Windows.Forms.ToolStripButton();
            this.SixteenthNote = new System.Windows.Forms.ToolStripButton();
            this.ThirtySecondNote = new System.Windows.Forms.ToolStripButton();
            this.Sharp = new System.Windows.Forms.ToolStripButton();
            this.Flat = new System.Windows.Forms.ToolStripButton();
            this.GKey = new System.Windows.Forms.ToolStripButton();
            this.FKey = new System.Windows.Forms.ToolStripButton();
            this.FullRest = new System.Windows.Forms.ToolStripButton();
            this.HalfRest = new System.Windows.Forms.ToolStripButton();
            this.QuarterRest = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(130, 1000);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(130, 1000);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FullNote,
            this.HalfNote,
            this.QuarterNote,
            this.EightNote,
            this.SixteenthNote,
            this.ThirtySecondNote,
            this.Sharp,
            this.Flat,
            this.GKey,
            this.FKey,
            this.FullRest,
            this.HalfRest,
            this.QuarterRest});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(130, 1000);
            this.toolStrip1.TabIndex = 0;
            // 
            // FullNote
            // 
            this.FullNote.AutoSize = false;
            this.FullNote.Image = global::VirtualPiano.Properties.Resources.helenoot_icon;
            this.FullNote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FullNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FullNote.Margin = new System.Windows.Forms.Padding(0);
            this.FullNote.Name = "FullNote";
            this.FullNote.Size = new System.Drawing.Size(130, 55);
            this.FullNote.Text = "Hele noot";
            this.FullNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FullNote_MouseDown);
            // 
            // HalfNote
            // 
            this.HalfNote.AutoSize = false;
            this.HalfNote.Image = global::VirtualPiano.Properties.Resources.halvenoot_icon;
            this.HalfNote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HalfNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HalfNote.Name = "HalfNote";
            this.HalfNote.Size = new System.Drawing.Size(130, 55);
            this.HalfNote.Text = "Halve noot";
            this.HalfNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HalfNote_MouseDown);
            // 
            // QuarterNote
            // 
            this.QuarterNote.AutoSize = false;
            this.QuarterNote.Image = global::VirtualPiano.Properties.Resources.kwartnoot_icon;
            this.QuarterNote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.QuarterNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuarterNote.Name = "QuarterNote";
            this.QuarterNote.Size = new System.Drawing.Size(130, 55);
            this.QuarterNote.Text = "Kwart noot";
            this.QuarterNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QuarterNote_MouseDown);
            // 
            // EightNote
            // 
            this.EightNote.AutoSize = false;
            this.EightNote.Image = global::VirtualPiano.Properties.Resources.achtstenoot_icon;
            this.EightNote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EightNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EightNote.Name = "EightNote";
            this.EightNote.Size = new System.Drawing.Size(130, 55);
            this.EightNote.Text = "1/8e noot";
            this.EightNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EightNote_MouseDown);
            // 
            // SixteenthNote
            // 
            this.SixteenthNote.AutoSize = false;
            this.SixteenthNote.Image = global::VirtualPiano.Properties.Resources.zestiendenoot_icon;
            this.SixteenthNote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SixteenthNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SixteenthNote.Name = "SixteenthNote";
            this.SixteenthNote.Size = new System.Drawing.Size(130, 55);
            this.SixteenthNote.Text = "1/16e noot";
            this.SixteenthNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SixteenthNote_MouseDown);
            // 
            // ThirtySecondNote
            // 
            this.ThirtySecondNote.AutoSize = false;
            this.ThirtySecondNote.Image = global::VirtualPiano.Properties.Resources.tweeendertigstenoot_icon;
            this.ThirtySecondNote.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ThirtySecondNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ThirtySecondNote.Name = "ThirtySecondNote";
            this.ThirtySecondNote.Size = new System.Drawing.Size(130, 55);
            this.ThirtySecondNote.Text = "1/32e noot";
            // 
            // Sharp
            // 
            this.Sharp.AutoSize = false;
            this.Sharp.Image = global::VirtualPiano.Properties.Resources.Kruis;
            this.Sharp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Sharp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sharp.Name = "Sharp";
            this.Sharp.Size = new System.Drawing.Size(130, 55);
            this.Sharp.Text = "Kruis";
            // 
            // Flat
            // 
            this.Flat.AutoSize = false;
            this.Flat.Image = global::VirtualPiano.Properties.Resources.Mol;
            this.Flat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Flat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Flat.Name = "Flat";
            this.Flat.Size = new System.Drawing.Size(130, 55);
            this.Flat.Text = "Mol";
            // 
            // GKey
            // 
            this.GKey.AutoSize = false;
            this.GKey.Image = global::VirtualPiano.Properties.Resources.Gsleutel_icon;
            this.GKey.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GKey.Name = "GKey";
            this.GKey.Size = new System.Drawing.Size(130, 55);
            this.GKey.Text = "G-Sleutel";
            // 
            // FKey
            // 
            this.FKey.AutoSize = false;
            this.FKey.Image = global::VirtualPiano.Properties.Resources.fsleutel;
            this.FKey.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FKey.Name = "FKey";
            this.FKey.Size = new System.Drawing.Size(130, 55);
            this.FKey.Text = "F-Sleutel";
            // 
            // FullRest
            // 
            this.FullRest.AutoSize = false;
            this.FullRest.Image = global::VirtualPiano.Properties.Resources.HeleRust;
            this.FullRest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FullRest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FullRest.Name = "FullRest";
            this.FullRest.Size = new System.Drawing.Size(130, 55);
            this.FullRest.Text = "Hele Rust";
            this.FullRest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FullRest_MouseDown);
            // 
            // HalfRest
            // 
            this.HalfRest.AutoSize = false;
            this.HalfRest.Image = global::VirtualPiano.Properties.Resources.HalveRust;
            this.HalfRest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HalfRest.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.HalfRest.Name = "HalfRest";
            this.HalfRest.Size = new System.Drawing.Size(130, 55);
            this.HalfRest.Text = "Halve Rust";
            this.HalfRest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HalfRest_MouseDown);
            // 
            // QuarterRest
            // 
            this.QuarterRest.AutoSize = false;
            this.QuarterRest.Image = global::VirtualPiano.Properties.Resources.KwartRust;
            this.QuarterRest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.QuarterRest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuarterRest.Name = "QuarterRest";
            this.QuarterRest.Size = new System.Drawing.Size(130, 55);
            this.QuarterRest.Text = "Kwart rust";
            this.QuarterRest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QuarterRest_MouseDown);
            // 
            // ComposeView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.toolStripContainer1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "ComposeView";
            this.Size = new System.Drawing.Size(200, 1000);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComposeView_MouseDown);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton FullNote;
        private System.Windows.Forms.ToolStripButton HalfNote;
        private System.Windows.Forms.ToolStripButton QuarterNote;
        private System.Windows.Forms.ToolStripButton EightNote;
        private System.Windows.Forms.ToolStripButton SixteenthNote;
        private System.Windows.Forms.ToolStripButton ThirtySecondNote;
        private System.Windows.Forms.ToolStripButton Sharp;
        private System.Windows.Forms.ToolStripButton Flat;
        private System.Windows.Forms.ToolStripButton GKey;
        private System.Windows.Forms.ToolStripButton FKey;
        private System.Windows.Forms.ToolStripButton FullRest;
        private System.Windows.Forms.ToolStripButton HalfRest;
        private System.Windows.Forms.ToolStripButton QuarterRest;
    }
}
