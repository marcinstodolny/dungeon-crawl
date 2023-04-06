using GameLogic.DungeonManagement;
using GameLogic;
using ConsoleApp.Outputs;

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
                    Output.PrintInvalidInputError();
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
    }
}
