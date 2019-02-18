namespace PokerGame.Client.Forms
{
    partial class MainForm
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
            this.InputTxt = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.ClientList = new System.Windows.Forms.ListBox();
            this.ChangeNameBtn = new System.Windows.Forms.Button();
            this.NameTxtBox = new System.Windows.Forms.TextBox();
            this.RoomList = new System.Windows.Forms.ListBox();
            this.JoinRoomBtn = new System.Windows.Forms.Button();
            this.CreateRoomBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputTxt
            // 
            this.InputTxt.Location = new System.Drawing.Point(10, 419);
            this.InputTxt.Name = "InputTxt";
            this.InputTxt.Size = new System.Drawing.Size(644, 20);
            this.InputTxt.TabIndex = 0;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(659, 419);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(131, 20);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(10, 11);
            this.ChatBox.MaxLength = 5000000;
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(454, 403);
            this.ChatBox.TabIndex = 3;
            // 
            // ClientList
            // 
            this.ClientList.FormattingEnabled = true;
            this.ClientList.Location = new System.Drawing.Point(471, 11);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(120, 95);
            this.ClientList.TabIndex = 4;
            // 
            // ChangeNameBtn
            // 
            this.ChangeNameBtn.Location = new System.Drawing.Point(471, 390);
            this.ChangeNameBtn.Name = "ChangeNameBtn";
            this.ChangeNameBtn.Size = new System.Drawing.Size(151, 23);
            this.ChangeNameBtn.TabIndex = 5;
            this.ChangeNameBtn.Text = "Change Name";
            this.ChangeNameBtn.UseVisualStyleBackColor = true;
            this.ChangeNameBtn.Click += new System.EventHandler(this.ChangeNameBtn_Click);
            // 
            // NameTxtBox
            // 
            this.NameTxtBox.Location = new System.Drawing.Point(471, 364);
            this.NameTxtBox.Name = "NameTxtBox";
            this.NameTxtBox.Size = new System.Drawing.Size(151, 20);
            this.NameTxtBox.TabIndex = 6;
            this.NameTxtBox.Text = "Change your name here";
            // 
            // RoomList
            // 
            this.RoomList.FormattingEnabled = true;
            this.RoomList.Location = new System.Drawing.Point(471, 113);
            this.RoomList.Name = "RoomList";
            this.RoomList.Size = new System.Drawing.Size(120, 95);
            this.RoomList.TabIndex = 7;
            // 
            // JoinRoomBtn
            // 
            this.JoinRoomBtn.Location = new System.Drawing.Point(598, 113);
            this.JoinRoomBtn.Name = "JoinRoomBtn";
            this.JoinRoomBtn.Size = new System.Drawing.Size(93, 23);
            this.JoinRoomBtn.TabIndex = 8;
            this.JoinRoomBtn.Text = "Join Room";
            this.JoinRoomBtn.UseVisualStyleBackColor = true;
            // 
            // CreateRoomBtn
            // 
            this.CreateRoomBtn.Location = new System.Drawing.Point(598, 143);
            this.CreateRoomBtn.Name = "CreateRoomBtn";
            this.CreateRoomBtn.Size = new System.Drawing.Size(93, 23);
            this.CreateRoomBtn.TabIndex = 9;
            this.CreateRoomBtn.Text = "Create Room";
            this.CreateRoomBtn.UseVisualStyleBackColor = true;
            this.CreateRoomBtn.Click += new System.EventHandler(this.CreateRoomBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateRoomBtn);
            this.Controls.Add(this.JoinRoomBtn);
            this.Controls.Add(this.RoomList);
            this.Controls.Add(this.NameTxtBox);
            this.Controls.Add(this.ChangeNameBtn);
            this.Controls.Add(this.ClientList);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.InputTxt);
            this.Name = "MainForm";
            this.Text = "MainChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTxt;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.ListBox ClientList;
        private System.Windows.Forms.Button ChangeNameBtn;
        private System.Windows.Forms.TextBox NameTxtBox;
        private System.Windows.Forms.ListBox RoomList;
        private System.Windows.Forms.Button JoinRoomBtn;
        private System.Windows.Forms.Button CreateRoomBtn;
    }
}

