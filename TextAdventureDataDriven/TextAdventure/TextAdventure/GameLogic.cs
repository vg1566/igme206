using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class GameLogic
    {
        string letterSequence = "";
        int existentialDreadLimit = 5;
        Rooms rooms = new Rooms();
        /// <summary>
        /// The logic for how to move around in a text adventure.
        /// </summary>
        /// <param name="command">The integer command given by the user.</param>
        public string update(int command)
        {
            StringBuilder finalResponse = new StringBuilder("");
            switch (command)
            {
                case (int)Controller.COMMAND.ERROR:
                    finalResponse.Append("Error with last command. \r\n");
                    break;
                case (int)Controller.COMMAND.WEST:
                    if(rooms.adjacentRooms[3] == "none")
                    {
                        finalResponse.Append("There's no door in that direction. \r\n");
                    }
                    else
                    {
                        rooms.currentRoom = rooms.adjacentRooms[3];
                        rooms.roomUpdate();
                        if (letterSequence == "ne")
                        {
                            letterSequence = "new";
                        }
                        else
                        {
                            letterSequence = "";
                        }
                        finalResponse.Append("You are now in the " + rooms.roomName + ". \r\n");
                    }
                    break;
                case (int)Controller.COMMAND.EAST:
                    if (rooms.adjacentRooms[2] == "none")
                    {
                        finalResponse.Append("There's no door in that direction. \r\n");
                    }
                    else
                    {
                        rooms.currentRoom = rooms.adjacentRooms[2];
                        rooms.roomUpdate();
                        if(letterSequence == "n")
                        {
                            letterSequence = "ne";
                        }
                        else
                        {
                            letterSequence = "";
                        }
                        finalResponse.Append("You are now in the " + rooms.roomName + ". \r\n");
                    }
                    break;
                case (int)Controller.COMMAND.NORTH:
                    if (rooms.adjacentRooms[0] == "none")
                    {
                        finalResponse.Append("There's no door in that direction. \r\n");
                    }
                    else
                    {
                        rooms.currentRoom = rooms.adjacentRooms[0];
                        rooms.roomUpdate();
                        letterSequence = "n";
                        finalResponse.Append("You are now in the " + rooms.roomName + ". \r\n");
                    }
                    break;
                case (int)Controller.COMMAND.SOUTH:
                    if (rooms.adjacentRooms[1] == "none")
                    {
                        finalResponse.Append("There's no door in that direction. \r\n");
                    }
                    else
                    {
                        rooms.currentRoom = rooms.adjacentRooms[1];
                        rooms.roomUpdate();
                        if(letterSequence == "new")
                        {
                            finalResponse.Append("Before you can go to the " + rooms.roomName + ", you notice a newspaper on the ground. The headline reads, 'A Winner is You! How Uncreative Gamemakers Result in Games with Virtually No Content Besides Several Empty Rooms.' \r\nThat's a long headline, you think. Then you think, wait, this can't be all there is to the game, right? \r\nWrong, this is the end. \r\n[Ending Unlocked: Read the News] \r\nPress 'q' to quit the game. \r\n");
                        }
                        else
                        {
                            letterSequence = "";
                            finalResponse.Append("You are now in the " + rooms.roomName + ". \r\n");
                        }
                    }
                    break;
                case (int)Controller.COMMAND.LOOK:
                    finalResponse.Append(rooms.roomDescription + " \r\n");
                    break;
                case (int)Controller.COMMAND.COUGH:
                    finalResponse.Append("You cough. \r\n");
                    break;
                case (int)Controller.COMMAND.PONDEREXISTENCE:
                    switch(existentialDreadLimit)
                    {
                        case 5:
                            finalResponse.Append("You think about existence for a while. \r\n");
                            existentialDreadLimit--;
                            break;
                        case 4:
                            finalResponse.Append("You think about what it means to be alive. It's sort of depressing, because you can't remember doing anything worthwhile with your life. \r\n");
                            existentialDreadLimit--;
                            break;
                        case 3:
                            finalResponse.Append("Actually, you can't remember much of anything about your life. Did you even have one at all? Before you came here... How did you get here, anyways? Come to think of it, you don't remember stepping into this building at all. You really don't even remember... \r\nYour name. Do you even have a name? You must, right? Yes, you think. Everyone has a name. So why is it so hard to remember yours? How can you be sure you've lived at all if you can't remember a thing? \r\nYou try to recall the faces of your loved ones. \r\nYou fail. \r\n");
                            existentialDreadLimit--;
                            break;
                        case 2:
                            finalResponse.Append("Your ears are ringing. What does it mean? Is it possible you never had an existence at all before being brought to this place? You don't know anything about the outside world. You don't even know how to get there. \r\nAs your thoughts spin, you recall a single memory from the very first moment you got here, before you had so much as looked around: \r\n'Type look to view a description of a room, q to quit, or n/s/e/w to move in that direction:' \r\n");
                            existentialDreadLimit--;
                            break;
                        case 1:
                            finalResponse.Append("[Ending Get: Puppetmaster] \r\nYou feel sick. \r\n");
                            existentialDreadLimit--;
                            break;
                        default:
                            finalResponse.Append("Please don't press q. \r\n");
                            break;
                    }
                    break;
                default:
                    break;
            }

            finalResponse.Append("Please enter next command : ");
            return finalResponse.ToString();
        }
                      
    }
}