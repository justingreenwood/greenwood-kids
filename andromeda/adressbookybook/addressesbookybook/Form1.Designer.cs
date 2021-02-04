namespace addressesbookybook
{
    partial class addressstuff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addressstuff));
            this.addresses = new System.Windows.Forms.CheckedListBox();
            this.buttonadd = new System.Windows.Forms.Button();
            this.buttonremove = new System.Windows.Forms.Button();
            this.buttonedit = new System.Windows.Forms.Button();
            this.buttonsave = new System.Windows.Forms.Button();
            this.buttonquit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addresses
            // 
            this.addresses.FormattingEnabled = true;
            this.addresses.Location = new System.Drawing.Point(12, 12);
            this.addresses.Name = "addresses";
            this.addresses.Size = new System.Drawing.Size(401, 184);
            this.addresses.TabIndex = 0;
            // 
            // buttonadd
            // 
            this.buttonadd.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonadd.Location = new System.Drawing.Point(12, 212);
            this.buttonadd.Name = "buttonadd";
            this.buttonadd.Size = new System.Drawing.Size(75, 25);
            this.buttonadd.TabIndex = 1;
            this.buttonadd.Text = "add";
            this.buttonadd.UseVisualStyleBackColor = true;
            this.buttonadd.Click += new System.EventHandler(this.buttonadd_Click);
            // 
            // buttonremove
            // 
            this.buttonremove.Font = new System.Drawing.Font("Ink Free", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonremove.Location = new System.Drawing.Point(93, 212);
            this.buttonremove.Name = "buttonremove";
            this.buttonremove.Size = new System.Drawing.Size(75, 25);
            this.buttonremove.TabIndex = 2;
            this.buttonremove.Text = "remove";
            this.buttonremove.UseVisualStyleBackColor = true;
            this.buttonremove.Click += new System.EventHandler(this.buttonremove_Click);
            // 
            // buttonedit
            // 
            this.buttonedit.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonedit.Location = new System.Drawing.Point(174, 212);
            this.buttonedit.Name = "buttonedit";
            this.buttonedit.Size = new System.Drawing.Size(75, 25);
            this.buttonedit.TabIndex = 3;
            this.buttonedit.Text = "edit";
            this.buttonedit.UseVisualStyleBackColor = true;
            this.buttonedit.Click += new System.EventHandler(this.buttonedit_Click);
            // 
            // buttonsave
            // 
            this.buttonsave.BackColor = System.Drawing.Color.Lime;
            this.buttonsave.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonsave.Location = new System.Drawing.Point(255, 212);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(75, 25);
            this.buttonsave.TabIndex = 4;
            this.buttonsave.Text = "save";
            this.buttonsave.UseVisualStyleBackColor = false;
            this.buttonsave.Click += new System.EventHandler(this.buttonsave_Click);
            // 
            // buttonquit
            // 
            this.buttonquit.BackColor = System.Drawing.Color.Red;
            this.buttonquit.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonquit.Location = new System.Drawing.Point(336, 212);
            this.buttonquit.Name = "buttonquit";
            this.buttonquit.Size = new System.Drawing.Size(75, 25);
            this.buttonquit.TabIndex = 5;
            this.buttonquit.Text = "quit";
            this.buttonquit.UseVisualStyleBackColor = false;
            this.buttonquit.Click += new System.EventHandler(this.buttonquit_Click);
            // 
            // addressstuff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 270);
            this.Controls.Add(this.buttonquit);
            this.Controls.Add(this.buttonsave);
            this.Controls.Add(this.buttonedit);
            this.Controls.Add(this.buttonremove);
            this.Controls.Add(this.buttonadd);
            this.Controls.Add(this.addresses);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "addressstuff";
            this.Text = "Addressbook stuffystuff";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox addresses;
        private System.Windows.Forms.Button buttonadd;
        private System.Windows.Forms.Button buttonremove;
        private System.Windows.Forms.Button buttonedit;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Button buttonquit;
    }
}

