using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Abstract
{
    public abstract class Consumable : Items
    {
        public int HPrestore { get; set; }

        public Consumable(Square square, string name, char mapSymbol, int hpRestore) : base(square, name, mapSymbol)
        {
            HPrestore = hpRestore;
        }

    }
}
