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
            this.ucPlayer4 = new PokerGame.Client.Forms.Controls.ucPlayer();
            this.SuspendLayout();
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.Location = new System.Drawing.Point(628, 12);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(120, 95);
            this.ClientList.TabIndex = 0;
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(492, 367);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(256, 171);
            this.ChatBox.TabIndex = 1;
            // 
            // SendTxtBtn
            // 
            this.SendTxtBtn.Location = new System.Drawing.Point(648, 544);
            this.SendTxtBtn.Name = "SendTxtBtn";
            this.SendTxtBtn.Size = new System.Drawing.Size(100, 23);
            this.SendTxtBtn.TabIndex = 2;
            this.SendTxtBtn.Text = "Send";
            this.SendTxtBtn.UseVisualStyleBackColor = true;
            // 
            // InputTxtBot
            // 
            this.InputTxtBot.Location = new System.Drawing.Point(492, 545);
            this.InputTxtBot.Name = "InputTxtBot";
            this.InputTxtBot.Size = new System.Drawing.Size(150, 20);
            this.InputTxtBot.TabIndex = 3;
            // 
            // ucPlayer1
            // 
            this.ucPlayer1.Location = new System.Drawing.Point(12, 12);
            this.ucPlayer1.Name = "ucPlayer1";
            this.ucPlayer1.Size = new System.Drawing.Size(194, 147);
            this.ucPlayer1.TabIndex = 4;
            // 
            // ucPlayer2
            // 
            this.ucPlayer2.Location = new System.Drawing.Point(12, 165);
            this.ucPlayer2.Name = "ucPlayer2";
            this.ucPlayer2.Size = new System.Drawing.Size(194, 147);
            this.ucPlayer2.TabIndex = 5;
            // 
            // ucPlayer3
            // 
            this.ucPlayer3.Location = new System.Drawing.Point(12, 318);
            this.ucPlayer3.Name = "ucPlayer3";
            this.ucPlayer3.Size = new System.Drawing.Size(194, 147);
            this.ucPlayer3.TabIndex = 6;
            // 
            // ucPlayer4
            // 
            this.ucPlayer4.Location = new System.Drawing.Point(554, 113);
            this.ucPlayer4.Name = "ucPlayer4";
            this.ucPlayer4.Size = new System.Drawing.Size(194, 147);
            this.ucPlayer4.TabIndex = 7;
            // 
            // GameRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 581);
            this.Controls.Add(this.ucPlayer4);
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
        private Controls.ucPlayer ucPlayer4;
    }
}