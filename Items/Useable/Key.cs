using RoguelikeGame.DungeonManagement;
using RoguelikeGame.Items.Consumable;
using static RoguelikeGame.Items.Consumable.Food;

namespace RoguelikeGame.Items.Useable
{

    public class Key : Abstract.Useable
    {
        public Key(string keyType) : base("", ' ', 0, 0)
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
        public void PlaceItem(Game game) // change type
        {
            var enumLength = Enum.GetNames(typeof(FoodType)).Length;
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.dungeon);
            var item = new Food((FoodType)RandomGenerator.NextInt(enumLength));
            game.dungeon.Board[randX, randY].Item = item;
        }


    }
}
