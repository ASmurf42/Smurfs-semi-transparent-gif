﻿namespace AlphaDithering
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.popoutPB = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popoutPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.popoutPB);
            this.panel1.Location = new System.Drawing.Point(-2, -6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 474);
            this.panel1.TabIndex = 0;
            // 
            // popoutPB
            // 
            this.popoutPB.Location = new System.Drawing.Point(0, 0);
            this.popoutPB.Name = "popoutPB";
            this.popoutPB.Size = new System.Drawing.Size(520, 500);
            this.popoutPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.popoutPB.TabIndex = 0;
            this.popoutPB.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(15, 19);
            this.trackBar1.Maximum = 32;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(452, 56);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 465);
            this.Controls.Add(this.panel1);
            this.Name = "PopupForm";
            this.Text = "PopupForm";
            this.SizeChanged += new System.EventHandler(this.PopupForm_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popoutPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox popoutPB;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}