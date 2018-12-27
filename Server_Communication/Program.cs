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
        private static List<Client> _clientSockets = new List<Client>();
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
            Client client = new Client();
            client.socket = _serverSocket.EndAccept(AR);
            _clientSockets.Add(client);
            client.name = "Client" + (_clientSockets.IndexOf(client) + 1);
            string connect = client.name + " Connected";
            Console.WriteLine(client.name + " Connected");
            byte[] conn = Encoding.ASCII.GetBytes(connect);
            client.socket.BeginSend(conn, 0, conn.Length, SocketFlags.None, new AsyncCallback(SendCallback), client.socket);
            client.socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), client.socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            //receiving the bullshit            
            Socket socket = (Socket)AR.AsyncState;
            try
            {
                int received = socket.EndReceive(AR);   //!!!!!!!!!!!!!Exception to handle!!!!!!!!!!!!
                byte[] dataBuff = new byte[received];
                Array.Copy(_buffer, dataBuff, received);
                string text = Encoding.ASCII.GetString(dataBuff);
                Console.WriteLine("Text received: " + text);

                if(text.Contains("/"))
                {
                    string[] command = text.Split(' ');
                    string cmd = command[0];
                    switch (cmd)
                    {
                        case "/help":
                            string send_help = "/name (name) - change your name \n" + "/quit - disconnect from server \n" + "/list - get all clients list \n" + "*(user name) (text) - write a message to a specific user ";
                            byte[] help = Encoding.ASCII.GetBytes(send_help);
                            socket.BeginSend(help, 0, help.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                            break;
                        case "/name":
                            _clientSockets.Find(x => x.socket == socket).name = command[1];
                            break;
                        case "/list":
                            foreach (Client e in _clientSockets)
                            {
                                string client_name = e.name;
                                byte[] name = Encoding.ASCII.GetBytes(client_name);
                                socket.BeginSend(name, 0, name.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                            }
                            break;
                        case "/quit":
                            string quit = "/quit";
                            byte[] _quit = Encoding.ASCII.GetBytes(quit);
                            socket.BeginSend(_quit, 0, _quit.Length, SocketFlags.None, new AsyncCallback(SendCallbackQuit), socket);
                            break;
                        default:
                            string no_cmd = "There are no commands like this!";
                            byte[] no_Cmd = Encoding.ASCII.GetBytes(no_cmd);
                            socket.BeginSend(no_Cmd, 0, no_Cmd.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                            break;
                    }
                }
                else if (text.Contains("*"))
                {
                    string[] full_text = text.Split(' ');
                    string name = full_text[0].Remove(0, 1);
                    full_text[0] = _clientSockets.Find(x => x.socket == socket).name + " (private):";
                    string msg = String.Join(" ", full_text);
                    byte[] _msg = Encoding.ASCII.GetBytes(msg);
                    Socket receiver = _clientSockets.Find(x => x.name == name).socket;
                    receiver.BeginSend(_msg, 0, _msg.Length, SocketFlags.None, new AsyncCallback(SendCallback), receiver);
                }
                else
                {
                    //throwing the bullshit back at the clients
                    byte[] data = Encoding.ASCII.GetBytes(text);
                    _clientSockets.ForEach((client) => { if (client.socket != socket) { client.socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), client.socket); } });
                }
                if (!text.Equals("/quit"))
                {
                    //start receiving again
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                }
                

            }
            catch (SocketException ex)
            {
                Release(socket);
            }
        }

        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);            
        }

        private static void SendCallbackQuit(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
            Release(socket);
        }

        private static void Release(Socket client)
        {
            try
            {
                string clientName = _clientSockets.Find(x => x.socket == client).name.ToString();
                _clientSockets.Remove(_clientSockets.Find(x => x.socket == client));
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                Console.WriteLine(clientName + " has Disconnected");
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void Main(String[] args)
        {
            Console.Title = "Server";
            ServerSetup();
            Console.ReadLine();
        }
    }
    
}
