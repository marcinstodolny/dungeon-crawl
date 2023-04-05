using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Entity.Abstract;
using RoguelikeGame.Entity.Interaction.Creatures;
using RoguelikeGame.Entity.Interaction.Item.Useable;
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

        public Player(string name, Square square, int health = 20, int armor = 5, int damage = 5) : base(name, '@', square)
        {
            square.Player = this;
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
                        PickupItem(Square);
                        Square.Interactive = null;
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
            if (square.Interactive!.GetType().BaseType == typeof(Consumable))
            {
                var consumable = (Consumable)square.Interactive;
                if (consumable.Name == "Dimetylotryptamina")
                {
                    Display.DisplayDMT();
                    DMT = true;
                }
                Health += consumable.HPrestore;
                Display.DisplayFoodEat(square);
                WaitMessage();
            }
            else if (square.Interactive!.GetType().BaseType == typeof(Useable))
            {
                var item = (Useable)square.Interactive;
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
                    Armor += ((Armor)item).Protection;
                }
                else if (item.GetType() == typeof(Weapons))
                {
                    Damage += ((Weapons)item).Attack;
                }
                Display.DisplayItemPickup(square);
                WaitMessage();
            }
        }

        private Square ApproachEnemy(Square newSquare)
        {
            if (newSquare.Interactive!.GetType() != typeof(Enemy))
            {
                return Square;
            }
            var enemy = (Enemy)newSquare.Interactive;
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
            newSquare.Interactive = null;
            return newSquare;

        }
        private Square ApproachAlly(Square newSquare)
        {
            if (newSquare.Interactive!.GetType() != typeof(Ally))
            {
                return newSquare;
            }
            var ally = (Ally)newSquare.Interactive;
            Display.DisplayAllyMessage(ally);
            WaitMessage();
            Health += ally.BonusHealth;
            Damage += ally.BonusDamage;
            newSquare.Interactive = null;

            return newSquare;
        }

        private static void WaitMessage()
        {
            Display.PressAnyKey();
            Input.WaitForKeyPress();
        }
    }
}