using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoguelikeGame.Items.Abstract;

namespace RoguelikeGame.Items.Useable
{
    public class Weapons : Useable
    {
        protected Weapons(Square square, string name, char mapSymbol, int attack, int armor) : base(square, name, mapSymbol, attack, armor) { }

        public PooStick(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Ultimate weapon - stick with a poo at the end";
            mapSymbol = '\u2694';
            attack = 500;
        }

        public RustyPan(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Slightly rusted pan";
            mapSymbol = '\u2694';
            attack = 15;
        }

        public Club(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Club (Welcome to the club)";
            mapSymbol = '\u2694';
            attack = 20;
        }

        public ShortSword(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Short sword (looks big in small hands)";
            mapSymbol = '\u2694';
            attack = 30;
        }

        public ShortSAxe(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Short axe";
            mapSymbol = '\u2694';
            attack = 40;
        }

        public LongSword(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Loooong sword";
            mapSymbol = '\u2694';
            attack = 50;
        }

        public LongAxe(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Long axe";
            mapSymbol = '\u2694';
            attack = 60;
        }

        public Hammer(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Hammer time";
            mapSymbol = '\u2694';
            attack = 65;
        }

        public Claymore(Square square, string name, char mapSymbol, int attack) : base(square)
        {
            name = "Claymore";
            mapSymbol = '\u2694';
            attack = 70;
        }



    }
}
