using RoguelikeGame.DungeonManagement;
using RoguelikeGame.UI;
using System.Numerics;

namespace RoguelikeGame
{
    internal class Player
    {
        public Square Position { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Player(Square position, int health, int armor, int damage)
        {
            Position = position;
            Armor = armor;
            Health = health;
            Damage = damage;
        }

        public void Move(Dungeon dungeon, ConsoleKeyInfo input)
        {
            Position.Status = SquareStatus.Empty;
            switch (input.Key)
            {
                case ConsoleKey.A:
                    if (Position.X > 0 && dungeon.Board[Position.Y, Position.X - 1].Status != SquareStatus.Wall)
                    {
                        Position = dungeon.Board[Position.Y, Position.X - 1];
                    }
                    break;
                case ConsoleKey.D:
                    if (Position.X < dungeon.Width - 1 && dungeon.Board[Position.Y, Position.X + 1].Status != SquareStatus.Wall)
                    {
                        Position = dungeon.Board[Position.Y, Position.X + 1];
                    }
                    break;
                case ConsoleKey.W:
                    if (Position.Y > 0 && dungeon.Board[Position.Y - 1, Position.X].Status != SquareStatus.Wall)
                    {
                        Position = dungeon.Board[Position.Y - 1, Position.X];
                    }
                    break;
                case ConsoleKey.S:
                    if (Position.Y < dungeon.Height - 1 && dungeon.Board[Position.Y + 1, Position.X].Status != SquareStatus.Wall)
                    {
                        Position = dungeon.Board[Position.Y + 1, Position.X];
                    }
                    break;
                case ConsoleKey.Escape:
                    //quit to menu
                    break;
            }
            Position.Status = SquareStatus.Player;
        }
    }
}