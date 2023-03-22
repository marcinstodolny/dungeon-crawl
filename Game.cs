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
            dungeon = new Dungeon();
            player = new Player();
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
                        GameLoop(game);
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

        private static void GameLoop(Game game)
        {
            Player player = game.player;
            Dungeon dungeon = game.dungeon;
            dungeon.PlayerPlacement(player);
            bool gameplay = true;
            while (gameplay)
            {
                Display.Clear();
                Display.PrintDungeon(dungeon);
                ConsoleKeyInfo playerMove = Input.GetPlayerMovement();
                player.Move(dungeon, playerMove);
            }
        }
    }
}
