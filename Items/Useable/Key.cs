using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Useable
{

    public class Key : Abstract.Useable
    {
        public Key(Square square, string keyType) : base(square, "", ' ', 0, 0)
        {
            KeyType(keyType);
        }

        public void KeyType(string keyType)
        {
            switch (keyType)
            {
                case "key":
                    Name = "Key";
                    MapSymbol = '\u26BF';
                    break;
                case "DiamondKey":
                    Name = "Diamond key";
                    MapSymbol = '\u26BF';
                    break;
                case "GoldenKey":
                    Name = "Golden key";
                    MapSymbol = '\u26BF';
                    break;

            }
        }
        

    }
}
