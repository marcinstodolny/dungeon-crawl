using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Interactive : Entity
    {
        protected Interactive(string name, char mapSymbol, Square square) : base(name, mapSymbol, square)
        {

        }
        public void RemoveFromBoard()
        {
            Square.Interactive = null;
        }
    }
}
