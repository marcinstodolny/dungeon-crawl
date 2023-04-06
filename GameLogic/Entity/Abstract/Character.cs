using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract
{
    public abstract class Character : Interactive
    {

        protected Character(Square square) : base(square)
        {
        }
        public void ChangeSquare(Square newSquare)
        {
            Square.Interactive = null;
            Square = newSquare;
            Square.Interactive = this;
        }
        public abstract string ApproachCharacter(Player player);
        public override void RemoveFromBoard()
        {
            Square.Interactive = null;
            Square.Status = SquareStatus.Floor;
        }
    }
}

