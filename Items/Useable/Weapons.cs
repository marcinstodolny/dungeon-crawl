using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Consumable;
using static RoguelikeGame.Items.Consumable.Food;

namespace RoguelikeGame.Items.Useable
{

    public class Weapons : Abstract.Useable
    {
        public Weapons(string weaponType) : base("", ' ', 0, 0)
        {
            WeaponType(weaponType);
        }

        public void WeaponType(string weaponType)
        {
            switch (weaponType)
            {
                case "PooStick":
                    Name = "Ultimate weapon - stick with a poo at the en";
                    MapSymbol = '\u2694';
                    Attack = 500;
                    break;
                case "RustyPan":
                    Name = "Slightly rusted pan";
                    MapSymbol = '\u2694';
                    Attack = 15;
                    break;
                case "Club":
                    Name = "Club (Welcome to the club)";
                    MapSymbol = '\u2694';
                    Attack = 20;
                    break;
                case "ShortSword":
                    Name = "Short sword (looks big in small hands)";
                    MapSymbol = '\u2694';
                    Attack = 30;
                    break;
                case "ShortSAxe":
                    Name = "Short axe";
                    MapSymbol = '\u2694';
                    Attack = 40;
                    break;
                case "LongSword":
                    Name = "Loooong sword";
                    MapSymbol = '\u2694';
                    Attack = 50;
                    break;
                case "LongAxe":
                    Name = "Long axe";
                    MapSymbol = '\u2694';
                    Attack = 60;
                    break;
                case "Hammer":
                    Name = "Hammer time";
                    MapSymbol = '\u2694';
                    Attack = 65;
                    break;
                case "Claymore":
                    Name = "Claymore";
                    MapSymbol = '\u2694';
                    Attack = 70;
                    break;
            }
        }
        public void PlaceItem(Game game) // change type
        {
            var enumLength = Enum.GetNames(typeof(FoodType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.dungeon);
            var item = new Food((FoodType)RandomGenerator.NextInt(enumLength));
            game.dungeon.Board[randX, randY].Item = item;
        }


    }
}
