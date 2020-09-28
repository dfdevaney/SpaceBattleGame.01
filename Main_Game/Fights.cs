using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Main_Game
{
    class Fights
    {
        static readonly Random rando = new Random();
        public static void FirstFight()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Prepare for a fight!");
            Console.WriteLine("\nPress any key to continue ...");
            Console.ReadKey();
            Console.ResetColor();
            Combat(true, "", 1, 5);
        }
        public static void FirstBossFight()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou hear a loud cackle! As you look up ahead, you notice you are in deep trouble. ");
            Console.WriteLine("\nPress any key to continue ...");
            Console.ReadKey();
            Console.ResetColor();
            Combat(false, "Becky the Witch", 4, 4);
        }
        public static void SecondBossFight()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nExhausted, you look up ahead. There is another Alien staring at you, while sharpening his sword.");
            Console.WriteLine("\nPress any key to continue ...");
            Console.ReadKey();
            Console.ResetColor();
            Combat(false, "Memphis the Oracle", 4, 4);
        }
        public static void RandomFight()
        {
            switch(rando.Next(0,2))
            {
                case 0:
                    FirstFight();
                    break;
                case 1:
                    FirstBossFight();
                    break;
                case 2:
                    SecondBossFight();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = ""; // N is for Name.
            int p; // P is for Enemy Power.
            int h; // H is for Enemy Health.

                if (random)
            {
                n = GetName();
                p = rando.Next(1, 5);
                h = rando.Next(1, 6);
            }
                else
            {
                n = name;
                p = power;
                h = health;
            }
            while (h > 0)
            {
                Console.WriteLine(n);
                Console.WriteLine($"Power: {p} \t Health: {h}");
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un    (H)eal   |");
                Console.WriteLine("Potions: " + Program.currentPlayer.potion + " Health: " + Program.currentPlayer.health);

                string input = Console.ReadLine();
                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You draw your sword & swing at the enemy!");
                    Console.ResetColor();
                    int damage = p - Program.currentPlayer.armorValue;
                    if (damage < 0)
                        damage = 0;
                    int attack = rando.Next(0, Program.currentPlayer.weaponValue) + rando.Next(1, 4);
                    Console.WriteLine("\nYou lose " + damage + " health & deal " + attack + " damage!");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nAs the " + n + " prepares to strike, you ready your sword to block the incoming attack!");
                    Console.ResetColor();
                    Console.WriteLine("\nPress any key to continue ...");
                    Console.ReadKey();
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no escape! You must fight the " + n + "!");
                    Console.ResetColor();
                    Console.WriteLine("\nPress any key to continue ...");
                    Console.ReadKey();
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    if (Program.currentPlayer.potion == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nUh-oh! You have no more potions remaining!");
                        Console.ResetColor();
                        Console.WriteLine("\nPress any key to continue ...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nYou reach into your bag & take a big drink of your potion!");
                        Console.WriteLine($"\nYou gain {Program.currentPlayer.potionValue} health.");
                        Console.ResetColor();
                        Program.currentPlayer.health += Program.currentPlayer.potionValue;
                        Program.currentPlayer.potion -= 1;
                        Console.WriteLine("\nPress any key to continue ...");
                        Console.ReadKey();
                    }
                }
                if (Program.currentPlayer.health <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are out of health! Game Over!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{Program.currentPlayer.name}'s total score: {Program.currentPlayer.score}");
                    Console.WriteLine($"{Program.currentPlayer.name}'s total coins: {Program.currentPlayer.gold}");
                    Console.ResetColor();
                    Console.WriteLine("\nPress any key to End ...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            Program.currentPlayer.score++; // This increases the Score by 1 for each enemy defeated.
            int Coins = rando.Next(10, 100);
            Console.WriteLine($"\nYou have defeated the {n}! You collect {Coins} gold coins.");
            Program.currentPlayer.gold += Coins; // This increases the current Gold Coin count + collected amount.
            Console.WriteLine("\nYou walk past your fallen foe, but see another!");
            Console.ResetColor();

        }
        public static string GetName()
        {
            switch(rando.Next(0,4))
            {
                case 0:
                    return "Alien Grunt";

                case 1:
                    return "Alien Chief";

                case 2:
                    return "Alien Hunter";

                case 3:
                    return "Alien Wizard";
            }
            return "A Genaric Alien";
        }
    }
}
