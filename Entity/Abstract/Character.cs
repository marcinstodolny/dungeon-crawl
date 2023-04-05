using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Abstract;

public abstract class Character : Interactive
{

    protected Character(Square square, string name, char mapSymbol) : base(name, mapSymbol, square)
    {
    }
    public void ChangeSquare(Square newSquare)
    {
        Square.Interactive = null;
        Square = newSquare;
        Square.Interactive = this;
    }
}

