using GameLogic.DungeonManagement;
using GameLogic;
using static ConsoleApp.Outputs.Output;

namespace ConsoleApp.Inputs
{
    internal class Input
    {
        public static string GetUserInput()
        {
            string userInput = "";
            while (string.IsNullOrEmpty(userInput))
            {
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static ushort GetChoice(ushort optionsCount)
        {
            ushort choice = 0;
            bool validInput = false;
            while (!validInput)
            {
                string inputString = GetUserInput();
                if (ushort.TryParse(inputString, out choice) && choice >= 1 && choice <= optionsCount)
                {
                    validInput = true;
                }
                else
                {
                    Display.PrintInvalidInputError();
                }
            }
            return choice;
        }

        public static void WaitForInput()
        {
            Console.ReadLine();
        }


        public static ConsoleKeyInfo WaitForKeyPress()
        {
            return Console.ReadKey(true);
        }

        public static void GetPlayerMovement(Game game)
        {
            switch (Input.WaitForKeyPress().Key)
            {
                case ConsoleKey.A:
                    game.PassPlayerDirection(Direction.West);
                    break;
                case ConsoleKey.W:
                    game.PassPlayerDirection(Direction.North);
                    break;
                case ConsoleKey.S:
                    game.PassPlayerDirection(Direction.South);
                    break;
                case ConsoleKey.D:
                    game.PassPlayerDirection(Direction.East);
                    break;
                case ConsoleKey.E:
                    game.PassPlayerDirection(Direction.None);
                    Display.WaitMessage();
                    break;
                case ConsoleKey.I:
                    Display.ShowOnScreen(game.InventoryString());
                    Display.WaitMessage();
                    break;
                case ConsoleKey.H:
                    Display.DisplayHelp();
                    Display.WaitMessage();
                    break;
                case ConsoleKey.M:
                    Display.ShowOnScreen(Game.MapLegendString());
                    Display.WaitMessage();
                    break;
                case ConsoleKey.Escape:
                    game.GameIsOn = false;
                    break;
                default:
                    break;
            }
        }
    }
}
