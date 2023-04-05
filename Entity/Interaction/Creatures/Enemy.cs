using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Creatures
{

    public class Enemy : Abstract.Character
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public Enemy(Square square) : base(square)
        {
            var randomEnemy = DbManager.GetEnemy();
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

        public override string ApproachCharacter(Player player)
        {
            Health -= player.Damage;
            if (Health > 0)
            {
                if (Damage - player.Armor <= 0)
                {
                    return $"You have dealt {player.Damage} to enemy\n" +
                           $"Enemy have missed";
                }
                player.Health -= Damage - player.Armor;
                return player.Health <= 0 ? "Game Over\nYou have been slain"
                    : $"You have dealt {player.Damage} to enemy\n" +
                      $"Enemy have dealt {Damage - player.Armor} to you";
            }
            RemoveFromBoard();
            return $"You successfully defeated {Name}";
        }
    }
}
