using System.Numerics;

namespace RoguelikeGame.DungeonManagement
{
    internal class Dungeon
    {
        public readonly int Height = 32;
        public readonly int Width = 140;
        private readonly Random Rand = new();
        public Square[,] Board { get; }

        public Dungeon()
        {
            Board = new Square[Width, Height];

            // Fill the board with empty squares by default
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Board[x, y] = new Square(x, y);
                }
            }

            int minRoomWidth = 6;
            int maxRoomWidth = Width / 4;
            int minRoomHeight = 6;
            int maxRoomHeight = Height / 4;

            // Define the dimensions of the room
            int roomWidth = Math.Max(minRoomWidth, Rand.Next(maxRoomWidth));
            int roomHeight = Math.Max(minRoomHeight, Rand.Next(maxRoomHeight));

            // Choose a random location for the top-left corner of the room
            int roomCornerX = Rand.Next(Width - roomWidth);
            int roomCornerY = Rand.Next(Height - roomHeight);

            // Fill the room with floor squares by default
            for (int x = roomCornerX; x < roomCornerX + roomWidth; x++)
            {
                for (int y = roomCornerY; y < roomCornerY + roomHeight; y++)
                {
                    Board[x, y].Status = SquareStatus.Floor;
                }
            }

            // Set the edges of the rectangle to be walls
            bool topDoor = Rand.Next(2) == 0;
            bool bottomDoor = Rand.Next(2) == 0;
            for (int x = roomCornerX; x < roomCornerX + roomWidth; x++)
            {
                Board[x, roomCornerY].Status = SquareStatus.Wall;
                Board[x, roomCornerY + roomHeight - 1].Status = SquareStatus.Wall;

                // Add a door randomly along the top and bottom walls
                if (x > roomCornerX && x < roomCornerX + roomWidth - 1)
                {
                    if (Rand.Next(2) == 0 && topDoor)
                    {
                        Board[x, roomCornerY].Status = SquareStatus.Door;
                        Board[x, roomCornerY - 1].Status = SquareStatus.Corridor;
                        topDoor = false;
                    }
                    if (Rand.Next(2) == 0 && bottomDoor)
                    {
                        Board[x, roomCornerY + roomHeight - 1].Status = SquareStatus.Door;
                        Board[x, roomCornerY + roomHeight].Status = SquareStatus.Corridor;
                        bottomDoor = false;
                    }
                }
            }
            bool leftDoor = Rand.Next(2) == 0;
            bool rightDoor = Rand.Next(2) == 0;
            for (int y = roomCornerY; y < roomCornerY + roomHeight; y++)
            {
                Board[roomCornerX, y].Status = SquareStatus.Wall;
                Board[roomCornerX + roomWidth - 1, y].Status = SquareStatus.Wall;

                // Add a door randomly along the left and right walls
                if (y > roomCornerY && y < roomCornerY + roomHeight - 1)
                {
                    if (Rand.Next(2) == 0 && leftDoor)
                    {
                        Board[roomCornerX, y].Status = SquareStatus.Door;
                        Board[roomCornerX - 1, y].Status = SquareStatus.Corridor;
                        leftDoor = false;
                    }
                    if (Rand.Next(2) == 0 && rightDoor)
                    {
                        Board[roomCornerX + roomWidth - 1, y].Status = SquareStatus.Door;
                        Board[roomCornerX + roomWidth, y].Status = SquareStatus.Corridor;
                        rightDoor = false;
                    }
                }
            }
        }

        public Player PlayerPlacement(string name)
        {
            (int randX, int randY) = FindRandomPlacement();
            return new Player(name, Board[randX, randY]);
        }

        public (int, int) FindRandomPlacement()
        {
            int randX = Rand.Next(Width);
            int randY = Rand.Next(Height);
            while (Board[randX, randY].Status != SquareStatus.Floor)
            {
                randX = Rand.Next(Width);
                randY = Rand.Next(Height);
            }
            return (randX, randY);
        }
    }
}
