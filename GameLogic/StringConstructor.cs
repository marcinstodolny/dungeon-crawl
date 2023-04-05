using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.SquareCreator;
using GameLogic.Entity;
using GameLogic.Entity.Abstract;
using System.Text;

namespace GameLogic
{
    public class StringConstructor
    {
        public static string DungeonToString(Dungeon dungeon)
        {
            StringBuilder sbReturn = new();

            for (int y = 0; y < dungeon.Dimensions.Y; y++)
            {
                for (int x = 0; x < dungeon.Dimensions.X; x++)
                {
                    sbReturn.Append(new string($"{(char)dungeon.Grid[x, y].Status}"));
                }
                sbReturn.Append('\n');
            }
            return sbReturn.ToString();
        }
        public static string EntityMessage(Player player)
        {
            if (player.Square.Interactive != null && player.Square.Interactive.GetType().BaseType!.BaseType == typeof(Item))
            {
                return $"Here is an {player.Square.Interactive.Name}, press E to pick up\n";
            }
            else
            {
                return "\n";
            }
        }

        public static string UserStatsToString(Player player)
        {
            return $"Health: {player.Health}\n" + $"Damage: {player.Damage}\n" + $"Armor: {player.Armor}\n";
        }

        public static string PressHForHelp()
        {
            return "\nPress H for help\n";
        }

        public static string MapLegendString()
        {
            return "\nMap Legend:\n" + $"{(char)SquareStatus.Player} : Player\n" + $"{(char)SquareStatus.Item} : Item\n" + $"{(char)SquareStatus.Enemy} : Enemy\n"
                              + $"{(char)SquareStatus.Ally} : Ally\n" + $"{(char)SquareStatus.WallHorizontal} : Wall\n" + $"{(char)SquareStatus.Door} : Door\n"
                              + $"{(char)SquareStatus.Hallway} : Hallway\n";
        }

        public static string InventoryString(Player player)
        {
            StringBuilder sbReturn = new();

            sbReturn.Append("\nYour inventory:");
            foreach (var item in player.Inventory)
            {
                sbReturn.Append(new string($"\n{item.Key.Name}: {item.Value}"));
            }
            sbReturn.Append('\n');
            return sbReturn.ToString();
        }
    }
}
