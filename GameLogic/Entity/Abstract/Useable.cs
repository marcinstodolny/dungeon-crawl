using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract
{
    public abstract class Useable : Item
    {
        protected Useable(string name, char mapSymbol, Square square) : base(name, mapSymbol, square)
        {
        }
    }
}
