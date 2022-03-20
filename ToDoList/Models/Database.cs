using System;
// using MySql.Data.MySqlClient;
using MySqlConnector;
using ToDoList;

namespace ToDoList.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}