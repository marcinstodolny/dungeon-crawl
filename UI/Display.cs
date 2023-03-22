using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.UI
{
    internal class Display
    {
        public static void PrintInvalidInputError()
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
        }
        public static void Clear()
        {
            Console.Clear();
        }

        public static void PrintMainMenu()
        {
            Clear();
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. High Scores");
            Console.WriteLine("3. Exit");
        }

        public static void PrintHighScores(List<Score> highScores)
        {
            Clear();
            if (highScores.Count == 0)
            {
                Console.WriteLine("There are no scores yet. Be the first!");
                return;
            }

            Console.WriteLine("High scores:");
            for (int i = 0; i < highScores.Count; i++)
            {
                Score score = highScores[i];
                Console.WriteLine($"{i + 1}. Score: {score.FinalScore}, Player Name: {score.Name}");
            }
        }

        public static void PrintExitGame()
        {
            Clear();
            Console.WriteLine("Goodbye!");
        }

        public static void PrintDungeon(Dungeon dungeon)
        {
            Console.WriteLine();
        }

        public static void ShowBoard()
        {
            Console.WriteLine();
        }
    }
}
