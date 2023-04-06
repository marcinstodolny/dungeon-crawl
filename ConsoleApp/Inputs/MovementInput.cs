using ConsoleApp.Outputs;
using GameLogic.DungeonManagement;
using GameLogic;


namespace ConsoleApp.Inputs
{
    internal class MovementInput
    {
        public static void GetPlayerMovement(Game game)
        {
            string outputMessage = "";
            switch (Input.WaitForKeyPress().Key)
            {

                case ConsoleKey.A:
                    outputMessage = game.PassPlayerDirection(Direction.West);
                    Output.ShowOnScreen(game.ScreenViewportToString() + outputMessage);
                    WaitIfOutput(outputMessage);
                    break;
                case ConsoleKey.W:
                    outputMessage = game.PassPlayerDirection(Direction.North);
                    Output.ShowOnScreen(game.ScreenViewportToString() + outputMessage);
                    WaitIfOutput(outputMessage);
                    break;
                case ConsoleKey.S:
                    outputMessage = game.PassPlayerDirection(Direction.South);
                    Output.ShowOnScreen(game.ScreenViewportToString() + outputMessage);
                    WaitIfOutput(outputMessage);
                    break;
                case ConsoleKey.D:
                    outputMessage = game.PassPlayerDirection(Direction.East);
                    Output.ShowOnScreen(game.ScreenViewportToString() + outputMessage);
                    WaitIfOutput(outputMessage);
                    break;
                case ConsoleKey.E:
                    outputMessage = game.PassPlayerDirection(Direction.None);
                    Output.ShowOnScreen(game.ScreenViewportToString() + outputMessage);
                    Output.WaitMessage();
                    break;
                case ConsoleKey.I:
                    Output.ShowOnScreen(game.InventoryString());
                    Output.WaitMessage();
                    break;
                case ConsoleKey.H:
                    Output.Clear();
                    Output.DisplayHelp();
                    Output.WaitMessage();
                    break;
                case ConsoleKey.M:
                    Output.ShowOnScreen(Game.MapLegendString());
                    Output.WaitMessage();
                    break;
                case ConsoleKey.F5:
                    Output.SavingMessage();
                    DbManager.ClearSavedProgressinDB();
                    DbManager.CreatePlayerInDB(game.Player);
                    DbManager.AddItemsToDatabase(game.Player);
                    DbManager.CreateGridInDB(game.Dungeon);
                    Output.SavedMessage();
                    break;
                case ConsoleKey.Escape:
                    game.GameIsOn = false;
                    break;
                default:
                    break;
            }
        }

        private static void WaitIfOutput(string outputMessage)
        {
            if (outputMessage != "" && outputMessage != "\n")
            {
                Output.WaitMessage();
            }
        }
    }
}
