using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract;

public abstract class Character : Entity
{

    protected Character(Square square, string name, char mapSymbol) : base(square, name, mapSymbol)
    {
    }
}

