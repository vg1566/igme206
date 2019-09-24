using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericForestAdventure
{
    class Program
    {
        public class Keyword
        {
            public string name = "null";
            public Keyword(string n)
            {
                name = n;
            }
            public bool destroyed = false;
            public bool wary = false;
        }
        public class Item : Keyword
        {
            public Item(string n) : base(n)
            {
                name = n;
            }
            public bool inInventory = false;
            public bool equipped = false;
            public bool rusted = false;
            public bool full = false;
        }
        public class Room
        {
            public int x;
            public int y;
            public bool currentlyOccupied = false;
            public string roomDescription;
        }
        public class CenterRoom : Room
        {
            public CenterRoom()
            {
                x = 0;
                y = 0;
                currentlyOccupied = true;
                roomDescription = "You are standing in a forest clearing with a DAIS and a SWORD stuck in said DAIS.";
            }
        }
        public class WestRoom : Room
        {
            public WestRoom()
            {
                x = -1;
                y = 0;
                currentlyOccupied = true;
                roomDescription = "You are standing in a forest clearing with a MERCHANT manning a table full of wares.";
            }
        }
        public class EastRoom : Room
        {
            public EastRoom()
            {
                x = 1;
                y = 0;
                currentlyOccupied = true;
                roomDescription = "You are standing in a house with not much in it, aside from a couple of things on the shelves, a spray BOTTLE of white vinegar and an empty PITCHER.";
            }
        }
        public class NorthRoom : Room
        {
            public NorthRoom()
            {
                x = 0;
                y = 1;
                currentlyOccupied = true;
                roomDescription = "You are standing in a forest clearing with a STATUE wearing ROBES and a CROWN.";
            }
        }
        public class SouthRoom : Room
        {
            public SouthRoom()
            {
                x = 0;
                y = -1;
                currentlyOccupied = true;
                roomDescription = "You are standing in a forest clearing. You are surrounded by FLOWER plants.";
            }
        }
        public class GameLogic
        {
            private static GameLogic gameLogic = new GameLogic();
            public Room centerRoom = new CenterRoom();
            public Room northRoom = new NorthRoom();
            public Room southRoom = new SouthRoom();
            public Room eastRoom = new EastRoom();
            public Room westRoom = new WestRoom();
            public Item sword = new Item("sword");
            public Item crown = new Item("crown");
            public Item robes = new Item("robes");
            public Item duncecap = new Item("duncecap");
            public Item flowers = new Item("flowers");
            public Item polish = new Item("polish");
            public Item pitcher = new Item("pitcher");
            public Item bottle = new Item("bottle");
            public Item[] inventory = new Item[8];
            public Keyword dais = new Keyword("dais");
            public Keyword merchant = new Keyword("merchant");
            public Keyword statue = new Keyword("statue");
            public Keyword[] keywordList = new Keyword[3];
            public int[] coordinates = { 0, 0 };
            public string updateLocation(int[] coords)
            {
                if (coords[0] == 0)
                {
                    if (coords[1] == 0)
                    {
                        return "center";
                    }
                    else if (coords[1] == 1)
                    {
                        return "east";
                    }
                    else if (coords[1] == -1)
                    {
                        return "west";
                    }
                }
                else if (coords[0] == 1)
                {
                    return "north";
                }
                else if (coords[0] == -1)
                {
                    return "south";
                }
                return "error";
            }
            public void inventorySetup()
            {
                inventory[0] = sword;
                inventory[1] = crown;
                inventory[2] = robes;
                inventory[3] = duncecap;
                inventory[4] = flowers;
                inventory[5] = polish;
                inventory[6] = pitcher;
                inventory[7] = bottle;
                keywordList[0] = dais;
                keywordList[1] = merchant;
                keywordList[2] = statue;
                crown.rusted = true;
                sword.rusted = true;

            }
            public string parseCommand(string input)
            {
                char space = ' ';
                input = input.ToLower();
                string[] words = input.Split(space);
                string location = "";
                location = updateLocation(coordinates);
                string returnPhrase = "null null null";
                if (words.Length > 2)
                {
                    returnPhrase = "null null long";
                }
                else if (words.Length < 1)
                {
                    returnPhrase = "null null null";
                }
                else if (words[0] == "look")
                {
                    if (words.Length == 1)
                    {
                        returnPhrase = "look around " + location;
                    }
                    else if (words[1] == "around")
                    {
                        returnPhrase = "look around " + location;
                    }
                    else if (words[1] == "sword")
                    {
                        if (location == "center" || sword.inInventory == true)
                        {
                            returnPhrase = "look sword succeed";
                        }
                        else
                        {
                            returnPhrase = "look sword fail";
                        }
                    }
                    else if (words[1] == "crown")
                    {
                        if (location == "north" || crown.inInventory == true)
                        {
                            returnPhrase = "look crown succeed";
                        }
                        else
                        {
                            returnPhrase = "look crown fail";
                        }
                    }
                    else if (words[1] == "duncecap")
                    {
                        if (location == "north" || duncecap.inInventory == true)
                        {
                            returnPhrase = "look duncecap succeed";
                        }
                        else
                        {
                            returnPhrase = "look duncecap fail";
                        }
                    }
                    else if (words[1] == "robes")
                    {
                        if (location == "north" || robes.inInventory == true)
                        {
                            returnPhrase = "look robes succeed";
                        }
                        else
                        {
                            returnPhrase = "look robes fail";
                        }
                    }
                    else if (words[1] == "flowers")
                    {
                        if (flowers.inInventory == true)
                        {
                            returnPhrase = "look flowers bouquet";
                        }
                        else if (location == "south")
                        {
                            returnPhrase = "look flowers succeed";
                        }
                        else
                        {
                            returnPhrase = "look flowers fail";
                        }
                    }
                    else if (words[1] == "polish")
                    {
                        if (location == "west" || polish.inInventory == true)
                        {
                            returnPhrase = "look polish succeed";
                        }
                        else
                        {
                            returnPhrase = "look polish fail";
                        }
                    }
                    else if (words[1] == "pitcher")
                    {
                        if (location == "east" || pitcher.inInventory == true)
                        {
                            returnPhrase = "look pitcher succeed";
                        }
                        else
                        {
                            returnPhrase = "look pitcher fail";
                        }
                    }
                    else if (words[1] == "bottle")
                    {
                        if (location == "east" || bottle.inInventory == true)
                        {
                            returnPhrase = "look bottle succeed";
                        }
                        else
                        {
                            returnPhrase = "look bottle fail";
                        }
                    }
                    else if (words[1] == "statue")
                    {
                        if (location == "north")
                        {
                            returnPhrase = "look statue succeed";
                        }
                        else
                        {
                            returnPhrase = "look statue fail";
                        }
                    }
                    else if (words[1] == "dais")
                    {
                        if (location == "center")
                        {
                            returnPhrase = "look dais succeed";
                        }
                        else
                        {
                            returnPhrase = "look dais fail";
                        }
                    }
                    else if (words[1] == "merchant")
                    {
                        returnPhrase = "look merchant success";
                    }
                    else if (words[1] == "inventory")
                    {
                        returnPhrase = "look inventory success";
                    }
                }
                else if (words[0] == "equip")
                {
                    if (words.Length == 1)
                    {
                        returnPhrase = "equip null null";
                    }
                    else if (words[1] == "sword")
                    {
                        if (location == "center" && (crown.equipped || duncecap.equipped))
                        {
                            sword.inInventory = true;
                            sword.equipped = true;
                            returnPhrase = "equip sword success";
                        }
                        else if (location == "center")
                        {
                            returnPhrase = "equip sword unworthy";
                        }
                        else
                        {
                            returnPhrase = "equip sword fail";
                        }
                    }
                    else if (words[1] == "crown")
                    {
                        if (crown.equipped)
                        {
                            returnPhrase = "equip crown repeat";
                        }
                        else if (location == "north")
                        {
                            if (statue.destroyed)
                            {
                                returnPhrase = "equip crown dent";
                            }
                            else if (crown.rusted)
                            {
                                returnPhrase = "equip crown rust";
                            }
                            else
                            {
                                returnPhrase = "equip crown success";
                                crown.inInventory = true;
                                crown.equipped = true;
                            }
                        }
                        else
                        {
                            returnPhrase = "equip crown fail";
                        }
                    }
                    else if (words[1] == "duncecap")
                    {
                        if (location == "north" && keywordList[2].destroyed)
                        {
                            if (inventory[3].inInventory)
                            {
                                returnPhrase = "equip duncecap repeat";
                            }
                            else
                            {
                                duncecap.equipped = true;
                                duncecap.inInventory = true;
                                returnPhrase = "equip duncecap success";
                            }
                        }
                        else
                        {
                            returnPhrase = "equip duncecap fail";
                        }
                    }
                    else if (words[1] == "robes")
                    {
                        if (location == "north" && statue.destroyed)
                        {
                            returnPhrase = "equip robes torn";
                        }
                        else if (location == "north" && !robes.equipped)
                        {
                            robes.inInventory = true;
                            robes.equipped = true;
                            returnPhrase = "equip robes success";
                        }
                        else if (robes.equipped)
                        {
                            returnPhrase = "equip robes repeat";
                        }
                        else
                        {
                            returnPhrase = "equip robes fail";
                        }
                    }
                    else if (words[1] == "flowers")
                    {
                        if (location == "south" && !flowers.equipped)
                        {
                            flowers.inInventory = true;
                            flowers.equipped = true;
                            returnPhrase = "equip flowers success";
                        }
                        else if (flowers.equipped)
                        {
                            returnPhrase = "equip flowers repeat";
                        }
                        else
                        {
                            returnPhrase = "equip flowers fail";
                        }
                    }
                    else if (words[1] == "polish")
                    {
                        Console.WriteLine(location + polish.inInventory);
                        if (location == "west" && !polish.inInventory)
                        {
                            if (merchant.destroyed)
                            {
                                returnPhrase = "equip polish murder";
                                polish.inInventory = true;
                            }
                            else
                            {
                                returnPhrase = "equip polish thief";
                            }
                        }
                        else if (polish.inInventory)
                        {
                            returnPhrase = "equip polish inventory";
                        }
                        else
                        {
                            returnPhrase = "equip polish fail";
                        }
                    }
                    else if (words[1] == "pitcher")
                    {
                        if (location == "east" && !pitcher.inInventory)
                        {
                            pitcher.inInventory = true;
                            returnPhrase = "equip pitcher success";
                        }
                        else if (pitcher.inInventory)
                        {
                            returnPhrase = "equip pitcher inventory";
                        }
                        else
                        {
                            returnPhrase = "equip pitcher fail";
                        }
                    }
                    else if (words[1] == "bottle")
                    {
                        if (location == "east" && !bottle.inInventory)
                        {
                            bottle.inInventory = true;
                            returnPhrase = "equip bottle success";
                        }
                        else if (bottle.inInventory)
                        {
                            returnPhrase = "equip bottle inventory";
                        }
                        else
                        {
                            returnPhrase = "equip bottle fail";
                        }
                    }
                    else if (words[1] == "statue")
                    {
                        if (location == "north" && !crown.inInventory && !robes.inInventory)
                        {
                            keywordList[2].destroyed = true;
                            returnPhrase = "equip statue success";
                        }
                        else if (location == "north" && (crown.inInventory || robes.inInventory))
                        {
                            returnPhrase = "equip statue attempt";
                        }
                        else
                        {
                            returnPhrase = "equip statue fail";
                        }
                    }
                    else if (words[1] == "dais")
                    {
                        if (location == "center")
                        {
                            returnPhrase = "equip dais success";
                        }
                        {
                            returnPhrase = "equip dais fail";
                        }
                    }
                    else if (words[1] == "inventory")
                    {
                        returnPhrase = "equip inventory success";
                    }
                }
                else if (words[0] == "stab")
                {
                    if (words.Length == 1)
                    {
                        returnPhrase = "stab null null";
                    }
                    else if (!sword.inInventory)
                    {
                        returnPhrase = "stab null fail";
                    }
                    else if (words[1] == "sword")
                    {
                        returnPhrase = "stab sword success";
                    }
                    else if (words[1] == "crown")
                    {
                        if (location == "north" || crown.inInventory)
                        {
                            returnPhrase = "stab crown success";
                        }
                        else
                        {
                            returnPhrase = "stab crown missing";
                        }
                    }
                    else if (words[1] == "duncecap")
                    {
                        if ((location == "north" && statue.destroyed) || duncecap.inInventory)
                        {
                            returnPhrase = "stab duncecap success";
                        }
                        else
                        {
                            returnPhrase = "stab duncecap missing";
                        }
                    }
                    else if (words[1] == "robes")
                    {
                        if (location == "north" || robes.inInventory)
                        {
                            returnPhrase = "stab robes success";
                        }
                        else
                        {
                            returnPhrase = "stab robes missing";
                        }
                    }
                    else if (words[1] == "flowers")
                    {
                        if (location == "south" || flowers.inInventory)
                        {
                            returnPhrase = "stab flowers success";
                        }
                        else
                        {
                            returnPhrase = "stab flowers missing";
                        }
                    }
                    else if (words[1] == "polish")
                    {
                        if (polish.inInventory)
                        {
                            returnPhrase = "stab polish success";
                        }
                        else if (location == "west")
                        {
                            returnPhrase = "stab polish thief";
                        }
                        else
                        {
                            returnPhrase = "stab polish missing";
                        }
                    }
                    else if (words[1] == "pitcher")
                    {
                        if (location == "east" || pitcher.inInventory)
                        {
                            returnPhrase = "stab pitcher success";
                        }
                        else
                        {
                            returnPhrase = "stab pitcher missing";
                        }
                    }
                    else if (words[1] == "bottle")
                    {
                        if (location == "east" || bottle.inInventory)
                        {
                            returnPhrase = "stab bottle success";
                        }
                        else
                        {
                            returnPhrase = "stab bottle missing";
                        }
                    }
                    else if (words[1] == "statue")
                    {
                        if (location == "north")
                        {
                            returnPhrase = "stab statue success";
                        }
                        else
                        {
                            returnPhrase = "stab statue missing";
                        }
                    }
                    else if (words[1] == "dais")
                    {
                        if (location == "center")
                        {
                            returnPhrase = "stab dais success";
                        }
                        else
                        {
                            returnPhrase = "stab dais missing";
                        }
                    }
                    else if (words[1] == "inventory")
                    {
                        returnPhrase = "stab inventory success";
                    }
                    else if (words[1] == "merchant")
                    {
                        if (location == "west")
                        {
                            if (keywordList[1].destroyed)
                            {
                                returnPhrase = "stab merchant repeat";
                            }
                            else if (pitcher.inInventory && !pitcher.full)
                            {
                                merchant.destroyed = true;
                                pitcher.full = true;
                                returnPhrase = "stab merchant fill";
                            }
                            else
                            {
                                merchant.destroyed = true;
                                returnPhrase = "stab merchant success";
                            }
                        }
                        else
                        {
                            returnPhrase = "stab merchant missing";
                        }
                    }
                }
                else if (words[0] == "spray")
                {
                    if (words.Length == 1)
                    {
                        returnPhrase = "spray null null";
                    }
                    else if (!bottle.inInventory)
                    {
                        returnPhrase = "spray null missing";
                    }
                    else if (words[1] == "sword")
                    {
                        if (location == "center" || sword.inInventory)
                        {
                            if (sword.rusted)
                            {
                                returnPhrase = "spray sword repeat";
                            }
                            else
                            {
                                returnPhrase = "spray sword success";
                                sword.rusted = true;
                            }
                        }
                        else
                        {
                            returnPhrase = "spray sword fail";
                        }
                    }
                    else if (words[1] == "crown")
                    {
                        if (location == "north" || crown.inInventory)
                        {
                            if (sword.rusted)
                            {
                                returnPhrase = "spray crown repeat";
                            }
                            else
                            {
                                returnPhrase = "spray crown success";
                                sword.rusted = true;
                            }
                        }
                        else
                        {
                            returnPhrase = "spray crown fail";
                        }
                    }
                    else if (words[1] == "duncecap")
                    {
                        if ((location == "north" && statue.destroyed) || duncecap.inInventory)
                        {
                            returnPhrase = "spray duncecap success";
                        }
                        else
                        {
                            returnPhrase = "spray duncecap fail";
                        }
                    }
                    else if (words[1] == "robes")
                    {
                        if (location == "north" || robes.inInventory)
                        {
                            returnPhrase = "spray robes success";
                        }
                        else
                        {
                            returnPhrase = "spray robes fail";
                        }
                    }
                    else if (words[1] == "flowers")
                    {
                        if (location == "south" || flowers.inInventory)
                        {
                            returnPhrase = "spray flowers success";
                        }
                        else
                        {
                            returnPhrase = "spray flowers fail";
                        }
                    }
                    else if (words[1] == "polish")
                    {
                        if (polish.inInventory)
                        {
                            returnPhrase = "spray polish success";
                        }
                        else if (location == "west")
                        {
                            if(merchant.destroyed)
                            {
                                returnPhrase = "spray polish murder";
                            }
                            else
                            {
                                returnPhrase = "spray polish thief";
                            }
                        }
                        else
                        {
                            returnPhrase = "spray polish fail";
                        }
                    }
                    else if (words[1] == "pitcher")
                    {
                        if (location == "east" || pitcher.inInventory)
                        {
                            returnPhrase = "spray pitcher success";
                        }
                        else
                        {
                            returnPhrase = "spray pitcher fail";
                        }
                    }
                    else if (words[1] == "bottle")
                    {
                        if (location == "east" || bottle.inInventory)
                        {
                            returnPhrase = "spray bottle success";
                        }
                        else
                        {
                            returnPhrase = "spray bottle fail";
                        }
                    }
                    else if (words[1] == "statue")
                    {
                        if (location == "north")
                        {
                            if(statue.destroyed)
                            {
                                returnPhrase = "spray statue broken";
                            }
                            else
                            {
                                returnPhrase = "spray statue success";
                            }
                        }
                        else
                        {
                            returnPhrase = "spray statue fail";
                        }
                    }
                    else if (words[1] == "dais")
                    {
                        if (location == "center")
                        {
                            returnPhrase = "spray dais success";
                        }
                        else
                        {
                            returnPhrase = "spray dais fail";
                        }
                    }
                    else if (words[1] == "inventory")
                    {
                        returnPhrase = "spray inventory success";
                    }
                }
                else if (words[0] == "behold")
                {
                    if (words[1] == "robes")
                    {
                        if (location == "north" || robes.inInventory)
                        {
                            returnPhrase = "behold robes success";
                        }
                        else
                        {
                            returnPhrase = "behold robes fail";
                        }
                    }
                    else
                    {
                        returnPhrase = "behold behold null";
                    }
                }
                else if (words[0] == "charm")
                {
                    if (words[1] == "merchant")
                    {
                        if (location == "west")
                        {
                            if (merchant.destroyed)
                            {
                                returnPhrase = "charm merchant murder";
                            }
                            else
                            {
                                if (merchant.wary)
                                {
                                    returnPhrase = "charm merchant repeat";
                                }
                                else if (flowers.equipped)
                                {
                                    returnPhrase = "charm merchant success";
                                    polish.inInventory = true;
                                    merchant.wary = true;
                                }
                                else
                                {
                                    returnPhrase = "charm merchant missing";
                                }
                            }
                        }
                        else
                        {
                            returnPhrase = "charm fail null";
                        }
                    }
                    else
                    {
                        returnPhrase = "charm item fail";
                    }
                }
                else if (words[0] == "pour")
                {
                    if (words[1] == "pitcher")
                    {
                        if (pitcher.full)
                        {
                            if (location == "center")
                            {
                                returnPhrase = "pour pitcher success";
                            }
                            else
                            {
                                returnPhrase = "pour pitcher fail";
                            }
                        }
                        else
                        {
                            returnPhrase = "pour pitcher empty";
                        }
                    }
                    else 
                    {
                        returnPhrase = "pour fail fail";
                    }
                }
                else if (words[0] == "polish")
                {
                    if (words.Length == 1)
                    {
                        returnPhrase = "polish null null";
                    }
                    else if (!polish.inInventory)
                    {
                        returnPhrase = "polish missing null";
                    }
                    else if (words[1] == "sword")
                    {
                        if (sword.inInventory)
                        {
                            if (sword.rusted)
                            {
                                sword.rusted = false;
                                if (pitcher.inInventory && !pitcher.full)
                                {
                                    pitcher.full = true;
                                    returnPhrase = "polish sword full";
                                }
                                else
                                {
                                    returnPhrase = "polish sword success";
                                }
                            }
                            else
                            {
                                returnPhrase = "polish sword clean";
                            }
                        }
                        else if (location == "center")
                        {
                            returnPhrase = "polish sword stuck";
                        }
                        else
                        {
                            returnPhrase = "polish sword fail";
                        }
                    }
                    else if (words[1] == "crown")
                    {
                        if (crown.inInventory)
                        {
                            if (crown.rusted)
                            {
                                crown.rusted = false;
                                returnPhrase = "polish crown success";
                            }
                            else
                            {
                                returnPhrase = "polish crown repeat";
                            }
                        }
                        else if (location == "north")
                        {
                            crown.rusted = false;
                            returnPhrase = "polish crown free";
                        }
                        else
                        {
                            returnPhrase = "polish crown fail";
                        }
                    }
                    else
                    {
                        returnPhrase = "polish fail null";
                    }
                }
                else if (words[0] == "n")
                {
                    if (coordinates[0] < 1 && coordinates[1] == 0)
                    {
                        coordinates[0] = coordinates[0] + 1;

                        returnPhrase = "n null succeed";
                    }
                    else
                    {
                        if (location == "east")
                        {
                            returnPhrase = "n house fail";
                        }
                        else
                        {
                            returnPhrase = "n tree fail";
                        }
                    }
                }
                else if (words[0] == "s")
                {
                    if (coordinates[0] > -1 && coordinates[1] == 0)
                    {
                        coordinates[0] = coordinates[0] - 1;

                        returnPhrase = "s null succeed";
                    }
                    else
                    {
                        if (location == "east")
                        {
                            returnPhrase = "s house fail";
                        }
                        else
                        {
                            returnPhrase = "s tree fail";
                        }
                    }
                }
                else if (words[0] == "e")
                {
                    if (coordinates[1] < 1 && coordinates[0] == 0)
                    {
                        coordinates[1] = coordinates[1] + 1;

                        returnPhrase = "e null succeed";
                    }
                    else
                    {
                        if (location == "east")
                        {
                            returnPhrase = "e house fail";
                        }
                        else
                        {
                            returnPhrase = "e tree fail";
                        }
                    }
                }
                else if (words[0] == "w")
                {
                    if (coordinates[1] > -1 && coordinates[0] == 0)
                    {
                        coordinates[1] = coordinates[1] - 1;
                        if (merchant.destroyed && !pitcher.full)
                        {
                            pitcher.full = true;
                            returnPhrase = "w fill succeed";
                        }
                        else
                        {
                            returnPhrase = "w null succeed";
                        }
                    }
                    else
                    {
                        returnPhrase = "w tree fail";
                    }
                }
                //Console.WriteLine(coordinates[0] + ", " + coordinates[1]);
                return returnPhrase;
            }
        }
        public class Controller
        {
            public string getName()
            {
                string name = Console.ReadLine();
                return name;
            }
            public string nextCommand()
            {
                string command = Console.ReadLine();
                return command;
            }
        }
        public class View
        {
            public void Intro1()
            {
                Console.WriteLine("A young man stands alone in a forest. Although it has been many years since he was first brought into this world, it is only now that he will be given a name.");
                Console.WriteLine("What is this man's name?");
            }
            public void Intro2(string name)
            {
                Console.WriteLine("Your name is " + name + ". ");
                Console.WriteLine("You have a variety of interests, such as reading, listening to music, metal maintenance, and entering portals of questionable origin. It is that last interest which is likely responsible for your current predicament, being stuck in this aforementioned forest.");
                Console.WriteLine("What will you do? (Hint: LOOK around)");
            }
            public void ReadCommand(string input, Item[] inventory, Keyword[] keywordList)
            {
                char space = ' ';
                input = input.ToLower();
                string[] words = input.Split(space);
                bool skip = false;
                if (words[0] == "look")
                {
                    if (words[2] == "fail")
                    {
                        Console.WriteLine("You can't LOOK at the " + words[1].ToUpper() + " if you're not nearby.");
                    }
                    if (words[1] == "around")
                    {
                        Console.WriteLine("You LOOK around the area.");
                        if (words[2] == "center")
                        {
                            Console.WriteLine("You are currently in a forest clearing with a raised DAIS in the center.");
                            skip = false;
                            for (int i = 0; i < 8; i++)
                            {
                                if (inventory[i].name == "sword" && inventory[i].inInventory)
                                {
                                    skip = true;
                                    Console.WriteLine("There is a DIVOT in the DAIS where a SWORD used to be. If you listen closely, you can hear a sort of faint whisper.");
                                    Console.WriteLine("Maybe if you were a bit closer to it, you could make out what it's saying.");
                                }
                            }
                            if (skip == false)
                            {
                                Console.WriteLine("There is a SWORD sticking out of the DAIS. Pulling on it does nothing.");
                            }
                            Console.WriteLine("There is some writing on the DAIS, but you're not LOOKing closely enough at it to read it.");
                            Console.WriteLine("To the north, south, and west, there are more forest clearings, and to the east, there's a house.");
                        }
                        else if (words[2] == "west")
                        {
                            Console.WriteLine("You are currently in a clearing west of where you started.");
                            if (keywordList[1].destroyed)
                            {
                                Console.WriteLine("The body of the poor, helpless, innocent MERCHANT you killed lies here.");
                                Console.WriteLine("");
                                Console.WriteLine("You monster.");
                            }
                            else if (keywordList[1].wary)
                            {
                                Console.WriteLine("The MERCHANT is still at the table, albeit looking at you warily.");
                                Console.WriteLine("Guess that's what happens when you threaten someone with flowers.");
                            }
                            else
                            {
                                Console.WriteLine("There is a friendly looking MERCHANT selling wares at a table.");
                            }
                        }
                        else if (words[2] == "east")
                        {
                            Console.WriteLine("You are currently in a house east of where you started.");
                            if (inventory[6].inInventory && inventory[7].inInventory)
                            {
                                Console.WriteLine("There's not much in here.");
                                Console.WriteLine("You've looted everything there is to loot.");
                            }
                            else if (inventory[6].inInventory)
                            {
                                Console.WriteLine("There's not much in here besides a spray BOTTLE of white vinegar on a shelf.");
                            }
                            else if (inventory[7].inInventory)
                            {
                                Console.WriteLine("There's not much in here besides an empty PITCHER on a shelf.");
                            }
                            else
                            {
                                Console.WriteLine("There's not much in here, though you do spot a spray BOTTLE of white vinegar and an empty PITCHER on a shelf.");
                                Console.WriteLine("Huh. What a strange and not at all for-convenience item combo.");
                            }
                        }
                        else if (words[2] == "south")
                        {
                            Console.WriteLine("You are currently in a clearing south of where you started.");
                            Console.WriteLine("Nothing here except an assortment of different FLOWER plants.");
                        }
                        else if (words[2] == "north")
                        {
                            Console.WriteLine("You are currently in a clearing north of where you started.");
                            if (keywordList[2].destroyed)
                            {
                                Console.WriteLine("And, well, there used to be a STATUE here, wearing awesome ROBES and a cool CROWN.");
                                Console.WriteLine("It was here for a very long time, just minding it's own business, being a cool STATUE.");
                                Console.WriteLine("Of course, now it's in pieces on the ground.");
                                Console.WriteLine("Because someone thought they could wear it as a hat.");
                            }
                            else if (inventory[1].inInventory && inventory[2].inInventory)
                            {
                                Console.WriteLine("The STATUE here stands silent, de-ROBEd and CROWN-less.");
                            }
                            else if (inventory[1].inInventory)
                            {
                                Console.WriteLine("The STATUE here stands silently without its CROWN, though it's still wearing its awesome ROBES.");
                            }
                            else if (inventory[2].inInventory)
                            {
                                Console.WriteLine("The STATUE here stands silently without its ROBES, though it still has its cool CROWN.");
                            }
                            else
                            {
                                Console.WriteLine("There is a serene looking STATUE here wearing ROBES and a CROWN.");
                            }
                        }
                    }
                    else if (words[1] == "sword")
                    {
                        if (inventory[0].inInventory)
                        {
                            Console.WriteLine("You LOOK at the SWORD.");
                            if (inventory[0].rusted)
                            {
                                Console.WriteLine("It's rusty.");
                            }
                            else
                            {
                                Console.WriteLine("It hasn't stopped 'bleeding', but at least there's not as much now.");
                                Console.WriteLine("...");
                                Console.WriteLine("It's still gross.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The SWORD is still stuck in the DAIS.");
                        }
                    }
                    else if (words[1] == "crown")
                    {
                        Console.WriteLine("You LOOK at the CROWN.");
                        if (inventory[1].rusted)
                        {
                            Console.WriteLine("It's rusty.");
                            Console.WriteLine("You wonder why anyone would make an iron CROWN.");
                            Console.WriteLine("Or how it got wet enough to tarnish.");
                            Console.WriteLine("I mean really, if you're going to go through all that trouble, you should at least gild it so that the outside looks gold and it doesn't tarnish.");
                            Console.WriteLine("But whatever. You digress.");
                        }
                    }
                    else if (words[1] == "robes")
                    {
                        Console.WriteLine("You LOOK at the ROBES.");
                        if (inventory[2].full)
                        {
                            Console.WriteLine("They're still soaked.");
                            Console.WriteLine("Gross.");
                        }
                        Console.WriteLine("You feel like they're whispering to you...");
                        Console.WriteLine("They're saying...");
                        Console.WriteLine("");
                        Console.WriteLine("BEHOLD my ROBES");
                        Console.WriteLine("");
                        Console.WriteLine("Huh.");
                    }
                    else if (words[1] == "duncecap")
                    {
                        Console.WriteLine("You regard the DUNCECAP fondly.");
                        Console.WriteLine("It looks just as sad and pathetic as the day you got it, which was like just now, or a few minutes ago, tops.");
                    }
                    else if (words[1] == "flowers")
                    {
                        if (words[2] == "bouquet")
                        {
                            Console.WriteLine("You LOOK at your bouquet of FLOWERS.");
                            Console.WriteLine("They are indeed pretty FLOWERS, and you think that with them, no one would be able to resist your CHARM.");
                        }
                        else
                        {
                            Console.WriteLine("You LOOK at the FLOWERS.");
                            Console.WriteLine("They're very pretty. You bet you could pick some, or at least EQUIP enough for a bouquet.");
                        }
                    }
                    else if (words[1] == "polish")
                    {
                        Console.WriteLine("You LOOK at the tin of POLISH.");
                        Console.WriteLine("Boy, you sure bet you could POLISH some things with this.");
                    }
                    else if (words[1] == "pitcher")
                    {
                        Console.WriteLine("You LOOK at the PITCHER");
                        if (inventory[6].full)
                        {
                            Console.WriteLine("It's been filled with blood.");
                            Console.WriteLine("Gross");
                        }
                        else
                        {
                            Console.WriteLine("It's empty.");
                        }
                    }
                    else if (words[1] == "bottle")
                    {
                        Console.WriteLine("You LOOK at the spray BOTTLE of white vinegar.");
                        Console.WriteLine("Wow, this is the type of thing that can rust metal really quickly!");
                    }
                    else if (words[1] == "dais")
                    {
                        Console.WriteLine("You LOOK at the DAIS.");
                        if (inventory[0].inInventory)
                        {
                            Console.WriteLine("There's a divot where the SWORD use to be.");
                            Console.WriteLine("It seems to be calling to you.");
                            Console.WriteLine("It's saying...");
                            Console.WriteLine("");
                            Console.WriteLine("Blood");
                            Console.WriteLine("");
                            Console.WriteLine("...The magic altar needs blood, does it? Sounds outdated. There's probably a convenient alternative around somewhere.");
                            Console.WriteLine("Or at the very least a way to get blood without killing anything.");
                        }
                        else
                        {
                            Console.WriteLine("There sure is a SWORD stuck in there.");
                            Console.WriteLine("There's some weird whispering coming from where the SWORD is buried in the DAIS, but with the SWORD in there, you can't make out what it's saying.");
                            Console.WriteLine("There's also some writing on the DAIS. It reads...");
                            Console.WriteLine("'WARNING: SPOOKY MAGYYKS AT WORK.'");
                            Console.WriteLine("Ooh, spooky magyyks? Maybe that can get you home!");
                        }
                    }
                    else if (words[1] == "merchant")
                    {
                        Console.WriteLine("You LOOK at the MERCHANT.");
                        if (keywordList[1].destroyed)
                        {
                            Console.WriteLine("The MERCHANT is... Still there.");
                            Console.WriteLine("Lying in a pool of blood.");
                            Console.WriteLine("Because you killed the MERCHANT.");
                            Console.WriteLine("...");
                            Console.WriteLine("You chose to do that.");
                        }
                        else if (keywordList[1].wary)
                        {
                            Console.WriteLine("The MERCHANT is still manning the table, though sneaking small, wary glances at you.");
                            Console.WriteLine("The MERCHANT LOOKs decidedly unhappy about remaining in the area.");
                        }
                        else
                        {
                            if (inventory[6].inInventory)
                            {
                                //In case I need to implement another method of bartering
                            }
                            else
                            {
                                Console.WriteLine("The MERCHANT notices you LOOKing, and gestures to the wares laid out on the table.");
                                Console.WriteLine("None of them interest you much, except a small tin of POLISH, which appeals to you due to your interest in metal maintenance.");
                                Console.WriteLine("Unfortunately, you have no coin for these wares, so you can't buy anything.");
                                Console.WriteLine("Perhaps you could find something to CHARM the MERCHANT with?");
                            }
                        }
                    }
                    else if (words[1] == "statue")
                    {
                        if (keywordList[2].destroyed)
                        {
                            Console.WriteLine("You look at the pathetic remains of the STATUE.");
                            Console.WriteLine("You think, 'man, I wish I hadn't challenged the authority of gaming tropes.'");
                            Console.WriteLine("'Because if I hadn't, this rad dude might still be here today.'");
                            Console.WriteLine("But he's not.");
                            Console.WriteLine("You are cursed to the lame ending forever.");
                            Console.WriteLine("Can you please leave? This is depressing.");
                            Console.WriteLine("You ruined a perfectly good story for a sad DUNCECAP.");
                        }
                        else if (inventory[1].inInventory && inventory[2].inInventory)
                        {
                            Console.WriteLine("You LOOK at the STATUE.");
                            Console.WriteLine("The STATUE here stands silent, no less de-ROBEd and CROWN-less than you could see from LOOKing around the area.");
                        }
                        else if (inventory[1].inInventory)
                        {
                            Console.WriteLine("You LOOK at the STATUE.");
                            Console.WriteLine("The STATUE here stands silently, CROWN-less but ROBEd.");
                        }
                        else if (inventory[2].inInventory)
                        {
                            Console.WriteLine("You LOOK at the STATUE.");
                            Console.WriteLine("The STATUE here stands silently, ROBE-less but CROWNed");
                            if (inventory[1].rusted)
                            {
                                Console.WriteLine("The CROWN is rusted to the STATUE. If you want it you'll have to POLISH it.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You LOOK at the STATUE.");
                            Console.WriteLine("The STATUE is wearing ROBES and a CROWN.");
                            if (inventory[1].rusted)
                            {
                                Console.WriteLine("The CROWN is rusted to the STATUE. If you want it you'll have to POLISH it.");
                            }
                        }
                    }
                    else if (words[1] == "inventory")
                    {
                        Console.WriteLine("List of all items in inventory:");
                        for (int i = 0; i < 8; i++)
                        {
                            if (inventory[i].inInventory)
                            {
                                Console.Write(inventory[i].name + ", ");
                            }
                        }
                        Console.WriteLine("");
                    }
                }
                else if (words[0] == "equip")
                {
                    if (words[2] == "repeat")
                    {
                        Console.WriteLine("You can't EQUIP " + words[1].ToUpper() + " twice.");
                    }
                    else if (words[2] == "inventory")
                    {
                        Console.WriteLine("You can't EQUIP " + words[1].ToUpper() + " because you don't know how.");
                    }
                    else if (words[2] == "fail")
                    {
                        Console.WriteLine("You can't EQUIP " + words[1].ToUpper() + " because of distance from said " + words[1].ToUpper() + ".");
                    }
                    else if (words[1] == "sword")
                    {
                        Console.WriteLine("You attempt to EQUIP the SWORD.");
                        if (words[2] == "success")
                        {
                            if (inventory[1].equipped)
                            {
                                Console.WriteLine("With your new CROWN EQUIPped, you loosen the sword from the DAIS to what sounds like a choir of angels singing.");
                            }
                            else
                            {
                                Console.WriteLine("With your sad DUNCECAP EQUIPped, you loosen the sword from the DAIS to what sounds like a choir of angels retching.");
                                Console.WriteLine("Truly, this is the worst possible way you could've done this.");
                            }
                            Console.WriteLine("You EQUIPed the SWORD!");
                            Console.WriteLine("You wonder if this means you'll have to STAB anything on your quest.");
                        }
                        else if (words[2] == "unworthy")
                        {
                            Console.WriteLine("The SWORD does not give.");
                            Console.WriteLine("It probably thinks you're too un-kingly to wield it.");
                            Console.WriteLine("'un-kingly.' You think that's a word.");
                        }
                    }
                    else if (words[1] == "crown")
                    {
                        if (words[2] == "repeat")
                        {
                            Console.WriteLine("You can't EQUIP the CROWN if it's already EQUIPped.");
                        }
                        else if (words[2] == "dent")
                        {
                            Console.WriteLine("You'd like to EQUIP the CROWN, but is is still dented, and sort of bent out of shape.");
                            Console.WriteLine("Besides, you lost your CROWN-having privileges.");
                        }
                        else if (words[2] == "rust")
                        {
                            Console.WriteLine("You try to EQUIP the CROWN, but you can't quite get it.");
                            Console.WriteLine("It's rusted to the STATUE.");
                        }
                        else
                        {
                            Console.WriteLine("You successfully EQUIP the CROWN.");
                        }
                    }
                    else if (words[1] == "duncecap")
                    {
                        if (words[2] == "success")
                        {
                            Console.WriteLine("You lunge for the DUNCECAP, stuffing your head into it so violently that you doubt this thing is ever coming off.");
                            Console.WriteLine("But why would you want this to come off? After all, you earned this.");
                            Console.WriteLine("You EQUIPped the DUNCECAP!");
                        }
                        else
                        {
                            //repeat equip
                        }
                    }
                    else if (words[1] == "robes")
                    {
                        if (words[2] == "torn")
                        {
                            Console.WriteLine("You can't EQUIP the ROBES anymore. They got torn when you broke the STATUE.");
                            Console.WriteLine("You will never know what it's like to wear those truly glorious ROBES.");
                        }
                        else
                        {
                            Console.WriteLine("You EQUIP the ROBES.");
                        }
                    }
                    else if (words[1] == "flowers")
                    {
                        Console.WriteLine("You carefully gather a bouquet of FLOWERS.");
                        Console.WriteLine("With these, you feel as though you could CHARM almost anyone.");
                        Console.WriteLine("You EQUIPped the FLOWERS!");
                    }
                    else if (words[1] == "polish")
                    {
                        if (words[2] == "murder")
                        {
                            Console.WriteLine("You, uh... you loot the MERCHANT's table.");
                            Console.WriteLine("The MERCHANT doesn't stop you, on account of being dead.");
                            Console.WriteLine("You got the POLISH!");
                            Console.WriteLine("Yay...?");
                        }
                        else if (words[2] == "thief")
                        {
                            Console.WriteLine("You attempt to take the tin of POLISH.");
                            Console.WriteLine("Take, not EQUIP, because you can't EQUIP POLISH.");
                            Console.WriteLine("The MERCHANT asks what are you doing.");
                            Console.WriteLine("You say taking some polish.");
                            Console.WriteLine("The MERCHANT asks do you have coin?");
                            Console.WriteLine("You wordlessly return the POLISH.");
                        }
                    }
                    else if (words[1] == "pitcher")
                    {
                        Console.WriteLine("You can't EQUIP the PITCHER, but you do take it.");
                        Console.WriteLine("It looks pretty handy for filling with liquids and POURing them out.");
                    }
                    else if (words[1] == "bottle")
                    {
                        Console.WriteLine("You can't EQUIP the BOTTLE, but you do take it.");
                        Console.WriteLine("You wonder what you should SPRAY first.");
                    }
                    else if (words[1] == "dais")
                    {
                        Console.WriteLine("You EQUIP the...");
                        Console.WriteLine("...");
                        Console.WriteLine("Really?");
                        Console.WriteLine("No, you can't do that.");
                        Console.WriteLine("You decide not to EQUIP the DAIS.");
                    }
                    else if (words[1] == "merchant")
                    {
                        Console.WriteLine("You'd try to EQUIP the MERCHANT, except you like to think you have a bit more sense than that.");
                    }
                    else if (words[1] == "statue")
                    {
                        if (words[2] == "attempt")
                        {
                            Console.WriteLine("What??");
                            Console.WriteLine("You can't EQUIP the STATUE.");
                            Console.WriteLine("Who would want to EQUIP that STATUE anyways?");
                            Console.WriteLine("The STATUE doesn't even have ROBES and/or a CROWN.");
                        }
                        else
                        {
                            Console.WriteLine("You EQUIP...");
                            Console.WriteLine("EQUIP the...");
                            Console.WriteLine("Wait, what??");
                            Console.WriteLine("No, you can't-");
                            Console.WriteLine("Oh, come on!");
                            Console.WriteLine("You think you're funny, huh? Want to EQUIP a STATUE? You think that will solve the puzzle? EQUIPping a STATUE. Well you know what? Fine.");
                            Console.WriteLine("You EQUIP the STATUE.");
                            Console.WriteLine("You think that the best way to do this is to wear it as a hat.");
                            Console.WriteLine("Like a man possessed by the strength of a thousand angry game developers, you somehow lift the whole statue and balance it on your head for all of two seconds.");
                            Console.WriteLine("And then it falls and breaks to pieces, tearing the ROBES and denting the CROWN.");
                            Console.WriteLine("In the rubble of what used to be a STATUE, there lies a sad little DUNCECAP, labeled 'thisisstupid.'");
                            Console.WriteLine("Is that 'kingly' enough for you?");
                            Console.WriteLine("[Achievement Get: This is Stupid]");
                        }
                    }
                }
                else if (words[0] == "stab")
                {
                    if (words[2] == "fail")
                    {
                        Console.WriteLine("You can't STAB anything without something to STAB with.");
                    }
                    else if (words[2] == "missing")
                    {
                        Console.WriteLine("You can only STAB things that are nearby.");
                    }
                    else if (words[1] == "sword")
                    {
                        Console.WriteLine("You try to STAB the SWORD with the SWORD.");
                        Console.WriteLine("Naturally, this doesn't work.");
                    }
                    else if (words[1] == "crown")
                    {
                        Console.WriteLine("You STAB the CROWN. The SWORD glances off the side.");
                    }
                    else if (words[1] == "robes")
                    {
                        Console.WriteLine("You STAB your ROBES right through the armhole.");
                        Console.WriteLine("There are now the exact same number of holes in your ROBES as before.");
                    }
                    else if (words[1] == "duncecap")
                    {
                        Console.WriteLine("You STAB the DUNCECAP in what may be the only reasonable reaction to said DUNCECAP.");
                        Console.WriteLine("However, the thing seems to be STAB resistant, like the cosmos are punishing you for your mistakes.");
                    }
                    else if (words[1] == "flowers")
                    {
                        Console.WriteLine("You STAB the FLOWERS.");
                        Console.WriteLine("You take the head off of a tulip.");
                    }
                    else if (words[1] == "polish")
                    {
                        if (words[2] == "thief")
                        {
                            Console.WriteLine("You go to STAB the tin of POLISH, but the MERCHANT stops you.");
                        }
                        else
                        {
                            Console.WriteLine("You STAB the tin of POLISH.");
                            Console.WriteLine("Nah, just kidding. Due to your interest in metal maintenance, you would never destroy such a product.");
                        }
                    }
                    else if (words[1] == "pitcher")
                    {
                        Console.WriteLine("You STAB the PITCHER.");
                        Console.WriteLine("The SWORD glances off the side.");
                    }
                    else if (words[1] == "bottle")
                    {
                        Console.WriteLine("You try to STAB the BOTTLE, but for some reason you keep missing.");
                    }
                    else if (words[1] == "dais")
                    {
                        Console.WriteLine("You STAB the SWORD back into the DAIS, and then pull it out again when nothing happens.");
                    }
                    else if (words[1] == "merchant")
                    {
                        if (words[2] == "repeat")
                        {
                            Console.WriteLine("Oh... you...");
                            Console.WriteLine("You STAB the already dead MERCHANT again.");
                            Console.WriteLine("Ok... you didn't need to do that but ok...");
                            Console.WriteLine("[Achievement Get: Overkill]");
                        }
                        else
                        {
                            Console.WriteLine("What? You're just going to STAB an innocent bystander?");
                            Console.WriteLine("Uhh...");
                            Console.WriteLine("Ok, fine, sure.");
                            Console.WriteLine("You STAB the MERCHANT.");
                            Console.WriteLine("The MERCHANT is dead.");
                            Console.WriteLine("You know, there was a non-violent way to solve this puzzle.");
                            Console.WriteLine("You didn't need to do that.");
                            Console.WriteLine("You chose to do that.");
                            if (words[2] == "fill")
                            {
                                Console.WriteLine("The PITCHER gets filled with blood.");
                            }
                        }
                    }
                    else if (words[1] == "statue")
                    {
                        Console.WriteLine("You STAB the STATUE but can't even damage it.");
                    }
                }
                else if (words[0] == "spray")
                {
                    if (words[2] == "missing")
                    {
                        Console.WriteLine("You don't have anything to SPRAY with.");
                    }
                    else if (words[2] == "fail")
                    {
                        Console.WriteLine("You can only SPRAY things that are nearby.");
                    }
                    else if (words[1] == "sword")
                    {
                        if (words[2] == "repeat")
                        {
                            Console.WriteLine("You SPRAY the SWORD with white vinegar, but the SWORD is already rusty.");
                        }
                        else
                        {
                            Console.WriteLine("You SPRAY the SWORD with white vinegar.");
                            Console.WriteLine("Oh, woah, it's rusting!");
                        }
                    }
                    else if (words[1] == "crown")
                    {
                        if (words[2] == "repeat")
                        {
                            Console.WriteLine("You SPRAY the CROWN with white vinegar, but the CROWN is already rusty.");
                        }
                        else
                        {
                            Console.WriteLine("You SPRAY the CROWN with white vinegar.");
                            Console.WriteLine("Oh, woah, it's rusting!");
                        }
                    }
                    else if (words[1] == "robes")
                    {
                        Console.WriteLine("You SPRAY the ROBES with white vinegar.");
                        Console.WriteLine("The ROBES now smell like vinegar.");
                    }
                    else if (words[1] == "duncecap")
                    {
                        Console.WriteLine("You SPRAY the DUNCECAP with white vinegar.");
                        Console.WriteLine("The DUNCECAP now smells like vinegar.");
                    }
                    else if (words[1] == "flowers")
                    {
                        Console.WriteLine("You SPRAY the FLOWERS with white vinegar.");
                        Console.WriteLine("The FLOWERS now smell like vinegar.");
                    }
                    else if (words[1] == "polish")
                    {
                        if (words[2] == "murder")
                        {
                            Console.WriteLine("You lean over the corpse of the MERCHANT to SPRAY the tin of POLISH with white vinegar.");
                            Console.WriteLine("Nothing happened.");
                        }
                        else if (words[2] == "thief")
                        {
                            Console.WriteLine("You go to SPRAY the tin of POLISH with white vinegar.");
                            Console.WriteLine("Naturally, the MERCHANT stops you.");
                        }
                        else
                        {
                            Console.WriteLine("You SPRAY the tin of POLISH with white vinegar.");
                            Console.WriteLine("Nothing happened.");
                        }
                    }
                    else if (words[1] == "pitcher")
                    {
                        Console.WriteLine("You SPRAY the PITCHER with white vinegar.");
                        Console.WriteLine("The PITCHER now smells like vinegar.");
                    }
                    else if (words[1] == "bottle")
                    {
                        Console.WriteLine("You try to SPRAY the spray BOTTLE with the spray BOTTLE.");
                        Console.WriteLine("Naturally, this doesn't work.");
                    }
                    else if (words[1] == "dais")
                    {
                        Console.WriteLine("You SPRAY the DAIS with white vinegar.");
                        Console.WriteLine("Nothing happened.");
                    }
                    else if (words[1] == "merchant")
                    {
                        Console.WriteLine("You try to SPRAY the MERCHANT with white vinegar.");
                        Console.WriteLine("The MERCHANT dodges skillfully, and, with a winning customer service smile, pretends nothing happened.");
                        Console.WriteLine("Wow. That's commitment!");
                    }
                    else if (words[1] == "statue")
                    {
                        if (words[2] == "broken")
                        {
                            Console.WriteLine("You SPRAY the broken pieces of the STATUE with white vinegar.");
                            Console.WriteLine("Nothing happened.");
                        }
                        else
                        {
                            Console.WriteLine("You SPRAY the STATUE with white vinegar.");
                            Console.WriteLine("Nothing happened.");
                        }
                    }
                    else if (words[1] == "inventory")
                    {
                        Console.WriteLine("You cannot SPRAY your INVENTORY, because an INVENTORY is more of an abstract concept used to keep track of items than a physical thing.");
                    }
                }
                else if (words[0] == "behold")
                {
                    if (words[2] == "fail")
                    {
                        Console.WriteLine("You cannot BEHOLD the ROBES if you are not near the ROBES.");
                    }
                    else if (words[1] == "behold")
                    {
                        Console.WriteLine("BEHOLD");
                    }
                    else if (words[1] == "robes")
                    {
                        Console.WriteLine("BEHOLD MY ROBES!");
                        Console.WriteLine("[Achievement Get: Robes Beheld]");
                    }
                }
                else if (words[0] == "pour")
                {
                    if (words[1] == "fail")
                    {
                        Console.WriteLine("You can't pour that.");
                    }
                    else if (words[1] == "pitcher")
                    {
                        if (words[2] == "empty")
                        {
                            Console.WriteLine("You attempt to POUR the PITCHER out.");
                            Console.WriteLine("You would've been successful, had the PITCHER contained anything.");
                        }
                        else if (words[2] == "fail")
                        {
                            Console.WriteLine("You don't POUR the PITCHER out here, because there's no reason to.");
                        }
                        else
                        {
                            Console.WriteLine("You POUR the PITCHER out onto the DAIS, into the DIVOT that asked for blood.");
                            Console.WriteLine("There's a sound like someone drinking, anf the whole forest glows white.");
                            Console.WriteLine("You start to feel dizzy, but feel as though you can be confident that when next you open your eyes, you'll be someplace you know.");
                            Console.WriteLine("Everything goes black.");
                            Console.WriteLine("...");
                            Console.WriteLine("..");
                            Console.WriteLine(".");
                            Console.WriteLine("A winner is you!");
                        }
                    }
                    else if (words[1] == "robes")
                    {

                    }
                    else if (words[1] == "duncecap")
                    {

                    }
                    else if (words[1] == "flowers")
                    {

                    }
                    else if (words[1] == "polish")
                    {

                    }
                    else if (words[1] == "pitcher")
                    {

                    }
                    else if (words[1] == "bottle")
                    {

                    }
                    else if (words[1] == "dais")
                    {

                    }
                    else if (words[1] == "merchant")
                    {

                    }
                    else if (words[1] == "statue")
                    {

                    }
                    else if (words[1] == "inventory")
                    {

                    }
                }
                else if (words[0] == "polish")
                {
                    if (words[1] == "missing")
                    {
                        Console.WriteLine("You don't have any POLISH to POLISH with.");
                    }
                    else if (words[1] == "fail")
                    {
                        Console.WriteLine("You can't POLISH that.");
                    }
                    else if (words[2] == "fail")
                    {
                        Console.WriteLine("You can only POLISH things that are nearby.");
                    }
                    else if (words[1] == "sword")
                    {
                        if (words[2] == "clean")
                        {
                            Console.WriteLine("The SWORD has already been POLISHed.");
                        }
                        else if (words[2] == "stuck")
                        {
                            Console.WriteLine("You can't POLISH the SWORD if it's still stuck in the DAIS.");
                        }
                        else
                        {
                            Console.WriteLine("You POLISH the SWORD, methodically removing all of the rust.");
                            Console.WriteLine("As you do so, you notice that the sword is... bleeding?");
                            Console.WriteLine("You didn't know swords did that.");
                            Console.WriteLine("Oh, wait, maybe it's the rust? You've heard about this, you think. It's called blood rust? Yeah, that must be what's happening. No magyyks here, no sir.");
                            Console.WriteLine("Still, it does look a remarkable amount like blood.");
                            if (words[2] == "full")
                            {
                                Console.WriteLine("You fill the PITCHER with 'blood.'");
                            }
                        }
                    }
                    else if (words[1] == "crown")
                    {
                        if (words[2] == "free")
                        {
                            Console.WriteLine("You carefully POLISH the CROWN until it is no longer rusted to the STATUE.");
                            Console.WriteLine("Now would be a good time to try to EQUIP it.");
                        }
                        else
                        {
                            Console.WriteLine("You POLISH the CROWN.");
                            Console.WriteLine("The CROWN is now once again free from rust.");
                            Console.WriteLine("Nothing else happened.");
                        }
                    }
                }
                else if (words[0] == "charm")
                {
                    if (words[1] == "merchant")
                    {
                        if (words[2] == "missing")
                        {
                            Console.WriteLine("You'd like to CHARM the MERCHANT, but you're not feeling particularly CHARMing right now. Perhaps if you had something to boost your confidence.");
                        }
                        else if (words[2] == "repeat")
                        {
                            Console.WriteLine("You've already CHARMed the MERCHANT, much to said MERCHANT's chagrin.");
                        }
                        else if (words[2] == "murder")
                        {
                            Console.WriteLine("You can't CHARM the MERCHANT because the MERCHANT is dead.");
                        }
                        else
                        {
                            Console.WriteLine("You approach the MERCHANT and brandish your bouquet of FLOWERS. It's CHARM time.");
                            Console.WriteLine("'your eyes,' You say, 'are an ocean. your hair. is also an ocean.");
                            Console.WriteLine("You were so focused on saying some utterly CHARMing things that it takes you a second to notice that the MERCHANT has flinched away from your beautiful bouquet.");
                            Console.WriteLine("Please get those away from me, the MERCHANT says.");
                            Console.WriteLine("You say you'll put them away if you can get that tin of POLISH.");
                            Console.WriteLine("The MERCHANT tosses you the tin and shoes you away.");
                            Console.WriteLine("You got the POLISH!");
                        }
                    }
                    else if (words[1] == "fail")
                    {
                        Console.WriteLine("You can only CHARM things that are nearby.");
                        Console.WriteLine("(Otherwise how would you work your magic?)");
                    }
                    else if (words[1] == "item")
                    {
                        Console.WriteLine("On second thought, you don't really want to CHARM that.");
                    }
                }
                else if (words[1] == "tree")
                {
                    Console.WriteLine("You can't go that way, the forest is too thick.");
                }
                else if (words[1] == "house")
                {
                    Console.WriteLine("You can't go that way, the house's only exit is to the west.");
                }
                else if (words[0] == "n")
                {
                    Console.WriteLine("You go north.");
                }
                else if (words[0] == "s")
                {
                    Console.WriteLine("You go south.");
                }
                else if (words[0] == "e")
                {
                    Console.WriteLine("You go east.");
                }
                else if (words[0] == "w")
                {
                    Console.WriteLine("You go west.");
                    if (words[1] == "fill")
                    {
                        Console.WriteLine("While you're here, you fill the PITCHER with the MERCHANT's blood.");
                    }
                }
                if (input == "null null null" || (words[1] == "null" && words[2] == "null"))
                {
                    Console.WriteLine("You decide not to do that, on account of not knowing what it means.");
                }
                else if (input == "null null long")
                {
                    Console.WriteLine("You decide not to do that, because it is too long.");
                }
            }
        }
        public class Adventure
        {
            static void Main(string[] args)
            {
                string input;
                bool win = false;
                View view = new View();
                Controller controller = new Controller();
                GameLogic gameLogic = new GameLogic();
                gameLogic.inventorySetup();
                view.Intro1();
                input = controller.getName();
                view.Intro2(input);
                while (win == false) // I didn't know if I wanted it to close out on its own so I just let it run forever (until closed)
                {
                    input = controller.nextCommand();
                    string commandParsed = gameLogic.parseCommand(input);
                    Console.WriteLine(commandParsed);
                    view.ReadCommand(commandParsed, gameLogic.inventory, gameLogic.keywordList);
                }
                //
                Console.ReadLine();
            }
        }

    }
}
