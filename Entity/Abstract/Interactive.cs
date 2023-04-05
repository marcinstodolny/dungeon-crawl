using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Interactive : Entity
    {
        protected Interactive(Square square) : base(square)
        {

        }
        public void RemoveFromBoard()
        {
            Square.Interactive = null;
            Square.Status = SquareStatus.Floor;
        }
    }
}
