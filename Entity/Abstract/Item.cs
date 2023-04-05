using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract;

public abstract class Item : Interactive
{
    protected Item(Square square) : base(square)
    {

    }
    public abstract string Interact(Player player);
}