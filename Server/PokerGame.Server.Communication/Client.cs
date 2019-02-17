using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using PokerGame.Common;

namespace PokerGame.Server.Communication
{
    public class Client
    {
        public Guid Id = Guid.NewGuid();
        public string Name = "Client";
        public Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Send(IMessage message)
        {
            byte[] _msg = Encoding.ASCII.GetBytes(message.ToString());
            socket.BeginSend(_msg, 0, _msg.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);          
        }

        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }       

        public void Release()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (SocketException) { }            
        }
    }
}
