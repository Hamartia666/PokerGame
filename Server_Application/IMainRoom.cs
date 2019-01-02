using PokerGame.Server.Communication;

namespace PokerGame.Server.Application
{
    internal interface IMainRoom
    {
        bool Connect(Client client);
        bool StartServer(int port);
    }
}