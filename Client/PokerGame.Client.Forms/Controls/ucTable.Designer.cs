namespace PokerGame.Client.Forms.Controls
{
    partial class ucTable
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
            this.ucCard1 = new PokerGame.Client.Forms.Controls.ucCard();
            this.ucCard2 = new PokerGame.Client.Forms.Controls.ucCard();
            this.ucCard3 = new PokerGame.Client.Forms.Controls.ucCard();
            this.ucCard4 = new PokerGame.Client.Forms.Controls.ucCard();
            this.ucCard5 = new PokerGame.Client.Forms.Controls.ucCard();
            this.SuspendLayout();
            // 
            // ucCard1
            // 
            this.ucCard1.Location = new System.Drawing.Point(17, 18);
            this.ucCard1.Name = "ucCard1";
            this.ucCard1.ShowValue = false;
            this.ucCard1.Size = new System.Drawing.Size(84, 107);
            this.ucCard1.TabIndex = 0;
            this.ucCard1.Visible = false;
            // 
            // ucCard2
            // 
            this.ucCard2.Location = new System.Drawing.Point(108, 18);
            this.ucCard2.Name = "ucCard2";
            this.ucCard2.ShowValue = false;
            this.ucCard2.Size = new System.Drawing.Size(84, 107);
            this.ucCard2.TabIndex = 1;
            this.ucCard2.Visible = false;
            // 
            // ucCard3
            // 
            this.ucCard3.Location = new System.Drawing.Point(199, 18);
            this.ucCard3.Name = "ucCard3";
            this.ucCard3.ShowValue = false;
            this.ucCard3.Size = new System.Drawing.Size(84, 107);
            this.ucCard3.TabIndex = 2;
            this.ucCard3.Visible = false;
            // 
            // ucCard4
            // 
            this.ucCard4.Location = new System.Drawing.Point(290, 18);
            this.ucCard4.Name = "ucCard4";
            this.ucCard4.ShowValue = false;
            this.ucCard4.Size = new System.Drawing.Size(84, 107);
            this.ucCard4.TabIndex = 3;
            this.ucCard4.Visible = false;
            // 
            // ucCard5
            // 
            this.ucCard5.Location = new System.Drawing.Point(381, 18);
            this.ucCard5.Name = "ucCard5";
            this.ucCard5.ShowValue = false;
            this.ucCard5.Size = new System.Drawing.Size(84, 107);
            this.ucCard5.TabIndex = 4;
            this.ucCard5.Visible = false;
            // 
            // ucTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucCard5);
            this.Controls.Add(this.ucCard4);
            this.Controls.Add(this.ucCard3);
            this.Controls.Add(this.ucCard2);
            this.Controls.Add(this.ucCard1);
            this.Name = "ucTable";
            this.Size = new System.Drawing.Size(487, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private ucCard ucCard1;
        private ucCard ucCard2;
        private ucCard ucCard3;
        private ucCard ucCard4;
        private ucCard ucCard5;
    }
}
