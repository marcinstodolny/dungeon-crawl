using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Useable
{

    public class Weapons : Abstract.Useable
    {
        public Weapons(Square square, string weaponType) : base(square, "", ' ', 0, 0)
        {
            WeaponType(weaponType);
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
                    MapSymbol = '\u2694';
                    Attack = 500;
                    break;
                case weaponType.RustyPan:
                    Name = "Slightly rusted pan";
                    MapSymbol = '\u2694';
                    Attack = 15;
                    break;
                case weaponType.Club:
                    Name = "Club (Welcome to the club)";
                    MapSymbol = '\u2694';
                    Attack = 20;
                    break;
                case weaponType.ShortSword:
                    Name = "Short sword (looks big in small hands)";
                    MapSymbol = '\u2694';
                    Attack = 30;
                    break;
                case weaponType.ShortSAxe:
                    Name = "Short axe";
                    MapSymbol = '\u2694';
                    Attack = 40;
                    break;
                case weaponType.LongSword:
                    Name = "Loooong sword";
                    MapSymbol = '\u2694';
                    Attack = 50;
                    break;
                case weaponType.LongAxe:
                    Name = "Long axe";
                    MapSymbol = '\u2694';
                    Attack = 60;
                    break;
                case weaponType.Hammer:
                    Name = "Hammer time";
                    MapSymbol = '\u2694';
                    Attack = 65;
                    break;
                case weaponType.Claymore:
                    Name = "Claymore";
                    MapSymbol = '\u2694';
                    Attack = 70;
                    break;
            }
        }
        

    }
}
