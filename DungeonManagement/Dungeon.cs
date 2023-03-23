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

            // Fill the board with empty squares by default
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Board[x, y] = new Square(x, y);
                }
            }
            // Choose a random location for the top-left corner of the room
            int roomCornerX = Rand.Next(Width - Width);
            int roomCornerY = Rand.Next(Height - Height);

            if (CheckRoomPlacement(roomCornerX, roomCornerY, Width, Height))
            {
                // Fill the room with floor squares by default
                for (int x = roomCornerX; x < roomCornerX + Width; x++)
                {
                    for (int y = roomCornerY; y < roomCornerY + Height; y++)
                    {
                        Board[x, y].Status = SquareStatus.Floor;
                    }
                }

                bool topDoor = false;
                bool bottomDoor = false;
                bool leftDoor = false;
                bool rightDoor = false;
                // Set the edges of the rectangle to be walls
                while (!topDoor && !bottomDoor && !leftDoor && !rightDoor)
                {
                    topDoor = Rand.Next(2) == 1;
                    bottomDoor = Rand.Next(2) == 1;
                    leftDoor = Rand.Next(2) == 1;
                    rightDoor = Rand.Next(2) == 1;
                    for (int x = roomCornerX; x < Width; x++)
                    {
                        Board[x, roomCornerY].Status = SquareStatus.Wall;
                        Board[x, roomCornerY + Height - 1].Status = SquareStatus.Wall;

                        // Add a door randomly along the top and bottom walls
                        if (x > roomCornerX && x < Width - 1)
                        {
                            if (Rand.Next(2) == 1 && !topDoor && roomCornerY > Height * 0.5)
                            {
                                Board[x, roomCornerY].Status = SquareStatus.ClosedDoor;
                                topDoor = true;
                            }
                            if (Rand.Next(2) == 1 && !bottomDoor && roomCornerY < Height * 0.5)
                            {
                                Board[x, roomCornerY + Height - 1].Status = SquareStatus.ClosedDoor;
                                bottomDoor = true;
                            }
                        }
                    }
                    for (int y = roomCornerY; y < roomCornerY + Height; y++)
                    {
                        Board[roomCornerX, y].Status = SquareStatus.Wall;
                        Board[roomCornerX + Width - 1, y].Status = SquareStatus.Wall;

                        // Add a door randomly along the left and right walls
                        if (y > roomCornerY && y <  Height - 1)
                        {
                            if (Rand.Next(2) == 1 && !leftDoor && roomCornerX > Width * 0.5)
                            {
                                Board[roomCornerX, y].Status = SquareStatus.ClosedDoor;
                                leftDoor = true;
                            }
                            if (Rand.Next(2) == 1 && !rightDoor && roomCornerX < Width * 0.5)
                            {
                                Board[roomCornerX + Width - 1, y].Status = SquareStatus.ClosedDoor;
                                rightDoor = true;
                            }
                        }
                    }
                }
            }
        }

        private bool CheckRoomPlacement(int roomCornerX, int roomCornerY, int roomWidth, int roomHeight)
        {
            for (int x = roomCornerX; x <  roomWidth; x++)
            {
                for (int y = roomCornerY; y <  roomHeight; y++)
                {
                    if (Board[x, y].Status != SquareStatus.Empty)
                    {
                        return false;
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