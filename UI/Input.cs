namespace RoguelikeGame.UI
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
                Display.PrintMainMenu();
                string inputString = GetUserInput();
                if (ushort.TryParse(inputString, out choice) && choice >= 1 && choice <= optionsCount)
                {
                    validInput = true;
                }
                else
                {
                    Display.PrintInvalidInputError();
                    Display.PressAnyKey();
                    WaitForKeyPress();
                    Display.Clear();
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
