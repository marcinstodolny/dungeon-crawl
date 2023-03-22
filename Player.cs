using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame
{
    internal class Player
    {
        public Square Square { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Player(Square square, int health, int armor, int damage)
        {
            square.Status = SquareStatus.Player;
            Square = square;
            Armor = armor;
            Health = health;
            Damage = damage;
        }

        public void Move(Dungeon dungeon, ConsoleKeyInfo input)
        {
            Square.Status = SquareStatus.Empty;
            switch (input.Key)
            {
                case ConsoleKey.A:
                    if (Square.X > 0)
                    {
                        Square = CheckForCollision(dungeon.Board[Square.X - 1, Square.Y]);
                    }
                    break;
                case ConsoleKey.D:
                    if (Square.X < dungeon.Width - 1)
                    {
                        Square = CheckForCollision(dungeon.Board[Square.X + 1, Square.Y]);
                    }
                    break;
                case ConsoleKey.W:
                    if (Square.Y > 0)
                    {
                        Square = CheckForCollision(dungeon.Board[Square.X, Square.Y - 1]);
                    }
                    break;
                case ConsoleKey.S:
                    if (Square.Y < dungeon.Height - 1)
                    {
                        Square = CheckForCollision(dungeon.Board[Square.X, Square.Y + 1]);
                    }
                    break;
                case ConsoleKey.Escape:
                    //quit to menu
                    break;
            }
            Square.Status = SquareStatus.Player;
        }

        private Square CheckForCollision(Square newSquare)
        {
            switch (newSquare.Status)
            {
                case SquareStatus.Wall:
                    return Square;
                case SquareStatus.Item:
                    //pickup item
                    return newSquare;
                case SquareStatus.Enemy:
                    //fight enemy
                    return newSquare;
                case SquareStatus.Door:
                    // go thought door
                    return newSquare;
                case SquareStatus.Floor:
                    return newSquare;
                case SquareStatus.Empty:
                    return Square;
                default:
                    return newSquare;
            }
        }
    }
}