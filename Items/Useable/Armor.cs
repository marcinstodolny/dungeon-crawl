using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeGame.Items.Useable
{
    public class Armor : Useable
    {
        protected Armor(Square square, string name, char mapSymbol, int attack, int armor) : base(square, name, mapSymbol, attack, armor) { }

        public Gambeson(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Gambeson";
            mapSymbol = '\u2720';
            armor = 10;
        }

        public BoiledLeather(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Boiled leather";
            mapSymbol = '\u2720';
            armor = 20;
        }

        public ShellArmor(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Shell armor";
            mapSymbol = '\u2720';
            armor = 50;
        }

        public ScaleArmor(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Scale armor";
            mapSymbol = '\u2720';
            armor = 70;
        }

        public LaminarArmor(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Laminar armor";
            mapSymbol = '\u2720';
            armor = 90;
        }

        public PlatedMailArmor(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Plated mail armor";
            mapSymbol = '\u2720';
            armor = 160;
        }

        public MailArmor(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Mail armor";
            mapSymbol = '\u2720';
            armor = 170;
        }

        public BrigandineArmor(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Brigandine armor";
            mapSymbol = '\u2720';
            armor = 180;
        }

        public PlateArmor(Square square, string name, char mapSymbol, int armor) : base(square)
        {
            name = "Plate armor";
            mapSymbol = '\u2720';
            armor = 200;
        }

    }
}
