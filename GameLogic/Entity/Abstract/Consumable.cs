using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract
{
    public abstract class Consumable : Item
    {
        public int HPrestore { get; set; }

        protected Consumable(string name, char mapSymbol, int hpRestore, Square square) : base(name, mapSymbol, square)
        {
            HPrestore = hpRestore;
        }
    }
}
