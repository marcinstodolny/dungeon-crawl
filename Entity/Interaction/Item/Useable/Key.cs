using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Item.Useable
{

    public class Key : Abstract.Useable
    {
        public Key(Square square) : base(square)
        {
            var randomKey = DbManager.GetItem("", "Keys");
            Name = randomKey["Name"];
            MapSymbol = randomKey["Symbol"].ToCharArray()[0];
            Id = int.Parse(randomKey["Id"]);
        }

        public static void PlaceItem(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Key(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Interactive = item;
        }
    }
}
