using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame
{
    internal class RandomGenerator
    {
        private static readonly Random Random = new();
        public static (int, int) FindRandomPlacement(Dungeon dungeon)
        {
            int randX = Random.Next(dungeon.Width);
            int randY = Random.Next(dungeon.Height);
            while (dungeon.Board[randX, randY].Status != SquareStatus.Floor || dungeon.Board[randX, randY].Interactive != null)
            {
                randX = Random.Next(dungeon.Width);
                randY = Random.Next(dungeon.Height);
            }
            return (randX, randY);
        }
        public static int NextInt(int max)
        {
            return Random.Next(max);
        }
    }
   
}
