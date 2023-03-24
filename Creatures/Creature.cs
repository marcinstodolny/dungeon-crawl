namespace RoguelikeGame.Creatures
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public char MapSymbol { get; set; }

        protected Creature(string name, char mapSymbol)
        {
            Name = name;
            MapSymbol = mapSymbol;
        }

    }
}
