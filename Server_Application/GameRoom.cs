using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerGame.Common;
using PokerGame.Server.Communication;
using PokerGame.Server.Console;
using PokerGame.Server.Game;

namespace PokerGame.Server.Application
{
    public class GameRoom : RoomBase
    {
        private GameEngine _gameEngine;

        public GameRoom(IOutput output) : base(output)
        {            
        }

        public override void ProcessMessage(IMessage message)
        {
            throw new NotImplementedException();
        }        
    }
}
