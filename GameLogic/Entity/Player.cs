using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.SquareCreator;
using GameLogic.Entity.Abstract;

namespace GameLogic.Entity
{
    public class Player : Abstract.Entity
    {
        public int Armor { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool Alive => Health > 0;

        public bool DMT = false;
        public int ViewRange = 7;
        public SquareStatus PreviousSquareStatus { get; set; }
        public Dictionary<Useable, int> Inventory { get; set; }

        public Player(string name, Square square, int health = 20, int armor = 5, int damage = 5) : base(square)
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

        public string TryToMove(Coordinates newCoordinates, Dungeon dungeon)
        {
            if (newCoordinates is { X: > 0, Y: > 0 }
                && newCoordinates.X < dungeon.Width
                && newCoordinates.Y < dungeon.Height)
            {
                Square nextSquare = dungeon.Grid[newCoordinates.X, newCoordinates.Y];
                if (nextSquare.Interactive != null
                    && nextSquare.Interactive.GetType().BaseType == typeof(Character))
                {
                    return ((Character)nextSquare.Interactive).ApproachCharacter(this);

                }
                else if (newCoordinates.X == Square.Position.X
                    && newCoordinates.Y == Square.Position.Y
                    && nextSquare.Interactive != null
                    && nextSquare.Interactive.GetType().BaseType!.BaseType == typeof(Item))
                {
                    return ((Item)nextSquare.Interactive).Interact(this);

                }
                else if (nextSquare.Walkable)
                {
                    if (nextSquare.Status != SquareStatus.Empty && nextSquare.Status != SquareStatus.Hallway)
                    {
                        RevealSquares(dungeon);
                    }
                    Square.Status = PreviousSquareStatus;
                    Square = dungeon.Grid[newCoordinates.X, newCoordinates.Y];
                    PreviousSquareStatus = Square.Status;
                    Square.Status = SquareStatus.Player;
                }
            }
            return "\n";
        }

        public void RevealSquares(Dungeon dungeon)
        {
            for (int y = Square.Position.Y - ViewRange + 1; y < Square.Position.Y + ViewRange; y++)
            {
                for (int x = Square.Position.X - ViewRange + 1; x < Square.Position.X + ViewRange; x++)
                {
                    if (x > 0 && y > 0 && x < dungeon.Width && y < dungeon.Height)
                    {
                        dungeon.Grid[x, y].Visible = true;
                    }
                }
            }
        }
    }
}