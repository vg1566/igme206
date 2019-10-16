using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class View
    {
        private static TextWriter writer = Console.Out;

        /// <summary>
        /// A text view. Note that this view class contains both the input 
        /// for a text adventure game as well as the text output.
        /// This class will add itself as an observer of the game
        /// messages in order to see when it should print out text.
        /// </summary>
        /// <param name="game">The logic for a game.</param>
        public View()
        {
                       
        }

        /// <summary>
        /// The observer function for the view. This method decides when to print
        /// out story information based on what is happening in the message list
        /// for the game.
        /// </summary>
        /// <param name="data"></param>
        public void update(string data)
        {
            writer.WriteLine(data + "\r\n");
        }

    }

}
