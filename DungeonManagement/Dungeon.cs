using System;

namespace RoguelikeGame.DungeonManagement
{
    internal class Dungeon
    {
        public readonly int Height = 52;
        public readonly int Width = 52;
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
                    Board[x, y] = new Square(x, y, SquareStatus.Empty);
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
            for (int x = roomCornerX; x < roomCornerX + roomWidth; x++)
            {
                Board[x, roomCornerY].Status = SquareStatus.Wall;
                Board[x, roomCornerY + roomHeight - 1].Status = SquareStatus.Wall;
            }
            for (int y = roomCornerY; y < roomCornerY + roomHeight; y++)
            {
                Board[roomCornerX, y].Status = SquareStatus.Wall;
                Board[roomCornerX + roomWidth - 1, y].Status = SquareStatus.Wall;
            }
        }

        public void PlayerPlacement(Player player)
        {
            (int randX, int randY) = FindRandomPlacement();
            player.SetPlayer(Board[randX, randY]);
            Board[randX, randY].Status = SquareStatus.Player;
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
