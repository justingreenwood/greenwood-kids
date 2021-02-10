namespace Windy_Address_Book
{
    partial class EditWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWindow));
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.OccupationLabel = new System.Windows.Forms.Label();
            this.OccupationTextBox = new System.Windows.Forms.TextBox();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.Goldenrod;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.ForeColor = System.Drawing.Color.SaddleBrown;
            this.CancelButton.Location = new System.Drawing.Point(158, 408);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(163, 50);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.Color.OrangeRed;
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.ForeColor = System.Drawing.Color.DarkRed;
            this.OKButton.Location = new System.Drawing.Point(-6, 408);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(165, 50);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 37);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(292, 20);
            this.NameTextBox.TabIndex = 2;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.NameLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.NameLabel.Location = new System.Drawing.Point(12, 21);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "NAME";
            this.NameLabel.Click += new System.EventHandler(this.NameLabel_Click);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.BackColor = System.Drawing.Color.DarkRed;
            this.AddressLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddressLabel.Location = new System.Drawing.Point(12, 114);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(94, 13);
            this.AddressLabel.TabIndex = 4;
            this.AddressLabel.Text = "HOME ADDRESS";
            this.AddressLabel.Click += new System.EventHandler(this.AddressLabel_Click);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(12, 130);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(292, 20);
            this.AddressTextBox.TabIndex = 5;
            this.AddressTextBox.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            // 
            // OccupationLabel
            // 
            this.OccupationLabel.AutoSize = true;
            this.OccupationLabel.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.OccupationLabel.ForeColor = System.Drawing.Color.Gold;
            this.OccupationLabel.Location = new System.Drawing.Point(12, 71);
            this.OccupationLabel.Name = "OccupationLabel";
            this.OccupationLabel.Size = new System.Drawing.Size(77, 13);
            this.OccupationLabel.TabIndex = 6;
            this.OccupationLabel.Text = "OCCUPATION";
            this.OccupationLabel.Click += new System.EventHandler(this.OccupationLabel_Click);
            // 
            // OccupationTextBox
            // 
            this.OccupationTextBox.Location = new System.Drawing.Point(12, 87);
            this.OccupationTextBox.Name = "OccupationTextBox";
            this.OccupationTextBox.Size = new System.Drawing.Size(289, 20);
            this.OccupationTextBox.TabIndex = 7;
            this.OccupationTextBox.TextChanged += new System.EventHandler(this.OccupationTextBox_TextChanged);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.EmailLabel.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.EmailLabel.Location = new System.Drawing.Point(12, 162);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(97, 13);
            this.EmailLabel.TabIndex = 8;
            this.EmailLabel.Text = "E-MAIL ADDRESS";
            this.EmailLabel.Click += new System.EventHandler(this.EmailLabel_Click);
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(12, 178);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(286, 20);
            this.EmailTextBox.TabIndex = 9;
            this.EmailTextBox.TextChanged += new System.EventHandler(this.EmailTextBox_TextChanged);
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.BackColor = System.Drawing.Color.Tomato;
            this.PhoneLabel.ForeColor = System.Drawing.Color.Maroon;
            this.PhoneLabel.Location = new System.Drawing.Point(12, 205);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(95, 13);
            this.PhoneLabel.TabIndex = 10;
            this.PhoneLabel.Text = "PHONE NUMBER";
            this.PhoneLabel.Click += new System.EventHandler(this.PhoneLabel_Click);
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(12, 222);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(286, 20);
            this.PhoneTextBox.TabIndex = 11;
            this.PhoneTextBox.TextChanged += new System.EventHandler(this.PhoneTextBox_TextChanged);
            // 
            // EditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(316, 457);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.OccupationTextBox);
            this.Controls.Add(this.OccupationLabel);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditWindow";
            this.Text = "Edit!";
            this.Load += new System.EventHandler(this.EditWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label OccupationLabel;
        private System.Windows.Forms.TextBox OccupationTextBox;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.TextBox PhoneTextBox;
    }
}