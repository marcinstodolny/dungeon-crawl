using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame.Entity.Interaction.Creatures
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

        public static void PlaceCreature(Game game)
        {
            var (randX, randY) = RandomGenerator.FindRandomPlacement(game.Dungeon);
            var ally = new Ally(game.Dungeon.Board[randX, randY]);
            game.Dungeon.Board[randX, randY].Interactive = ally;
        }

        public override string ApproachCharacter(Player player)
        {
            player.Health += BonusHealth;
            player.Damage += BonusDamage;
            player.Armor += BonusArmor;
            RemoveFromBoard();
            return Message;
        }

    }
}