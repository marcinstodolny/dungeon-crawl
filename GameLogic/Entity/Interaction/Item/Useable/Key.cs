using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;
using RoguelikeGame;

namespace GameLogic.Entity.Interaction.Item.Useable
{
    public class Key : Abstract.Useable
    {
        public Key(Square square) : base("", ' ', square)
        {
            var randomKey = DbManager.GetItem("", "Keys");
            Name = randomKey["Name"];
            MapSymbol = randomKey["Symbol"].ToCharArray()[0];
        }

        public static void PlaceItem(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var item = new Key(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = item;
        }
    }
}
