using PokerGame.Common;
using PokerGame.Server.Communication;

namespace PokerGame.Server.Application
{
    internal interface IMainRoom
    {
        void Connect(object sender, ClientEventArgs args);
        void ReceiveMessage(object sender, MessageEventArgs args);
        bool StartServer(int port);
    }
}