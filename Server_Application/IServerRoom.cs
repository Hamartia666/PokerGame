using PokerGame.Common;
using PokerGame.Server.Communication;
using System;

namespace PokerGame.Server.Application
{
    public interface IServerRoom
    {
        Guid Id { get; }
        void SendMessage(IMessage message);
        void SendMessage(Client client, IMessage message);
        void ProcessMessage(IMessage message);
    }
}