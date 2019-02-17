using PokerGame.Common;
using PokerGame.Server.Communication;
using System;

namespace PokerGame.Server.Application
{
    public interface IServerRoom
    {
        Guid Id { get; }
        bool SendMessage();
        bool SendMessage(Client client);
        void ProcessMessage(IMessage message);
    }
}