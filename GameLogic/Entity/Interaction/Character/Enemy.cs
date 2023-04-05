using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;
using RoguelikeGame;

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
    }
}
