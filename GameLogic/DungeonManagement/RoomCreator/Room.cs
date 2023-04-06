using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.DungeonManagement.RoomCreator
{
    public class Room
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Room(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Draw(Square[,] grid)
        {
            for (int x = X; x < X + Width; x++)
            {
                for (int y = Y; y < Y + Height; y++)
                {
                    if (x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1))
                    {
                        Coordinates coordinates = new(x, y);
                        bool walkable = false;
                        bool visible = true;
                        SquareStatus status;
                        if (x == X || x == X + Width - 1)
                        {
                            status = SquareStatus.WallVertical;
                        }
                        else if (y == Y || y == Y + Height - 1)
                        {
                            status = SquareStatus.WallHorizontal;
                        }
                        else
                        {
                            status = SquareStatus.Floor;
                            walkable = true;
                            visible = false;
                        }

                        if (x == X && y == Y)
                        {
                            status = SquareStatus.CornerNW;
                        }
                        else if (x == X + Width - 1 && y == Y)
                        {
                            status = SquareStatus.CornerNE;
                        }
                        else if (x == X && y == Y + Height - 1)
                        {
                            status = SquareStatus.CornerSW;
                        }
                        else if (x == X + Width - 1 && y == Y + Height - 1)
                        {
                            status = SquareStatus.CornerSE;
                        }
                        grid[x, y] = new Square(coordinates, status, walkable, visible);
                    }
                }
            }

            GenerateDoors(grid);
        }

        private void GenerateDoors(Square[,] grid)
        {
            var random = new Random();
            var doorPositions = new List<Coordinates>();

            // Choose a random position for a door on each wall, excluding corners
            if (Width > 2)
            {
                doorPositions.Add(new Coordinates(X + random.Next(1, Width - 1), Y));
                doorPositions.Add(new Coordinates(X + random.Next(1, Width - 1), Y + Height - 1));
            }

            if (Height > 2)
            {
                doorPositions.Add(new Coordinates(X, Y + random.Next(1, Height - 1)));
                doorPositions.Add(new Coordinates(X + Width - 1, Y + random.Next(1, Height - 1)));
            }

            // Shuffle the door positions
            for (int i = doorPositions.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (doorPositions[i], doorPositions[j]) = (doorPositions[j], doorPositions[i]);
            }

            // Choose a random number of doors between 1 and 4, or the maximum available positions
            int numDoors = random.Next(1, Math.Min(5, doorPositions.Count + 1));

            // Add doors to the grid
            for (int i = 0; i < numDoors; i++)
            {
                int x = doorPositions[i].X;
                int y = doorPositions[i].Y;
                grid[x, y].Status = SquareStatus.Door;
                grid[x, y].Walkable = true;
            }
        }
    }
}
