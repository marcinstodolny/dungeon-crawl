using GameLogic.Entity;

namespace GameLogic.DungeonManagement
{
    public struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinates FromDirection(Direction direction, Player player)
        {
            Coordinates coordinates = player.Square.Position;
            int vectorTurn = 1;

            if (player.DMT)
            {
                vectorTurn = -1;
            }    

            return direction switch
            {
                Direction.North => new Coordinates(coordinates.X, coordinates.Y - vectorTurn),
                Direction.South => new Coordinates(coordinates.X, coordinates.Y + vectorTurn),
                Direction.East => new Coordinates(coordinates.X + vectorTurn, coordinates.Y),
                Direction.West => new Coordinates(coordinates.X - vectorTurn, coordinates.Y),
                Direction.None => new Coordinates(coordinates.X, coordinates.Y),
            };
        }
    }
}
