namespace GameToEarnLegos
{
    partial class FormTriangleTrees
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTriangleTrees));
            timerGameLoop = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // timerGameLoop
            // 
            timerGameLoop.Tick += timerGameLoop_Tick;
            // 
            // FormTriangleTrees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(1924, 1061);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTriangleTrees";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Triangle Trees";
            KeyDown += FormTriangleTrees_KeyDown;
            KeyUp += FormTriangleTrees_KeyUp;
            MouseDown += FormTriangleTrees_MouseDown;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timerGameLoop;
    }
}