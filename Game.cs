using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;

namespace RoguelikeGame
{
    internal class Game
    {
        public List<Score> highScores;

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

                switch (choice)
                {
                    case 1:
                        // new game
                        var dungeon = new Dungeon(10);
                        Console.WriteLine(dungeon.Board[1, 1].Status);
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
