using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Server.Application
{
    public interface IOutput
    {
        void Write(string text);
    }
}
