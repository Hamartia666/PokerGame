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
        Dictionary<Guid, string> _clients;

        public GameRoom(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;
            
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
                default:
                    Close();
                    break;
            }
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

        private void AppendToChatBox(string body)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                ChatBox.Text += body + Environment.NewLine;
            });
            this.Invoke(invoker);
        }



        void Send()
        {
            
        }
    }
}
