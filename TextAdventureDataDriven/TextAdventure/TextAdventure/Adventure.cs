using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Adventure
    {
        static void Main(string[] args)
        {
            GameLogic theGame = new GameLogic();
            View view = new View();
            Controller control = new Controller();
            bool isDone = false;
            string response = "Type look to view a description of a room, q to quit, or n/s/e/w to move in that direction: ";
            while (!isDone)
            {
                view.update(response);
                int command = control.handleCommand();
                if (command == (int)Controller.COMMAND.QUIT)
                    isDone = true;
                else
                    response = theGame.update(command);
            } 
        }
    }
}
