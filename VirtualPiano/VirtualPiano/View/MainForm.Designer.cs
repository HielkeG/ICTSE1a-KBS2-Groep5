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
            this.menuBarView1 = new VirtualPiano.View.MenuBarView();
            this.formContent = new VirtualPiano.View.ComposeView();
            this.SuspendLayout();
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
            // 
            // formContent
            // 
            this.formContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.formContent.Font = new System.Drawing.Font("Modern No. 20", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formContent.ForeColor = System.Drawing.Color.Transparent;
            this.formContent.Location = new System.Drawing.Point(2, 24);
            this.formContent.Margin = new System.Windows.Forms.Padding(0);
            this.formContent.Name = "formContent";
            this.formContent.Size = new System.Drawing.Size(1900, 1017);
            this.formContent.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.menuBarView1);
            this.Controls.Add(this.formContent);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public View.ComposeView formContent;
        private View.MenuBarView menuBarView1;
    }
}

