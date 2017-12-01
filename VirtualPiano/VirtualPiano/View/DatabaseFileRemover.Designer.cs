namespace VirtualPiano.View
{
    partial class DatabaseFileRemover
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
            this.label1 = new System.Windows.Forms.Label();
            this.ZoekOpdracht = new System.Windows.Forms.TextBox();
            this.ItemsList = new System.Windows.Forms.ListBox();
            this.Verwijder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zoeken";
            // 
            // ZoekOpdracht
            // 
            this.ZoekOpdracht.Location = new System.Drawing.Point(108, 65);
            this.ZoekOpdracht.Name = "ZoekOpdracht";
            this.ZoekOpdracht.Size = new System.Drawing.Size(100, 20);
            this.ZoekOpdracht.TabIndex = 2;
            this.ZoekOpdracht.TextChanged += new System.EventHandler(this.ZoekOpdracht_TextChanged);
            // 
            // ItemsList
            // 
            this.ItemsList.FormattingEnabled = true;
            this.ItemsList.Location = new System.Drawing.Point(33, 91);
            this.ItemsList.Name = "ItemsList";
            this.ItemsList.Size = new System.Drawing.Size(261, 446);
            this.ItemsList.TabIndex = 3;
            // 
            // Verwijder
            // 
            this.Verwijder.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Verwijder.Location = new System.Drawing.Point(120, 553);
            this.Verwijder.Name = "Verwijder";
            this.Verwijder.Size = new System.Drawing.Size(75, 23);
            this.Verwijder.TabIndex = 4;
            this.Verwijder.Text = "Verwijder";
            this.Verwijder.UseVisualStyleBackColor = true;
            this.Verwijder.Click += new System.EventHandler(this.Verwijder_Click);
            // 
            // DatabaseFileRemover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 597);
            this.Controls.Add(this.Verwijder);
            this.Controls.Add(this.ItemsList);
            this.Controls.Add(this.ZoekOpdracht);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseFileRemover";
            this.Text = "DatabaseFileRemover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ZoekOpdracht;
        public System.Windows.Forms.ListBox ItemsList;
        private System.Windows.Forms.Button Verwijder;
    }
}