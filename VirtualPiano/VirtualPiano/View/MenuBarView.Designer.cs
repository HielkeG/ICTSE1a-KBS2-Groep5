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
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nieuwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verwijderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.opslaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geluidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geluidAanuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayingKeyboard = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitaarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.marimbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notenbalkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toevoegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem,
            this.geluidToolStripMenuItem,
            this.instrumentToolStripMenuItem,
            this.notenbalkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(419, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nieuwToolStripMenuItem,
            this.openenToolStripMenuItem,
            this.verwijderToolStripMenuItem,
            this.toolStripSeparator1,
            this.opslaanToolStripMenuItem});
            this.bestandToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // nieuwToolStripMenuItem
            // 
            this.nieuwToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.nieuwToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nieuwToolStripMenuItem.Name = "nieuwToolStripMenuItem";
            this.nieuwToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nieuwToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.nieuwToolStripMenuItem.Text = "Nieuw...";
            this.nieuwToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.nieuwToolStripMenuItem.Click += new System.EventHandler(this.nieuwToolStripMenuItem_Click);
            // 
            // openenToolStripMenuItem
            // 
            this.openenToolStripMenuItem.Name = "openenToolStripMenuItem";
            this.openenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openenToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openenToolStripMenuItem.Text = "Openen...";
            this.openenToolStripMenuItem.Click += new System.EventHandler(this.openenToolStripMenuItem_Click);
            // 
            // verwijderToolStripMenuItem
            // 
            this.verwijderToolStripMenuItem.Name = "verwijderToolStripMenuItem";
            this.verwijderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.verwijderToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.verwijderToolStripMenuItem.Text = "Verwijder..";
            this.verwijderToolStripMenuItem.Click += new System.EventHandler(this.verwijderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // opslaanToolStripMenuItem
            // 
            this.opslaanToolStripMenuItem.Name = "opslaanToolStripMenuItem";
            this.opslaanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.opslaanToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.opslaanToolStripMenuItem.Text = "Opslaan";
            this.opslaanToolStripMenuItem.Click += new System.EventHandler(this.opslaanToolStripMenuItem_Click);
            // 
            // geluidToolStripMenuItem
            // 
            this.geluidToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.geluidToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geluidAanuitToolStripMenuItem,
            this.PlayingKeyboard});
            this.geluidToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geluidToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.geluidToolStripMenuItem.Name = "geluidToolStripMenuItem";
            this.geluidToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.geluidToolStripMenuItem.Text = "Geluid";
            // 
            // geluidAanuitToolStripMenuItem
            // 
            this.geluidAanuitToolStripMenuItem.Checked = true;
            this.geluidAanuitToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.geluidAanuitToolStripMenuItem.Name = "geluidAanuitToolStripMenuItem";
            this.geluidAanuitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.geluidAanuitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.geluidAanuitToolStripMenuItem.Text = "Geluid aan/uit";
            this.geluidAanuitToolStripMenuItem.Click += new System.EventHandler(this.GeluidAanUit);
            // 
            // PlayingKeyboard
            // 
            this.PlayingKeyboard.Name = "PlayingKeyboard";
            this.PlayingKeyboard.Size = new System.Drawing.Size(191, 22);
            this.PlayingKeyboard.Text = "Typend spelen";
            this.PlayingKeyboard.Click += new System.EventHandler(this.PlayingKeyboard_Click);
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
            this.pianoToolStripMenuItem.Click += new System.EventHandler(this.pianoToolStripMenuItem_Click);
            // 
            // gitaarToolStripMenuItem1
            // 
            this.gitaarToolStripMenuItem1.AccessibleName = "Instrument";
            this.gitaarToolStripMenuItem1.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.gitaarToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.gitaarToolStripMenuItem1.Image = global::VirtualPiano.Properties.Resources.Gitaar;
            this.gitaarToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.gitaarToolStripMenuItem1.Name = "gitaarToolStripMenuItem1";
            this.gitaarToolStripMenuItem1.Size = new System.Drawing.Size(217, 82);
            this.gitaarToolStripMenuItem1.Text = "Gitaar";
            this.gitaarToolStripMenuItem1.Click += new System.EventHandler(this.gitaarToolStripMenuItem1_Click);
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
            this.marimbaToolStripMenuItem.Click += new System.EventHandler(this.marimbaToolStripMenuItem_Click);
            // 
            // notenbalkToolStripMenuItem
            // 
            this.notenbalkToolStripMenuItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.notenbalkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toevoegenToolStripMenuItem});
            this.notenbalkToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.notenbalkToolStripMenuItem.Name = "notenbalkToolStripMenuItem";
            this.notenbalkToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.notenbalkToolStripMenuItem.Text = "Notenbalk";
            // 
            // toevoegenToolStripMenuItem
            // 
            this.toevoegenToolStripMenuItem.Name = "toevoegenToolStripMenuItem";
            this.toevoegenToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.toevoegenToolStripMenuItem.Text = "Toevoegen";
            this.toevoegenToolStripMenuItem.Click += new System.EventHandler(this.toevoegenToolStripMenuItem_Click);
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
            this.Size = new System.Drawing.Size(419, 29);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem opslaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verwijderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem pianoToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem marimbaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem gitaarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem notenbalkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toevoegenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nieuwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geluidToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem geluidAanuitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem PlayingKeyboard;
    }
}
