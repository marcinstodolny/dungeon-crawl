namespace RoguelikeGame
{
    public struct Score
    {
        public int FinalScore { get; set; }
        public string Name { get; set; }
        public Score(int score, string playerName)
        {
            this.FinalScore = score;
            this.Name = playerName;
        }
    }
}
