namespace RoguelikeGame.DungeonManagement
{
    public class Square
    {
        public int X { get; }
        public int Y { get; }
        public SquareStatus Status { get; set; }
        public bool Visible { get; set; }
        public Entity.Abstract.Entity? Entity { get; set; } = null;
        public Square(int x, int y)
        {
            X = x;
            Y = y;
            Status = SquareStatus.Empty;
            Visible = false;
        }
        
        public char GetCharacter()
        {
            char squareStatusCharacter = ' ';
            switch (Status)
            {
                case SquareStatus.Player:
                    squareStatusCharacter = '@';
                    break;
                case SquareStatus.Wall:
                    squareStatusCharacter = '#';
                    break;
                case SquareStatus.Floor:
                    squareStatusCharacter = Entity?.MapSymbol ?? '.';
                    break;
                case SquareStatus.Door:
                    squareStatusCharacter = '+';
                    break;
                case SquareStatus.Corridor:
                    squareStatusCharacter = '\x2588';
                    break;
            }
            return squareStatusCharacter;
        }
    }
}
