using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Item.Consumable
{
    public class Potions : Abstract.Consumable
    {
        public Potions(Square square) : base(square)
        {
            var randomPotion = DbManager.GetItem("HPRestore", "Potions");
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
        public override string Interact(Player player)
        {
            player.Health += HPrestore;
            RemoveFromBoard();
            if (Name != "Dimetylotryptamina")
            {
                return $"You have eat {Name}";
            }
            player.DMT = true;
            return $"Enjoy the Ride";
        }
    }
}
