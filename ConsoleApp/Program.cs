using GameLogic;
using ConsoleApp.Inputs;
using static ConsoleApp.Outputs.Output;
using GameLogic.DungeonManagement;

namespace ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ushort optionsCount = 3;
            bool exit = false;
            while (!exit)
            {
                Display.PrintMainMenu();
                ushort choice = Input.GetChoice(optionsCount);

                switch ((MenuOptions)choice)
                {
                    case MenuOptions.NewGame:
                        SetupGame();
                        break;
                    case MenuOptions.HighScores:
                        Display.PrintHighScores();
                        break;
                    case MenuOptions.Exit:
                        Display.PrintExitGame();
                        exit = true;
                        break;
                    default:
                        Display.PrintInvalidInputError();
                        break;
                }
                Display.PressAnyKey();
                Input.WaitForKeyPress();
                Display.Clear();
            }
        }

        private static void SetupGame()
        {
            Display.Clear();
            Display.AskForName();
            string name = Input.GetUserInput();
            Game game = new();
            game.InitializePlayer(name);
            DbManager.CreateGridInDB(game.Dungeon);
            while (game.GameIsOn && game.Player.Alive)
            {
                GameLoop(game);
            }
        }

        private static void GameLoop(Game game)
        {
            Display.Clear();
            Display.ShowOnScreen(game.ScreenString());
            Input.GetPlayerMovement(game);
        }
    }
}