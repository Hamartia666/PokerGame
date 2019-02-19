using PokerGame.Common;

namespace PokerGame.Client.Forms
{
    internal interface IProcessMessage
    {
        void ProcessMessage(IMessage msg);
    }
}