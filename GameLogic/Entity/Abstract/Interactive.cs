using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract
{
    public abstract class Interactive : Entity
    {
        public int Id;
        protected Interactive(Square square) : base(square)
        {

        }
    }
}
