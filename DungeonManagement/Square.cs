namespace RoguelikeGame.DungeonManagement
{
    internal class Square
    {
        public int X { get; }
        public int Y { get; }
        public SquareStatus Status { get; set; }
        public Square(int x, int y)
        {
            X = x;
            Y = y;
            Status = SquareStatus.Empty;
        }
    }
}
