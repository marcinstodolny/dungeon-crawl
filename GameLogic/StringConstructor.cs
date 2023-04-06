using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.SquareCreator;
using GameLogic.Entity;
using GameLogic.Entity.Abstract;
using System.Text;

namespace GameLogic
{
    public class StringConstructor
    {
        public static string DungeonViewportToString(Dungeon dungeon, Player player)
        {
            int viewportWidth = 140;
            int viewportHeight = 24;

            int startX = player.Square.Position.X - (viewportWidth / 2);
            int startY = player.Square.Position.Y - (viewportHeight / 2);

            int endX = startX + viewportWidth;
            int endY = startY + viewportHeight;

            StringBuilder sb = new();

            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    if (x >= 0 && x < dungeon.Width && y >= 0 && y < dungeon.Height)
                    {
                        Square square = dungeon.Grid[x, y];
                        if (square.Visible)
                        {
                            sb.Append(square.Interactive != null
                                ? new string($"{square.Interactive.MapSymbol}")
                                : new string($"{(char)square.Status}"));
                        }
                        else
                        {
                            sb.Append(' ');
                        }

                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }

        public static string ItemMessage(Player player)
        {
            if (player.Square.Interactive != null && player.Square.Interactive.GetType().BaseType!.BaseType == typeof(Item))
            {
                return $"\nHere's {player.Square.Interactive.Name}, press E to pick up\n";
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
