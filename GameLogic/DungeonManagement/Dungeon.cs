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
                    Grid[x, y] = new Square(new Coordinates(x, y), SquareStatus.Empty, true);
                }
            }

            GenerateRooms();
        }

        private List<Cell> CreateCells(int cellWidth, int cellHeight)
        {
            List<Cell> cells = new();
            int numCellsX = Width / cellWidth;
            int numCellsY = Height / cellHeight;

            for (int x = 0; x < numCellsX; x++)
            {
                for (int y = 0; y < numCellsY; y++)
                {
                    cells.Add(new Cell(x * cellWidth, y * cellHeight, cellWidth, cellHeight));
                }
            }

            return cells;
        }



        private void GenerateRooms()
        {
            int cellWidth = Width / 12;
            int cellHeight = Height / 12;
            List<Cell> cells = CreateCells(cellWidth, cellHeight);

            foreach (Cell cell in cells)
            {
                int roomX = cell.X + RandomGenerator.NextInt(cell.Width / 4) + 3;
                int roomY = cell.Y + RandomGenerator.NextInt(cell.Height / 4) + 3;
                int roomWidth = RandomGenerator.NextInt(cell.Width / 2 - 4) + cell.Width / 2 - 4;
                int roomHeight = RandomGenerator.NextInt(cell.Height / 2 - 4) + cell.Height / 2 - 4;
                int numberOfCreatures = RandomGenerator.NextInt((roomWidth * roomHeight) / 25);
                int numberOfItems = RandomGenerator.NextInt((roomWidth * roomHeight) / 25);

                Room newRoom = new(roomX, roomY, roomWidth, roomHeight);
                newRoom.Draw(Grid);
                Rooms.Add(newRoom);
                PlaceCreaturesInRoom(numberOfCreatures, newRoom);
                PlaceItemsInRoom(numberOfItems, newRoom);
            }
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
