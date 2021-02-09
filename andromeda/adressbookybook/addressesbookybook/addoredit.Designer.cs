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
            this.textBoxfirst = new System.Windows.Forms.TextBox();
            this.textBoxlast = new System.Windows.Forms.TextBox();
            this.textBoxstreetnum = new System.Windows.Forms.TextBox();
            this.textBoxstate = new System.Windows.Forms.TextBox();
            this.textBoxzip = new System.Windows.Forms.TextBox();
            this.textBoxcity = new System.Windows.Forms.TextBox();
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
            // textBoxfirst
            // 
            this.textBoxfirst.Location = new System.Drawing.Point(13, 23);
            this.textBoxfirst.Name = "textBoxfirst";
            this.textBoxfirst.Size = new System.Drawing.Size(100, 20);
            this.textBoxfirst.TabIndex = 3;
            // 
            // textBoxlast
            // 
            this.textBoxlast.Location = new System.Drawing.Point(15, 63);
            this.textBoxlast.Name = "textBoxlast";
            this.textBoxlast.Size = new System.Drawing.Size(100, 20);
            this.textBoxlast.TabIndex = 4;
            // 
            // textBoxstreetnum
            // 
            this.textBoxstreetnum.Location = new System.Drawing.Point(12, 140);
            this.textBoxstreetnum.Name = "textBoxstreetnum";
            this.textBoxstreetnum.Size = new System.Drawing.Size(124, 20);
            this.textBoxstreetnum.TabIndex = 5;
            // 
            // textBoxstate
            // 
            this.textBoxstate.Location = new System.Drawing.Point(123, 180);
            this.textBoxstate.Name = "textBoxstate";
            this.textBoxstate.Size = new System.Drawing.Size(42, 20);
            this.textBoxstate.TabIndex = 6;
            // 
            // textBoxzip
            // 
            this.textBoxzip.Location = new System.Drawing.Point(190, 180);
            this.textBoxzip.Name = "textBoxzip";
            this.textBoxzip.Size = new System.Drawing.Size(66, 20);
            this.textBoxzip.TabIndex = 7;
            // 
            // textBoxcity
            // 
            this.textBoxcity.Location = new System.Drawing.Point(15, 180);
            this.textBoxcity.Name = "textBoxcity";
            this.textBoxcity.Size = new System.Drawing.Size(89, 20);
            this.textBoxcity.TabIndex = 8;
            // 
            // buttonokay
            // 
            this.buttonokay.BackColor = System.Drawing.Color.Lime;
            this.buttonokay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonokay.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonokay.Location = new System.Drawing.Point(246, 12);
            this.buttonokay.Name = "buttonokay";
            this.buttonokay.Size = new System.Drawing.Size(75, 23);
            this.buttonokay.TabIndex = 9;
            this.buttonokay.Text = "okay";
            this.buttonokay.UseVisualStyleBackColor = false;
            this.buttonokay.Click += new System.EventHandler(this.buttonokay_Click);
            // 
            // buttoncancel
            // 
            this.buttoncancel.BackColor = System.Drawing.Color.Red;
            this.buttoncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttoncancel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttoncancel.Location = new System.Drawing.Point(246, 41);
            this.buttoncancel.Name = "buttoncancel";
            this.buttoncancel.Size = new System.Drawing.Size(75, 23);
            this.buttoncancel.TabIndex = 10;
            this.buttoncancel.Text = "cancel";
            this.buttoncancel.UseVisualStyleBackColor = false;
            this.buttoncancel.Click += new System.EventHandler(this.buttoncancel_Click);
            // 
            // addoredit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(333, 232);
            this.Controls.Add(this.buttoncancel);
            this.Controls.Add(this.buttonokay);
            this.Controls.Add(this.textBoxcity);
            this.Controls.Add(this.textBoxzip);
            this.Controls.Add(this.textBoxstate);
            this.Controls.Add(this.textBoxstreetnum);
            this.Controls.Add(this.textBoxlast);
            this.Controls.Add(this.textBoxfirst);
            this.Controls.Add(this.address);
            this.Controls.Add(this.labellast);
            this.Controls.Add(this.labelfirst);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addoredit";
            this.Text = "add or edit";
            this.Load += new System.EventHandler(this.addoredit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelfirst;
        private System.Windows.Forms.Label labellast;
        private System.Windows.Forms.ListBox address;
        private System.Windows.Forms.TextBox textBoxfirst;
        private System.Windows.Forms.TextBox textBoxlast;
        private System.Windows.Forms.TextBox textBoxstreetnum;
        private System.Windows.Forms.TextBox textBoxstate;
        private System.Windows.Forms.TextBox textBoxzip;
        private System.Windows.Forms.TextBox textBoxcity;
        private System.Windows.Forms.Button buttonokay;
        private System.Windows.Forms.Button buttoncancel;
    }
}