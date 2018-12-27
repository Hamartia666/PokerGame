using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client_Communication
{
    public class Communication
    {
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private bool _stop = false;
        public Communication()
        {
            LoopConnect();
            Task.Run(() => ReceiveLoop());
            Task.Run(() => SendLoop());
            while (!_stop)
            { }
        }

        private void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Loopback, 100);
                }
                catch (SocketException)
                {
                    Console.Clear();
                    Console.WriteLine("Connection Attempts: " + attempts.ToString());
                }
            }
            Console.WriteLine("Connected!");
        }

        private void SendLoop()
        {
            while (!_stop)
            {
                string msg = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(msg);
                _clientSocket.Send(buffer);
            }

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
                    if (Encoding.ASCII.GetString(data).Equals("/quit"))
                    {
                        _stop = true;
                        Release();
                    }

                    Console.WriteLine("Received: " + Encoding.ASCII.GetString(data));
                }
                catch (SocketException e)
                {
                    Release();
                }
            }
        }

        private void Release()
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
        }
    }
}
