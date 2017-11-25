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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.opslaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opslaanAlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exporterenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beeldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geluidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geluidAanuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem,
            this.beeldToolStripMenuItem,
            this.geluidToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(500, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nieuwToolStripMenuItem,
            this.openenToolStripMenuItem,
            this.toolStripSeparator1,
            this.opslaanToolStripMenuItem,
            this.opslaanAlsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exporterenToolStripMenuItem});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // nieuwToolStripMenuItem
            // 
            this.nieuwToolStripMenuItem.Name = "nieuwToolStripMenuItem";
            this.nieuwToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nieuwToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.nieuwToolStripMenuItem.Text = "Nieuw...";
            // 
            // openenToolStripMenuItem
            // 
            this.openenToolStripMenuItem.Name = "openenToolStripMenuItem";
            this.openenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openenToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.openenToolStripMenuItem.Text = "Openen...";
            this.openenToolStripMenuItem.Click += new System.EventHandler(this.openenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // opslaanToolStripMenuItem
            // 
            this.opslaanToolStripMenuItem.Name = "opslaanToolStripMenuItem";
            this.opslaanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.opslaanToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.opslaanToolStripMenuItem.Text = "Opslaan";
            this.opslaanToolStripMenuItem.Click += new System.EventHandler(this.opslaanToolStripMenuItem_Click);
            // 
            // opslaanAlsToolStripMenuItem
            // 
            this.opslaanAlsToolStripMenuItem.Name = "opslaanAlsToolStripMenuItem";
            this.opslaanAlsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.opslaanAlsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.opslaanAlsToolStripMenuItem.Text = "Opslaan als...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // exporterenToolStripMenuItem
            // 
            this.exporterenToolStripMenuItem.Name = "exporterenToolStripMenuItem";
            this.exporterenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.exporterenToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.exporterenToolStripMenuItem.Text = "Exporteren...";
            // 
            // beeldToolStripMenuItem
            // 
            this.beeldToolStripMenuItem.Name = "beeldToolStripMenuItem";
            this.beeldToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.beeldToolStripMenuItem.Text = "Beeld";
            // 
            // geluidToolStripMenuItem
            // 
            this.geluidToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geluidAanuitToolStripMenuItem});
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
            // MenuBarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MenuBarView";
            this.Size = new System.Drawing.Size(500, 25);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nieuwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem opslaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opslaanAlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporterenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beeldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geluidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem geluidAanuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
