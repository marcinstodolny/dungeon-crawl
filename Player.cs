using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Abstract;
using RoguelikeGame.Items.Consumable;
using RoguelikeGame.Items.Useable;
using RoguelikeGame.UI;


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
        public Dictionary<Useable, int> Inventory { get; set; }

        public Player(string name, Square square, int health = 10, int armor = 10, int damage = 10)
        {
            Name = name;
            Square = square;
            square.Status = SquareStatus.Player;
            Armor = armor;
            Health = health;
            Damage = damage;
            Inventory = new Dictionary<Useable, int>();
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
                case ConsoleKey.E:
                    if (Square.Item != null)
                    {
                        PickupItem(Square);
                        Square.Status = SquareStatus.Floor;
                        Square.Item = null;
                    }
                    break;
                case ConsoleKey.Escape:
                    return false;
            }
            PreviousSquareStatus = Square.Status is SquareStatus.Corridor or SquareStatus.Door or SquareStatus.Item
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
                    return newSquare;
                case SquareStatus.Enemy:
                    //fight enemy
                    return Square;
                case SquareStatus.Door:
                    // go thought door
                    return newSquare;
                case SquareStatus.Floor:
                    return newSquare;
                default:
                    return Square;
            }
        }

        private void PickupItem(Square square)
        {
            if (square.Item!.GetType() == typeof(Food) || square.Item.GetType() == typeof(Potions))
            {
                var food = (Consumable) square.Item;
                Health += food.HPrestore;
            }
            else if (square.Item.GetType() == typeof(Armor) || square.Item.GetType() == typeof(Weapons))
            {
                var item = (Useable)square.Item;
                if (Inventory.ContainsKey(item))
                {
                    Inventory[item]++;
                }
                else
                {
                    Inventory[item] = 1;
                }
                if (item.GetType() == typeof(Armor))
                {
                    Armor += item.Armor;
                }
                else if (item.GetType() == typeof(Weapons))

                {
                    Damage += item.Attack;
                }
            }
        }
    }
}