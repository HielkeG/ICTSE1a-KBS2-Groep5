namespace VirtualPiano.View
{
    partial class DatabaseFileExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseFileExplorer));
            this.label1 = new System.Windows.Forms.Label();
            this.ZoekOpdracht = new System.Windows.Forms.TextBox();
            this.ItemsList = new System.Windows.Forms.ListBox();
            this.Selecteer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zoeken";
            // 
            // ZoekOpdracht
            // 
            this.ZoekOpdracht.Location = new System.Drawing.Point(99, 76);
            this.ZoekOpdracht.Name = "ZoekOpdracht";
            this.ZoekOpdracht.Size = new System.Drawing.Size(100, 20);
            this.ZoekOpdracht.TabIndex = 1;
            this.ZoekOpdracht.TextChanged += new System.EventHandler(this.ZoekOpdracht_TextChanged);
            // 
            // ItemsList
            // 
            this.ItemsList.FormattingEnabled = true;
            this.ItemsList.Location = new System.Drawing.Point(29, 102);
            this.ItemsList.Name = "ItemsList";
            this.ItemsList.Size = new System.Drawing.Size(261, 446);
            this.ItemsList.TabIndex = 2;
            // 
            // Selecteer
            // 
            this.Selecteer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Selecteer.Location = new System.Drawing.Point(124, 562);
            this.Selecteer.Name = "Selecteer";
            this.Selecteer.Size = new System.Drawing.Size(75, 23);
            this.Selecteer.TabIndex = 3;
            this.Selecteer.Text = "Selecteer";
            this.Selecteer.UseVisualStyleBackColor = true;
            this.Selecteer.Click += new System.EventHandler(this.Selecteer_Click);
            // 
            // DatabaseFileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 596);
            this.Controls.Add(this.Selecteer);
            this.Controls.Add(this.ItemsList);
            this.Controls.Add(this.ZoekOpdracht);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(360, 635);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 635);
            this.Name = "DatabaseFileExplorer";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Nummers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ZoekOpdracht;
        public System.Windows.Forms.ListBox ItemsList;
        private System.Windows.Forms.Button Selecteer;
    }
}