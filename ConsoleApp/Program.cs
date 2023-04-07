using GameLogic;
using ConsoleApp.Inputs;
using ConsoleApp.Outputs;
using GameLogic.Entity;

namespace ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ushort optionsCount = 4;
            bool exit = false;
            while (!exit)
            {
                Output.PrintMainMenu();
                ushort choice = Input.GetChoice(optionsCount);

                switch ((MenuOptions)choice)
                {
                    case MenuOptions.NewGame:
                        SetupGame();
                        break;
                    case MenuOptions.Continue:
                        ContinueGame();
                        break;
                    case MenuOptions.HighScores:
                        ShowHighScores();
                        break;
                    case MenuOptions.Exit:
                        Output.PrintExitGame();
                        exit = true;
                        break;
                    default:
                        Output.PrintInvalidInputError();
                        break;
                }
                Output.PressAnyKey();
                Output.Clear();
            }
        }

        private static void SetupGame()
        {
            Output.Clear();
            Output.AskForName();
            string name = Input.GetUserInput();
            Game game = new();
            game.InitializePlayer(name);
            while (game.GameIsOn && game.Player.Alive)
            {
                GameLoop(game);
            }
        }

        private static void GameLoop(Game game)
        {
            Output.ShowOnScreen(game.ScreenViewportToString());
            MovementInput.GetPlayerMovement(game);
        }

        private static void ContinueGame()
        {
            Game game = new();
            Output.LoadingMessage();
            game.LoadGame(game);
            Output.LoadedMessage();
            while (game.GameIsOn && game.Player.Alive)
            {
                GameLoop(game);
            }
        }

        private static void ShowHighScores()
        {
            Output.NotImplementedException();
        }
    }
}