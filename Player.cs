using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame
{
    internal class Player
    {
        public Square Square { get; set; }
        public SquareStatus PreviousSquareStatus { get; set; }
        public string Name { get; set; }
        public int Armor = 10;
        public int Health = 10;
        public int Damage = 10;

        public Player(string name)
        {
            Name = name;
            PreviousSquareStatus = SquareStatus.Floor;
        }

        public void SetPlayer(Square square)
        {
            Square = square;
            Square.Status = SquareStatus.Player;
        }

        public bool Move(Dungeon dungeon, ConsoleKeyInfo input)
        {
            Square.Status = PreviousSquareStatus;
            switch (input.Key)
            {
                case ConsoleKey.A:
                    if (Square.X > 0 && dungeon.Board[Square.X - 1, Square.Y].Walkable())
                    {
                        Square = dungeon.Board[Square.X - 1, Square.Y];
                    }
                    break;
                case ConsoleKey.D:
                    if (Square.X < dungeon.Width - 1 && dungeon.Board[Square.X + 1, Square.Y].Walkable())
                    {
                        Square = dungeon.Board[Square.X + 1, Square.Y];
                    }
                    break;
                case ConsoleKey.W:
                    if (Square.Y > 0 && dungeon.Board[Square.X, Square.Y - 1].Walkable())
                    {
                        Square = dungeon.Board[Square.X, Square.Y - 1];
                    }
                    break;
                case ConsoleKey.S:
                    if (Square.Y < dungeon.Height - 1 && dungeon.Board[Square.X, Square.Y + 1].Walkable())
                    {
                        Square = dungeon.Board[Square.X, Square.Y + 1];
                    }
                    break;
                case ConsoleKey.Escape:
                    return false;
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
            return true;
        }
    }
}