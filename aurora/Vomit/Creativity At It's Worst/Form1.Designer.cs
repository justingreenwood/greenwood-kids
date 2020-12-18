namespace Creativity_At_It_s_Worst
{
    partial class FaceFull
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceFull));
            this.Mouth_Button = new System.Windows.Forms.Button();
            this.RightEye_Button = new System.Windows.Forms.Button();
            this.LeftEye_Button = new System.Windows.Forms.Button();
            this.Nose_Button = new System.Windows.Forms.Button();
            this.Eyebrow1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Nose_Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Mouth_Button
            // 
            this.Mouth_Button.BackColor = System.Drawing.Color.Maroon;
            this.Mouth_Button.Location = new System.Drawing.Point(42, 303);
            this.Mouth_Button.Name = "Mouth_Button";
            this.Mouth_Button.Size = new System.Drawing.Size(326, 152);
            this.Mouth_Button.TabIndex = 0;
            this.Mouth_Button.UseVisualStyleBackColor = false;
            this.Mouth_Button.Click += new System.EventHandler(this.Mouth_Button_Click);
            // 
            // RightEye_Button
            // 
            this.RightEye_Button.BackColor = System.Drawing.Color.Honeydew;
            this.RightEye_Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.RightEye_Button.Location = new System.Drawing.Point(42, 77);
            this.RightEye_Button.Name = "RightEye_Button";
            this.RightEye_Button.Size = new System.Drawing.Size(81, 56);
            this.RightEye_Button.TabIndex = 1;
            this.RightEye_Button.UseVisualStyleBackColor = false;
            this.RightEye_Button.Click += new System.EventHandler(this.RightEye_Button_Click);
            // 
            // LeftEye_Button
            // 
            this.LeftEye_Button.BackColor = System.Drawing.Color.Honeydew;
            this.LeftEye_Button.Location = new System.Drawing.Point(281, 77);
            this.LeftEye_Button.Name = "LeftEye_Button";
            this.LeftEye_Button.Size = new System.Drawing.Size(81, 56);
            this.LeftEye_Button.TabIndex = 2;
            this.LeftEye_Button.UseVisualStyleBackColor = false;
            this.LeftEye_Button.Click += new System.EventHandler(this.LeftEye_Button_Click);
            // 
            // Nose_Button
            // 
            this.Nose_Button.BackColor = System.Drawing.Color.MistyRose;
            this.Nose_Button.Location = new System.Drawing.Point(162, 169);
            this.Nose_Button.Name = "Nose_Button";
            this.Nose_Button.Size = new System.Drawing.Size(75, 51);
            this.Nose_Button.TabIndex = 3;
            this.Nose_Button.UseVisualStyleBackColor = false;
            this.Nose_Button.Click += new System.EventHandler(this.Nose_Button_Click);
            // 
            // Eyebrow1
            // 
            this.Eyebrow1.BackColor = System.Drawing.Color.SaddleBrown;
            this.Eyebrow1.Location = new System.Drawing.Point(272, 33);
            this.Eyebrow1.Name = "Eyebrow1";
            this.Eyebrow1.Size = new System.Drawing.Size(106, 18);
            this.Eyebrow1.TabIndex = 4;
            this.Eyebrow1.Click += new System.EventHandler(this.Eyebrow1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(30, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 5;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Nose_Timer
            // 
            this.Nose_Timer.Interval = 1000;
            this.Nose_Timer.Tick += new System.EventHandler(this.Nose_Timer_Tick);
            // 
            // FaceFull
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(398, 529);
            this.Controls.Add(this.Mouth_Button);
            this.Controls.Add(this.Eyebrow1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RightEye_Button);
            this.Controls.Add(this.LeftEye_Button);
            this.Controls.Add(this.Nose_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FaceFull";
            this.Text = "Face of Fury";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Mouth_Button;
        private System.Windows.Forms.Button RightEye_Button;
        private System.Windows.Forms.Button LeftEye_Button;
        private System.Windows.Forms.Button Nose_Button;
        private System.Windows.Forms.Label Eyebrow1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Nose_Timer;
    }
}

