using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public char MapSymbol { get; set; }
        public Square Square { get; set; }

        protected Entity(string name, char mapSymbol, Square square)
        {
            Square = square;
            Name = name;
            MapSymbol = mapSymbol;
        }
    }
}