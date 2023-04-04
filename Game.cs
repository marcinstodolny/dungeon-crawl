using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;
using Microsoft.Data.SqlClient;
using System.Configuration;
using RoguelikeGame.Entity.Consumable;
using RoguelikeGame.Entity.Creatures;
using RoguelikeGame.Entity.Useable;

namespace RoguelikeGame
{
    public class Game
    {
        public string ConnectionString => ConfigurationManager.AppSettings["connectionString"]!;
        public List<Score> HighScores;
        public Dungeon Dungeon;
        public Player Player;
        public int NumberOfItems = 3;
        public int NumberOfCreatures = 5;

        public Game()
        {
            HighScores = new List<Score>();
        }

        public static void Menu()
        {
            Game game = new();
            var testConnection = game.TestConnection();
            ushort optionsCount = 3;
            bool exit = false;
            while (!exit)
            {
                ushort choice = Input.GetChoice(optionsCount);

                switch ((GameMenu)choice)
                {
                    case GameMenu.NewGame:
                        game.Dungeon = new Dungeon();
                        game.SetupGame();
                        break;
                    case GameMenu.HighScores:
                        Display.PrintHighScores(game.HighScores);
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
                Input.WaitForKeyPress();
                Display.Clear();
            }
        }

        private void SetupGame()
        {
            Display.Clear();
            Display.AskForName();
            Player = Dungeon.PlayerPlacement(Input.GetUserInput());
            SetupItem();
            SetupEnemiesAndAlly();
            bool gamePlay = true;
            while (gamePlay && Player.Alive)
            {
                gamePlay = GameLoop();
            }
        }

        private bool GameLoop()
        {
            Display.Clear();
            Display.PrintDungeon(Dungeon);
            Display.DisplayUserStats(Player);
            Display.PressHForHelp();
            Display.ShowItemMessage(Player);
            ConsoleKeyInfo playerMove = Input.WaitForKeyPress();
            return Player.Control(Dungeon, playerMove);
        }

        private void SetupItem()
        {
            for (var i = 0; i < NumberOfItems; i++)
            {
                Armor.PlaceItem(this);
                Key.PlaceItem(this);
                Weapons.PlaceItem(this);
                Food.PlaceItem(this);
                Potions.PlaceItem(this);
            }
        }
        private void SetupEnemiesAndAlly()
        {
            for (var i = 0; i < NumberOfCreatures; i++)
            {
                Enemy.PlaceCreature(this);
                Ally.PlaceCreature(this);
            }
        }

        public bool TestConnection()
        {
            using var connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

}
