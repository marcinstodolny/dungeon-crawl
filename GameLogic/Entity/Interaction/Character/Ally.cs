using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.DungeonManagement.SquareCreator;

namespace GameLogic.Entity.Interaction.Character
{

    public class Ally : Abstract.Character
    {
        public int BonusDamage { get; set; }
        public int BonusHealth { get; set; }
        public int BonusArmor { get; set; }
        public string Message { get; set; }
        public Ally(Square square) : base(square)
        {
            var randomAlly = DbManager.GetAlly();
            Name = randomAlly["Name"];
            MapSymbol = randomAlly["Symbol"].ToCharArray()[0];
            Message = randomAlly["Message"];
            Id = int.Parse(randomAlly["Id"]);
            switch (randomAlly["Type"])
            {
                case "Health":
                    BonusHealth = int.Parse(randomAlly["Bonus"]);
                    break;
                case "Damage":
                    BonusDamage = int.Parse(randomAlly["Bonus"]);
                    break;
                case "Armor":
                    BonusArmor = int.Parse(randomAlly["Bonus"]);
                    break;
            }
        }

        public static void PlaceCreature(Dungeon dungeon, Room room)
        {
            Coordinates coordinates = RandomGenerator.FindRandomPlacement(dungeon, room);
            var ally = new Enemy(dungeon.Grid[coordinates.X, coordinates.Y]);
            dungeon.Grid[coordinates.X, coordinates.Y].Interactive = ally;
        }

        public override string ApproachCharacter(Player player)
        {
            player.Health += BonusHealth;
            player.Damage += BonusDamage;
            player.Armor += BonusArmor;
            RemoveFromBoard();
            return "\n" + Message;
        }
    }
}