using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract
{
    public abstract class Useable : Item
    {
        public int Id;
        protected Useable(Square square) : base(square)
        {
        }

        protected void AddToInventory(Player player)
        {
            if (player.Inventory.ContainsKey(this))
            {
                player.Inventory[this]++;
            }
            else
            {
                player.Inventory[this] = 1;
            }
        }
    }
}