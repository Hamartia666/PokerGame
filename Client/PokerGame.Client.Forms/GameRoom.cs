using PokerGame.Client.Forms.Controls;
using PokerGame.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame.Client.Forms
{
    public partial class GameRoom : Form, IProcessMessage
    {
        Guid RoomId;
        Guid ClientId;
        private MainForm _parent;
        Dictionary<Guid, string> _clientPlayers;
        List<ucPlayer> _ucPlayers;

        public GameRoom(MainForm parent)
        {
            InitializeComponent();
            StartBtn.Enabled = false;
            _parent = parent;
            _clientPlayers = new Dictionary<Guid, string>();
            _ucPlayers = new List<ucPlayer>
            {
                ucPlayer1,
                ucPlayer2,
                ucPlayer3,
                ucPlayerMain
            };
        }

        public void ProcessMessage(IMessage msg)
        {
            switch (msg.Command)
            {
                case eCommand.txt:
                    AppendToChatBox(msg.Body);
                    break;
                case eCommand.list:
                    UpdateClientList(msg.Body);
                    break;
                case eCommand.info:
                    RoomId = msg.RoomId;
                    ClientId = msg.ClientId.Value;
                    break;
                case eCommand.sitPlayer:
                    UpdatePlayers(msg.ClientId.Value);
                    break;
                case eCommand.startGame:
                    ProcessStartGame(msg.Body);
                    break;
                default:
                    Close();
                    break;
            }
        }

        private void ProcessStartGame(string body)
        {
            //split all hands
            var hands = body.Split('*');
            foreach (var hand in hands)
            {
                var data = hand.Split('%');
                var clientId = Guid.Parse(data[0]);
                var cards = GetCards(data[1]);
                ProcessSingleHand(clientId, cards);
            }
        }

        private void ProcessSingleHand(Guid clientId, List<Card> cards)
        {
            if (_ucPlayers.Any(x => x._clientId == clientId))
            {
                _ucPlayers.First(x => x._clientId == clientId).UpdateCards(cards);
                if (clientId == ClientId)
                    _ucPlayers.First(x => x._clientId == clientId).DisplayCards();
            }

        }

        private List<Card> GetCards(string input)
        {
            var cardList = new List<Card>();
            //split cards
            var cards = input.Split(';');
            foreach (var c in cards)
            {
                var card = c.Split(',').Select(int.Parse).ToArray();
                cardList.Add(new Card((eSuit)card[0], (eValue)card[1]));
            }
            return cardList;
        }

        private void UpdatePlayers(Guid clientId)
        {
            if (_clientPlayers.ContainsKey(clientId))
            {
                if (clientId == ClientId)
                {
                    AppendToChatBox("You have already joined the table!");
                }
            }
            else
            {
                var name = _parent._clientList.First(x => x.Key == clientId).Value;
                _clientPlayers.Add(clientId, name);
                if (clientId == ClientId)
                {
                    ucPlayerMain.SitPlayer(name, clientId);
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        StartBtn.Enabled = true;
                    });
                    this.Invoke(invoker);
                    AppendToChatBox("You have joined the table");
                }
                else
                {
                    _ucPlayers.First(x => x.IsFree).SitPlayer(name, clientId);
                }
            }
        }

        private void UpdateClientList(string body)
        {
            var c = body.Split(',');
            List<string> a = new List<string>();
            foreach (var e in c)
            {
                var b = e.Split('%');
                a.Add(b[0]);
                if (_clientPlayers.ContainsKey(Guid.Parse(b[1])))
                {
                    _ucPlayers.First(x => x._clientId == Guid.Parse(b[1])).UpdateName(b[0]);
                }
            }
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                ClientList.Items.Clear();
                ClientList.Items.AddRange(a.ToArray());
            });
            this.Invoke(invoker);
        }

        private void AppendToChatBox(string body)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                ChatBox.Text += body + Environment.NewLine;
            });
            this.Invoke(invoker);
        }

        private void SitBtn_Click(object sender, EventArgs e)
        {
            _parent.CommChannel.Send(new Common.Message(eCommand.sitPlayer, RoomId, ClientId, ""));
            SitBtn.Enabled = false;
        }

        private void SendTxtBtn_Click(object sender, EventArgs e)
        {
            _parent.CommChannel.Send(new Common.Message(eCommand.txt, RoomId, ClientId, InputTxtBot.Text));
            InputTxtBot.Clear();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            StartBtn.Enabled = false;
            _parent.CommChannel.Send(new Common.Message(eCommand.startGame, RoomId, ClientId, ""));
        }
    }
}
