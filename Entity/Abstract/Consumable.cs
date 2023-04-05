using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Consumable : Item
    {
        public int HPrestore { get; set; }

        protected Consumable(Square square) : base(square)
        {
        }
    }
}
