using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    public class Rooms
    {
        public string currentRoom = "centerRoom";
        public string roomName;
        public string roomDescription;
        public string[] adjacentRooms;
        string[] nullRoomSet = { "none", "none", "none", "none" };

        public Rooms()
        {
            roomUpdate();
        }
        /// <summary>
        /// The logic for sorting the file into usable components
        /// </summary>
        public void roomUpdate()
        {
            string fileContent = "";
            try
            {
                FileStream file = new FileStream(currentRoom + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                file.Close();
                file = new FileStream(currentRoom + ".txt", FileMode.Open, FileAccess.Read);
                for (int i = 0; i < (int)file.Length; i++)
                {
                    fileContent = fileContent + (char)file.ReadByte();
                }
                file.Close();
                string[] fileParts = fileContent.Split('|');
                if (fileParts.Length == 3)
                {
                    roomName = fileParts[0];
                    roomDescription = fileParts[1];
                    adjacentRooms = fileParts[2].Split('*');
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            catch (ApplicationException ex)
            {
                roomName = "error";
                roomDescription = "error";
                adjacentRooms =  nullRoomSet;
                Console.WriteLine("Error: " + currentRoom + " file not found.");
            }
        }
    }
}
