﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using PokerGame.Client.Communication;
using PokerGame.Common;

namespace PokerGame.Client.Forms
{
    public partial class MainForm : Form
    {
        CommunicationHub commChannel;
        Guid RoomId;
        Guid ClientId;

        
        
        private void Send()
        {
            commChannel.Send(new Common.Message(eCommand.txt, RoomId, ClientId, InputTxt.Text));
            InputTxt.Clear();
            //byte[] buffer = Encoding.ASCII.GetBytes(msg);
            //_clientSocket.Send(buffer);
        }

        private void Send(Common.Message msg)
        {
            commChannel.Send(msg);
        }

        private void AppendToChatBox(string text) //PROBLEM
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                ChatBox.Text += text + Environment.NewLine;
            });
            this.Invoke(invoker);
        }

        public MainForm()
        {
            InitializeComponent();            
        }

        private void DisplayReceivedMessage(object sender, MessageEventArgs e)
        {
            foreach (var msg in e.messages)
            {
                switch (msg.Command)
                {
                    case eCommand.txt:
                        AppendToChatBox(msg.Body);
                        break;
                    case eCommand.info:
                        RoomId = msg.RoomId;
                        ClientId = msg.ClientId.Value;
                        break;
                    case eCommand.list:
                        UpdateClientList(msg.Body);
                        break;
                    case eCommand.listRoom:
                        UpdateRoomList(msg.Body);
                        break;
                    default:
                        Close();
                        break;
                }
            }
        }

        private void UpdateRoomList(string body)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                RoomList.Items.Clear();
                RoomList.Items.AddRange(body.Split(','));
            });
            this.Invoke(invoker);
        }

        private void UpdateClientList(string body)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                ClientList.Items.Clear();
                ClientList.Items.AddRange(body.Split(','));
            });
            this.Invoke(invoker);
        }

        private void DisplayConnectedMesage(object sender, EventArgs e)
        {
            AppendToChatBox("Connected!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Show();
            commChannel = new CommunicationHub();
            commChannel.OnConnect += DisplayConnectedMesage;
            commChannel.OnMessageReceived += DisplayReceivedMessage;
            commChannel.Start();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            //AppendToChatBox("You: " + InputTxt.Text);
            Send();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Send(new Common.Message(eCommand.quit, RoomId, ClientId, ""));
            commChannel.Release();
        }

        private void ChangeNameBtn_Click(object sender, EventArgs e)
        {
            commChannel.Send(new Common.Message(eCommand.changeName, RoomId, ClientId, NameTxtBox.Text));
            NameTxtBox.Clear();
        }

        private void CreateRoomBtn_Click(object sender, EventArgs e)
        {
            commChannel.Send(new Common.Message(eCommand.createRoom, RoomId, ClientId, ""));
        }
    }
}
