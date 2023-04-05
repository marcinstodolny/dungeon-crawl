using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract;

public abstract class Item : Interactive
{
    protected Item(string name, char mapSymbol, Square square) : base(name, mapSymbol, square)
    {

    }
}