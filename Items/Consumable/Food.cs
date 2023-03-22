using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Abstract;

namespace RoguelikeGame.Items.Consumable
{
    public class Food : Abstract.Consumable
    {

        public Food(Square square, string name, char mapSymbol, int hpRestore, string foodType) : base(square, name,
            mapSymbol, hpRestore)
        {
            FoodType = foodType;
        }

        public void FoodType(string foodType)
        {
            switch (foodType)
            {
                case "chicken":
                    this.Name = "Dungeon chicken wings";
                    this.MapSymbol = '\u10EC';
                    this.HPrestore = 150;
                    break;
                case "steak":
                    this.Name = "Perfectly good steak found on the floor";
                    this.MapSymbol = '\u10EC';
                    this.HPrestore = 250;
                    break;
                case "apple":
                    this.Name = "Apple (an apple a day, keeps the doctor away)";
                    this.MapSymbol = '\u10EC';
                    this.HPrestore = 20;
                    break;
                case "sushi":
                    this.Name = "Sushi mix set no.23 (I wonder who ordered it)";
                    this.MapSymbol = '\u10EC';
                    this.HPrestore = 150;
                    break;
                default:
                    this.Name = "Cave food (hard to recognize what is it)";
                    this.MapSymbol = '\u10EC';
                    this.HPrestore = 15;
                    break;
            }
        }

    }
}
