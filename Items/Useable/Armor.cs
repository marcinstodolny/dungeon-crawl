﻿using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Consumable;
using static RoguelikeGame.Items.Consumable.Food;

namespace RoguelikeGame.Items.Useable
{

    public class Armor : Abstract.Useable
    {
        public Armor(string armorType) : base("", ' ', 0, 0)
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
        public void PlaceItem(Game game) // change type
        {
            var enumLength = Enum.GetNames(typeof(FoodType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.dungeon);
            var item = new Food((FoodType)RandomGenerator.NextInt(enumLength));
            game.dungeon.Board[randX, randY].Item = item;
        }


    }
}
