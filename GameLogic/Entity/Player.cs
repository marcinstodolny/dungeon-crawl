using GameLogic.DungeonManagement;
using System.Text;
using GameLogic.DungeonManagement.SquareCreator;
using GameLogic.Entity.Abstract;
using GameLogic.Entity.Interaction.Character;
using GameLogic.Entity.Interaction.Item.Useable;

namespace GameLogic.Entity
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

        public void TryToMove(Coordinates newCoordinates, Dungeon dungeon)
        {
            if (newCoordinates.X == Square.Position.X && newCoordinates.Y == Square.Position.Y)
            {
                //pickup item

            }
            else if (dungeon.Grid[newCoordinates.X, newCoordinates.Y].Walkable)
            {
                Square.Status = PreviousSquareStatus;
                Square = dungeon.Grid[newCoordinates.X, newCoordinates.Y];
                PreviousSquareStatus = Square.Status;
                Square.Status = SquareStatus.Player;
            }
        }



        //private Square CheckForCollision(Square newSquare)
        //{
        //    if (newSquare.Interactive != null && newSquare.Interactive.GetType().BaseType == typeof(Character))
        //    {
        //        return newSquare.Interactive.GetType() == typeof(Ally) ? ApproachAlly(newSquare) : ApproachEnemy(newSquare);
        //    }

        //    return newSquare.Status switch
        //    {
        //        SquareStatus.Wall => Square,
        //        _ => newSquare
        //    };
        //}

        //private void PickupItem(Square square)
        //{
        //    if (square.Interactive!.GetType().BaseType == typeof(Consumable))
        //    {
        //        var consumable = (Consumable)square.Interactive;
        //        if (consumable.Name == "Dimetylotryptamina")
        //        {
        //            Display.DisplayDMT();
        //            DMT = true;
        //        }
        //        Health += consumable.HPrestore;
        //        Display.DisplayFoodEat(square);
        //        WaitMessage();
        //    }
        //    else if (square.Interactive!.GetType().BaseType == typeof(Useable))
        //    {
        //        var item = (Useable)square.Interactive;
        //        if (Inventory.ContainsKey(item))
        //        {
        //            Inventory[item]++;
        //        }
        //        else
        //        {
        //            Inventory[item] = 1;
        //        }
        //        if (item.GetType() == typeof(Armor))
        //        {
        //            Armor += ((Armor)item).Protection;
        //        }
        //        else if (item.GetType() == typeof(Weapons))
        //        {
        //            Damage += ((Weapons)item).Attack;
        //        }
        //        Display.DisplayItemPickup(square);
        //        WaitMessage();
        //    }
        //}

        //private Square ApproachEnemy(Square newSquare)
        //{
        //    if (newSquare.Interactive!.GetType() != typeof(Enemy))
        //    {
        //        return Square;
        //    }
        //    var enemy = (Enemy)newSquare.Interactive;
        //    Display.DisplayEnemyInfo(enemy);
        //    enemy.Health -= Damage;
        //    if (enemy.Health > 0)
        //    {
        //        if (enemy.Damage - Armor <= 0)
        //        {
        //            Display.DisplayFight(this, enemy, true);
        //            WaitMessage();
        //            return Square;
        //        }
        //        Health -= enemy.Damage - Armor;
        //        if (Health < 0)
        //        {
        //            Display.DeadMessage();
        //            WaitMessage();
        //            return Square;
        //        }
        //        Display.DisplayFight(this, enemy);
        //        WaitMessage();
        //        return Square;
        //    }
        //    Display.DisplayFightVictory(enemy);
        //    WaitMessage();
        //    newSquare.Interactive = null;
        //    return newSquare;

        //}
        //private Square ApproachAlly(Square newSquare)
        //{
        //    if (newSquare.Interactive!.GetType() != typeof(Ally))
        //    {
        //        return newSquare;
        //    }
        //    var ally = (Ally)newSquare.Interactive;
        //    Display.DisplayAllyMessage(ally);
        //    WaitMessage();
        //    Health += ally.BonusHealth;
        //    Damage += ally.BonusDamage;
        //    Armor += ally.BonusArmor;
        //    newSquare.Interactive = null;

        //    return newSquare;
        //}
    }
}
