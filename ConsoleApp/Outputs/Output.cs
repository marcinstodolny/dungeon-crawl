using ConsoleApp.Inputs;
using System.Numerics;

namespace ConsoleApp.Outputs
{
    internal class Output
    {
        public static void PrintInvalidInputError()
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("\n\nPress any key to continue...");
        }
        public static void Clear()
        {
            Console.Clear();
        }

        public static void PrintMainMenu()
        {
            Clear();
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Continue");
            Console.WriteLine("3. High Scores");
            Console.WriteLine("4. Exit");
        }

        public static void PrintExitGame()
        {
            Clear();
            Console.WriteLine("Goodbye!");
        }

        public static void AskForName()
        {
            Console.WriteLine("Enter your name:");
        }

        public static void DisplayHelp()
        {
            Console.WriteLine("Available keys:\n" + "W,A,S,D: Player Move\n" + "I: Show inventory\n"
                                + "E: Pickup item while standing on it\n" + "M: Map Legend\n" + "ESC: Quit to menu\n");
        }

        public static void ShowOnScreen(string screen)
        {
            Clear();
            Console.Write(screen);
        }

        public static void WaitMessage()
        {
            PressAnyKey();
            Input.WaitForKeyPress();
        }

        public static void NotImplementedException() 
        {
            throw new NotImplementedException();
        }

        public static void SavingMessage()
        {
            Console.WriteLine("Saving (please wait).");
        }
        public static void SavedMessage()
        {
            Console.WriteLine("Progress saved.");
            Thread.Sleep(2000);
        }
    }
}
