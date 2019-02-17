using PokerGame.Common;
using System;
using System.Collections.Generic;
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
        private IPAddress serverAddress = IPAddress.Loopback;

        public EventHandler OnConnect;
        public EventHandler<MessageEventArgs> OnMessageReceived;

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

        public CommunicationHub() { }

        public CommunicationHub(string ipAddress)
        {
            serverAddress = IPAddress.Parse(ipAddress);
        }

        private void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(serverAddress, 100);
                }
                catch (SocketException)
                {
                    Console.Clear();
                    Console.WriteLine("Connection Attempts: " + attempts.ToString());
                }
            }
            Connected();
        }

        public void SendText(string textToSend)
        {
            byte[] buffer = Encoding.ASCII.GetBytes("t|"+textToSend);
            _clientSocket.Send(buffer);
        }

        public void Send(string textToSend)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(textToSend);
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
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
        }
    }
}
