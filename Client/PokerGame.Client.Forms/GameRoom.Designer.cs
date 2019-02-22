namespace PokerGame.Client.Forms
{
    partial class GameRoom
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
            this.ClientList = new System.Windows.Forms.ListBox();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.SendTxtBtn = new System.Windows.Forms.Button();
            this.InputTxtBot = new System.Windows.Forms.TextBox();
            this.ucPlayer1 = new PokerGame.Client.Forms.Controls.ucPlayer();
            this.ucPlayer2 = new PokerGame.Client.Forms.Controls.ucPlayer();
            this.ucPlayer3 = new PokerGame.Client.Forms.Controls.ucPlayer();
            this.ucPlayerMain = new PokerGame.Client.Forms.Controls.ucPlayer();
            this.SitBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.All_inBtn = new System.Windows.Forms.Button();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.FoldBtn = new System.Windows.Forms.Button();
            this.BidBtn = new System.Windows.Forms.Button();
            this.BidValue = new System.Windows.Forms.NumericUpDown();
            this.grpActions = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.BidValue)).BeginInit();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.Location = new System.Drawing.Point(835, 12);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(120, 95);
            this.ClientList.TabIndex = 0;
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(699, 367);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(256, 171);
            this.ChatBox.TabIndex = 1;
            // 
            // SendTxtBtn
            // 
            this.SendTxtBtn.Location = new System.Drawing.Point(855, 544);
            this.SendTxtBtn.Name = "SendTxtBtn";
            this.SendTxtBtn.Size = new System.Drawing.Size(100, 23);
            this.SendTxtBtn.TabIndex = 2;
            this.SendTxtBtn.Text = "Send";
            this.SendTxtBtn.UseVisualStyleBackColor = true;
            this.SendTxtBtn.Click += new System.EventHandler(this.SendTxtBtn_Click);
            // 
            // InputTxtBot
            // 
            this.InputTxtBot.Location = new System.Drawing.Point(699, 545);
            this.InputTxtBot.Name = "InputTxtBot";
            this.InputTxtBot.Size = new System.Drawing.Size(150, 20);
            this.InputTxtBot.TabIndex = 3;
            // 
            // ucPlayer1
            // 
            this.ucPlayer1.Location = new System.Drawing.Point(279, 12);
            this.ucPlayer1.Name = "ucPlayer1";
            this.ucPlayer1.Size = new System.Drawing.Size(194, 147);
            this.ucPlayer1.TabIndex = 4;
            // 
            // ucPlayer2
            // 
            this.ucPlayer2.Location = new System.Drawing.Point(25, 206);
            this.ucPlayer2.Name = "ucPlayer2";
            this.ucPlayer2.Size = new System.Drawing.Size(194, 147);
            this.ucPlayer2.TabIndex = 5;
            // 
            // ucPlayer3
            // 
            this.ucPlayer3.Location = new System.Drawing.Point(488, 206);
            this.ucPlayer3.Name = "ucPlayer3";
            this.ucPlayer3.Size = new System.Drawing.Size(194, 147);
            this.ucPlayer3.TabIndex = 6;
            // 
            // ucPlayerMain
            // 
            this.ucPlayerMain.Location = new System.Drawing.Point(279, 418);
            this.ucPlayerMain.Name = "ucPlayerMain";
            this.ucPlayerMain.Size = new System.Drawing.Size(194, 147);
            this.ucPlayerMain.TabIndex = 7;
            // 
            // SitBtn
            // 
            this.SitBtn.Location = new System.Drawing.Point(699, 330);
            this.SitBtn.Name = "SitBtn";
            this.SitBtn.Size = new System.Drawing.Size(75, 23);
            this.SitBtn.TabIndex = 8;
            this.SitBtn.Text = "Sit at Table";
            this.SitBtn.UseVisualStyleBackColor = true;
            this.SitBtn.Click += new System.EventHandler(this.SitBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(781, 329);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 9;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // All_inBtn
            // 
            this.All_inBtn.Location = new System.Drawing.Point(100, 122);
            this.All_inBtn.Name = "All_inBtn";
            this.All_inBtn.Size = new System.Drawing.Size(75, 23);
            this.All_inBtn.TabIndex = 10;
            this.All_inBtn.Text = "All in";
            this.All_inBtn.UseVisualStyleBackColor = true;
            this.All_inBtn.Click += new System.EventHandler(this.All_inBtn_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Location = new System.Drawing.Point(100, 93);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(75, 23);
            this.CheckBtn.TabIndex = 11;
            this.CheckBtn.Text = "Check";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // FoldBtn
            // 
            this.FoldBtn.Location = new System.Drawing.Point(100, 64);
            this.FoldBtn.Name = "FoldBtn";
            this.FoldBtn.Size = new System.Drawing.Size(75, 23);
            this.FoldBtn.TabIndex = 12;
            this.FoldBtn.Text = "Fold";
            this.FoldBtn.UseVisualStyleBackColor = true;
            this.FoldBtn.Click += new System.EventHandler(this.FoldBtn_Click);
            // 
            // BidBtn
            // 
            this.BidBtn.Location = new System.Drawing.Point(100, 35);
            this.BidBtn.Name = "BidBtn";
            this.BidBtn.Size = new System.Drawing.Size(75, 23);
            this.BidBtn.TabIndex = 13;
            this.BidBtn.Text = "Bid";
            this.BidBtn.UseVisualStyleBackColor = true;
            this.BidBtn.Click += new System.EventHandler(this.BidBtn_Click);
            // 
            // BidValue
            // 
            this.BidValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BidValue.Location = new System.Drawing.Point(30, 38);
            this.BidValue.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.BidValue.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BidValue.Name = "BidValue";
            this.BidValue.Size = new System.Drawing.Size(64, 20);
            this.BidValue.TabIndex = 14;
            this.BidValue.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.BidBtn);
            this.grpActions.Controls.Add(this.BidValue);
            this.grpActions.Controls.Add(this.All_inBtn);
            this.grpActions.Controls.Add(this.CheckBtn);
            this.grpActions.Controls.Add(this.FoldBtn);
            this.grpActions.Enabled = false;
            this.grpActions.Location = new System.Drawing.Point(493, 375);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(200, 163);
            this.grpActions.TabIndex = 15;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Actions";
            // 
            // GameRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 581);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.SitBtn);
            this.Controls.Add(this.ucPlayerMain);
            this.Controls.Add(this.ucPlayer3);
            this.Controls.Add(this.ucPlayer2);
            this.Controls.Add(this.ucPlayer1);
            this.Controls.Add(this.InputTxtBot);
            this.Controls.Add(this.SendTxtBtn);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.ClientList);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameRoom";
            this.Text = "GameRoom";
            ((System.ComponentModel.ISupportInitialize)(this.BidValue)).EndInit();
            this.grpActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ClientList;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.Button SendTxtBtn;
        private System.Windows.Forms.TextBox InputTxtBot;
        private Controls.ucPlayer ucPlayer1;
        private Controls.ucPlayer ucPlayer2;
        private Controls.ucPlayer ucPlayer3;
        private Controls.ucPlayer ucPlayerMain;
        private System.Windows.Forms.Button SitBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button All_inBtn;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button FoldBtn;
        private System.Windows.Forms.Button BidBtn;
        private System.Windows.Forms.NumericUpDown BidValue;
        private System.Windows.Forms.GroupBox grpActions;
    }
}