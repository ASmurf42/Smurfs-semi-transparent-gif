namespace AlphaDithering
{
    partial class PopupForm
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
            this.popoutPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.popoutPB)).BeginInit();
            this.SuspendLayout();
            // 
            // popoutPB
            // 
            this.popoutPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popoutPB.Location = new System.Drawing.Point(0, 0);
            this.popoutPB.Name = "popoutPB";
            this.popoutPB.Size = new System.Drawing.Size(494, 465);
            this.popoutPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.popoutPB.TabIndex = 0;
            this.popoutPB.TabStop = false;
            this.popoutPB.Click += new System.EventHandler(this.popoutPB_Click);
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 465);
            this.Controls.Add(this.popoutPB);
            this.Name = "PopupForm";
            this.Text = "PopupForm";
            ((System.ComponentModel.ISupportInitialize)(this.popoutPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox popoutPB;
    }
}