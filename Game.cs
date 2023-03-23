using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;
using RoguelikeGame.Items.Consumable;
using RoguelikeGame.Items.Useable;

namespace RoguelikeGame
{
    public class Game
    {
        public List<Score> highScores;
        public Dungeon dungeon;
        public Player player;
        public int NumberOfItems = 3;

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
                        game.SetupGame();
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

        private void SetupGame()
        {
            Display.Clear();
            Display.AskForName();
            player = dungeon.PlayerPlacement(Input.GetUserInput());
            SetupItem();
            bool gamePlay = true;
            while (gamePlay)
            {
                gamePlay = GameLoop();
            }
        }

        private bool GameLoop()
        {
            Display.Clear();
            Display.PrintDungeon(dungeon);
            Display.ShowItemMessage(player);
            ConsoleKeyInfo playerMove = Input.GetPlayerMovement();
            return player.Move(dungeon, playerMove);
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
    }

}
