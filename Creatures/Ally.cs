using RoguelikeGame.DungeonManagement;


namespace RoguelikeGame.Creatures
{

    public class Ally : Creature
    {
        public int BonusDamage { get; set; } = 0;
        public int BonusHealth { get; set; } = 0;
        public string Message { get; set; }
        public Ally(AllyType allyType) : base("", ' ')
        {
            SetWeaponType(allyType);
        }
        public enum AllyType
        {
            Wizard,
            Warrior

        }
        public void SetWeaponType(AllyType allyType)
        {
            switch (allyType)
            {
                case AllyType.Wizard:
                    Name = "Merlin";
                    MapSymbol = 'W';
                    BonusHealth = 20;
                    Message = "Welcome to my house, I am merlin the wizard that will boost your health \nYou gained 20 bonus health";
                    break;
                case AllyType.Warrior:
                    Name = "David";
                    MapSymbol = 'W';
                    BonusDamage = 2;
                    Message = "Welcome to my house, I am David long time ago I was a warrior and now I can show you how to deal more damage to enemies \nYou gained 2 bonus damage";
                    break;
            }
        }
        public static void PlaceCreature(Game game)
        {
            var enumLength = Enum.GetNames(typeof(AllyType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var ally = new Ally((AllyType)RandomGenerator.NextInt(enumLength));
            game.Dungeon.Board[randX, randY].Creature = ally;
            game.Dungeon.Board[randX, randY].Status = SquareStatus.Ally;
        }


    }
}