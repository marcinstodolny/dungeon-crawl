using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;

namespace RoguelikeGame
{
    internal class Game
    {
        public List<Score> highScores;
        public Dungeon dungeon;

        public Game() 
        {
            highScores = new List<Score>();
            dungeon = new(10);
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

                switch (choice)
                {
                    case 1:
                        // new game
                        Display.PrintDungeon(game.dungeon);
                        break;
                    case 2:
                        // high scores
                        Display.PrintHighScores(game.highScores);
                        break;
                    case 3:
                        // exit
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
    }
}
