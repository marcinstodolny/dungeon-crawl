using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Item.Consumable
{
    public class Food : Abstract.Consumable
    {
        public Food(Square square) : base(square)
        {
            var randomFood = DbManager.GetItem("HPRestore", "Foods");
            Name = randomFood["Name"];
            MapSymbol = randomFood["Symbol"].ToCharArray()[0];
            HPrestore = int.Parse(randomFood["Stat"]);
        }

        public static void PlaceItem(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Food(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Interactive = item;
        }
        public override string Interact(Player player)
        {
            player.Health += HPrestore;
            RemoveFromBoard();
            return $"You have eat {Name}";
        }
    }
}
