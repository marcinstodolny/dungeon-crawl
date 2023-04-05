using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;
using RoguelikeGame;

namespace GameLogic.Entity.Interaction.Item.Useable
{
    public class Weapons : Abstract.Useable
    {
        public int Attack;
        public Weapons(Square square) : base("", ' ', square)
        {
            var randomWeapon = DbManager.GetItem("Attack", "Weapons");
            Name = randomWeapon["Name"];
            MapSymbol = randomWeapon["Symbol"].ToCharArray()[0];
            Attack = int.Parse(randomWeapon["Stat"]);
        }

        public static void PlaceItem(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var item = new Weapons(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = item;
        }
    }
}
