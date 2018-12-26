using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Server_Communication
{
    class Program
    {
        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clientSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private static void ServerSetup()
        {
            Console.WriteLine("Setting up the Server...");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSocket.Listen(100);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = _serverSocket.EndAccept(AR);
            _clientSockets.Add(socket);
            Console.WriteLine("Client Connected");
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            //receiving the bullshit
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);   //!!!!!!!!!!!!!Exception to handle!!!!!!!!!!!!
            byte[] dataBuff = new byte[received];
            Array.Copy(_buffer, dataBuff, received);
            string text = Encoding.ASCII.GetString(dataBuff);
            Console.WriteLine("Text received: " + text);

            //throwing the bullshit back at the clients
            byte[] data = Encoding.ASCII.GetBytes(text);
            _clientSockets.ForEach((client) => { if (client != socket) { client.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), client); } });

            //start receiving again
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        }

        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        public static void Main(String[] args)
        {
            Console.Title = "Server";
            ServerSetup();
            Console.ReadLine();
        }
    }
    
}
