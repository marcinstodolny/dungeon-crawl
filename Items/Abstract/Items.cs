using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Abstract
{
    public abstract class Items
    {
        public string Name { get; set; }
        public char MapSymbol { get; set; }

        protected Items(string name, char mapSymbol)
        {
            Name = name;
            MapSymbol = mapSymbol;
        }

    }
}
