using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Consumable;
using static RoguelikeGame.Items.Consumable.Food;

namespace RoguelikeGame.Items.Useable
{

    public class Key : Abstract.Useable
    {
        public Key(keyType keyType) : base("", ' ', 0, 0)
        {
            SetKeyType(keyType);
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
        public static void PlaceItem(Game game)
        {
            var enumLength = Enum.GetNames(typeof(keyType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var item = new Key((keyType)RandomGenerator.NextInt(enumLength));
            game.Dungeon.Board[randX, randY].Item = item;
            game.Dungeon.Board[randX, randY].Status = SquareStatus.Item;
        }


    }
}
