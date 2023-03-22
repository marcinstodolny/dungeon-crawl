namespace RoguelikeGame.DungeonManagement
{
    internal class Square
    {
        public int X { get; }
        public int Y { get; }
        public SquareStatus Status { get; set; }

        public Coordinates Position { get; set; }
        public Square(Coordinates position, SquareStatus status)
        {
            Position = position;
            Status = status;
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
                    squareStatusCharacter = '.';
                    break;
                case SquareStatus.Enemy:
                    squareStatusCharacter = 'M';
                    break;
                case SquareStatus.Item:
                    squareStatusCharacter = '$';
                    break;
                case SquareStatus.Door:
                    squareStatusCharacter = '+';
                    break;
                case SquareStatus.Corridor:
                    squareStatusCharacter = '\u00b2';
                    break;
            }
            return squareStatusCharacter;
        }
    }
}
