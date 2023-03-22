using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoguelikeGame.Items.Abstract
{
    public abstract class Items
    {
        public string Name { get; }
        public char MapSymbol { get; }
        public Square Square;

        public Items(Square square, string name, char mapSymbol)
        {
            Square = square;
            square.Status = SquareStatus.Item;
            Name = name;
            MapSymbol = mapSymbol;
        }

    }
}
