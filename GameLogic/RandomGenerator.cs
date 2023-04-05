using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic
{
    internal class RandomGenerator
    {
        private static readonly Random Random = new();
        public static Coordinates FindRandomPlacement(Dungeon dungeon, Room room)
        {
            int randX = Random.Next(room.X + 1, room.X + room.Width - 1);
            int randY = Random.Next(room.Y + 1, room.Y + room.Height - 1);

            while (dungeon.Grid[randX, randY].Status != SquareStatus.Floor)
            {
                randX = Random.Next(room.X + 1, room.X + room.Width - 1);
                randY = Random.Next(room.Y + 1, room.Y + room.Height - 1);
            }

            return new Coordinates(randX, randY);
        }
        public static int NextInt(int max)
        {
            return Random.Next(max);
        }
    }
   
}
