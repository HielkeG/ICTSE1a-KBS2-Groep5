﻿namespace VirtualPiano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.formContent = new VirtualPiano.View.ComposeView();
            this.SuspendLayout();
            // 
            // formContent
            // 
            this.formContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formContent.BackColor = System.Drawing.Color.Transparent;
            this.formContent.BackgroundImage = global::VirtualPiano.Properties.Resources.topbarbg;
            this.formContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.formContent.Font = new System.Drawing.Font("Modern No. 20", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formContent.ForeColor = System.Drawing.Color.Black;
            this.formContent.Location = new System.Drawing.Point(0, 0);
            this.formContent.Margin = new System.Windows.Forms.Padding(0);
            this.formContent.Name = "formContent";
            this.formContent.Size = new System.Drawing.Size(1920, 1050);
            this.formContent.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.formContent);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "MainForm";
            this.Text = "VirtualPiano";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        public View.ComposeView formContent;
    }
}

