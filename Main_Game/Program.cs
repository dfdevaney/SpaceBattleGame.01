using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Game
{
    class Program
    {
        public static Player currentPlayer = new Player(); // This creates a new instance of the Player.
        public static bool MainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Fights.FirstFight();
            while (MainLoop)
            {
                Fights.RandomFight();
            }
        }
        static void Start()
        {
            string TitleOfGame = "The Final Space Battle!";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to continue ...");
            Console.SetCursorPosition((Console.WindowWidth - TitleOfGame.Length) / 2, Console.CursorTop);
            Console.WriteLine(TitleOfGame);

            Console.ReadKey();

            Console.WriteLine("\nWhat is your Name?");
            currentPlayer.name = Console.ReadLine();
            Console.WriteLine("\nPress any key to continue ...");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("You awake to find yourself on a strange, purple planet. Looking around, you see aliens flying in Maserattie's. \nYou are bewildered ...");
            Console.WriteLine("\nA younger looking alien aggresively approaches you. Luckily, you still seem to have a weapon.");
            Console.WriteLine("\nPress any key to continue ...");
            Console.ResetColor();
            Console.ReadKey();

        }
    }
}
