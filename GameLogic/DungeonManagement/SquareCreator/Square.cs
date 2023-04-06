using GameLogic.Entity;

namespace GameLogic.DungeonManagement.SquareCreator
{
    public class Square
    {
        public Coordinates Position { get; set; }
        public SquareStatus Status { get; set; }
        public bool Visible { get; set; }
        public bool Walkable { get; set; }
        public Entity.Abstract.Interactive? Interactive { get; set; } = null;
        public Player? Player { get; set; } = null;
        public Square(Coordinates position, SquareStatus status, bool walkable, bool visible = true)
        {
            Position = position;
            Status = status;
            Walkable = walkable;
            Visible = visible;
        }
    }
}