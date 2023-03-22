using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame
{
    internal class Player
    {
        public Square Square { get; set; }
        public SquareStatus PreviousSquareStatus { get; set; }
        public int Armor = 10;
        public int Health = 10;
        public int Damage = 10;

        public Player()
        {
            PreviousSquareStatus = SquareStatus.Floor;
        }

        public void SetPlayer(Square square)
        {
            Square = square;
            Square.Status = SquareStatus.Player;
        }

        public void Move(Dungeon dungeon, ConsoleKeyInfo input)
        {
            Square.Status = PreviousSquareStatus;
            switch (input.Key)
            {
                case ConsoleKey.A:
                    if (Square.X > 0 && dungeon.Board[Square.X - 1, Square.Y].Status != SquareStatus.Wall && dungeon.Board[Square.X - 1, Square.Y].Status != SquareStatus.Empty)
                    {
                        Square = dungeon.Board[Square.X - 1, Square.Y];
                    }
                    break;
                case ConsoleKey.D:
                    if (Square.X < dungeon.Width - 1 && dungeon.Board[Square.X + 1, Square.Y].Status != SquareStatus.Wall && dungeon.Board[Square.X + 1, Square.Y].Status != SquareStatus.Empty)
                    {
                        Square = dungeon.Board[Square.X + 1, Square.Y];
                    }
                    break;
                case ConsoleKey.W:
                    if (Square.Y > 0 && dungeon.Board[Square.X, Square.Y - 1].Status != SquareStatus.Wall && dungeon.Board[Square.X, Square.Y - 1].Status != SquareStatus.Empty)
                    {
                        Square = dungeon.Board[Square.X, Square.Y - 1];
                    }
                    break;
                case ConsoleKey.S:
                    if (Square.Y < dungeon.Height - 1 && dungeon.Board[Square.X, Square.Y + 1].Status != SquareStatus.Wall && dungeon.Board[Square.X, Square.Y + 1].Status != SquareStatus.Empty)
                    {
                        Square = dungeon.Board[Square.X, Square.Y + 1];
                    }
                    break;
                case ConsoleKey.Escape:
                    //quit to menu
                    break;
            }
            if (Square.Status == SquareStatus.Corridor || Square.Status == SquareStatus.Door) 
            {
                PreviousSquareStatus = Square.Status;
            }
            else
            {
                PreviousSquareStatus = SquareStatus.Floor;
            }
            Square.Status = SquareStatus.Player;
        }
    }
}