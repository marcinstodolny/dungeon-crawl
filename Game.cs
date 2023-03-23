using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;
using System.Xml.Linq;
using RoguelikeGame.Items.Useable;

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
                        SetupGame(game);
                        break;
                    case GameMenu.HighScores:
                        Display.PrintHighScores(game.highScores);
                        break;
                    case GameMenu.Exit:
                        Display.PrintExitGame();
                        exit = true;
                        break;
                    default:
                        Display.PrintInvalidInputError();
                        break;
                }
                Display.PressAnyKey();
                Input.WaitForInput();
                Display.Clear();
            }
        }

        private static void SetupGame(Game game)
        {
            Display.Clear();
            Display.AskForName();
            game.player = game.dungeon.PlayerPlacement(Input.GetUserInput());
            (int randX, int randY) = RandomGenerator.FindRandomPlacement(game.dungeon); 
            var item = new Armor(game.dungeon.Board[randX, randY], "Gambeson");
            game.dungeon.Board[randX, randY].Item = item;
            bool gamePlay = true;
            while (gamePlay)
            {
                gamePlay = GameLoop(game.dungeon, game.player);
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
