using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract
{
    public abstract class Consumable : Item
    {
        public int HPrestore { get; set; }

        protected Consumable(Square square) : base(square)
        {
        }

    }
}
