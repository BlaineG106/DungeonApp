using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace Dungeon
{
    class MainGame
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon Royale";
            Console.WriteLine("A tough task lies ahead, your journey begins...");

            int score = 0; //running score variable

            Weapon longSword = new Weapon("Long Sword", 5, 12, false);
            Weapon swordShield = new Weapon("Sword and Shields", 3, 9, true);

            Weapon longBow = new Weapon("Long Bow", 7, 15, false);
            Weapon crossBow = new Weapon("CrossBow", 5, 12, true);

            var weapon = longSword;
            var race = Race.Knight;
            var characterName = "Knight";
            var maxHealth = 0;
            var life = 0;
            var block = 0;
            var hitChance = 0;

            bool characterExit = false;
            do
            {
                Console.WriteLine("Select your character: \n\n" +
                    "A) Knight \n" +
                    "B) Archer \n");

                string characterChoice = Console.ReadLine().ToUpper();

                switch (characterChoice)
                {
                    case "A":
                    case "KNIGHT":
                        maxHealth = 50;
                        life = 50;
                        block = 5;
                        race = Race.Knight;
                        characterName = "Knight";
                        characterExit = true;
                        bool knightWeaponExit = false;
                        do
                        {
                            Console.WriteLine("Please Choose a weapon: \n" +
                                "A) Long Sword\n" +
                                "B) Sword and Shield\n");
                            string knightWeaponChoice = Console.ReadLine().ToUpper();

                            switch (knightWeaponChoice)
                            {
                                case "A":
                                case "LONG SWORD":
                                    weapon = longSword;
                                    hitChance = 70;
                                    knightWeaponExit = true;
                                    break;
                                case "B":
                                case "SWORD AND SHIELD":
                                    weapon = swordShield;
                                    hitChance = 60;
                                    block = block + 3;
                                    knightWeaponExit = true;
                                    break;
                                default:
                                    Console.WriteLine("The weapon you are looking for doesn't exist, please try again");
                                    break;
                            }//end knight weapon choice
                        } while (!knightWeaponExit);
                        break;
                    case "B":
                    case "ARCHER":
                        maxHealth = 40;
                        life = 40;
                        block = 3;
                        race = Race.Archer;
                        characterName = "Archer";
                        characterExit = true;
                        bool archerWeaponExit = false;
                        do
                        {
                            Console.WriteLine("Select your Weapon: \n" +
                                "A) Long Bow\n" +
                                "B) Cross Bow\n");
                            string archerWeaponChoice = Console.ReadLine().ToUpper();

                            switch (archerWeaponChoice)
                            {
                                case "A":
                                case "LONG BOW":
                                    weapon = longBow;
                                    hitChance = 50;
                                    archerWeaponExit = true;
                                    break;
                                case "B":
                                case "CROSS BOW":
                                    weapon = crossBow;
                                    hitChance = 40;
                                    block = block + 3;
                                    archerWeaponExit = true;
                                    break;
                                default:
                                    Console.WriteLine("The weapon you are looking for doesn't exist, please try again");
                                    break;
                            }
                        } while (!archerWeaponExit); //exit the archer weapon choice
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please try again\n");
                        break;
                }
            } while (!characterExit); //end characterMenu 

            Console.Clear();

            Player p1 = new Player(characterName, maxHealth, life, block, hitChance,  race, weapon);

            Console.WriteLine(p1);

            Console.WriteLine("Press any key to enter dungeon\n");

            Console.ReadKey();

            Console.Clear();

           

            bool exitGame = false;

            do
            {
                Console.WriteLine(GetRoom());
                //Monsters
                Goblin spearGoblin = new Goblin("Spear Goblin", 15, 15, 60, 20, 5, 10, "A large goblin with a large spear which it throws with much power doing huge damage.", true);
                Goblin daggerGoblin = new Goblin();

                Knight skeletonKnight = new Knight();
                Knight megaKnight = new Knight("Mega Knight", 25, 25, 50, 25, 10, 15, "A massive skeleton knight with large spiked balls for hands and an ability to leap and slam on top of his apponents.", true);

                Dragon babyDrag = new Dragon();
                Dragon InfernoDrag = new Dragon("Inferno Dragon", 20, 20, 40, 30, 8, 12, "A older dragon covered in a steel armour, has the ability to hold a sustained spray of fire for almost a minute.", true);

                Monster[] monsters = { spearGoblin, daggerGoblin, skeletonKnight, megaKnight, babyDrag, InfernoDrag };

                Random rand = new Random();
                int monsterNbr = rand.Next(monsters.Length);
                Monster monster = monsters[monsterNbr];

                Console.WriteLine("\nYou Have encountered a {0}\n\n\n", monster.Name);

                bool repeat = false;
                do
                {
                    //Menu
                    Console.WriteLine("\nPlease choose an action: \n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n\n" +
                        "Score: {0}\n", score);

                    ConsoleKey userAction = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (userAction)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(p1, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou defeated {0}!\n", monster.Name);
                                Console.ResetColor();
                                repeat = true;
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("You Run Away!");
                            Console.WriteLine("{0} attacks you as you run away!\n", monster.Name);
                            Combat.DoAttack(monster, p1);
                            repeat = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("-=-= Player Info =-=-\n");
                            Console.WriteLine(p1);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("-=-= Monster Info =-=-\n");
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                            Console.WriteLine("See you later Traveler, Til the next quest...");
                            exitGame = true;
                            break;
                        default:
                            Console.WriteLine("Please choose a valid option...");
                            break;
                    }//end switch
                    if (p1.Life <= 0)
                    {
                       
                        exitGame = true;
                    }

                } while (!exitGame && !repeat);



            } while (!exitGame);

            Console.WriteLine("You Have Died.\n" +
                           "Game Over\n\n");
            Console.WriteLine("Final Score: {0}", score);


        }//end Main()
        private static string GetRoom()
        {
            string[] rooms =
            {
                "You enter a room split in two by a small river, two bridges connect the sides...",
                "You enter a cave with large tracks all over the ground...",
                "You enter a room made of stone bricks, the walls scorched in random patterns...",
                "You enter a mossy room with rocks covered in vines and a small pond in the center...",
                "You enter a hot room filled with red bricks and fire pits scattered around the floor...",
                "You enter a room filled with water yet you can breathe, magic must be involved...",
                "You enter a room with a large pit and a small platform in the middle...",
                "You walk up a stair case which goes outside, you are on top of a large rock with steep sides...",
                "You enter a dark room barely lit by light pearing through small cracks in the cealing..."
            };

            Random rand = new Random();

            int roomNbr = rand.Next(rooms.Length);
            string room = "-=-=-= New Room =-=-=-\n" + rooms[roomNbr] + "\n";

            return room;
        }
    }//end class
}//end namespace
