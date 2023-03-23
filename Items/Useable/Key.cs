using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Items.Useable
{

    public class Key : Abstract.Useable
    {
        public Key(Square square, string keyType) : base(square, "", ' ', 0, 0)
        {
            KeyType(keyType);
        }
        public enum keyType
        {
            Key,
            DiamondKey,
            GoldenKey
         
        }
        public void SetKeyType(keyType keyType)
        {
            switch (keyType)
            {
                case keyType.Key:
                    Name = "Key";
                    MapSymbol = '\u26BF';
                    break;
                case keyType.DiamondKey:
                    Name = "Diamond key";
                    MapSymbol = '\u26BF';
                    break;
                case keyType.GoldenKey:
                    Name = "Golden key";
                    MapSymbol = '\u26BF';
                    break;

            }
        }
        

    }
}
