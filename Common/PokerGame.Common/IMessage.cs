using PokerGame.Common;
using System;

namespace PokerGame.Common
{
    public interface IMessage
    {
        string Body { get; }
        eCommand Command { get; }
        Guid? ClientId { get; }
        Guid RoomId { get; }
    }
}