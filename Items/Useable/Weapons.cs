using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Consumable;
using static RoguelikeGame.Items.Consumable.Food;

namespace RoguelikeGame.Items.Useable
{

    public class Weapons : Abstract.Useable
    {
        public Weapons(weaponType weaponType) : base("", ' ', 0, 0)
        {
            SetWeaponType(weaponType);
        }
        public enum weaponType
        {
            PooStick,
            RustyPan,
            Club,
            ShortSword,
            ShortSAxe,
            LongSword,
            LongAxe,
            Hammer,
            Claymore

        }
        public void SetWeaponType(weaponType weaponType)
        {
            switch (weaponType)
            {
                case weaponType.PooStick:
                    Name = "Ultimate weapon - stick with a poo at the en";
                    MapSymbol = '$';
                    Attack = 500;
                    break;
                case weaponType.RustyPan:
                    Name = "Slightly rusted pan";
                    MapSymbol = '$';
                    Attack = 2;
                    break;
                case weaponType.Club:
                    Name = "Club (Welcome to the club)";
                    MapSymbol = '$';
                    Attack = 3;
                    break;
                case weaponType.ShortSword:
                    Name = "Short sword (looks big in small hands)";
                    MapSymbol = '$';
                    Attack = 4;
                    break;
                case weaponType.ShortSAxe:
                    Name = "Short axe";
                    MapSymbol = '$';
                    Attack = 5;
                    break;
                case weaponType.LongSword:
                    Name = "Loooong sword";
                    MapSymbol = '$';
                    Attack = 6;
                    break;
                case weaponType.LongAxe:
                    Name = "Long axe";
                    MapSymbol = '$';
                    Attack = 7;
                    break;
                case weaponType.Hammer:
                    Name = "Hammer time";
                    MapSymbol = '$';
                    Attack = 8;
                    break;
                case weaponType.Claymore:
                    Name = "Claymore";
                    MapSymbol = '$';
                    Attack = 9;
                    break;
            }
        }
        public static void PlaceItem(Game game)
        {
            var enumLength = Enum.GetNames(typeof(weaponType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Weapons((weaponType)RandomGenerator.NextInt(enumLength));
            game.Dungeon.Board[randX, randY].Item = item;
            game.Dungeon.Board[randX, randY].Status = SquareStatus.Item;
        }


    }
}
