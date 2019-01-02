using PokerGame.Common;
using PokerGame.Server.Communication;
using System;

namespace PokerGame.Server.Application
{
    public interface IServerRoom
    {
        Guid Id { get; }
        bool SendMessage(IServerRoom room);
        bool SendMessage(Client client);
        void ReceiveMessage(IMessage message);
    }
}