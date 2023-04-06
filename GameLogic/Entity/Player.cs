﻿using GameLogic.DungeonManagement;
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

        public void TryToMove(Coordinates newCoordinates, Dungeon dungeon)
        {
            if (newCoordinates is { X: > 0, Y: > 0 } 
                && newCoordinates.X < dungeon.Width 
                && newCoordinates.Y < dungeon.Height)
            {
                Square nextSquare = dungeon.Grid[newCoordinates.X, newCoordinates.Y];
                if (nextSquare.Interactive != null 
                    && nextSquare.Interactive.GetType().BaseType == typeof(Character))
                {
                    ((Character)nextSquare.Interactive).ApproachCharacter(this); //TODO display returned message and wait

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

        //public bool Control(Dungeon dungeon, ConsoleKeyInfo input)
        //{
        //    Square.Status = PreviousSquare.Status; // todo fulls square instead of just status
        //    PreviousSquare = Square;
        //    switch (input.Key)
        //    {
        //            break;
        //        case ConsoleKey.E:
        //            if (Square.Interactive != null)
        //            {
        //                Console.WriteLine(((Item)Square.Interactive).Interact(this)); // todo updated item interact
        //                WaitMessage();
        //            }
        //            break;
        //        case ConsoleKey.I:
        //            Display.ShowYourInventory(this);
        //            WaitMessage();
        //            break;
        //        case ConsoleKey.H:
        //            Display.DisplayHelp();
        //            WaitMessage();
        //            break;
        //        case ConsoleKey.M:
        //            Display.DisplayMapLegend();
        //            WaitMessage();
        //            break;
        //        case ConsoleKey.Escape:
        //            return false;
        //    }
        //    PreviousSquare.Status = Square.Status is SquareStatus.Corridor or SquareStatus.Door or SquareStatus.Empty
        //        ? Square.Status
        //        : SquareStatus.Floor;
        //    PreviousSquare.Player = null;
        //    Square.Status = SquareStatus.Player;  // todo updated previous square status as full square
        //    Square.Player = this;
        //    return true;
        //}
        //private Square CheckForCollision(Square newSquare) todo updated character approach
        //{
        //    if (newSquare.Interactive != null)
        //    {
        //        if (newSquare.Interactive.GetType().BaseType == typeof(Character))
        //        {
        //            Console.WriteLine(((Character)newSquare.Interactive).ApproachCharacter(this));
        //            WaitMessage();
        //            return Square;
        //        }
        //    }

        //    switch (newSquare.Status)
        //    {
        //        case SquareStatus.Corridor:

        //            return newSquare;
        //        case SquareStatus.Item:
        //            return newSquare;
        //        case SquareStatus.Door:
        //            // go thought door
        //            return newSquare;
        //        case SquareStatus.Floor:
        //            return newSquare;
        //        case SquareStatus.Empty:
        //            return newSquare;
        //        default:
        //            return Square;
        //    }
        //}