namespace RoguelikeGame.DungeonManagement
{
    internal class Dungeon
    {
        public int Height { get; }
        public int Width { get; }
        public Square[,] Board { get; }
        public Dungeon(int height, int width)
        {
            Height = height;
            Width = width;
            Board = new Square[width, height];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    Board[i, j] = new Square(i, j, SquareStatus.Floor);
                }
            }
        }
    }
}
