using RoguelikeGame.Creatures;
using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Abstract;
using RoguelikeGame.Items.Consumable;
using RoguelikeGame.Items.Useable;
using RoguelikeGame.UI;


namespace RoguelikeGame
{
    public class Player
    {
        public Square Square { get; set; }
        public string Name { get; set; }
        public int Armor { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool Alive => Health > 0;
        public bool DMT = false;
        public SquareStatus PreviousSquareStatus { get; set; }
        public Dictionary<Useable, int> Inventory { get; set; }

        public Player(string name, Square square, int health = 20, int armor = 5, int damage = 5)
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

        public bool Control(Dungeon dungeon, ConsoleKeyInfo input)
        {
            Square.Status = PreviousSquareStatus;
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
                    if (Square.Item != null)
                    {
                        PickupItem(Square);
                        Square.Status = SquareStatus.Floor;
                        Square.Item = null;
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
            PreviousSquareStatus = Square.Status is SquareStatus.Corridor or SquareStatus.Door or SquareStatus.Empty or SquareStatus.Item
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
                case SquareStatus.Ally:
                    return ApproachAlly(newSquare);
                case SquareStatus.Enemy:
                    return ApproachEnemy(newSquare);
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

        private void PickupItem(Square square)
        {
            if (square.Item!.GetType() == typeof(Food) || square.Item.GetType() == typeof(Potions))
            {
                var consumable = (Consumable) square.Item;
                if (consumable.Name == "Dimetylotryptamina")
                {
                    Display.DisplayDMT();
                    DMT = true;
                }
                Health += consumable.HPrestore;
                Display.DisplayFoodEat(square);
                WaitMessage();
            }
            else if (square.Item.GetType() == typeof(Armor) || square.Item.GetType() == typeof(Weapons) || square.Item.GetType() == typeof(Key))
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
                Display.DisplayItemPickup(square);
                WaitMessage();
            }
        }

        private Square ApproachEnemy(Square newSquare)
        {
            if (newSquare.Creature!.GetType() != typeof(Enemy))
            {
                return Square;
            }
            var enemy = (Enemy)newSquare.Creature;
            Display.DisplayEnemyInfo(enemy);
            enemy.Health -= Damage;
            if (enemy.Health > 0)
            {
                if (enemy.Damage - Armor <= 0)
                {
                    Display.DisplayFight(this, enemy, true);
                    WaitMessage();
                    return Square;
                }
                Health -= enemy.Damage - Armor;
                if (Health < 0)
                {
                    Display.DeadMessage();
                    WaitMessage();
                    return Square;
                }
                Display.DisplayFight(this, enemy);
                WaitMessage();
                return Square;
            }
            Display.DisplayFightVictory(enemy);
            WaitMessage();
            newSquare.Creature = null;
            return newSquare;

        }
        private Square ApproachAlly(Square newSquare)
        {
            if (newSquare.Creature!.GetType() != typeof(Ally))
            {
                return newSquare;
            }
            var ally = (Ally)newSquare.Creature;
            Display.DisplayAllyMessage(ally);
            WaitMessage();
            Health += ally.BonusHealth;
            Damage += ally.BonusDamage;
            newSquare.Creature = null;

            return newSquare;
        }

        private static void WaitMessage()
        {
            Display.PressAnyKey();
            Input.WaitForKeyPress();
        }
    }
}