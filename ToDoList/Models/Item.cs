using System.Collections.Generic;
using MySqlConnector;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; set; }

    public Item(string description)
    {
      Description = description;
    }
    public Item(string description, int id)
    {
      Description = description;
      Id = id;
    }

    public void Save()
    {
      MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=epicodus;port=3306;database=to_do_list;SslMode=None");
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO items (description) VALUES (@ItemDescription);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ItemDescription";
      param.Value = this.Description;
      cmd.Parameters.Add(param);
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Item Find(int id)
    {
      MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=epicodus;port=3306;database=to_do_list;SslMode=None");
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM `items` WHERE id = @ThisId;";

      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;
      cmd.Parameters.Add(param);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int itemId = 0;
      string itemDescription = "";
      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemDescription = rdr.GetString(1);
      }
      Item foundItem = new Item(itemDescription, itemId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundItem;
    }

    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> { };
      MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=epicodus;port=3306;database=to_do_list;SslMode=None");
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item(itemDescription, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = new MySqlConnection("server=localhost;userid=root;password=epicodus;port=3306;database=to_do_list;SslMode=None");
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM items;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}