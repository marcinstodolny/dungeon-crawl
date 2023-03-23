using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Abstract
{
    public abstract class Consumable : Items
    {
        public int HPrestore { get; set; }

        protected Consumable(string name, char mapSymbol, int hpRestore) : base(name, mapSymbol)
        {
            HPrestore = hpRestore;
        }

    }
}
