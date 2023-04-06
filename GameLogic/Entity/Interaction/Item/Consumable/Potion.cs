﻿using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Interaction.Item.Consumable
{
    public class Potion : Abstract.Consumable
    {
        public Potion(Square square) : base(square)
        {
            var randomPotion = DbManager.GetItem("HPRestore", "Potion");
            Name = randomPotion["Name"];
            MapSymbol = randomPotion["Symbol"].ToCharArray()[0];
            HPrestore = int.Parse(randomPotion["Stat"]);
            Id = int.Parse(randomPotion["Id"]);
        }

        public static void PlaceItem(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var item = new Potion(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = item;
        }

        public override string Interact(Player player)
        {
            player.Health += HPrestore;
            RemoveFromBoard();
            if (Name != "Dimetylotryptamina")
            {
                return $"You have eat {Name}";
            }
            player.DMT = true;
            return $"Enjoy the Ride";
        }
    }
}
