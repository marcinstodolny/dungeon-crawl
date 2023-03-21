namespace RoguelikeGame
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            var dungeon = new Dungeon(10);
            Console.WriteLine(dungeon.Board[1, 1].Status);
        }
    }
}