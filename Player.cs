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
                    if (Square.Position.X > 0 && dungeon.Board[Square.Position.Y, Square.Position.X - 1].Status != SquareStatus.Wall)
                    {
                        Square = dungeon.Board[Square.Position.Y, Square.Position.X - 1];
                    }
                    break;
                case ConsoleKey.D:
                    if (Square.Position.X < dungeon.Width - 1 && dungeon.Board[Square.Position.Y, Square.Position.X + 1].Status != SquareStatus.Wall)
                    {
                        Square = dungeon.Board[Square.Position.Y, Square.Position.X + 1];
                    }
                    break;
                case ConsoleKey.W:
                    if (Square.Position.Y > 0 && dungeon.Board[Square.Position.Y - 1, Square.Position.X].Status != SquareStatus.Wall)
                    {
                        Square = dungeon.Board[Square.Position.Y - 1, Square.Position.X];
                    }
                    break;
                case ConsoleKey.S:
                    if (Square.Position.Y < dungeon.Height - 1 && dungeon.Board[Square.Position.Y + 1, Square.Position.X].Status != SquareStatus.Wall)
                    {
                        Square = dungeon.Board[Square.Position.Y + 1, Square.Position.X];
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