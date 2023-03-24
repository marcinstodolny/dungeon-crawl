using RoguelikeGame.Creatures;
using RoguelikeGame.DungeonManagement;
using System;

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

        public static void AskForName() 
        { 
            Console.WriteLine("Enter your name:"); 
        }

        public static void PrintDungeon(Dungeon dungeon)
        {
            Console.WriteLine(dungeon.DungeonToString());
        }

        public static void ShowBoardWithColors(Dungeon dungeon)
        {
            for (int y = 0; y < dungeon.Height; y++)
            {
                for (int x = 0; x < dungeon.Width; x++)
                {

                    Console.Write($"{dungeon.Board[x, y].GetCharacter()}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }

        public static void ShowItemMessage(Player player)
        {
            if (player.Square.Item != null)
            {
                Console.WriteLine($"Here is an {player.Square.Item.Name}, press E to pick up\n");
            }
        }

        public static void DisplayAllyMessage(Ally ally)
        {
            Console.WriteLine(ally.Message);
        }

        public static void DisplayEnemyInfo(Enemy enemy)
        {
            Console.WriteLine($"You encountered {enemy.Name} with {enemy.Health} health left\n");
        }

        public static void DisplayFight(Player player, Enemy enemy, bool miss=false)
        {
            if (!miss)
            {
                Console.WriteLine($"You have dealt {player.Damage} to enemy\n" +
                                  $"Enemy have dealt {enemy.Damage - player.Armor} to you");
            }
            else
            {
                Console.WriteLine($"You have dealt {player.Damage} to enemy\n" +
                                  $"Enemy have missed");
            }
        }

        public static void DisplayFightVictory(Enemy enemy)
        {
            Console.WriteLine($"You successfully defeated {enemy.Name}");
        }

        public static void DeadMessage()
        {
            Console.WriteLine($"Game Over\n" +
                              $"You have been slain");
        }

        public static void ShowYourInventory(Player player)
        {
            Console.WriteLine("Your inventory:");
            foreach (var item in player.Inventory)
            {
                Console.WriteLine($"{item.Key.Name}: {item.Value}");
            }
        }
        public static void DisplayItemPickup(Square square)
        {
            Console.WriteLine($"You have picked up {square.Item!.Name}");
            
        }
        public static void DisplayFoodEat(Square square)
        {
            Console.WriteLine($"You have ate {square.Item!.Name}");

        }

        public static void DisplayUserStats(Player player)
        {
            Console.WriteLine($"Health: {player.Health}\n" + $"Damage: {player.Damage}\n" + $"Armor: {player.Armor}");
        }

        public static void PressHForHelp()
        {
            Console.WriteLine("Press H for help\n");
        }

        public static void DisplayHelp()
        {
            Console.WriteLine("Available keys:\n" + "W,A,S,D: Player Move\n" + "I: Show inventory\n" 
                              + "E: Pickup item while standing on it\n" + "M: Map Legend\n" + "ESC: Quit to menu");
        }

        public static void DisplayMapLegend()
        {
            Console.WriteLine("Map Legend:\n" + "@: Player" + "$: Item\n" + "M: Monster (Enemy)\n"
                              + "A: Ally\n" + "#: Wall\n" + "+: Door\n" + "\x2588: Corridor\n");
        }
    }
}