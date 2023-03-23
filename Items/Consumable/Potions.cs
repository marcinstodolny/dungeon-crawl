using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Consumable
{
    public class Potions : Abstract.Consumable
    {
        public Potions(Square square, string foodType) : base(square, "", ' ', 0)
        {
            PotionType(foodType);
        }

        public void PotionType(string potionType)
        {
            switch (potionType)
            {
                case "EnemiesTears":
                    Name = "Tears of your enemies";
                    MapSymbol = '\u104E';
                    HPrestore = 150;
                    break;
                case "EnemiesBlood":
                    Name = "Blood of your enemies";
                    MapSymbol = '\u104E';
                    HPrestore = 200;
                    break;
                case "GinAndTonic":
                    Name = "Gin & Tonic";
                    MapSymbol = '\u104E';
                    HPrestore = 50;
                    break;
                case "DMT":
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
