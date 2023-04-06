using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract
{
    public abstract class Entity
    {
        public string Name { get; set; } = "";
        public char MapSymbol { get; set; }
        public Square Square { get; set; }

        protected Entity(Square square)
        {
            Square = square;
        }
    }
}