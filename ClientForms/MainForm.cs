using System;
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
        
        private void Send()
        {
            string msg = InputTxt.Text;
            commChannel.SendText(msg);
            InputTxt.Clear();
            //byte[] buffer = Encoding.ASCII.GetBytes(msg);
            //_clientSocket.Send(buffer);
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
            if (e.message.Command == eCommand.txt)
                AppendToChatBox(e.message.Body);
            else
            {
                Close();
            }
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
            AppendToChatBox("You: " + InputTxt.Text);
            Send();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            commChannel.Release();
        }
    }
}
