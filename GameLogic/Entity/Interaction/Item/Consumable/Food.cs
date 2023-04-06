using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Interaction.Item.Consumable
{
    public class Food : Abstract.Consumable
    {
        public Food(Square square) : base(square)
        {
            var randomFood = DbManager.GetItem("HPRestore", "Foods");
            Name = randomFood["Name"];
            MapSymbol = randomFood["Symbol"].ToCharArray()[0];
            HPrestore = int.Parse(randomFood["Stat"]);
            Id = int.Parse(randomFood["Id"]);
        }

        public static void PlaceItem(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var item = new Food(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = item;
        }

        public override string Interact(Player player)
        {
            player.Health += HPrestore;
            RemoveFromBoard();
            return $"You eat {Name}";
        }
    }
}