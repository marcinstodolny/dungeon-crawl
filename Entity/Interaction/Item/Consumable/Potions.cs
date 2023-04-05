using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Item.Consumable
{
    public class Potions : Abstract.Consumable
    {
        public Potions(Square square) : base("", ' ', 0, square)
        {
            var randomPotion = ItemsDbManager.GetItem("HPRestore", "Potions");
            Name = randomPotion["Name"];
            MapSymbol = randomPotion["Symbol"].ToCharArray()[0];
            HPrestore = int.Parse(randomPotion["Stat"]);
        }
        public static void PlaceItem(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Potions(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Interactive = item;
        }
    }
}
