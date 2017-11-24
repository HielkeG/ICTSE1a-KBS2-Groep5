namespace VirtualPiano.View
{
    partial class StaffView
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
            this.SnapTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StaffView
            // 
            this.AccessibleName = "StaffView";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "StaffView";
            this.Size = new System.Drawing.Size(1600, 182);
            this.MouseEnter += new System.EventHandler(this.StaffView_MouseEnter);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseActions);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer SnapTimer;
    }
}
