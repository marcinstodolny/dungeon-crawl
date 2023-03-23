using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Consumable
{
    public class Food : Abstract.Consumable
    {
        public Food(Square square,string foodType) : base(square, "", ' ', 0)
        {
            FoodType(foodType);
        }

        public void FoodType(string foodType)
        {
            switch (foodType)
            {
                case "chicken":
                    Name = "Dungeon chicken wings";
                    MapSymbol = '\u10EC';
                    HPrestore = 150;
                    break;
                case "steak":
                    Name = "Perfectly good steak found on the floor";
                    MapSymbol = '\u10EC';
                    HPrestore = 250;
                    break;
                case "apple":
                    Name = "Apple (an apple a day, keeps the doctor away)";
                    MapSymbol = '\u10EC';
                    HPrestore = 20;
                    break;
                case "sushi":
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

    }
}
