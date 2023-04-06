using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace GameLogic;

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
        const string getCommand =
            $"SELECT TOP 1 TRIM(Name) as Name, Symbol, TRIM(Message) as Message, Bonus, Type FROM Allies ORDER BY NEWID()";
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

    //public static Dictionary<string, string> AddItemToDatabase()
        //{
        //    throw new NotImplementedException();
        //}

        //public static Dictionary<string, string> RemoveItemFromDatabase()
        //{
        //    throw new NotImplementedException();
        //}

        //public static Dictionary<string, string> LoadItemsFromSave()
        //{
        //    throw new NotImplementedException();
        //}
}