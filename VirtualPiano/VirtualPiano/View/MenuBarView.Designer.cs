namespace VirtualPiano.View
{
    partial class MenuBarView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.New = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Sound = new System.Windows.Forms.ToolStripMenuItem();
            this.SoundOnOff = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Staff = new System.Windows.Forms.ToolStripMenuItem();
            this.AddStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.midiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardVerbindenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instellingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VirtualKeyboard = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyboardVisible = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitaarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marimbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File,
            this.Sound,
            this.instrumentToolStripMenuItem,
            this.Staff,
            this.midiToolStripMenuItem,
            this.VirtualKeyboard,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(590, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.BackColor = System.Drawing.Color.WhiteSmoke;
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.Open,
            this.Remove,
            this.toolStripSeparator1,
            this.Save});
            this.File.ForeColor = System.Drawing.SystemColors.ControlText;
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(61, 24);
            this.File.Text = "Bestand";
            // 
            // New
            // 
            this.New.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.New.Name = "New";
            this.New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.New.Size = new System.Drawing.Size(170, 22);
            this.New.Text = "Nieuw...";
            this.New.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.New.Click += new System.EventHandler(this.NewSong_Click);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open.Size = new System.Drawing.Size(170, 22);
            this.Open.Text = "Openen...";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Remove
            // 
            this.Remove.Name = "Remove";
            this.Remove.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.Remove.Size = new System.Drawing.Size(170, 22);
            this.Remove.Text = "Verwijder..";
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save.Size = new System.Drawing.Size(170, 22);
            this.Save.Text = "Opslaan";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Sound
            // 
            this.Sound.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Sound.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SoundOnOff});
            this.Sound.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sound.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Sound.Name = "Sound";
            this.Sound.Size = new System.Drawing.Size(53, 24);
            this.Sound.Text = "Geluid";
            // 
            // SoundOnOff
            // 
            this.SoundOnOff.Checked = true;
            this.SoundOnOff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SoundOnOff.Name = "SoundOnOff";
            this.SoundOnOff.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.SoundOnOff.Size = new System.Drawing.Size(191, 22);
            this.SoundOnOff.Text = "Geluid aan/uit";
            this.SoundOnOff.Click += new System.EventHandler(this.ToggleSound);
            // 
            // instrumentToolStripMenuItem
            // 
            this.instrumentToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.instrumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pianoToolStripMenuItem,
            this.gitaarToolStripMenuItem1,
            this.marimbaToolStripMenuItem});
            this.instrumentToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.instrumentToolStripMenuItem.Name = "instrumentToolStripMenuItem";
            this.instrumentToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.instrumentToolStripMenuItem.Text = "Instrument";
            // 
            // Staff
            // 
            this.Staff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Staff.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddStaff});
            this.Staff.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Staff.Name = "Staff";
            this.Staff.Size = new System.Drawing.Size(74, 24);
            this.Staff.Text = "Notenbalk";
            // 
            // AddStaff
            // 
            this.AddStaff.Name = "AddStaff";
            this.AddStaff.Size = new System.Drawing.Size(132, 22);
            this.AddStaff.Text = "Toevoegen";
            this.AddStaff.Click += new System.EventHandler(this.AddStaffView_Click);
            // 
            // midiToolStripMenuItem
            // 
            this.midiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyboardVerbindenToolStripMenuItem,
            this.instellingenToolStripMenuItem});
            this.midiToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.midiToolStripMenuItem.Name = "midiToolStripMenuItem";
            this.midiToolStripMenuItem.Size = new System.Drawing.Size(43, 24);
            this.midiToolStripMenuItem.Text = "Midi";
            this.midiToolStripMenuItem.Click += new System.EventHandler(this.midiToolStripMenuItem_Click);
            // 
            // keyboardVerbindenToolStripMenuItem
            // 
            this.keyboardVerbindenToolStripMenuItem.Name = "keyboardVerbindenToolStripMenuItem";
            this.keyboardVerbindenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.keyboardVerbindenToolStripMenuItem.Text = "Keyboard verbinden";
            this.keyboardVerbindenToolStripMenuItem.Click += new System.EventHandler(this.ConnectKeyboard);
            // 
            // instellingenToolStripMenuItem
            // 
            this.instellingenToolStripMenuItem.Name = "instellingenToolStripMenuItem";
            this.instellingenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.instellingenToolStripMenuItem.Text = "Instellingen";
            this.instellingenToolStripMenuItem.Click += new System.EventHandler(this.Settings_Click);
            // 
            // VirtualKeyboard
            // 
            this.VirtualKeyboard.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KeyboardVisible});
            this.VirtualKeyboard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.VirtualKeyboard.Name = "VirtualKeyboard";
            this.VirtualKeyboard.Size = new System.Drawing.Size(111, 24);
            this.VirtualKeyboard.Text = "Virtueel keyboard";
            // 
            // KeyboardVisible
            // 
            this.KeyboardVisible.Name = "KeyboardVisible";
            this.KeyboardVisible.Size = new System.Drawing.Size(124, 22);
            this.KeyboardVisible.Text = "Zichtbaar";
            this.KeyboardVisible.Click += new System.EventHandler(this.Visible_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // pianoToolStripMenuItem
            // 
            this.pianoToolStripMenuItem.AccessibleName = "Instrument";
            this.pianoToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.pianoToolStripMenuItem.Checked = true;
            this.pianoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pianoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.pianoToolStripMenuItem.Image = global::VirtualPiano.Properties.Resources.piano;
            this.pianoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pianoToolStripMenuItem.Name = "pianoToolStripMenuItem";
            this.pianoToolStripMenuItem.Size = new System.Drawing.Size(217, 82);
            this.pianoToolStripMenuItem.Text = "Piano";
            this.pianoToolStripMenuItem.Click += new System.EventHandler(this.Piano_Click);
            // 
            // gitaarToolStripMenuItem1
            // 
            this.gitaarToolStripMenuItem1.AccessibleName = "Instrument";
            this.gitaarToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.gitaarToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.gitaarToolStripMenuItem1.Image = global::VirtualPiano.Properties.Resources.guitar;
            this.gitaarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.gitaarToolStripMenuItem1.Name = "gitaarToolStripMenuItem1";
            this.gitaarToolStripMenuItem1.Size = new System.Drawing.Size(217, 82);
            this.gitaarToolStripMenuItem1.Text = "Gitaar";
            this.gitaarToolStripMenuItem1.Click += new System.EventHandler(this.Gitaar_Click);
            // 
            // marimbaToolStripMenuItem
            // 
            this.marimbaToolStripMenuItem.AccessibleName = "Instrument";
            this.marimbaToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.marimbaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.marimbaToolStripMenuItem.Image = global::VirtualPiano.Properties.Resources.marimba;
            this.marimbaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.marimbaToolStripMenuItem.Name = "marimbaToolStripMenuItem";
            this.marimbaToolStripMenuItem.Size = new System.Drawing.Size(217, 82);
            this.marimbaToolStripMenuItem.Text = "Marimba";
            this.marimbaToolStripMenuItem.Click += new System.EventHandler(this.Marimba_Click);
            // 
            // MenuBarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MenuBarView";
            this.Size = new System.Drawing.Size(590, 29);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Remove;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pianoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem marimbaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem gitaarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Staff;
        private System.Windows.Forms.ToolStripMenuItem AddStaff;
        private System.Windows.Forms.ToolStripMenuItem New;
        private System.Windows.Forms.ToolStripMenuItem Sound;
        public System.Windows.Forms.ToolStripMenuItem SoundOnOff;
        private System.Windows.Forms.ToolStripMenuItem midiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyboardVerbindenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VirtualKeyboard;
        public System.Windows.Forms.ToolStripMenuItem KeyboardVisible;
        private System.Windows.Forms.ToolStripMenuItem instellingenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}
