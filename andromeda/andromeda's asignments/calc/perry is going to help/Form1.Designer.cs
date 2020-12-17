namespace perry_is_going_to_help
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
            this.gender = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.wrench = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.youragedifrence = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gender
            // 
            this.gender.Font = new System.Drawing.Font("Ink Free", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gender.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.gender.Location = new System.Drawing.Point(72, 9);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(166, 62);
            this.gender.TabIndex = 0;
            this.gender.Text = "gender";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "male";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "female";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // wrench
            // 
            this.wrench.AcceptsReturn = true;
            this.wrench.AccessibleName = "age";
            this.wrench.Location = new System.Drawing.Point(82, 139);
            this.wrench.Name = "wrench";
            this.wrench.Size = new System.Drawing.Size(145, 20);
            this.wrench.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Ink Free", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(125, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "age";
            // 
            // youragedifrence
            // 
            this.youragedifrence.Font = new System.Drawing.Font("Courier New", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.youragedifrence.Location = new System.Drawing.Point(12, 219);
            this.youragedifrence.Name = "youragedifrence";
            this.youragedifrence.Size = new System.Drawing.Size(776, 24);
            this.youragedifrence.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.youragedifrence);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wrench);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gender);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gender;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox wrench;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label youragedifrence;
    }
}

