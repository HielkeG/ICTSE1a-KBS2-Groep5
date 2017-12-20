using System;
using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComposeView));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Metronome = new System.Windows.Forms.Timer(this.components);
            this.Snelheid = new System.Windows.Forms.TextBox();
            this.RedLine = new System.Windows.Forms.Timer(this.components);
            this.TitelBox = new System.Windows.Forms.TextBox();
            this.MetronoomLabel = new System.Windows.Forms.Label();
            this.MetronomeSpeed = new System.Windows.Forms.TextBox();
            this.CurrentPageLabel = new System.Windows.Forms.Label();
            this.metroTip = new System.Windows.Forms.ToolTip(this.components);
            this.GKey = new System.Windows.Forms.ToolStripButton();
            this.FKey = new System.Windows.Forms.ToolStripButton();
            this.FullNote = new System.Windows.Forms.ToolStripButton();
            this.HalfNote = new System.Windows.Forms.ToolStripButton();
            this.QuarterNote = new System.Windows.Forms.ToolStripButton();
            this.EightNote = new System.Windows.Forms.ToolStripButton();
            this.SixteenthNote = new System.Windows.Forms.ToolStripButton();
            this.FullRest = new System.Windows.Forms.ToolStripButton();
            this.HalfRest = new System.Windows.Forms.ToolStripButton();
            this.QuarterRest = new System.Windows.Forms.ToolStripButton();
            this.EightRest = new System.Windows.Forms.ToolStripButton();
            this.SixteenthRest = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Flat = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.Bin = new System.Windows.Forms.ToolStripButton();
            this.menuBarView1 = new VirtualPiano.View.MenuBarView();
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
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.Transparent;
            this.toolStripContainer1.ContentPanel.BackgroundImage = global::VirtualPiano.Properties.Resources.toolbarbg;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.ContentPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer1.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(80, 927);
            this.toolStripContainer1.Location = new System.Drawing.Point(1, 105);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(80, 927);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GKey,
            this.FKey,
            this.toolStripSeparator1,
            this.FullNote,
            this.HalfNote,
            this.QuarterNote,
            this.EightNote,
            this.SixteenthNote,
            this.toolStripSeparator2,
            this.FullRest,
            this.HalfRest,
            this.QuarterRest,
            this.EightRest,
            this.SixteenthRest,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.Flat,
            this.toolStripSeparator4,
            this.toolStripButton2,
            this.toolStripSeparator5,
            this.Bin});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(8, 13);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(65, 895);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator1.Size = new System.Drawing.Size(50, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator2.Size = new System.Drawing.Size(50, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator3.Size = new System.Drawing.Size(50, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator4.Size = new System.Drawing.Size(50, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator5.Size = new System.Drawing.Size(50, 6);
            // 
            // Metronome
            // 
            this.Metronome.Tick += new System.EventHandler(this.Metronome_Tick);
            // 
            // Snelheid
            // 
            this.Snelheid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Snelheid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Snelheid.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Snelheid.Location = new System.Drawing.Point(304, 103);
            this.Snelheid.Name = "Snelheid";
            this.Snelheid.Size = new System.Drawing.Size(100, 23);
            this.Snelheid.TabIndex = 16;
            this.Snelheid.TextChanged += new System.EventHandler(this.Snelheid_TextChanged);
            // 
            // RedLine
            // 
            this.RedLine.Interval = 20;
            this.RedLine.Tick += new System.EventHandler(this.RedLine_Tick);
            // 
            // TitelBox
            // 
            this.TitelBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitelBox.BackColor = System.Drawing.Color.White;
            this.TitelBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TitelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitelBox.Location = new System.Drawing.Point(720, 45);
            this.TitelBox.Margin = new System.Windows.Forms.Padding(0);
            this.TitelBox.MaxLength = 96;
            this.TitelBox.Name = "TitelBox";
            this.TitelBox.Size = new System.Drawing.Size(480, 37);
            this.TitelBox.TabIndex = 1;
            this.TitelBox.Text = "Artiest - Titel";
            this.TitelBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TitelBox.TextChanged += new System.EventHandler(this.TitelBox_TextChanged);
            this.TitelBox.Enter += new System.EventHandler(this.TitelBox_Enter);
            this.TitelBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TitelBox_KeyDown);
            this.TitelBox.Leave += new System.EventHandler(this.TitelBox_Leave);
            // 
            // MetronoomLabel
            // 
            this.MetronoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MetronoomLabel.ForeColor = System.Drawing.Color.Black;
            this.MetronoomLabel.Location = new System.Drawing.Point(1582, 56);
            this.MetronoomLabel.Name = "MetronoomLabel";
            this.MetronoomLabel.Size = new System.Drawing.Size(107, 23);
            this.MetronoomLabel.TabIndex = 3;
            this.MetronoomLabel.Text = "Metronoom:";
            // 
            // MetronomeSpeed
            // 
            this.MetronomeSpeed.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MetronomeSpeed.Location = new System.Drawing.Point(1695, 54);
            this.MetronomeSpeed.Name = "MetronomeSpeed";
            this.MetronomeSpeed.Size = new System.Drawing.Size(40, 25);
            this.MetronomeSpeed.TabIndex = 4;
            this.MetronomeSpeed.Text = "100";
            this.MetronomeSpeed.TextChanged += new System.EventHandler(this.MetronomeSpeed_TextChanged);
            // 
            // CurrentPageLabel
            // 
            this.CurrentPageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentPageLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CurrentPageLabel.Location = new System.Drawing.Point(1765, 955);
            this.CurrentPageLabel.Name = "CurrentPageLabel";
            this.CurrentPageLabel.Size = new System.Drawing.Size(106, 58);
            this.CurrentPageLabel.TabIndex = 5;
            this.CurrentPageLabel.Text = "1";
            // 
            // GKey
            // 
            this.GKey.AutoSize = false;
            this.GKey.BackColor = System.Drawing.Color.Transparent;
            this.GKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GKey.Image = ((System.Drawing.Image)(resources.GetObject("GKey.Image")));
            this.GKey.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GKey.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.GKey.Name = "GKey";
            this.GKey.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.GKey.Size = new System.Drawing.Size(55, 55);
            this.GKey.Text = "G-Sleutel";
            this.GKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GKey_MouseDown);
            // 
            // FKey
            // 
            this.FKey.AutoSize = false;
            this.FKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FKey.Image = ((System.Drawing.Image)(resources.GetObject("FKey.Image")));
            this.FKey.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FKey.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.FKey.Name = "FKey";
            this.FKey.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.FKey.Size = new System.Drawing.Size(55, 55);
            this.FKey.Text = "F-Sleutel";
            this.FKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FKey_MouseDown);
            // 
            // FullNote
            // 
            this.FullNote.AutoSize = false;
            this.FullNote.BackColor = System.Drawing.Color.Transparent;
            this.FullNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FullNote.Image = ((System.Drawing.Image)(resources.GetObject("FullNote.Image")));
            this.FullNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FullNote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.FullNote.Name = "FullNote";
            this.FullNote.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.FullNote.Size = new System.Drawing.Size(50, 50);
            this.FullNote.Text = "Hele noot";
            this.FullNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FullNote_MouseDown);
            // 
            // HalfNote
            // 
            this.HalfNote.AutoSize = false;
            this.HalfNote.BackColor = System.Drawing.Color.Transparent;
            this.HalfNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HalfNote.Image = ((System.Drawing.Image)(resources.GetObject("HalfNote.Image")));
            this.HalfNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HalfNote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.HalfNote.Name = "HalfNote";
            this.HalfNote.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.HalfNote.Size = new System.Drawing.Size(50, 50);
            this.HalfNote.Text = "Halve noot";
            this.HalfNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HalfNote_MouseDown);
            // 
            // QuarterNote
            // 
            this.QuarterNote.AutoSize = false;
            this.QuarterNote.BackColor = System.Drawing.Color.Transparent;
            this.QuarterNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuarterNote.Image = ((System.Drawing.Image)(resources.GetObject("QuarterNote.Image")));
            this.QuarterNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuarterNote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.QuarterNote.Name = "QuarterNote";
            this.QuarterNote.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.QuarterNote.Size = new System.Drawing.Size(50, 50);
            this.QuarterNote.Text = "Kwart noot";
            this.QuarterNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QuarterNote_MouseDown);
            // 
            // EightNote
            // 
            this.EightNote.AutoSize = false;
            this.EightNote.BackColor = System.Drawing.Color.Transparent;
            this.EightNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EightNote.Image = ((System.Drawing.Image)(resources.GetObject("EightNote.Image")));
            this.EightNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EightNote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.EightNote.Name = "EightNote";
            this.EightNote.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.EightNote.Size = new System.Drawing.Size(50, 50);
            this.EightNote.Text = "1/8e noot";
            this.EightNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EightNote_MouseDown);
            // 
            // SixteenthNote
            // 
            this.SixteenthNote.AutoSize = false;
            this.SixteenthNote.BackColor = System.Drawing.Color.Transparent;
            this.SixteenthNote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SixteenthNote.Image = ((System.Drawing.Image)(resources.GetObject("SixteenthNote.Image")));
            this.SixteenthNote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SixteenthNote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.SixteenthNote.Name = "SixteenthNote";
            this.SixteenthNote.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.SixteenthNote.Size = new System.Drawing.Size(50, 50);
            this.SixteenthNote.Text = "1/16e noot";
            this.SixteenthNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SixteenthNote_MouseDown);
            // 
            // FullRest
            // 
            this.FullRest.AutoSize = false;
            this.FullRest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FullRest.Image = global::VirtualPiano.Properties.Resources.helerust_icon;
            this.FullRest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.FullRest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FullRest.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.FullRest.Name = "FullRest";
            this.FullRest.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.FullRest.Size = new System.Drawing.Size(50, 50);
            this.FullRest.Text = "Hele Rust";
            this.FullRest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FullRest_MouseDown);
            // 
            // HalfRest
            // 
            this.HalfRest.AutoSize = false;
            this.HalfRest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HalfRest.Image = global::VirtualPiano.Properties.Resources.halverust_icon;
            this.HalfRest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.HalfRest.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.HalfRest.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.HalfRest.Name = "HalfRest";
            this.HalfRest.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.HalfRest.Size = new System.Drawing.Size(50, 50);
            this.HalfRest.Text = "Halve Rust";
            this.HalfRest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HalfRest_MouseDown);
            // 
            // QuarterRest
            // 
            this.QuarterRest.AutoSize = false;
            this.QuarterRest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuarterRest.Image = global::VirtualPiano.Properties.Resources.kwartrust_icon;
            this.QuarterRest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.QuarterRest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuarterRest.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.QuarterRest.Name = "QuarterRest";
            this.QuarterRest.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.QuarterRest.Size = new System.Drawing.Size(50, 50);
            this.QuarterRest.Text = "Kwart rust";
            this.QuarterRest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.QuarterRest_MouseDown);
            // 
            // EightRest
            // 
            this.EightRest.AutoSize = false;
            this.EightRest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EightRest.Image = global::VirtualPiano.Properties.Resources.achtsterust_icon;
            this.EightRest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EightRest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EightRest.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.EightRest.Name = "EightRest";
            this.EightRest.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.EightRest.Size = new System.Drawing.Size(50, 50);
            this.EightRest.Text = "Achtste rust";
            this.EightRest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EightRest_MouseDown);
            // 
            // SixteenthRest
            // 
            this.SixteenthRest.AutoSize = false;
            this.SixteenthRest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SixteenthRest.Image = global::VirtualPiano.Properties.Resources.zestienderust_icon;
            this.SixteenthRest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SixteenthRest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SixteenthRest.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.SixteenthRest.Name = "SixteenthRest";
            this.SixteenthRest.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.SixteenthRest.Size = new System.Drawing.Size(50, 50);
            this.SixteenthRest.Text = "SixteenthRest";
            this.SixteenthRest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SixteenthRest_MouseDown);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButton1.Size = new System.Drawing.Size(50, 50);
            this.toolStripButton1.Text = "Mol";
            this.toolStripButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Sharp_MouseDown);
            // 
            // Flat
            // 
            this.Flat.AutoSize = false;
            this.Flat.BackColor = System.Drawing.Color.Transparent;
            this.Flat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Flat.Image = ((System.Drawing.Image)(resources.GetObject("Flat.Image")));
            this.Flat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Flat.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Flat.Name = "Flat";
            this.Flat.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.Flat.Size = new System.Drawing.Size(50, 50);
            this.Flat.Text = "Mol";
            this.Flat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Flat_MouseDown);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButton2.Size = new System.Drawing.Size(50, 50);
            this.toolStripButton2.Text = "Noten samenvoegen";
            this.toolStripButton2.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Bin
            // 
            this.Bin.AutoSize = false;
            this.Bin.BackColor = System.Drawing.Color.Transparent;
            this.Bin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Bin.Image = ((System.Drawing.Image)(resources.GetObject("Bin.Image")));
            this.Bin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Bin.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.Bin.Name = "Bin";
            this.Bin.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.Bin.Size = new System.Drawing.Size(50, 50);
            this.Bin.Text = "Prullenbak";
            this.Bin.Click += new System.EventHandler(this.Bin_Click);
            this.Bin.MouseEnter += new System.EventHandler(this.Bin_MouseEnter);
            this.Bin.MouseLeave += new System.EventHandler(this.Bin_MouseLeave);
            this.Bin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Bin_MouseMove);
            // 
            // menuBarView1
            // 
            this.menuBarView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menuBarView1.BackColor = System.Drawing.Color.Transparent;
            this.menuBarView1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuBarView1.Location = new System.Drawing.Point(0, 0);
            this.menuBarView1.Margin = new System.Windows.Forms.Padding(0);
            this.menuBarView1.Name = "menuBarView1";
            this.menuBarView1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 100);
            this.menuBarView1.Size = new System.Drawing.Size(1920, 24);
            this.menuBarView1.Song = null;
            this.menuBarView1.TabIndex = 7;
            // 
            // ComposeView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.MetronomeSpeed);
            this.Controls.Add(this.MetronoomLabel);
            this.Controls.Add(this.CurrentPageLabel);
            this.Controls.Add(this.menuBarView1);
            this.Controls.Add(this.TitelBox);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ComposeView";
            this.Size = new System.Drawing.Size(1859, 1014);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComposeView_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ComposeView_MouseEnter);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ComposeView_MouseUp);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        private void ComposeView_MouseDown(object sender, MouseEventArgs e)
        {
            TitelBox.Enabled = false;
            TitelBox.Enabled = true;
        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton FullNote;
        private System.Windows.Forms.ToolStripButton HalfNote;
        private System.Windows.Forms.ToolStripButton QuarterNote;
        private System.Windows.Forms.ToolStripButton EightNote;
        private System.Windows.Forms.ToolStripButton SixteenthNote;
        private System.Windows.Forms.ToolStripButton Flat;
        private System.Windows.Forms.ToolStripButton GKey;
        private System.Windows.Forms.ToolStripButton FKey;
        private System.Windows.Forms.ToolStripButton FullRest;
        private System.Windows.Forms.ToolStripButton HalfRest;
        private System.Windows.Forms.ToolStripButton QuarterRest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton EightRest;
        private System.Windows.Forms.ToolStripButton SixteenthRest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public Timer Metronome;
        private TextBox Snelheid;
        public Timer RedLine;
        public TextBox TitelBox;
        private MenuBarView menuBarView1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton Bin;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator5;
        private Label MetronoomLabel;
        private TextBox MetronomeSpeed;
        private Label CurrentPageLabel;
        private ToolTip metroTip;
    }
}
