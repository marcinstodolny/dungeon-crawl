using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;
using RoguelikeGame;

namespace GameLogic.Entity.Interaction.Item.Consumable
{
    public class Food : Abstract.Consumable
    {
        public Food(Square square) : base("", ' ', 0, square)
        {
            var randomFood = DbManager.GetItem("HPRestore", "Foods");
            Name = randomFood["Name"];
            MapSymbol = randomFood["Symbol"].ToCharArray()[0];
            HPrestore = int.Parse(randomFood["Stat"]);
        }

        public static void PlaceItem(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var item = new Food(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = item;
        }
    }
}