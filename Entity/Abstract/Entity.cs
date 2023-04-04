using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public char MapSymbol { get; set; }
        public Square Square { get; set; }

        protected Entity(Square square, string name, char mapSymbol)
        {
            Square = square;
            Name = name;
            MapSymbol = mapSymbol;
        }
        public void ChangeSquare(Square newSquare)
        {
            Square.Entity = null;
            Square = newSquare;
            Square.Entity = this;

        }
    }
}