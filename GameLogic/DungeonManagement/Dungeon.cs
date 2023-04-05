using GameLogic.DungeonManagement.SquareCreator;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.Entity.Interaction.Character;
using GameLogic.Entity.Interaction.Item.Consumable;
using GameLogic.Entity.Interaction.Item.Useable;

namespace GameLogic.DungeonManagement
{
    public class Dungeon
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Square[,] Grid { get; set; }
        public List<Room> Rooms { get; set; }

        public Coordinates Dimensions { get; set; }

        public Dungeon(int height, int width)
        {
            Width = width;
            Height = height;
            Grid = new Square[width, height];
            Rooms = new List<Room>();
            Dimensions = new Coordinates(Width, Height);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Grid[x, y] = new Square(new Coordinates(x, y), SquareStatus.Empty, false);
                }
            }

            GenerateRooms();
            ConnectRooms();
        }

        private void GenerateRooms()
        {
            Random random = new();

            bool canPlaceMoreRooms = true;
            while (canPlaceMoreRooms)
            {
                int roomWidth = random.Next(6, (Width / 4) + 1);
                int roomHeight = random.Next(6, (Height / 4) + 1);
                int roomX = random.Next(1, Width - roomWidth - 1);
                int roomY = random.Next(1, Height - roomHeight - 1);
                int numberOfCreatures = random.Next((roomWidth * roomHeight / 40), (roomWidth * roomHeight / 10));
                int numberOfItems = random.Next((roomWidth * roomHeight / 40), (roomWidth * roomHeight / 10));

                Room newRoom = new(roomX, roomY, roomWidth, roomHeight);

                if (CanPlaceRoom(newRoom))
                {
                    newRoom.Draw(Grid);
                    Rooms.Add(newRoom);
                    //PlaceCreaturesInRoom(numberOfCreatures, newRoom);
                    //PlaceItemsInRoom(numberOfItems, newRoom);
                }
                else
                {
                    canPlaceMoreRooms = false;
                }
            }
        }

        private bool CanPlaceRoom(Room newRoom)
        {
            foreach (Room existingRoom in Rooms)
            {
                if (RoomsOverlap(newRoom, existingRoom) || !HasEnoughSpaceBetweenRooms(newRoom, existingRoom))
                {
                    return false;
                }
            }

            return true;
        }

        private bool RoomsOverlap(Room room1, Room room2)
        {
            return room1.X < room2.X + room2.Width &&
                   room1.X + room1.Width > room2.X &&
                   room1.Y < room2.Y + room2.Height &&
                   room1.Y + room1.Height > room2.Y;
        }

        private bool HasEnoughSpaceBetweenRooms(Room room1, Room room2)
        {
            return Math.Abs(room1.X - room2.X) > 3 && Math.Abs(room1.Y - room2.Y) > 3;
        }

        private void ConnectRooms()
        {
            for (int i = 0; i < Rooms.Count - 1; i++)
            {
                Room currentRoom = Rooms[i];
                Room nextRoom = Rooms[i + 1];

                ConnectTwoRooms(currentRoom, nextRoom);
            }
        }

        private void ConnectTwoRooms(Room room1, Room room2)
        {
            
        }

        private void PlaceCreaturesInRoom(int numberOfCreatures, Room room)
        {
            Random random = new();
            for (var i = 0; i < numberOfCreatures; i++)
            {
                int randomCreature = random.Next(1, 3);
                switch (randomCreature)
                {
                    case 1:
                        Enemy.PlaceCreature(this, room);
                        break;
                    case 2:
                        Ally.PlaceCreature(this, room);
                        break;
                }
            }
        }

        private void PlaceItemsInRoom(int numberOfItems, Room room)
        {
            Random random = new();
            for (var i = 0; i < numberOfItems; i++)
            {
                int randomItem = random.Next(1, 5);
                switch (randomItem)
                {
                    case 1:
                        Armor.PlaceItem(this, room);
                        break;
                    case 2:
                        Weapons.PlaceItem(this, room);
                        break;
                    case 3:
                        Food.PlaceItem(this, room);
                        break;
                    case 4:
                        Potions.PlaceItem(this, room);
                        break;
                        //case 5:
                        //Key.PlaceItem(this, newRoom);
                        //break;
                }
            }
        }
    }
}
