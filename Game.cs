using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;

namespace RoguelikeGame
{
    internal class Game
    {
        public List<Score> highScores;
        public Dungeon dungeon;
        public Player player;

        public Game()
        {
            highScores = new List<Score>();
        }

        public static void Menu()
        {
            Game game = new();
            ushort optionsCount = 3;
            bool exit = false;
            while (!exit)
            {
                Display.PrintMainMenu();
                ushort choice = Input.GetChoice(optionsCount);

                switch ((GameMenu)choice)
                {
                    case GameMenu.NewGame:
                        game.dungeon = new Dungeon();
                        SetGame(game);
                        break;
                    case GameMenu.HighScores:
                        Display.PrintHighScores(game.highScores);
                        break;
                    case GameMenu.Exit:
                        Display.PrintExitGame();
                        exit = true;
                        break;
                    default:
                        // invalid input
                        Display.PrintInvalidInputError();
                        break;
                }
                Display.PressAnyKey();
                Input.WaitForInput();
                Display.Clear();
            }
        }

        private static void SetGame(Game game)
        {
            Display.Clear();
            Display.AskForName();
            string playerName = Input.GetUserInput();
            game.player = new Player(playerName);
            game.dungeon.PlayerPlacement(game.player);
            bool gameplay = true;
            while (gameplay)
            {
                gameplay = GameLoop(game.dungeon, game.player);
            }
        }

        private static bool GameLoop(Dungeon dungeon, Player player)
        {
            Display.Clear();
            Display.PrintDungeon(dungeon);
            ConsoleKeyInfo playerMove = Input.GetPlayerMovement();
            return player.Move(dungeon, playerMove);
        }
    }
}
