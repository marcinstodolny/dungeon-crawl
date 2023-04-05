﻿using ConsoleApp.Inputs;
using System.Numerics;

namespace ConsoleApp.Outputs
{
    internal class Output
    {
        internal class Display
        {
            public static void PrintInvalidInputError()
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            public static void PressAnyKey()
            {
                Console.WriteLine("\nPress any key to continue...");
            }
            public static void Clear()
            {
                Console.Clear();
            }

            public static void PrintMainMenu()
            {
                Clear();
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. High Scores");
                Console.WriteLine("3. Exit");
            }

            public static void PrintHighScores()
            {
                NotImplementedException();
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

            public static void ShowItemMessage()
            {
                    NotImplementedException();
            }

            public static void DisplayUserStats()
            {
                NotImplementedException();
            }

            public static void HelpMessage()
            {
                NotImplementedException();
            }

            public static void DisplayHelp()
            {
                Console.WriteLine("Available keys:\n" + "W,A,S,D: Player Move\n" + "I: Show inventory\n"
                                  + "E: Pickup item while standing on it\n" + "M: Map Legend\n" + "ESC: Quit to menu");
            }

            public static void ShowOnScreen(string screen)
            {
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
        }
    }
}