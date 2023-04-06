using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Interaction.Item.Useable
{
    public class Keys : Abstract.Useable
    {
        public Keys(Square square) : base(square)
        {
            var randomKey = DbManager.GetItem("", "Keys");
            Name = randomKey["Name"];
            MapSymbol = randomKey["Symbol"].ToCharArray()[0];
            Id = int.Parse(randomKey["Id"]);
        }

        public static void PlaceItem(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var item = new Keys(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = item;
        }

        public override string Interact(Player player)
        {
            AddToInventory(player);
            RemoveFromBoard();
            return $"\nYou have picked up {Name}";
        }
    }
}
