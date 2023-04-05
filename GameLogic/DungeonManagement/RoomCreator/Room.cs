using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.DungeonManagement.RoomCreator
{
    public class Room
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<(int, int)> Walls { get; set; }

        public Room(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Walls = new List<(int, int)>();

            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    if (i == x || i == x + width - 1 || j == y || j == y + height - 1)
                    {
                        Walls.Add((i, j));
                    }
                }
            }
        }

        public int CalculateDistanceTo(Room other)
        {
            int xDistance = Math.Abs(X - other.X);
            int yDistance = Math.Abs(Y - other.Y);

            return xDistance + yDistance;
        }

        public (int, int) GetRandomWall()
        {
            var random = new Random();
            int index = random.Next(Walls.Count);

            return Walls[index];
        }

        public void Draw(Square[,] grid)
        {
            for (int x = X; x < X + Width; x++)
            {
                for (int y = Y; y < Y + Height; y++)
                {
                    Coordinates coordinates = new(x, y);
                    bool walkable = false;
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
                    grid[x, y] = new Square(coordinates, status, walkable);
                }
            }
        }
    }
}



//using GameLogic.DungeonManagement.SquareCreator;

//namespace GameLogic.DungeonManagement.RoomCreator
//{
//    public class Room
//    {
//        public Coordinates TopLeft { get; private set; }
//        public Coordinates TopRight { get; private set; }
//        public Coordinates BottomLeft { get; private set; }
//        public Coordinates BottomRight { get; private set; }
//        public bool IsVisible { get; set; }
//        public List<Coordinates> Doors { get; private set; }

//        public Room(Coordinates topLeft, Coordinates topRight, Coordinates bottomLeft, Coordinates bottomRight)
//        {
//            TopLeft = topLeft;
//            TopRight = topRight;
//            BottomLeft = bottomLeft;
//            BottomRight = bottomRight;

//            GenerateDoors();
//        }

//        private void GenerateDoors()
//        {
//            Doors = new List<Coordinates>();
//            Random rand = new Random();

//            // Generate doors for each wall
//            for (int i = 0; i < 4; i++)
//            {
//                if (rand.Next(2) == 1) // 50% chance of door generation
//                {
//                    Coordinates doorCoords;
//                    switch (i)
//                    {
//                        case 0: // North wall
//                            doorCoords = new Coordinates(rand.Next(TopLeft.X + 1, TopRight.X), TopLeft.Y);
//                            break;
//                        case 1: // East wall
//                            doorCoords = new Coordinates(TopRight.X, rand.Next(TopRight.Y + 1, BottomRight.Y));
//                            break;
//                        case 2: // South wall
//                            doorCoords = new Coordinates(rand.Next(BottomLeft.X + 1, BottomRight.X), BottomLeft.Y);
//                            break;
//                        default: // West wall
//                            doorCoords = new Coordinates(TopLeft.X, rand.Next(TopLeft.Y + 1, BottomLeft.Y));
//                            break;
//                    }

//                    Doors.Add(doorCoords);
//                }
//            }
//        }

//        public void DrawRoom(Dungeon dungeon)
//        {
//            for (int x = TopLeft.X; x <= TopRight.X; x++)
//            {
//                for (int y = TopLeft.Y; y <= BottomLeft.Y; y++)
//                {
//                    Coordinates coordinates = new(x, y);
//                    bool walkable = false;
//                    SquareStatus status;
//                    if (x == TopLeft.X && y == TopLeft.Y)
//                    {
//                        status = SquareStatus.CornerNW;
//                    }
//                    else if (x == TopRight.X && y == TopRight.Y)
//                    {
//                        status = SquareStatus.CornerNE;
//                    }
//                    else if (x == BottomLeft.X && y == BottomLeft.Y)
//                    {
//                        status = SquareStatus.CornerSW;
//                    }
//                    else if (x == BottomRight.X && y == BottomRight.Y)
//                    {
//                        status = SquareStatus.CornerSE;
//                    }
//                    else if (x == TopLeft.X || x == TopRight.X)
//                    {
//                        status = SquareStatus.WallVertical;
//                    }
//                    else if (y == TopLeft.Y || y == BottomLeft.Y)
//                    {
//                        status = SquareStatus.WallHorizontal;
//                    }
//                    else
//                    {
//                        status = SquareStatus.Floor;
//                        walkable = true;
//                    }

//                    dungeon.Grid[x, y] = new Square(coordinates, status, walkable);

//                    foreach (Coordinates door in Doors)
//                    {
//                        if (door.X == x && door.Y == y)
//                        {
//                            dungeon.Grid[x, y].Status = SquareStatus.Door;
//                            dungeon.Grid[x, y].Walkable = true;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}
