using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Entity.Abstract;
using RoguelikeGame.UI;


namespace RoguelikeGame.Entity
{
    public class Player : Abstract.Entity
    {
        public int Armor { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool Alive => Health > 0;
        public bool DMT = false;
        public Square PreviousSquare { get; set; }
        public Dictionary<Useable, int> Inventory { get; set; }

        public Player(string name, Square square, int health = 20, int armor = 5, int damage = 5) : base(square)
        {
            square.Player = this;
            Name = name;
            Armor = armor;
            Health = health;
            Damage = damage;
            Inventory = new Dictionary<Useable, int>();
            PreviousSquare = Square;
            PreviousSquare.Status = SquareStatus.Floor;
        }

        public bool Control(Dungeon dungeon, ConsoleKeyInfo input)
        {
            Square.Status = PreviousSquare.Status;
            PreviousSquare = Square;
            switch (input.Key)
            {
                case ConsoleKey.A when DMT:
                    if (Square.X > 0)
                    {
                        Square = CheckForCollision(dungeon.Board[Square.X + 1, Square.Y]);
                    }
                    break;
                case ConsoleKey.D when DMT:
                    if (Square.X < dungeon.Width - 1)
                    {
                        Square = CheckForCollision(dungeon.Board[Square.X - 1, Square.Y]);
                    }
                    break;
                case ConsoleKey.W when DMT:
                    if (Square.Y > 0)
                    {
                        Square = CheckForCollision(dungeon.Board[Square.X, Square.Y + 1]);
                    }
                    break;
                case ConsoleKey.S when DMT:
                    if (Square.Y < dungeon.Height - 1)
                    {
                        Square = CheckForCollision(dungeon.Board[Square.X, Square.Y - 1]);
                    }
                    break;
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
                case ConsoleKey.E:
                    if (Square.Interactive != null)
                    {
                        Console.WriteLine(((Item)Square.Interactive).Interact(this));
                        WaitMessage();
                    }
                    break;
                case ConsoleKey.I:
                    Display.ShowYourInventory(this);
                    WaitMessage();
                    break;
                case ConsoleKey.H:
                    Display.DisplayHelp();
                    WaitMessage();
                    break;
                case ConsoleKey.M:
                    Display.DisplayMapLegend();
                    WaitMessage();
                    break;
                case ConsoleKey.Escape:
                    return false;
            }
            PreviousSquare.Status = Square.Status is SquareStatus.Corridor or SquareStatus.Door or SquareStatus.Empty
                ? Square.Status
                : SquareStatus.Floor;
            PreviousSquare.Player = null;
            Square.Status = SquareStatus.Player;
            Square.Player = this;
            return true;
        }

        private Square CheckForCollision(Square newSquare)
        {
            if (newSquare.Interactive != null)
            {
                if (newSquare.Interactive.GetType().BaseType == typeof(Character))
                {
                    Console.WriteLine(((Character)newSquare.Interactive).ApproachCharacter(this));
                    WaitMessage();
                    return Square;
                }
            }

            switch (newSquare.Status)
            {
                case SquareStatus.Corridor:

                    return newSquare;
                case SquareStatus.Item:
                    return newSquare;
                case SquareStatus.Door:
                    // go thought door
                    return newSquare;
                case SquareStatus.Floor:
                    return newSquare;
                case SquareStatus.Empty:
                    return newSquare;
                default:
                    return Square;
            }
        }

        private static void WaitMessage()
        {
            Display.PressAnyKey();
            Input.WaitForKeyPress();
        }
    }
}