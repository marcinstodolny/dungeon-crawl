using RoguelikeGame.DungeonManagement;


namespace RoguelikeGame
{
    internal class Player
    {
        public Square Square { get; set; }
        public string Name { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public SquareStatus PreviousSquareStatus { get; set; }
        public Dictionary<Items.Abstract.Items, int> Inventory { get; set; }

        public Player(string name, Square square, int health = 10, int armor = 10, int damage = 10)
        {
            Name = name;
            Square = square;
            square.Status = SquareStatus.Player;
            Armor = armor;
            Health = health;
            Damage = damage;
            Inventory = new Dictionary<Items.Abstract.Items, int>();
            PreviousSquareStatus = SquareStatus.Floor;
        }

        public bool Move(Dungeon dungeon, ConsoleKeyInfo input)
        {
            Square.Status = PreviousSquareStatus;
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
                    return false;
            }
            PreviousSquareStatus = Square.Status is SquareStatus.Corridor or SquareStatus.Door
                ? Square.Status
                : SquareStatus.Floor;
            Square.Status = SquareStatus.Player;
            return true;
        }

        private Square CheckForCollision(Square newSquare)
        {
            switch (newSquare.Status)
            {
                case SquareStatus.Corridor:
                    
                    return newSquare;
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
                default:
                    return Square;
            }
        }
    }
}