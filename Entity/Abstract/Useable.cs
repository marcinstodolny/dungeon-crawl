using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Useable : Item
    {
        public int Id;
        protected Useable(string name, char mapSymbol, Square square) : base(name, mapSymbol, square)
        {
        }
    }
}