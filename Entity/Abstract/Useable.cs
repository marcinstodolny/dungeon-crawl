using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Useable : Entity
    {
        protected Useable(string name, char mapSymbol, Square square) : base(square, name, mapSymbol)
        {
        }
    }
}