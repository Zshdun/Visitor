namespace WinFormsApp3
{
    partial class Form1
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
            CheckStats = new Button();
            BuySword = new Button();
            BuyBow = new Button();
            SuspendLayout();
            // 
            // CheckStats
            // 
            CheckStats.Location = new Point(285, 226);
            CheckStats.Name = "CheckStats";
            CheckStats.Size = new Size(105, 23);
            CheckStats.TabIndex = 0;
            CheckStats.Text = "Check Stats";
            CheckStats.UseVisualStyleBackColor = true;
            
            // 
            // BuySword
            // 
            BuySword.Location = new Point(212, 149);
            BuySword.Name = "BuySword";
            BuySword.Size = new Size(75, 23);
            BuySword.TabIndex = 1;
            BuySword.Text = "Buy Sword";
            BuySword.UseVisualStyleBackColor = true;
            BuySword.Click += button2_Click;
            // 
            // BuyBow
            // 
            BuyBow.Location = new Point(426, 149);
            BuyBow.Name = "BuyBow";
            BuyBow.Size = new Size(75, 23);
            BuyBow.TabIndex = 2;
            BuyBow.Text = "Buy Bow";
            BuyBow.UseVisualStyleBackColor = true;
            BuyBow.Click += BuyBow_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BuyBow);
            Controls.Add(BuySword);
            Controls.Add(CheckStats);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button CheckStats;
        private Button BuySword;
        private Button BuyBow;
    }
}