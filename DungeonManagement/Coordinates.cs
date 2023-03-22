namespace RoguelikeGame.DungeonManagement
{
    public struct Coordinates
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Coordinates(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}