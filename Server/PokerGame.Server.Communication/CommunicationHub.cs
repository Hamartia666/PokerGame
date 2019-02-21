using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using PokerGame.Common;
using System.Configuration;

namespace PokerGame.Server.Communication
{
    public class CommunicationHub
    {
        private readonly int _port;
        private byte[] _buffer = new byte[1024];
        private readonly Socket _serverSocket;

        public EventHandler<ClientEventArgs> OnClientConnect;
        public EventHandler<MessageEventArgs> OnMessageReceived;

        public CommunicationHub()
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["ServerPort"], out int port))
                port = 50000;
            _port = port;
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void ClientConnected(Client c)
        {
            if (OnClientConnect == null) return;
            ClientEventArgs args = new ClientEventArgs(c);
            OnClientConnect(this, args);
        }

        private bool MessageReceived(string text)
        {
            // Make sure someone is listening to event
            if (OnMessageReceived == null) return true;
            MessageEventArgs args = new MessageEventArgs(text);
            OnMessageReceived(this, args);
            return args.messages.Where(x=>x.Command == eCommand.quit).Any();
        }

        public bool ServerSetup()
        {
            return ServerSetup(_port);
        }

        public bool ServerSetup(int port)
        {            
            try
            {
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                _serverSocket.Listen(port);
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            Client client = new Client();
            client.socket = _serverSocket.EndAccept(AR);
            ClientConnected(client);
            client.socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), client.socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            //receiving the bullshit            
            Socket socket = (Socket)AR.AsyncState;
            try
            {
                int received = socket.EndReceive(AR);   //!!!!!!!!!!!!!Exception to handle!!!!!!!!!!!!
                byte[] dataBuff = new byte[received];
                Array.Copy(_buffer, dataBuff, received);
                string text = Encoding.ASCII.GetString(dataBuff);
                if (!MessageReceived(text))
                {
                    //start receiving again
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                }               
            }
            catch (SocketException)
            {
            }
        }
        
    }
    
}
