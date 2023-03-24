using RoguelikeGame.Creatures;

namespace RoguelikeGame.DungeonManagement
{
    public class Square
    {
        public int X { get; }
        public int Y { get; }
        public SquareStatus Status { get; set; }
        public bool Visible { get; set; }
        public Items.Abstract.Items? Item { get; set; } = null;
        public Creature? Creature { get; set; } = null;
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
                    squareStatusCharacter = '.';
                    break;
                case SquareStatus.Enemy:
                    squareStatusCharacter = 'M';
                    break;
                case SquareStatus.Ally:
                    squareStatusCharacter = 'A';
                    break;
                case SquareStatus.Item:
                    squareStatusCharacter = '$';
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
