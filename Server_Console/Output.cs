using PokerGame.Server.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Server.Console
{
    public class Output : IOutput
    {
        public void Write(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
