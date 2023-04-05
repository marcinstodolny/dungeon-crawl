using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Creatures
{

    public class Enemy : Abstract.Character
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public Enemy(Square square) : base(square, "", ' ')
        {
            var randomEnemy = ItemsDbManager.GetEnemy();
            Name = randomEnemy["Name"];
            MapSymbol = randomEnemy["Symbol"].ToCharArray()[0];
            Damage = int.Parse(randomEnemy["Damage"]);
            Health = int.Parse(randomEnemy["Health"]);
        }

        public static void PlaceCreature(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var enemy = new Enemy(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Interactive = enemy;
        }


    }
}
