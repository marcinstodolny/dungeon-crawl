using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoguelikeGame.Items.Abstract;

namespace RoguelikeGame.Items.Consumable
{
    public class Food : Consumable
    {
        protected Food(Square square, string name, char mapSymbol, int hpRestore) : base(square, name, mapSymbol, hpRestore) { }

        public ChickenWings(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Dungeon chicken wings";
            mapSymbol = '\u10EC';
            hpRestore = 150;
        }
        public MediumRareSteak(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Perfectly good steak found on the floor";
            mapSymbol = '\u10EC';
            hpRestore = 250;
        }
        public Apple(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Apple (an apple a day, keeps the doctor away)";
            mapSymbol = '\ud1bc';
            hpRestore = 20;
        }
        public Sushi(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Sushi mix set no.23 (I wonder who ordered it)";
            mapSymbol = '\u10EC';
            hpRestore = 200;
        }
    }
}
