using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoguelikeGame.Items.Abstract;

namespace RoguelikeGame.Items.Consumable
{
    public class Potions : Consumable
    {
        protected Potions(Square square, string name, char mapSymbol, int hpRestore) : base(square, name, mapSymbol, hpRestore) { }

        public EnemiesTears(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Tears of your enemies";
            mapSymbol = '\u104E';
            hpRestore = 150;
        }
        public EnemiesBlood(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Blood of your enemies";
            mapSymbol = '\u104E';
            hpRestore = 200;
        }

        public GinAndTonic(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Gin & Tonic";
            mapSymbol = '\u104E';
            hpRestore = 50;
        }
        public GarageDrink(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Garage drink";
            mapSymbol = '\u104E';
            hpRestore = 50;
        }

        public DMT(Square square, string name, char mapSymbol, int hpRestore) : base(square)
        {
            name = "Dimetylotryptamina";
            mapSymbol = '\u104E';
            hpRestore = 1000;
        }
    }
}
