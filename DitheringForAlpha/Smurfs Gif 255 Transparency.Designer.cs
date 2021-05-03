namespace SmurfsAlphaDithering
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.current_frame = new System.Windows.Forms.NumericUpDown();
            this.Dith_all = new System.Windows.Forms.Button();
            this.animate = new System.Windows.Forms.CheckBox();
            this.playback_fps = new System.Windows.Forms.NumericUpDown();
            this.groupBox_Dithering = new System.Windows.Forms.GroupBox();
            this.dither = new System.Windows.Forms.Button();
            this.GreyScale = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lable_dither_1 = new System.Windows.Forms.Label();
            this.dither_steps = new System.Windows.Forms.NumericUpDown();
            this.ditherAlpha = new System.Windows.Forms.Button();
            this.Alpha_err_fix = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.save = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.groupBox_Dithering_A = new System.Windows.Forms.GroupBox();
            this.fix_Algorithm_err = new System.Windows.Forms.CheckBox();
            this.groupBox_Animation = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label_animation_1 = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.Button();
            this.PBOrginal_ = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.current_frame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playback_fps)).BeginInit();
            this.groupBox_Dithering.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dither_steps)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox_Dithering_A.SuspendLayout();
            this.groupBox_Animation.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBOrginal_)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(683, 684);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // current_frame
            // 
            this.current_frame.Location = new System.Drawing.Point(7, 12);
            this.current_frame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.current_frame.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.current_frame.Name = "current_frame";
            this.current_frame.Size = new System.Drawing.Size(63, 22);
            this.current_frame.TabIndex = 10;
            this.current_frame.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.current_frame.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // Dith_all
            // 
            this.Dith_all.Location = new System.Drawing.Point(7, 62);
            this.Dith_all.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dith_all.Name = "Dith_all";
            this.Dith_all.Size = new System.Drawing.Size(157, 38);
            this.Dith_all.TabIndex = 11;
            this.Dith_all.Text = "dither all in list";
            this.Dith_all.UseVisualStyleBackColor = true;
            this.Dith_all.Click += new System.EventHandler(this.Dith_all_Click);
            this.Dith_all.MouseHover += new System.EventHandler(this.Dith_all_MouseHover);
            // 
            // animate
            // 
            this.animate.AutoSize = true;
            this.animate.Location = new System.Drawing.Point(7, 2);
            this.animate.Margin = new System.Windows.Forms.Padding(4);
            this.animate.Name = "animate";
            this.animate.Size = new System.Drawing.Size(121, 21);
            this.animate.TabIndex = 12;
            this.animate.Text = "play animation";
            this.animate.UseVisualStyleBackColor = true;
            this.animate.CheckedChanged += new System.EventHandler(this.animate_CheckedChanged);
            // 
            // playback_fps
            // 
            this.playback_fps.Location = new System.Drawing.Point(7, 25);
            this.playback_fps.Margin = new System.Windows.Forms.Padding(4);
            this.playback_fps.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.playback_fps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playback_fps.Name = "playback_fps";
            this.playback_fps.Size = new System.Drawing.Size(64, 22);
            this.playback_fps.TabIndex = 13;
            this.playback_fps.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // groupBox_Dithering
            // 
            this.groupBox_Dithering.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Dithering.Controls.Add(this.dither);
            this.groupBox_Dithering.Controls.Add(this.GreyScale);
            this.groupBox_Dithering.Controls.Add(this.groupBox2);
            this.groupBox_Dithering.Enabled = false;
            this.groupBox_Dithering.Location = new System.Drawing.Point(8, 81);
            this.groupBox_Dithering.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Dithering.Name = "groupBox_Dithering";
            this.groupBox_Dithering.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Dithering.Size = new System.Drawing.Size(284, 81);
            this.groupBox_Dithering.TabIndex = 17;
            this.groupBox_Dithering.TabStop = false;
            this.groupBox_Dithering.Text = "Dithering";
            // 
            // dither
            // 
            this.dither.AccessibleDescription = "Press to dither image with normal floyd steingberg dithering";
            this.dither.Location = new System.Drawing.Point(7, 16);
            this.dither.Margin = new System.Windows.Forms.Padding(4);
            this.dither.Name = "dither";
            this.dither.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dither.Size = new System.Drawing.Size(157, 60);
            this.dither.TabIndex = 4;
            this.dither.Text = "dither";
            this.dither.UseVisualStyleBackColor = true;
            this.dither.Click += new System.EventHandler(this.dither_Click);
            this.dither.MouseHover += new System.EventHandler(this.dither_MouseHover);
            // 
            // GreyScale
            // 
            this.GreyScale.AutoSize = true;
            this.GreyScale.Location = new System.Drawing.Point(179, 55);
            this.GreyScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GreyScale.Name = "GreyScale";
            this.GreyScale.Size = new System.Drawing.Size(81, 21);
            this.GreyScale.TabIndex = 6;
            this.GreyScale.Text = "no color";
            this.GreyScale.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lable_dither_1);
            this.groupBox2.Controls.Add(this.dither_steps);
            this.groupBox2.Location = new System.Drawing.Point(171, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(107, 39);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // lable_dither_1
            // 
            this.lable_dither_1.AutoSize = true;
            this.lable_dither_1.Location = new System.Drawing.Point(55, 12);
            this.lable_dither_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable_dither_1.Name = "lable_dither_1";
            this.lable_dither_1.Size = new System.Drawing.Size(44, 17);
            this.lable_dither_1.TabIndex = 15;
            this.lable_dither_1.Text = "Steps";
            // 
            // dither_steps
            // 
            this.dither_steps.AccessibleDescription = "The ammount of different possible colors in dither image";
            this.dither_steps.Location = new System.Drawing.Point(7, 10);
            this.dither_steps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dither_steps.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.dither_steps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dither_steps.Name = "dither_steps";
            this.dither_steps.Size = new System.Drawing.Size(40, 22);
            this.dither_steps.TabIndex = 5;
            this.dither_steps.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ditherAlpha
            // 
            this.ditherAlpha.Location = new System.Drawing.Point(7, 17);
            this.ditherAlpha.Margin = new System.Windows.Forms.Padding(4);
            this.ditherAlpha.Name = "ditherAlpha";
            this.ditherAlpha.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ditherAlpha.Size = new System.Drawing.Size(157, 38);
            this.ditherAlpha.TabIndex = 3;
            this.ditherAlpha.Text = "Dither alpha";
            this.ditherAlpha.UseVisualStyleBackColor = true;
            this.ditherAlpha.Click += new System.EventHandler(this.ditherAlpha_Click);
            this.ditherAlpha.MouseEnter += new System.EventHandler(this.ditherAlpha_MouseEnter);
            // 
            // Alpha_err_fix
            // 
            this.Alpha_err_fix.AutoSize = true;
            this.Alpha_err_fix.Checked = true;
            this.Alpha_err_fix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Alpha_err_fix.Location = new System.Drawing.Point(177, 22);
            this.Alpha_err_fix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Alpha_err_fix.Name = "Alpha_err_fix";
            this.Alpha_err_fix.Size = new System.Drawing.Size(96, 21);
            this.Alpha_err_fix.TabIndex = 8;
            this.Alpha_err_fix.Text = "Fix A Error";
            this.Alpha_err_fix.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.save);
            this.groupBox4.Controls.Add(this.reset);
            this.groupBox4.Controls.Add(this.groupBox_Dithering);
            this.groupBox4.Controls.Add(this.groupBox_Dithering_A);
            this.groupBox4.Controls.Add(this.groupBox_Animation);
            this.groupBox4.Controls.Add(this.open);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(688, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.groupBox4.Size = new System.Drawing.Size(300, 684);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // save
            // 
            this.save.AccessibleDescription = "Click to save";
            this.save.Enabled = false;
            this.save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.save.Location = new System.Drawing.Point(120, 16);
            this.save.Margin = new System.Windows.Forms.Padding(4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(100, 58);
            this.save.TabIndex = 2;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            this.save.MouseHover += new System.EventHandler(this.save_MouseHover);
            // 
            // reset
            // 
            this.reset.AccessibleDescription = "Click to restart the program";
            this.reset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.reset.Location = new System.Drawing.Point(227, 17);
            this.reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(65, 58);
            this.reset.TabIndex = 3;
            this.reset.Text = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            this.reset.MouseHover += new System.EventHandler(this.reset_MouseHover);
            // 
            // groupBox_Dithering_A
            // 
            this.groupBox_Dithering_A.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Dithering_A.Controls.Add(this.fix_Algorithm_err);
            this.groupBox_Dithering_A.Controls.Add(this.Dith_all);
            this.groupBox_Dithering_A.Controls.Add(this.Alpha_err_fix);
            this.groupBox_Dithering_A.Controls.Add(this.ditherAlpha);
            this.groupBox_Dithering_A.Enabled = false;
            this.groupBox_Dithering_A.Location = new System.Drawing.Point(8, 167);
            this.groupBox_Dithering_A.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Dithering_A.Name = "groupBox_Dithering_A";
            this.groupBox_Dithering_A.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Dithering_A.Size = new System.Drawing.Size(284, 106);
            this.groupBox_Dithering_A.TabIndex = 19;
            this.groupBox_Dithering_A.TabStop = false;
            this.groupBox_Dithering_A.Text = "Alpha Dithering";
            // 
            // fix_Algorithm_err
            // 
            this.fix_Algorithm_err.AutoSize = true;
            this.fix_Algorithm_err.Location = new System.Drawing.Point(177, 49);
            this.fix_Algorithm_err.Name = "fix_Algorithm_err";
            this.fix_Algorithm_err.Size = new System.Drawing.Size(111, 21);
            this.fix_Algorithm_err.TabIndex = 12;
            this.fix_Algorithm_err.Text = "Algorithm err";
            this.fix_Algorithm_err.UseVisualStyleBackColor = true;
            // 
            // groupBox_Animation
            // 
            this.groupBox_Animation.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Animation.Controls.Add(this.groupBox7);
            this.groupBox_Animation.Controls.Add(this.groupBox6);
            this.groupBox_Animation.Enabled = false;
            this.groupBox_Animation.Location = new System.Drawing.Point(8, 274);
            this.groupBox_Animation.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Animation.Name = "groupBox_Animation";
            this.groupBox_Animation.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Animation.Size = new System.Drawing.Size(284, 127);
            this.groupBox_Animation.TabIndex = 21;
            this.groupBox_Animation.TabStop = false;
            this.groupBox_Animation.Text = "Animation";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.animate);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.playback_fps);
            this.groupBox7.Location = new System.Drawing.Point(8, 66);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(184, 54);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "FPS";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.current_frame);
            this.groupBox6.Controls.Add(this.label_animation_1);
            this.groupBox6.Location = new System.Drawing.Point(7, 18);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(184, 43);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            // 
            // label_animation_1
            // 
            this.label_animation_1.AutoSize = true;
            this.label_animation_1.Location = new System.Drawing.Point(76, 15);
            this.label_animation_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_animation_1.Name = "label_animation_1";
            this.label_animation_1.Size = new System.Drawing.Size(95, 17);
            this.label_animation_1.TabIndex = 20;
            this.label_animation_1.Text = "Current frame";
            // 
            // open
            // 
            this.open.AccessibleDescription = "Click to open image";
            this.open.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolTip;
            this.open.ForeColor = System.Drawing.SystemColors.ControlText;
            this.open.Location = new System.Drawing.Point(8, 16);
            this.open.Margin = new System.Windows.Forms.Padding(4);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(104, 58);
            this.open.TabIndex = 1;
            this.open.Text = "open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            this.open.MouseHover += new System.EventHandler(this.open_MouseHover);
            // 
            // PBOrginal_
            // 
            this.PBOrginal_.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBOrginal_.Location = new System.Drawing.Point(389, 422);
            this.PBOrginal_.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PBOrginal_.Name = "PBOrginal_";
            this.PBOrginal_.Size = new System.Drawing.Size(199, 184);
            this.PBOrginal_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBOrginal_.TabIndex = 22;
            this.PBOrginal_.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 684);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.PBOrginal_);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.current_frame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playback_fps)).EndInit();
            this.groupBox_Dithering.ResumeLayout(false);
            this.groupBox_Dithering.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dither_steps)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox_Dithering_A.ResumeLayout(false);
            this.groupBox_Dithering_A.PerformLayout();
            this.groupBox_Animation.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBOrginal_)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown current_frame;
        private System.Windows.Forms.Button Dith_all;
        private System.Windows.Forms.CheckBox animate;
        private System.Windows.Forms.NumericUpDown playback_fps;
        private System.Windows.Forms.GroupBox groupBox_Dithering;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button dither;
        private System.Windows.Forms.Button ditherAlpha;
        private System.Windows.Forms.NumericUpDown dither_steps;
        private System.Windows.Forms.CheckBox Alpha_err_fix;
        private System.Windows.Forms.CheckBox GreyScale;
        private System.Windows.Forms.Label lable_dither_1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox_Dithering_A;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.GroupBox groupBox_Animation;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label_animation_1;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.PictureBox PBOrginal_;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox fix_Algorithm_err;
    }
}

