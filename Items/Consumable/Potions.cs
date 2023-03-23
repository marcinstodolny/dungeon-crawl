using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoguelikeGame.Items.Abstract;
using RoguelikeGame.DungeonManagement;
using System.Xml.Linq;

namespace RoguelikeGame.Items.Consumable
{
    public class Potions : Abstract.Consumable
    {
        public string Type;

        protected Potions(Square square, string name, char mapSymbol, int hpRestore, string potionType) : base(square, name, mapSymbol,
            hpRestore)
        {
            Type = potionType;
        }

        public void PotionType(string potionType)
        {
            switch (potionType)
            {
                case "EnemiesTears":
                    this.Name = "Tears of your enemies";
                    this.MapSymbol = '\u104E';
                    this.HPrestore = 150;
                    break;
                case "EnemiesBlood":
                    this.Name = "Blood of your enemies";
                    this.MapSymbol = '\u104E';
                    this.HPrestore = 200;
                    break;
                case "GinAndTonic":
                    this.Name = "Gin & Tonic";
                    this.MapSymbol = '\u104E';
                    this.HPrestore = 50;
                    break;
                case "DMT":
                    this.Name = "Dimetylotryptamina";
                    this.MapSymbol = '\u104E';
                    this.HPrestore = 1000;
                    break;
                default:
                    this.Name = "Dungeon water";
                    this.MapSymbol = '\u104E';
                    this.HPrestore = 1;
                    break;
            }
        }
    }
}
