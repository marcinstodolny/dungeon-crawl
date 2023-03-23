using RoguelikeGame.DungeonManagement;
using static RoguelikeGame.Items.Consumable.Potions;

namespace RoguelikeGame.Items.Consumable
{
    public class Food : Abstract.Consumable
    {
        public Food(FoodType foodType) : base("", ' ', 0)
        {
            SetFoodType(foodType);
        }

        public enum FoodType
        {
            Chicken,
            Steak,
            Apple,
            Sushi,
        }

        public void SetFoodType(FoodType foodType)
        {
            switch (foodType)
            {
                case FoodType.Chicken:
                    Name = "Dungeon chicken wings";
                    MapSymbol = '\u10EC';
                    HPrestore = 150;
                    break;
                case FoodType.Steak:
                    Name = "Perfectly good steak found on the floor";
                    MapSymbol = '\u10EC';
                    HPrestore = 250;
                    break;
                case FoodType.Apple:
                    Name = "Apple (an apple a day, keeps the doctor away)";
                    MapSymbol = '\u10EC';
                    HPrestore = 20;
                    break;
                case FoodType.Sushi:
                    Name = "Sushi mix set no.23 (I wonder who ordered it)";
                    MapSymbol = '\u10EC';
                    HPrestore = 150;
                    break;
                default:
                    Name = "Cave food (hard to recognize what is it)";
                    MapSymbol = '\u10EC';
                    HPrestore = 15;
                    break;
            }
        }

        public static void PlaceItem(Game game)
        {
            var enumLength = Enum.GetNames(typeof(FoodType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.dungeon);
            var item = new Food((FoodType)RandomGenerator.NextInt(enumLength));
            game.dungeon.Board[randX, randY].Item = item;
            game.dungeon.Board[randX, randY].Status = SquareStatus.Item;
        }

    }
}
