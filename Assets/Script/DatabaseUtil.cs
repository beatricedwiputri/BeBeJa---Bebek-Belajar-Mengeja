using UnityEngine;
using System.Data;
using System.IO;
using Mono.Data.SqliteClient;


public class DatabaseUtil
{
    private static readonly string dbPath = Path.Combine(Application.persistentDataPath, "save_data.db");
    private static readonly string DBURL = $"URI=file:{dbPath}";
    private static DatabaseUtil instance;

    private IDbConnection connection;
    private IDbCommand command;
    private IDataReader reader;
    
    private DatabaseUtil() 
    {
        GetConnection();
    }
    
    public static DatabaseUtil GetInstance()
    {
        if (instance == null)
        {
            instance = new DatabaseUtil();
        }
        return instance;
    }
    
    private void GetConnection()
    {
        connection = new SqliteConnection(DBURL);
        connection.Open();
    }
    
    public void ExecuteQuery(string sql)
    {
        command = connection.CreateCommand();
        command.CommandText = sql;
        reader = command.ExecuteReader();
    }
    

}
