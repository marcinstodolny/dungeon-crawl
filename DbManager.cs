using Microsoft.Data.SqlClient;
using RoguelikeGame.Entity.Abstract;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using RoguelikeGame.Entity;
using System.Numerics;
using RoguelikeGame.DungeonManagement;

namespace RoguelikeGame;

public class DbManager
{
    public static string ConnectionString => ConfigurationManager.AppSettings["connectionString"]!;
    public static Dictionary<string, string> GetItem(string statistic, string table)
    {
        var getCommand = table == "Keys"
            ?
            $"SELECT TOP 1 id, TRIM(Name) as Name, Symbol " +
            $"FROM {table} ORDER BY NEWID()"
            :
            $"SELECT TOP 1 id, TRIM(Name) as Name, Symbol, {statistic} " +
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
                "Armors" => data.GetInt32("Armor").ToString(),
                "Weapons" => data.GetInt32("Attack").ToString(),
                "Potions" or "Foods" => data.GetInt32("HPRestore").ToString(),
                _ => ""
            };
            var id = data.GetInt32("id").ToString();
            var itemName = data.GetString("Name");
            var itemSymbol = data.GetString("Symbol");
            connection.Close();
            return new Dictionary<string, string>()
            {
                {"Id", id},
                {"Name", itemName},
                {"Symbol", itemSymbol},
                {"Stat", itemStatistic}
            };
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static Dictionary<string, string> GetEnemy()
    {
        const string getCommand = $"SELECT TOP 1 TRIM(Name) as Name, Symbol, Health, Damage FROM Enemies ORDER BY NEWID()";
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
            connection.Close();
            return new Dictionary<string, string>()
            {
                {"Name", itemName},
                {"Symbol", itemSymbol},
                {"Health", health},
                {"Damage", damage}
            };
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static Dictionary<string, string> GetAlly()
    {
        const string getCommand = $"SELECT TOP 1 TRIM(Name) as Name, Symbol, TRIM(Message) as Message, Bonus, Type FROM Allies ORDER BY NEWID()";
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
            connection.Close();
            return new Dictionary<string, string>()
            {
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
                "TRUNCATE TABLE SAVE_Doors; TRUNCATE TABLE SAVE_Inventory; TRUNCATE TABLE SAVE_MapItems; TRUNCATE TABLE SAVE_Monsters; TRUNCATE TABLE SAVE_Player; TRUNCATE TABLE SAVE_Room; TRUNCATE TABLE SAVE_RoomCorners;";
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
        const string insertCommand = @"INSERT INTO SAVE_Player (Coord_X, Coord_Y, Armor, HP, Damage, Alive, DMT)
                            VALUES (@Coord_X, @Coord_Y, @Armor, @HP, @Damage, @Alive, @DMT);";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(insertCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Coord_X", player.PreviousSquare.X);
                cmdInsert.Parameters.AddWithValue("@Coord_Y", player.PreviousSquare.Y);
                cmdInsert.Parameters.AddWithValue("@Armor", player.Armor);
                cmdInsert.Parameters.AddWithValue("@HP", player.Health);
                cmdInsert.Parameters.AddWithValue("@Damage", player.Damage);
                cmdInsert.Parameters.AddWithValue("@Alive", player.Alive);
                cmdInsert.Parameters.AddWithValue("@DMT", player.DMT);
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }
    public static void UpdatePlayerCoordsInDB(Player player)
    {
        const string updateCommand = @"UPDATE SAVE_Player SET Coord_X = @Coord_X,
                Coord_Y = @Coord_Y
                WHERE id = 1;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(updateCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Coord_X", player.PreviousSquare.X);
                cmdInsert.Parameters.AddWithValue("@Coord_Y", player.PreviousSquare.Y);
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }
    public static void UpdatePlayerArmorInDB(Player player)
    {
        const string updateCommand = @"UPDATE SAVE_Player SET Armor = @Armor,
                WHERE id = 1;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(updateCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Armor", player.Armor);
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }
    public static void UpdatePlayerHPInDB(Player player)
    {
        const string updateCommand = @"UPDATE SAVE_Player SET HP = @HP,
                WHERE id = 1;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(updateCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@HP", player.Health);
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }
    public static void UpdatePlayerDamageInDB(Player player)
    {
        const string updateCommand = @"UPDATE SAVE_Player SET Damage = @Damage,
                WHERE id = 1;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(updateCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Damage", player.Damage);
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }
    public static void UpdatePlayerAliveStatusInDB(Player player)
    {
        const string updateCommand = @"UPDATE SAVE_Player SET Alive = @Alive,
                WHERE id = 1;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(updateCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Alive", player.Alive);
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void UpdatePlayerDMTStatusInDB(Player player)
    {
        const string updateCommand = @"UPDATE SAVE_Player SET DMT = @DMT,
                WHERE id = 1;";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(updateCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@DMT", player.DMT);
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void CreateRoomInDB(int roomCornerNW, int roomCornerNE, int roomCornerSW, int roomCornerSE, bool visibility)
    {
        const string insertCommand = @"INSERT INTO SAVE_Rooms (Corner_NW_id, Corner_NE_id, Corner_SW_id, Corner_SE_id, Visibility)
                            VALUES (@Corner_NW_id, @Corner_NE_id, @Corner_SW_id, @Corner_SE_id, @Visibility);";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(insertCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Corner_NW_id", roomCornerNW);
                cmdInsert.Parameters.AddWithValue("@Corner_NE_id", roomCornerNE);
                cmdInsert.Parameters.AddWithValue("@Corner_SW_id", roomCornerSW);
                cmdInsert.Parameters.AddWithValue("@Corner_SE_id", roomCornerSE);
                cmdInsert.Parameters.AddWithValue("@visibility", visibility);
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void CreateRoomInDB(Square roomCornerNW, Square roomCornerNE, Square roomCornerSW, Square roomCornerSE, bool visibility)
    {
        const string insertCommand = @"INSERT INTO SAVE_Rooms (Corner_NW_id, Corner_NE_id, Corner_SW_id, Corner_SE_id, Visibility)
                            VALUES (@Corner_NW_id, @Corner_NE_id, @Corner_SW_id, @Corner_SE_id, @Visibility);";
        const string insertRoomCoorners = @"INSERT INTO SAVE_RoomCorners (Room_id, Coord_X, Coord_Y)
                            VALUES (@Room_id, @Coord_X, @Coord_Y);";
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

                var cmdInsert = new SqlCommand(insertCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsert.Parameters.AddWithValue("@Corner_NW_X", roomCornerNW);
                cmdInsert.Parameters.AddWithValue("@Corner_NW_Y", roomCornerNW);
                cmdInsert.Parameters.AddWithValue("@Corner_NE_id", roomCornerNE);
                cmdInsert.Parameters.AddWithValue("@Corner_SW_id", roomCornerSW);
                cmdInsert.Parameters.AddWithValue("@Corner_SE_id", roomCornerSE);
                cmdInsert.Parameters.AddWithValue("@visibility", visibility);




                var cmdInsertCoords = new SqlCommand(insertRoomCoorners, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmdInsertCoords.Parameters.AddWithValue("@Room_id", roomCornerNW);
                cmdInsertCoords.Parameters.AddWithValue("@Coord_X", roomCornerNW);
                cmdInsertCoords.Parameters.AddWithValue("@Coord_Y", roomCornerNW);


                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

}
    
