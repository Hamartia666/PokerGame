using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client_Communication
{
    class Program
    {
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private static void LoopConnect()
        {
            int attempts = 0;
            while(!_clientSocket.Connected)
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

        private static void SendLoop()
        {
            while(true)
            {
                string msg = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(msg);
                _clientSocket.Send(buffer);
            }
            
        }

        private static void ReceiveLoop()
        {
            while (true)
            {
                byte[] receive_data = new byte[1024];
                int rec = _clientSocket.Receive(receive_data);
                byte[] data = new byte[rec];
                Array.Copy(receive_data, data, rec);
                Console.WriteLine("Received: " + Encoding.ASCII.GetString(data));
            }
        }

        public static void Main(String[] args)
        {
            Console.Title = "Client";
            LoopConnect();
            while(true)
            {
                List<Task> tasks = new List<Task>();
                tasks.Add(Task.Run(() => ReceiveLoop()));
                tasks.Add(Task.Run(() => SendLoop()));
                Task.WaitAll(tasks.ToArray());
                Console.Write("Continue?: ");
                Console.ReadLine();
            }
        }


    }
}
