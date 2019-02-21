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
    public partial class MainForm : Form, IProcessMessage
    {
        private CommunicationHub commChannel;
        public CommunicationHub CommChannel { get { return commChannel; } }
        Guid RoomId;
        Guid ClientId;
        Dictionary<Guid, IProcessMessage> _rooms;
        Dictionary<Guid, string> _roomList;
        public Dictionary<Guid, string> _clientList;



        
        
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
            _rooms = new Dictionary<Guid, IProcessMessage>();
            _roomList = new Dictionary<Guid, string>();
            _clientList = new Dictionary<Guid, string>();
        }

        private void ProcessMessages(object sender, MessageEventArgs e)
        {
            foreach (var msg in e.messages)
            {
                //pierwze polaczenie
                if (_rooms.Any())
                    _rooms.First(x => x.Key == msg.RoomId).Value.ProcessMessage(msg);
                else
                    ProcessMessage(msg);
            }
        }

        public void ProcessMessage(IMessage msg)
        {
            switch (msg.Command)
            {
                case eCommand.txt:
                    AppendToChatBox(msg.Body);
                    break;
                case eCommand.info:
                    RoomId = msg.RoomId;
                    _rooms.Add(RoomId, this);
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

        private void UpdateRoomList(string body)
        {
            _roomList.Clear();
            var c = body.Split(',');
            foreach (var e in c)
            {
                var b = e.Split('%');
                _roomList.Add(Guid.Parse(b[0]), b[1]);
            }
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                RoomList.Items.Clear();
                RoomList.Items.AddRange(_roomList.Values.ToArray());
            });
            this.Invoke(invoker);
        }

        private void UpdateClientList(string body)
        {
            _clientList.Clear();
            var c = body.Split(',');
            foreach (var e in c)
            {
                var b = e.Split('%');
                _clientList.Add(Guid.Parse(b[1]), b[0]);
            }
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                ClientList.Items.Clear();
                ClientList.Items.AddRange(_clientList.Values.ToArray());
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
            commChannel.OnMessageReceived += ProcessMessages;
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

        private void JoinRoomBtn_Click(object sender, EventArgs e)
        {
            var a = _roomList.First(x => x.Value == RoomList.SelectedItem.ToString()).Key;
            var c = new GameRoom(this);
            _rooms.Add(a, c);
            c.Show();
            commChannel.Send(new Common.Message(eCommand.joinRoom, RoomId, ClientId, $"{a}"));
        }
    }
}
