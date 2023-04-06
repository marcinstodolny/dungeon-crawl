using GameLogic.DungeonManagement;
using System.Data.SqlClient;
using System.Configuration;
using GameLogic.DungeonManagement.RoomCreator;
using GameLogic.Entity;

namespace GameLogic;

public class Game
{
    public static void Main()
    { 
    }
    public static string ConnectionString => ConfigurationManager.AppSettings["connectionString"]!;
    public bool GameIsOn { get; set; }
    public Dungeon Dungeon { get; set; }
    public Player Player { get; set; }

    public List<Score> HighScores;


    public Game()
    {
        GameIsOn = true;
        Dungeon = new Dungeon(220, 360);
    }
    public void InitializePlayer(string name)
    {
        Player = PlayerPlacement(name);
        Player.RevealSquares(Dungeon);
    }

    public Player PlayerPlacement(string name)
    {
        Room room = Dungeon.Rooms[0];
        Coordinates coordinates = RandomGenerator.FindRandomPlacement(Dungeon, room);
        return new Player(name, Dungeon.Grid[coordinates.X, coordinates.Y]);
    }

    public string ScreenViewportToString()
    {
        return StringConstructor.DungeonViewportToString(Dungeon, Player) + StringConstructor.UserStatsToString(Player)
            + StringConstructor.PressHForHelp() + StringConstructor.ItemMessage(Player);
    }

    public static string MapLegendString()
    {
        return StringConstructor.MapLegendString();
    }

    public string InventoryString()
    {
        return StringConstructor.InventoryString(Player);
    }

    public string PassPlayerDirection(Direction direction)
    {
        return Player.TryToMove(Coordinates.FromDirection(direction, Player), Dungeon);
    }

    public static bool TestConnection()
    {
        using var connection = new SqlConnection(ConnectionString);
        try
        {
            connection.Open();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
    