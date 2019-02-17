using PokerGame.Server.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Title = "Server";
            //create main server room
            var mainRoom = new MainRoom(new Output());
            //start listening
            mainRoom.StartServer(100);
            System.Console.ReadLine();
        }

        
    }
}
