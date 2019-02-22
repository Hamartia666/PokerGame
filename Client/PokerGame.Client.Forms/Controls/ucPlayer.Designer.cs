namespace PokerGame.Client.Forms.Controls
{
    partial class ucPlayer
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
            this.playerName = new System.Windows.Forms.Label();
            this.cash_label = new System.Windows.Forms.Label();
            this.cash_value = new System.Windows.Forms.Label();
            this.ucCard2 = new PokerGame.Client.Forms.Controls.ucCard();
            this.ucCard1 = new PokerGame.Client.Forms.Controls.ucCard();
            this.Bid_label = new System.Windows.Forms.Label();
            this.Bid_value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerName
            // 
            this.playerName.AutoSize = true;
            this.playerName.Location = new System.Drawing.Point(3, 11);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(63, 13);
            this.playerName.TabIndex = 0;
            this.playerName.Text = "playerName";
            // 
            // cash_label
            // 
            this.cash_label.AutoSize = true;
            this.cash_label.Location = new System.Drawing.Point(3, 30);
            this.cash_label.Name = "cash_label";
            this.cash_label.Size = new System.Drawing.Size(43, 13);
            this.cash_label.TabIndex = 1;
            this.cash_label.Text = "Cash: $";
            // 
            // cash_value
            // 
            this.cash_value.AutoSize = true;
            this.cash_value.Location = new System.Drawing.Point(52, 30);
            this.cash_value.Name = "cash_value";
            this.cash_value.Size = new System.Drawing.Size(13, 13);
            this.cash_value.TabIndex = 2;
            this.cash_value.Text = "0";
            // 
            // ucCard2
            // 
            this.ucCard2.Location = new System.Drawing.Point(96, 46);
            this.ucCard2.Name = "ucCard2";
            this.ucCard2.ShowValue = false;
            this.ucCard2.Size = new System.Drawing.Size(84, 107);
            this.ucCard2.TabIndex = 4;
            // 
            // ucCard1
            // 
            this.ucCard1.Location = new System.Drawing.Point(6, 46);
            this.ucCard1.Name = "ucCard1";
            this.ucCard1.ShowValue = false;
            this.ucCard1.Size = new System.Drawing.Size(84, 107);
            this.ucCard1.TabIndex = 3;
            // 
            // Bid_label
            // 
            this.Bid_label.AutoSize = true;
            this.Bid_label.Location = new System.Drawing.Point(83, 30);
            this.Bid_label.Name = "Bid_label";
            this.Bid_label.Size = new System.Drawing.Size(34, 13);
            this.Bid_label.TabIndex = 5;
            this.Bid_label.Text = "Bid: $";
            // 
            // Bid_value
            // 
            this.Bid_value.AutoSize = true;
            this.Bid_value.Location = new System.Drawing.Point(132, 30);
            this.Bid_value.Name = "Bid_value";
            this.Bid_value.Size = new System.Drawing.Size(13, 13);
            this.Bid_value.TabIndex = 6;
            this.Bid_value.Text = "0";
            // 
            // ucPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Bid_value);
            this.Controls.Add(this.Bid_label);
            this.Controls.Add(this.ucCard2);
            this.Controls.Add(this.ucCard1);
            this.Controls.Add(this.cash_value);
            this.Controls.Add(this.cash_label);
            this.Controls.Add(this.playerName);
            this.Name = "ucPlayer";
            this.Size = new System.Drawing.Size(194, 147);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerName;
        private System.Windows.Forms.Label cash_label;
        private System.Windows.Forms.Label cash_value;
        private ucCard ucCard1;
        private ucCard ucCard2;
        private System.Windows.Forms.Label Bid_label;
        private System.Windows.Forms.Label Bid_value;
    }
}
