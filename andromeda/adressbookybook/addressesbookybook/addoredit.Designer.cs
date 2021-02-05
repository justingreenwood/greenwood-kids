namespace addressesbookybook
{
    partial class addoredit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addoredit));
            this.labelfirst = new System.Windows.Forms.Label();
            this.labellast = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.buttonokay = new System.Windows.Forms.Button();
            this.buttoncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelfirst
            // 
            this.labelfirst.AutoSize = true;
            this.labelfirst.Location = new System.Drawing.Point(12, 9);
            this.labelfirst.Name = "labelfirst";
            this.labelfirst.Size = new System.Drawing.Size(49, 13);
            this.labelfirst.TabIndex = 0;
            this.labelfirst.Text = "firstname";
            // 
            // labellast
            // 
            this.labellast.AutoSize = true;
            this.labellast.Location = new System.Drawing.Point(12, 46);
            this.labellast.Name = "labellast";
            this.labellast.Size = new System.Drawing.Size(52, 13);
            this.labellast.TabIndex = 1;
            this.labellast.Text = "last name";
            // 
            // address
            // 
            this.address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.address.FormattingEnabled = true;
            this.address.Location = new System.Drawing.Point(2, 94);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(330, 134);
            this.address.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 140);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(124, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(123, 180);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 20);
            this.textBox4.TabIndex = 6;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(190, 180);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(66, 20);
            this.textBox5.TabIndex = 7;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(15, 180);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(89, 20);
            this.textBox6.TabIndex = 8;
            // 
            // buttonokay
            // 
            this.buttonokay.BackColor = System.Drawing.Color.Lime;
            this.buttonokay.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonokay.Location = new System.Drawing.Point(246, 12);
            this.buttonokay.Name = "buttonokay";
            this.buttonokay.Size = new System.Drawing.Size(75, 23);
            this.buttonokay.TabIndex = 9;
            this.buttonokay.Text = "okay";
            this.buttonokay.UseVisualStyleBackColor = false;
            // 
            // buttoncancel
            // 
            this.buttoncancel.BackColor = System.Drawing.Color.Red;
            this.buttoncancel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttoncancel.Location = new System.Drawing.Point(246, 41);
            this.buttoncancel.Name = "buttoncancel";
            this.buttoncancel.Size = new System.Drawing.Size(75, 23);
            this.buttoncancel.TabIndex = 10;
            this.buttoncancel.Text = "cancel";
            this.buttoncancel.UseVisualStyleBackColor = false;
            // 
            // addoredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(333, 232);
            this.Controls.Add(this.buttoncancel);
            this.Controls.Add(this.buttonokay);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.address);
            this.Controls.Add(this.labellast);
            this.Controls.Add(this.labelfirst);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addoredit";
            this.Text = "add or edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelfirst;
        private System.Windows.Forms.Label labellast;
        private System.Windows.Forms.ListBox address;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button buttonokay;
        private System.Windows.Forms.Button buttoncancel;
    }
}