namespace PokerGame.Client.Forms.Controls
{
    partial class ucCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Suit = new System.Windows.Forms.Label();
            this.Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Suit
            // 
            this.Suit.AutoSize = true;
            this.Suit.Location = new System.Drawing.Point(17, 18);
            this.Suit.Name = "Suit";
            this.Suit.Size = new System.Drawing.Size(35, 13);
            this.Suit.TabIndex = 0;
            this.Suit.Text = "label1";
            // 
            // Value
            // 
            this.Value.AutoSize = true;
            this.Value.Location = new System.Drawing.Point(16, 67);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(35, 13);
            this.Value.TabIndex = 1;
            this.Value.Text = "label2";
            // 
            // ucCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Value);
            this.Controls.Add(this.Suit);
            this.Name = "ucCard";
            this.Size = new System.Drawing.Size(84, 107);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Suit;
        private System.Windows.Forms.Label Value;
    }
}
