using RoguelikeGame.DungeonManagement;
using static RoguelikeGame.Items.Consumable.Food;

namespace RoguelikeGame.Items.Consumable
{
    public class Potions : Abstract.Consumable
    {
        public Potions(PotionType foodType) : base("", ' ', 0)
        {
            SetPotionType(foodType);
        }

        public enum PotionType
        {
            EnemiesTears,
            EnemiesBlood,
            GinAndTonic,
            DMT,
        }

        public void SetPotionType(PotionType potionType)
        {
            switch (potionType)
            {
                case PotionType.EnemiesTears:
                    Name = "Tears of your enemies";
                    MapSymbol = '\u104E';
                    HPrestore = 10;
                    break;
                case PotionType.EnemiesBlood:
                    Name = "Blood of your enemies";
                    MapSymbol = '\u104E';
                    HPrestore = 15;
                    break;
                case PotionType.GinAndTonic:
                    Name = "Gin & Tonic";
                    MapSymbol = '\u104E';
                    HPrestore = 5;
                    break;
                case PotionType.DMT:
                    Name = "Dimetylotryptamina";
                    MapSymbol = '\u104E';
                    HPrestore = 100;
                    break;
                default:
                    Name = "Dungeon water";
                    MapSymbol = '\u104E';
                    HPrestore = 1;
                    break;
            }
        }
        public static void PlaceItem(Game game)
        {
            var enumLength = Enum.GetNames(typeof(PotionType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Potions((PotionType)RandomGenerator.NextInt(enumLength));
            game.Dungeon.Board[randX, randY].Item = item;
            game.Dungeon.Board[randX, randY].Status = SquareStatus.Item;
        }
    }
}
