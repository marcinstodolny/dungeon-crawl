using RoguelikeGame.DungeonManagement;


namespace RoguelikeGame.Creatures
{

    public class Enemy : Creature
    {
        public int Damage { get; set; }
        public int Health { get; set; }
        public Enemy(enemyType enemyType) : base("", ' ')
        {
            SetWeaponType(enemyType);
        }
        public enum enemyType
        {
            Demon,
            Wolf

        }
        public void SetWeaponType(enemyType enemyType)
        {
            switch (enemyType)
            {
                case enemyType.Demon:
                    Name = "Demon";
                    MapSymbol = 'E';
                    Damage = 7;
                    Health = 20;
                    break;
                case enemyType.Wolf:
                    Name = "Wolf";
                    MapSymbol = 'E';
                    Damage = 8;
                    Health = 10;
                    break;
            }
        }
        public static void PlaceCreature(Game game)
        {
            var enumLength = Enum.GetNames(typeof(enemyType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var enemy = new Enemy((enemyType)RandomGenerator.NextInt(enumLength));
            game.Dungeon.Board[randX, randY].Creature = enemy;
            game.Dungeon.Board[randX, randY].Status = SquareStatus.Enemy;
        }


    }
}
