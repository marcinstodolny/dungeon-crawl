namespace RoguelikeGame
{
    internal class Dungeon
    {
        public int Size { get; }
        public Square[,] Board { get; }
        public Dungeon(int size)
        {
            Size = size;
            Board = new Square[size, size];
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    Board[i, j] = new Square(i, j);
                }
            }
        }
    }
}
