using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Interaction.Character
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

        public static void PlaceCreature(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var enemy = new Enemy(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = enemy;
        }

        public override string ApproachCharacter(Player player)
        {
            Health -= player.Damage;
            if (Health > 0)
            {
                if (Damage - player.Armor <= 0)
                {
                    return $"You have dealt {player.Damage} to enemy\n" +
                           $"\nEnemy have missed";
                }
                player.Health -= Damage - player.Armor;
                return !player.Alive ? "Game Over\nYou have been slain"
                    : $"You have dealt {player.Damage} to enemy\n" +
                      $"\nEnemy have dealt {Damage - player.Armor} to you";
            }
            RemoveFromBoard();
            return $"You successfully defeated {Name}";
        }
    }
}
