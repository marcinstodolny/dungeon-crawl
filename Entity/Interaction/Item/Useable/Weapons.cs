using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Item.Useable
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

        public static void PlaceItem(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Weapons(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Interactive = item;
        }
        public override string PickUp(Player player)
        {
            AddToInventory(player);
            player.Damage += Damage;
            RemoveFromBoard();
            return $"You have picked up {Name}";
        }
    }
}
