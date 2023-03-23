using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Consumable
{
    public class Potions : Abstract.Consumable
    {
        public Potions(Square square, PotionType foodType) : base(square, "", ' ', 0)
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
                    HPrestore = 150;
                    break;
                case PotionType.EnemiesBlood:
                    Name = "Blood of your enemies";
                    MapSymbol = '\u104E';
                    HPrestore = 200;
                    break;
                case PotionType.GinAndTonic:
                    Name = "Gin & Tonic";
                    MapSymbol = '\u104E';
                    HPrestore = 50;
                    break;
                case PotionType.DMT:
                    Name = "Dimetylotryptamina";
                    MapSymbol = '\u104E';
                    HPrestore = 1000;
                    break;
                default:
                    Name = "Dungeon water";
                    MapSymbol = '\u104E';
                    HPrestore = 1;
                    break;
            }
        }
    }
}
