using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Abstract;

public abstract class Item : Interactive
{
    protected Item(Square square) : base(square)
    {

    }
    public abstract string Interact(Player player);

    public void RemoveFromBoard()
    {
        Square.Interactive = null;
    }
}