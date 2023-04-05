using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Interaction.Item.Useable
{
    public class Weapons : Abstract.Useable
    {
        public int Damage;
        public Weapons(Square square) : base(square)
        {
            var randomWeapon = DbManager.GetItem("Attack", "Weapons");
            Name = randomWeapon["Name"];
            MapSymbol = randomWeapon["Symbol"].ToCharArray()[0];
            Damage = int.Parse(randomWeapon["Stat"]);
            Id = int.Parse(randomWeapon["Id"]);
        }

        public static void PlaceItem(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var item = new Weapons(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = item;
        }

        public override string Interact(Player player)
        {
            AddToInventory(player);
            player.Damage += Damage;
            RemoveFromBoard();
            return $"You have picked up {Name}";
        }
    }
}
