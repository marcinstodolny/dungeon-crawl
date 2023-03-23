using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;
using System.Xml.Linq;
using RoguelikeGame.Items.Consumable;
using RoguelikeGame.Items.Useable;
using System;
using static RoguelikeGame.Items.Consumable.Food;

namespace RoguelikeGame
{
    public class Game
    {
        public List<Score> highScores;
        public Dungeon dungeon;
        public Player player;
        public static int NumberOfItems = 3;

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
            SetupItem(game);
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
            Display.ShowItemMessage(player);
            ConsoleKeyInfo playerMove = Input.GetPlayerMovement();
            return player.Move(dungeon, playerMove);
        }

        private static void SetupItem(Game game)
        {
            for (var i = 0; i < NumberOfItems; i++)
            {
                
            }
        }
    }

}
