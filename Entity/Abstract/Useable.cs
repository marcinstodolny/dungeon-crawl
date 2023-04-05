using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Useable : Item
    {
        public int Id;
        protected Useable(Square square) : base(square)
        {
        }
        public abstract string PickUp(Player player);
    }
}