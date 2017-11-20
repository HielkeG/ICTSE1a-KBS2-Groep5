namespace VirtualPiano
{
    partial class MainForm
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
            this.Titel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Snelheid = new System.Windows.Forms.Label();
            this.Componist = new System.Windows.Forms.Label();
            this.menuBarView1 = new VirtualPiano.View.MenuBarView();
            this.formContent = new VirtualPiano.View.ComposeView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Titel
            // 
            this.Titel.AutoSize = true;
            this.Titel.Font = new System.Drawing.Font("Modern No. 20", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titel.Location = new System.Drawing.Point(883, 24);
            this.Titel.Name = "Titel";
            this.Titel.Size = new System.Drawing.Size(153, 65);
            this.Titel.TabIndex = 2;
            this.Titel.Text = "Titel";
            this.Titel.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::VirtualPiano.Properties.Resources.kwartnoot;
            this.pictureBox1.Location = new System.Drawing.Point(204, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Snelheid
            // 
            this.Snelheid.AutoSize = true;
            this.Snelheid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Snelheid.Location = new System.Drawing.Point(232, 128);
            this.Snelheid.Name = "Snelheid";
            this.Snelheid.Size = new System.Drawing.Size(38, 15);
            this.Snelheid.TabIndex = 4;
            this.Snelheid.Text = "= 120";
            // 
            // Componist
            // 
            this.Componist.AutoSize = true;
            this.Componist.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Componist.Location = new System.Drawing.Point(1669, 128);
            this.Componist.Name = "Componist";
            this.Componist.Size = new System.Drawing.Size(136, 31);
            this.Componist.TabIndex = 5;
            this.Componist.Text = "Componist";
            // 
            // menuBarView1
            // 
            this.menuBarView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.menuBarView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuBarView1.Location = new System.Drawing.Point(0, 0);
            this.menuBarView1.Margin = new System.Windows.Forms.Padding(0);
            this.menuBarView1.Name = "menuBarView1";
            this.menuBarView1.Size = new System.Drawing.Size(1904, 25);
            this.menuBarView1.TabIndex = 1;
            this.menuBarView1.Load += new System.EventHandler(this.menuBarView1_Load);
            // 
            // formContent
            // 
            this.formContent.BackColor = System.Drawing.Color.Transparent;
            this.formContent.ForeColor = System.Drawing.Color.Transparent;
            this.formContent.Location = new System.Drawing.Point(2, 24);
            this.formContent.Name = "formContent";
            this.formContent.Size = new System.Drawing.Size(1900, 1017);
            this.formContent.TabIndex = 0;
            this.formContent.Load += new System.EventHandler(this.formContent_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Componist);
            this.Controls.Add(this.Snelheid);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Titel);
            this.Controls.Add(this.menuBarView1);
            this.Controls.Add(this.formContent);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public View.ComposeView formContent;
        private View.MenuBarView menuBarView1;
        private System.Windows.Forms.Label Titel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Snelheid;
        private System.Windows.Forms.Label Componist;
    }
}

