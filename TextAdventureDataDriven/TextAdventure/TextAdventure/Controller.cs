using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Controller
    {
        private static TextReader input = Console.In;
        public enum COMMAND { LOOK = 0, WEST = 1, EAST = 2, NORTH = 3, SOUTH = 4, ERROR=5, QUIT=6, COUGH=7, PONDEREXISTENCE=8 };

        /// <summary>
        /// When a command has been entered, this method handles it by placing all valid
        /// main commands into the message list for the game.
        /// </summary>
        public int handleCommand()
        {
            string command;
            int returnCommand = (int)COMMAND.ERROR;

            try
            {
                command = input.ReadLine();

                // try parsing it
                string msg = command.ToLower();
                switch (msg)
                {
                    case "look":
                        returnCommand = (int)COMMAND.LOOK;
                        break;
                    case "w":
                        returnCommand = (int)COMMAND.WEST;
                        break;
                    case "e":
                        returnCommand = (int)COMMAND.EAST;
                        break;
                    case "n":
                        returnCommand = (int)COMMAND.NORTH;
                        break;
                    case "s":
                        returnCommand = (int)COMMAND.SOUTH;
                        break;
                    case "q":
                        returnCommand = (int)COMMAND.QUIT;
                        break;
                    default:
                        returnCommand = (int)COMMAND.ERROR;
                        break;
                    case "cough":
                        returnCommand = (int)COMMAND.COUGH;
                        break;
                    case "ponder existence":
                        returnCommand = (int)COMMAND.PONDEREXISTENCE;
                        break;
                }
            }
            catch
            {
                returnCommand = (int)COMMAND.ERROR;
            }

            return returnCommand;

        }           
    }
}
