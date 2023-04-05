using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Item.Useable
{

    public class Armor : Abstract.Useable
    {
        public int Protection;
        public Armor(Square square) : base("", ' ', square)
        {
            var randomArmor = DbManager.GetItem("Armor", "Armors");
            Name = randomArmor["Name"];
            MapSymbol = randomArmor["Symbol"].ToCharArray()[0];
            Protection = int.Parse(randomArmor["Stat"]);
            Id = int.Parse(randomArmor["Id"]);
        }

        public static void PlaceItem(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Armor(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Interactive = item;
        }


    }
}
