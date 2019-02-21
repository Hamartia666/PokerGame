using PokerGame.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Client.Communication
{
    public class CommunicationHub
    {
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private bool _stop = false;
        private readonly IPAddress _serverAddress;
        private readonly int _port;

        public EventHandler OnConnect;
        public EventHandler<MessageEventArgs> OnMessageReceived;

        public CommunicationHub() : this(ConfigurationManager.AppSettings["ServerAddress"])
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["ServerPort"], out int port))
                port = 50000;
            _port = port;
        }

        public CommunicationHub(string ipAddress)
        {
            if (!IPAddress.TryParse(ipAddress, out IPAddress address))
                address = IPAddress.Loopback;
            _serverAddress = address;
        }

        private void Connected()
        {
            // Make sure someone is listening to event
            if (OnConnect == null) return;
            EventArgs args = new EventArgs();
            OnConnect(this, args);
        }

        private void MessageReceived(string text)
        {
            // Make sure someone is listening to event
            if (OnMessageReceived == null) return;
            MessageEventArgs args = new MessageEventArgs(text);
            OnMessageReceived(this, args);
        }

        public void Start()
        {
            LoopConnect();
            Task.Run(() => ReceiveLoop());
        }

        private void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(_serverAddress, _port);
                }
                catch (SocketException)
                {
                }                
            }
            Connected();
        }       

        public void Send(IMessage message)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message.ToString());
            _clientSocket.Send(buffer);
        }

        private void ReceiveLoop()
        {
            while (!_stop)
            {
                try
                {
                    byte[] receive_data = new byte[1024];
                    int rec = _clientSocket.Receive(receive_data);
                    byte[] data = new byte[rec];
                    Array.Copy(receive_data, data, rec);
                    MessageReceived(Encoding.ASCII.GetString(data));
                }
                catch (SocketException)
                {
                    Release();
                }
            }
        }

        public void Release()
        {
            try
            {
                if (_clientSocket == null)
                    return;
                _clientSocket.Shutdown(SocketShutdown.Both);
                _clientSocket.Close();
            }
            catch (SocketException)
            {

            }
        }
    }
}
