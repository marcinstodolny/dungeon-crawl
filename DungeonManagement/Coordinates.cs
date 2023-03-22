namespace RoguelikeGame.DungeonManagement
{
    public struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinates(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}