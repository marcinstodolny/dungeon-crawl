using GameLogic.DungeonManagement;
using GameLogic.DungeonManagement.SquareCreator;
using GameLogic.Entity;
using GameLogic.Entity.Abstract;
using GameLogic.Entity.Interaction.Character;
using GameLogic.Entity.Interaction.Item.Consumable;
using GameLogic.Entity.Interaction.Item.Useable;
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


    public static void AddItemsToDatabase(Player player)
    {
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                foreach (KeyValuePair<Useable, int> item in player.Inventory)
                {
                    string insertItemCommand = @"INSERT INTO SAVE_Inventory (Item_Name, Item_Count)
                            VALUES (@Item_Name, @Item_Count);";
                    var cmdInsert = new SqlCommand(insertItemCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmdInsert.Parameters.AddWithValue("@Item_Name", item.Key.Name);
                    cmdInsert.Parameters.AddWithValue("@Item_Count", item.Value);
                    cmdInsert.ExecuteNonQuery();
                }
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

    public static void LoadPlayerfromDB(Player player, Dungeon dungeon)
    {
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string getCommand =
                    "SELECT Name, Coord_X, Coord_Y, Armor, HP, Damage, Alive, DMT FROM SAVE_Player where id = 1;";
                var cmdGet = new SqlCommand(getCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                var reader = cmdGet.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["name"] as string;
                    int playerCoorX = (int)reader["Coord_X"];
                    int playerCoorY = (int)reader["Coord_Y"];
                    int armor = (int)reader["Armor"];
                    int health = (int)reader["HP"];
                    int damage = (int)reader["Damage"];
                    new Player(name, dungeon.Grid[playerCoorX, playerCoorY], health, armor, damage);
                    player.DMT = (bool)reader["DMT"];
                }

                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void LoadInventoryfromDB(Player player)
    {
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string getCommand = "SELECT Item_Name, Item_Count FROM SAVE_Inventory;";
                var cmdGet = new SqlCommand(getCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                var reader = cmdGet.ExecuteReader();
                while (reader.Read())
                {
                     // Please skip this part, it's a late-night-workaround (not actual solution) ;)
                    string item_name = reader["Item_Name"] as string;
                    int item_Count = (int)reader["Item_Count"];
                    Coordinates position = new Coordinates(300,300);
                    Square fakeSquare = new Square(position, SquareStatus.Empty, false, false);
                    Useable dummyItem = new Keys(fakeSquare);
                    dummyItem.Name = item_name;
                    player.Inventory[dummyItem] = item_Count;

                }

                connection.Close();
            }
        }
        catch (SqlException e)
        {
            throw new RuntimeWrappedException(e);
        }
    }

    public static void LoadGridfromDB(Dungeon dungeon)
    {
        try
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string getCommand =
                    "SELECT Coord_X, Coord_Y, Status, Walkable, Visible, Interact_Type, Interact_Id FROM SAVE_Grid;";
                var cmdGet = new SqlCommand(getCommand, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                var reader = cmdGet.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < dungeon.Width; i++)
                    {
                        for (int j = 0; j < dungeon.Height; j++)
                        {
                            int x = (int)reader["Coord_X"];
                            int y = (int)reader["Coord_Y"];
                            string statusString = reader["Status"] as string;
                            string interactiveObject = reader["Interact_Type"] as string;
                            int interactiveID = (int)reader["Interact_Id"];
                            Coordinates position = new Coordinates(x,y);
                            var status = (SquareStatus)Enum.Parse(typeof(SquareStatus), statusString);
                            var walkable = (bool)reader["Walkable"];
                            var visible = (bool)reader["Visible"];
                            Square square = new Square(position, status, walkable, visible);
                            if (interactiveObject == "")
                            {
                                dungeon.Grid[x, y].Interactive = null;
                            }
                            else
                            {
                                dungeon.Grid[x, y].Interactive = MapEventToLoadToGRidFromDB(interactiveObject, interactiveID, square);
                            }

                        }
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

    public static Interactive MapEventToLoadToGRidFromDB(string table, int eventId, Square square)
    {
        using (var connection = new SqlConnection(ConnectionString))
        {

            switch (table)
            {
                case "Ally":
                    string getAllayCommand =
                        $"SELECT Name, Symbol, Message, Bonus, Type FROM Ally WHERE id = {eventId};";
                    var cmdAllayGet = new SqlCommand(getAllayCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var readerAllay = cmdAllayGet.ExecuteReader();
                    while (readerAllay.Read())
                    {
                        Ally ally = new Ally(square);
                        ally.Name = (string)readerAllay["Name"];
                        ally.MapSymbol = (char)readerAllay["Symbol"];
                        ally.Message = (string)readerAllay["Name"];
                        if ((string)readerAllay["Type"] == "Health")
                        {
                            ally.BonusHealth = (int)readerAllay["Bonus"];
                        } 
                        else if ((string)readerAllay["Type"] == "Damage")
                        {
                            ally.BonusDamage = (int)readerAllay["Bonus"];
                        }
                        connection.Close();
                        return ally;
                    }
                    break;
                case "Enemy":
                    string getEnemyCommand =
                        $"SELECT Name, Symbol, Health, Damage FROM Enemy WHERE id = {eventId};";
                    var cmdEnemyGet = new SqlCommand(getEnemyCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var readerEnemy = cmdEnemyGet.ExecuteReader();
                    while (readerEnemy.Read())
                    {
                        Enemy enemy = new Enemy(square);
                        enemy.Name = (string)readerEnemy["Name"];
                        enemy.MapSymbol = (char)readerEnemy["Symbol"];
                        enemy.Health = (int)readerEnemy["Health"];
                        enemy.Damage = (int)readerEnemy["Damage"];
                        connection.Close();
                        return enemy;
                    }
                    break;
                case "Armor":
                    string getArmorCommand =
                        $"SELECT Name, Symbol, Armor FROM Armor WHERE id = {eventId};";
                    var cmdArmorGet = new SqlCommand(getArmorCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var readerArmor = cmdArmorGet.ExecuteReader();
                    while (readerArmor.Read())
                    {
                        Armor armor = new Armor(square);
                        armor.Name = (string)readerArmor["Name"];
                        armor.MapSymbol = (char)readerArmor["Symbol"];
                        armor.Protection = (int)readerArmor["Armor"];
                        connection.Close();
                        return armor;
                    }
                    break;
                case "Food":
                    string getFoodCommand =
                        $"SELECT Name, Symbol, HPrestore FROM Food WHERE id = {eventId};";
                    var cmdFoodGet = new SqlCommand(getFoodCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var readerFood = cmdFoodGet.ExecuteReader();
                    while (readerFood.Read())
                    {
                        Food food = new Food(square);
                        food.Name = (string)readerFood["Name"];
                        food.MapSymbol = (char)readerFood["Symbol"];
                        food.HPrestore = (int)readerFood["HPrestore"];
                        connection.Close();
                        return food;
                    }
                    break;
                case "Keys":
                    string getKeysCommand =
                        $"SELECT Name, Symbol FROM Keys WHERE id = {eventId};";
                    var cmdKeysGet = new SqlCommand(getKeysCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var readerKeys = cmdKeysGet.ExecuteReader();
                    while (readerKeys.Read())
                    {
                        Keys keys = new Keys(square);
                        keys.Name = (string)readerKeys["Name"];
                        keys.MapSymbol = (char)readerKeys["Symbol"];
                        connection.Close();
                        return keys;
                    }
                    break;
                case "Potion":
                    string getPotionCommand =
                        $"SELECT Name, Symbol, HPrestore FROM Potion WHERE id = {eventId};";
                    var cmdPotionGet = new SqlCommand(getPotionCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var readerPotion = cmdPotionGet.ExecuteReader();
                    while (readerPotion.Read())
                    {
                        Potion potion = new Potion(square);
                        potion.Name = (string)readerPotion["Name"];
                        potion.MapSymbol = (char)readerPotion["Symbol"];
                        potion.HPrestore = (int)readerPotion["HPrestore"];
                        connection.Close();
                        return potion;
                    }
                    break;
                case "Weapon":
                    string getWeaponCommand =
                        $"SELECT Name, Symbol, Attack FROM Weapon WHERE id = {eventId};";
                    var cmdWeaponGet = new SqlCommand(getWeaponCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var readerWeapon = cmdWeaponGet.ExecuteReader();
                    while (readerWeapon.Read())
                    {
                        Weapon weapon = new Weapon(square);
                        weapon.Name = (string)readerWeapon["Name"];
                        weapon.MapSymbol = (char)readerWeapon["Symbol"];
                        weapon.Damage = (int)readerWeapon["Attack"];
                        connection.Close();
                        return weapon;
                    }
                    break;
                
            }
        }

        return null;
    }
}



    
