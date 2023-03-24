using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Consumable;
using static RoguelikeGame.Items.Consumable.Food;

namespace RoguelikeGame.Items.Useable
{

    public class Armor : Abstract.Useable
    {
        public Armor(armorType armorType) : base("", ' ', 0, 0)
        {
            SetArmorType(armorType);
        }
        public enum armorType
        {
            Gambeson,
            BoiledLeather,
            ShellArmor,
            ScaleArmor,
            LaminarArmor,
            PlatedMailArmor,
            MailArmor,
            BrigandineArmor, 
            PlateArmor
        }
        public void SetArmorType(armorType armorType)
        {
            switch (armorType)
            {
                case armorType.Gambeson:
                    Name = "Gambeson";
                    MapSymbol = '\u104E';
                    Armor = 2;
                    break;
                case armorType.BoiledLeather:
                    Name = "Boiled leather";
                    MapSymbol = '\u104E';
                    Armor = 4;
                    break;
                case armorType.ShellArmor:
                    Name = "Shell armor";
                    MapSymbol = '\u104E';
                    Armor = 6;
                    break;
                case armorType.ScaleArmor:
                    Name = "Scale armor";
                    MapSymbol = '\u104E';
                    Armor = 8;
                    break;
                case armorType.LaminarArmor:
                    Name = "Laminar armor";
                    MapSymbol = '\u104E';
                    Armor = 9;
                    break;
                case armorType.PlatedMailArmor:
                    Name = "Plated mail armor";
                    MapSymbol = '\u104E';
                    Armor = 10;
                    break;
                case armorType.MailArmor:
                    Name = "Mail armor";
                    MapSymbol = '\u104E';
                    Armor = 12;
                    break;
                case armorType.BrigandineArmor:
                    Name = "Brigandine armor";
                    MapSymbol = '\u104E';
                    Armor = 14;
                    break;
                case armorType.PlateArmor:
                    Name = "Plate armor";
                    MapSymbol = '\u104E';
                    Armor = 16;
                    break;
            }
        }
        public static void PlaceItem(Game game)
        {
            var enumLength = Enum.GetNames(typeof(armorType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Armor((armorType)RandomGenerator.NextInt(enumLength));
            game.Dungeon.Board[randX, randY].Item = item;
            game.Dungeon.Board[randX, randY].Status = SquareStatus.Item;
        }


    }
}
