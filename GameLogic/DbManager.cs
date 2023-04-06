using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using GameLogic.DungeonManagement;
using GameLogic.Entity;
using GameLogic.Entity.Abstract;

namespace GameLogic;

public class DbManager
{
    public static string ConnectionString => ConfigurationManager.AppSettings["connectionString"]!;

    public static Dictionary<string, string> GetItem(string statistic, string table)
    {
        var getCommand = table == "Keys"
            ? $"SELECT TOP 1 id, TRIM(Name) as Name, Symbol " +
              $"FROM {table} ORDER BY NEWID()"
            : $"SELECT TOP 1 id, TRIM(Name) as Name, Symbol, {statistic} " +
              $"FROM {table} ORDER BY NEWID()";
        try
        {
            using var connection = new SqlConnection(ConnectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            var command = new SqlCommand(getCommand, connection);
            var data = command.ExecuteReader();
            if (!data.Read())
            {
                return new Dictionary<string, string>();
            }

            var itemStatistic = table switch
            {
                "Armor" => data.GetInt32("Armor").ToString(),
                "Weapon" => data.GetInt32("Attack").ToString(),
                "Potion" or "Food" => data.GetInt32("HPRestore").ToString(),
                _ => ""
            };
            var id = data.GetInt32("id").ToString();
            var itemName = data.GetString("Name");
            var itemSymbol = data.GetString("Symbol");
            connection.Close();
            return new Dictionary<string, string>()
            {
                { "Id", id },
                { "Name", itemName },
                { "Symbol", itemSymbol },
                { "Stat", itemStatistic }
            };
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static Dictionary<string, string> GetEnemy()
    {
        const string getCommand =
            $"SELECT TOP 1 id, TRIM(Name) as Name, Symbol, Health, Damage FROM Enemy ORDER BY NEWID()";
            try
        {
            using var connection = new SqlConnection(ConnectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            var command = new SqlCommand(getCommand, connection);
            var data = command.ExecuteReader();
            if (!data.Read())
            {
                return new Dictionary<string, string>();
            }

            var itemName = data.GetString("Name");
            var itemSymbol = data.GetString("Symbol");
            var health = data.GetInt32("Health").ToString();
            var damage = data.GetInt32("Damage").ToString();
            var id = data.GetInt32("Id").ToString();
            connection.Close();
            return new Dictionary<string, string>()
            {
                { "Id", id },
                { "Name", itemName },
                { "Symbol", itemSymbol },
                { "Health", health },
                { "Damage", damage }
            };
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static Dictionary<string, string> GetAlly()
    {
        const string getCommand =
            $"SELECT TOP 1 id, TRIM(Name) as Name, Symbol, TRIM(Message) as Message, Bonus, TRIM(Type) as Type FROM Ally ORDER BY NEWID()";
            try
        {
            using var connection = new SqlConnection(ConnectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            var command = new SqlCommand(getCommand, connection);
            var data = command.ExecuteReader();
            if (!data.Read())
            {
                return new Dictionary<string, string>();
            }

            var itemName = data.GetString("Name");
            var itemSymbol = data.GetString("Symbol");
            var message = data.GetString("Message");
            var bonus = data.GetInt32("Bonus").ToString();
            var type = data.GetString("Type");
            var id = data.GetInt32("Id").ToString();
            connection.Close();
            return new Dictionary<string, string>()
            {
                { "Id", id },
                { "Name", itemName },
                { "Symbol", itemSymbol },
                { "Message", message },
                { "Bonus", bonus },
                { "Type", type }
            };
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void ClearSavedProgressinDB()
    {
        const string deleteCommand =
            "TRUNCATE TABLE SAVE_Inventory;TRUNCATE TABLE SAVE_Player; TRUNCATE TABLE SAVE_Grid;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(deleteCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }


    public static void AddItemToDatabase(Useable item, string table)
    {
        const string insertItemCommand = @"INSERT INTO SAVE_Inventory(Item_Type, Item_Id)
                            VALUES (@Item_Type, @Item_Id);";

        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(insertItemCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Item_Type", table);
                cmdInsert.Parameters.AddWithValue("@Item_Id", item.Id);
                cmdInsert.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void CreatePlayerInDB(Player player)
    {
        const string insertCommand = @"INSERT INTO SAVE_Player (Coord_X, Coord_Y, Name, Armor, HP, Damage, Alive, DMT)
                            VALUES (@Coord_X, @Coord_Y, @Name, @Armor, @HP, @Damage, @Alive, @DMT);";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(insertCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Coord_X", player.Square.Position.X);
                cmdInsert.Parameters.AddWithValue("@Coord_Y", player.Square.Position.Y);
                cmdInsert.Parameters.AddWithValue("@Name", player.Name);
                cmdInsert.Parameters.AddWithValue("@Armor", player.Armor);
                cmdInsert.Parameters.AddWithValue("@HP", player.Health);
                cmdInsert.Parameters.AddWithValue("@Damage", player.Damage);
                cmdInsert.Parameters.AddWithValue("@Alive", player.Alive);
                cmdInsert.Parameters.AddWithValue("@DMT", player.DMT);
                cmdInsert.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void UpdatePlayerInDB(Player player)
    {
        const string updateCommand = @"UPDATE SAVE_Player SET Coord_X = @Coord_X,
                Coord_Y = @Coord_Y,
                Name = @Name,
                Armor = @Armor,
                HP = @HP,
                Damage = @Damage,
                Alive = @Alive,
                DMT = @DMT
                WHERE id = 1;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(updateCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Coord_X", player.Square.Position.X);
                cmdInsert.Parameters.AddWithValue("@Coord_Y", player.Square.Position.Y);
                cmdInsert.Parameters.AddWithValue("@Name", player.Name);
                cmdInsert.Parameters.AddWithValue("@Armor", player.Armor);
                cmdInsert.Parameters.AddWithValue("@HP", player.Health);
                cmdInsert.Parameters.AddWithValue("@Damage", player.Damage);
                cmdInsert.Parameters.AddWithValue("@Alive", player.Alive);
                cmdInsert.Parameters.AddWithValue("@DMT", player.DMT);
                cmdInsert.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void CreateGridInDB(Dungeon dungeon)
    {

        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                for (int x = 0; x < dungeon.Width; x++)
                {
                    for (int y = 0; y < dungeon.Height; y++)
                    {
                        string? interactObjectTypeString;
                        int? interactId;

                        if (dungeon.Grid[x, y].Interactive == null)
                        {
                            interactObjectTypeString = "";
                            interactId = 0;
                        }
                        else
                        {
                            interactObjectTypeString = dungeon.Grid[x, y].Interactive.GetType().Name;
                            interactId = dungeon.Grid[x, y].Interactive.Id;

                        }
                        int Walkable = dungeon.Grid[x, y].Walkable ? 1 : 0;
                        int Visible = dungeon.Grid[x, y].Visible ? 1 : 0;
                        string insertCommand =
                            @"INSERT INTO SAVE_Grid (Coord_X, Coord_Y, Status, Walkable, Visible, Interact_Type, Interact_Id)
                            VALUES (@Coord_X, @Coord_Y, @Status, @Walkable, @Visible, @Interact_Type, @Interact_Id);";
                        var cmdInsert = new SqlCommand(insertCommand, connection);

                        cmdInsert.Parameters.AddWithValue("@Coord_X", x);
                        cmdInsert.Parameters.AddWithValue("@Coord_Y", y);
                        cmdInsert.Parameters.AddWithValue("@Status", Enum.GetName(dungeon.Grid[x, y].Status));
                        cmdInsert.Parameters.AddWithValue("@Walkable", Walkable);
                        cmdInsert.Parameters.AddWithValue("@Visible", Visible);
                        cmdInsert.Parameters.AddWithValue("@Interact_Type", interactObjectTypeString);
                        cmdInsert.Parameters.AddWithValue("@Interact_Id", interactId);
                        cmdInsert.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }

    }

    public static void UpdateGridInDB(Dungeon dungeon)
    {
        const string insertCommand = @"UPDATE SAVE_Grid SET Status = @Status,
                                                            Walkable = @Walkable,
                                                            Visible = @Visible,
                                                            Interact_Type = @Interact_Type,
                                                            Interact_Id = @Interact_Id,
                                                            WHERE Coord_X = @Coord_X
                                                            AND Coord_Y = @Coord_Y;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(insertCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                for (int x = 0; x < dungeon.Width; x++)
                {
                    for (int y = 0; y < dungeon.Height; y++)
                    {
                        string? interactObjectType =
                            dungeon.Grid[x, y].Interactive.GetType().ToString().Split(".", -1)[0];

                        cmdInsert.Parameters.AddWithValue("@Coord_X", x);
                        cmdInsert.Parameters.AddWithValue("@Coord_Y", y);
                        cmdInsert.Parameters.AddWithValue("@Status", dungeon.Grid[x, y].Status);
                        cmdInsert.Parameters.AddWithValue("@Walkable", dungeon.Grid[x, y].Walkable);
                        cmdInsert.Parameters.AddWithValue("@Visible", dungeon.Grid[x, y].Visible);
                        cmdInsert.Parameters.AddWithValue("@Interact_Type", interactObjectType);
                        cmdInsert.Parameters.AddWithValue("@Interact_Id", dungeon.Grid[x, y].Interactive.Id);
                        cmdInsert.ExecuteNonQuery();

                    }
                }

                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }

    }
}
    
