using System.Text;

namespace RoguelikeGame.DungeonManagement
{
    public class Dungeon
    {
        public readonly int Height = 32;
        public readonly int Width = 140;
        private readonly Random Rand = new();
        public Square[,] Board { get; }

        public Dungeon()
        {
            Board = new Square[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Board[x, y] = new Square(x, y);
                }
            }

            int minRoomWidth = 8;
            int maxRoomWidth = Width/4;
            int minRoomHeight = 6;
            int maxRoomHeight = Height/4;
            int placementTries = 40;

            while (placementTries > 0)
            {
                // Define the dimensions of the room
                int roomWidth = Math.Max(minRoomWidth, Rand.Next(maxRoomWidth));
                int roomHeight = Math.Max(minRoomHeight, Rand.Next(maxRoomHeight));

                // Choose a random location for the top-left corner of the room
                int roomCornerX = Rand.Next(Width - roomWidth);
                int roomCornerY = Rand.Next(Height - roomHeight);

                if (CheckRoomPlacement(roomCornerX, roomCornerY, Width, Height))
                {
                    PlaceFloor(roomCornerX, roomCornerY, roomWidth, roomHeight);
                    PlaceWalls(roomCornerX, roomCornerY, roomWidth, roomHeight);
                    placementTries = 40;
                }
                placementTries--;
            }
        }

        public void PlaceFloor(int roomCornerX, int roomCornerY, int roomWidth, int roomHeight)
        {
            for (int x = roomCornerX; x < roomCornerX + roomWidth; x++)
            {
                for (int y = roomCornerY; y < roomCornerY + roomHeight; y++)
                {
                    Board[x, y].Status = SquareStatus.Floor;
                }
            }
        }

        public void PlaceWalls(int roomCornerX, int roomCornerY, int roomWidth, int roomHeight)
        {
            bool topDoor = false;
            bool bottomDoor = false;
            bool leftDoor = false;
            bool rightDoor = false;
            while (!topDoor && !bottomDoor && !leftDoor && !rightDoor)
            {
                for (int x = roomCornerX; x < roomCornerX + roomWidth; x++)
                {
                    Board[x, roomCornerY].Status = SquareStatus.Wall;
                    Board[x, roomCornerY + roomHeight - 1].Status = SquareStatus.Wall;

                    if (x > roomCornerX && x < roomCornerX + roomWidth - 1)
                    {
                        if (Rand.Next(2) == 0 && !topDoor)
                        {
                            Board[x, roomCornerY].Status = SquareStatus.Door;
                            topDoor = true;
                        }
                        if (Rand.Next(2) == 0 && !bottomDoor)
                        {
                            Board[x, roomCornerY + roomHeight - 1].Status = SquareStatus.Door;
                            bottomDoor = true;
                        }
                    }
                }
                for (int y = roomCornerY; y < roomCornerY + roomHeight; y++)
                {
                    Board[roomCornerX, y].Status = SquareStatus.Wall;
                    Board[roomCornerX + roomWidth - 1, y].Status = SquareStatus.Wall;

                    if (y > roomCornerY && y < roomCornerY + roomHeight - 1)
                    {
                        if (Rand.Next(2) == 0 && !leftDoor)
                        {
                            Board[roomCornerX, y].Status = SquareStatus.Door;
                            leftDoor = true;
                        }
                        if (Rand.Next(2) == 0 && !rightDoor)
                        {
                            Board[roomCornerX + roomWidth - 1, y].Status = SquareStatus.Door;
                            rightDoor = true;
                        }
                    }
                }
            }
        }

        private bool CheckRoomPlacement(int roomCornerX, int roomCornerY, int roomWidth, int roomHeight)
        {
            for (int x = roomCornerX; x <= roomCornerX + roomWidth + 1; x++)
            {
                for (int y = roomCornerY; y <= roomCornerY + roomHeight + 1; y++)
                {
                    if (x < Width && y < Height && x >= 0 && y >= 0) 
                    { 
                        if (Board[x, y].Status != SquareStatus.Empty)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public Player PlayerPlacement(string name)
        {
            (int randX, int randY) = RandomGenerator.FindRandomPlacement(this);
            return new Player(name, Board[randX, randY]);
        }

        public string DungeonToString()
        {
            StringBuilder sbReturn = new();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    
                        sbReturn.Append(new string($"{Board[x, y].GetCharacter()}"));

                }
                sbReturn.Append('\n');
            }
            return sbReturn.ToString();
        }
    }

}