using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Consumable : Entity
    {
        public int HPrestore { get; set; }

        protected Consumable(string name, char mapSymbol, int hpRestore, Square square) : base(square, name, mapSymbol)
        {
            HPrestore = hpRestore;
        }
    }
}
