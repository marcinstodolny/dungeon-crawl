using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Useable
{

    public class Armor : Abstract.Useable
    {
        public Armor(Square square, string armorType) : base(square, "", ' ', 0, 0)
        {
            ArmorType(armorType);
        }

        public void ArmorType(string armorType)
        {
            switch (armorType)
            {
                case "Gambeson":
                    Name = "Gambeson";
                    MapSymbol = '\u104E';
                    Armor = 10;
                    break;
                case "BoiledLeather":
                    Name = "Boiled leather";
                    MapSymbol = '\u104E';
                    Armor = 20;
                    break;
                case "ShellArmor":
                    Name = "Shell armor";
                    MapSymbol = '\u104E';
                    Armor = 50;
                    break;
                case "ScaleArmor":
                    Name = "Scale armor";
                    MapSymbol = '\u104E';
                    Armor = 70;
                    break;
                case "LaminarArmor":
                    Name = "Laminar armor";
                    MapSymbol = '\u104E';
                    Armor = 90;
                    break;
                case "PlatedMailArmor":
                    Name = "Plated mail armor";
                    MapSymbol = '\u104E';
                    Armor = 160;
                    break;
                case "MailArmor":
                    Name = "Mail armor";
                    MapSymbol = '\u104E';
                    Armor = 170;
                    break;
                case "BrigandineArmor":
                    Name = "Brigandine armor";
                    MapSymbol = '\u104E';
                    Armor = 180;
                    break;
                case "PlateArmor":
                    Name = "Plate armor";
                    MapSymbol = '\u104E';
                    Armor = 200;
                    break;
            }
        }


    }
}
