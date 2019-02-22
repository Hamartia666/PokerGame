using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Server.Game
{
    public enum eGameState
    {
        preFlop,
        flop,
        turn,
        river,
        showdown,
        finish,
    }
}
