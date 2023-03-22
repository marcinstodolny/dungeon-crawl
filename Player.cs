using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;
using System.Numerics;

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
                    if (Square.X > 0 && dungeon.Board[Square.Y, Square.X - 1].Status != SquareStatus.Wall)
                    {
                        Square = dungeon.Board[Square.Y, Square.X - 1];
                    }
                    break;
                case ConsoleKey.D:
                    if (Square.X < dungeon.Width - 1 && dungeon.Board[Square.Y, Square.X + 1].Status != SquareStatus.Wall)
                    {
                        Square = dungeon.Board[Square.Y, Square.X + 1];
                    }
                    break;
                case ConsoleKey.W:
                    if (Square.Y > 0 && dungeon.Board[Square.Y - 1, Square.X].Status != SquareStatus.Wall)
                    {
                        Square = dungeon.Board[Square.Y - 1, Square.X];
                    }
                    break;
                case ConsoleKey.S:
                    if (Square.Y < dungeon.Height - 1 && dungeon.Board[Square.Y + 1, Square.X].Status != SquareStatus.Wall)
                    {
                        Square = dungeon.Board[Square.Y + 1, Square.X];
                    }
                    break;
                case ConsoleKey.Escape:
                    //quit to menu
                    break;
            }
            Square.Status = SquareStatus.Player;
        }
    }
}