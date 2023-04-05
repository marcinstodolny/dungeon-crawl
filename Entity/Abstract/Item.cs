using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract;

public abstract class Item : Interactive
{
    public int Id;
    protected Item(string name, char mapSymbol, Square square, int id) : base(name, mapSymbol, square)
    {

    }
}