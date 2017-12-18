namespace VirtualPiano.View
{
    partial class HelpSelectedView
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
            this.Title = new System.Windows.Forms.Label();
            this.ToOverview = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Explanation = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(14, 19);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(419, 23);
            this.Title.TabIndex = 0;
            this.Title.Text = "label1";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.Click += new System.EventHandler(this.Title_Click);
            // 
            // ToOverview
            // 
            this.ToOverview.Location = new System.Drawing.Point(89, 399);
            this.ToOverview.Name = "ToOverview";
            this.ToOverview.Size = new System.Drawing.Size(130, 23);
            this.ToOverview.TabIndex = 2;
            this.ToOverview.Text = "Terug naar overzicht";
            this.ToOverview.UseVisualStyleBackColor = true;
            this.ToOverview.Click += new System.EventHandler(this.ToOverview_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(228, 399);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(130, 23);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Terug naar applicatie";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Explanation
            // 
            this.Explanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Explanation.Location = new System.Drawing.Point(57, 60);
            this.Explanation.Name = "Explanation";
            this.Explanation.ReadOnly = true;
            this.Explanation.Size = new System.Drawing.Size(329, 315);
            this.Explanation.TabIndex = 4;
            this.Explanation.Text = "";
            // 
            // HelpSelectedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Explanation);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.ToOverview);
            this.Controls.Add(this.Title);
            this.Name = "HelpSelectedView";
            this.Size = new System.Drawing.Size(433, 435);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HelpSelectedView_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button ToOverview;
        private System.Windows.Forms.Button Exit;
        public System.Windows.Forms.RichTextBox Explanation;
    }
}
