using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Useable
{

    public class Weapons : Abstract.Useable
    {
        public int Attack;
        public Weapons(Square square) : base("", ' ', square)
        {
            var randomWeapon = ItemsDbManager.GetItem("Attack", "Weapons");
            Name = randomWeapon["Name"];
            MapSymbol = randomWeapon["Symbol"].ToCharArray()[0];
            Attack = int.Parse(randomWeapon["Stat"]);
        }

        public static void PlaceItem(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Weapons(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Entity = item;
        }
    }
}
