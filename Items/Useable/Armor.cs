using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Useable
{
    
    public class Armor : Abstract.Useable
    {
        public string Type;
        protected Armor(Square square, string name, char mapSymbol, int attack, int armor, string armorType) : base(
            square, name, mapSymbol, attack, armor)
        {
            Type = armorType;
        }

        public void ArmorType(string armorType)
        {
            switch (armorType)
            {
                case "Gambeson":
                    this.Name = "Gambeson";
                    this.MapSymbol = '\u104E';
                    this.Armor = 10;
                    break;
                case "BoiledLeather":
                    this.Name = "Boiled leather";
                    this.MapSymbol = '\u104E';
                    this.Armor = 20;
                    break;
                case "ShellArmor":
                    this.Name = "Shell armor";
                    this.MapSymbol = '\u104E';
                    this.Armor = 50;
                    break;
                case "ScaleArmor":
                    this.Name = "Scale armor";
                    this.MapSymbol = '\u104E';
                    this.Armor = 70;
                    break;
                case "LaminarArmor":
                    this.Name = "Laminar armor";
                    this.MapSymbol = '\u104E';
                    this.Armor = 90;
                    break;
                case "PlatedMailArmor":
                    this.Name = "Plated mail armor";
                    this.MapSymbol = '\u104E';
                    this.Armor = 160;
                    break;
                case "MailArmor":
                    this.Name = "Mail armor";
                    this.MapSymbol = '\u104E';
                    this.Armor = 170;
                    break;
                case "BrigandineArmor":
                    this.Name = "Brigandine armor";
                    this.MapSymbol = '\u104E';
                    this.Armor = 180;
                    break;
                case "PlateArmor":
                    this.Name = "Plate armor";
                    this.MapSymbol = '\u104E';
                    this.Armor = 200;
                    break;
            }
        }


    }
}
