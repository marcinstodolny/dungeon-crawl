using System.ComponentModel;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;
using RoguelikeGame.Entity.Abstract;

namespace RoguelikeGame;

public class DbManager
{
    public static string ConnectionString => ConfigurationManager.AppSettings["connectionString"]!;
    public static Dictionary<string, string> GetItem(string statistic, string table)
    {
        var getCommand = table == "Keys"
            ?
            $"SELECT TOP 1 id, Name, Symbol " +
            $"FROM {table} ORDER BY NEWID()"
            :
            $"SELECT TOP 1 id, Name, Symbol, {statistic} " +
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
            var itemName = data.GetString("Name").Split(';')[0];
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
        const string getCommand = $"SELECT TOP 1 Name, Symbol, Health, Damage FROM Enemies ORDER BY NEWID()";
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
            var itemName = data.GetString("Name").Split(';')[0];
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
        const string getCommand = $"SELECT TOP 1 Name, Symbol, Message, Bonus, Type FROM Allies ORDER BY NEWID()";
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

            var itemName = data.GetString("Name").Split(';')[0];
            var itemSymbol = data.GetString("Symbol");
            var message = data.GetString("Message").Split(';')[0];
            var bonus = data.GetInt32("Bonus").ToString();
            var type = data.GetString("Type").Split(';')[0];
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

    public static void ResetSavedProgress()
    {
            const string deleteCommand =
                "TRUNCATE TABLE SAVE_Doors, SAVE_Inventory, SAVE_MapItems, SAVE_Monsters, SAVE_Player, SAVE_Room, SAVE_RoomCorners";
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
        string getIdCommand = $"SELECT id FROM {table} WHERE Name LIKE {item.Name}%;";

        const string insertItemCommand = @"INSERT INTO SAVE_Inventory (Item_Type, Item_Id)
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

    public static void RemoveItemFromDatabase()
    {
        throw new NotImplementedException();
    }

    public static void LoadItemsFromSave()
    {
        throw new NotImplementedException();
    }
    
}