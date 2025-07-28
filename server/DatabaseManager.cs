using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;

public class DatabaseManager
{
  private static readonly string _targetDb = "one-month-db";

  public static async Task EnsureDatabaseExists(NpgsqlDataSource db)
  {
    // query string
    var query = @"
    CREATE TABLE IF NOT EXISTS errands (
      id SERIAL PRIMARY KEY,
      title VARCHAR(255) NOT NULL,a
      description TEXT,
      created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
      completed BOOLEAN DEFAULT FALSE
      );
    ";

    await using var conn = db.CreateConnection();
    await conn.OpenAsync();

    using var checkConnectionCmd = new NpgsqlCommand("SELECT 1 FROM pg_database WHERE datname = $1");
    checkConnectionCmd.Parameters.AddWithValue(_targetDb);
    var results = await checkConnectionCmd.ExecuteScalarAsync();
    if(results == null)
    {
      using var createDbCmd = new NpgsqlCommand($"CREATE DATABASE $1");
      createDbCmd.Parameters.AddWithValue(_targetDb);
      var createDbResults = await createDbCmd.ExecuteNonQueryAsync();

      using var createDbTables = new NpgsqlCommand(query, conn);
      var createDbTablesResults = await createDbTables.ExecuteNonQueryAsync();

      Console.WriteLine($"Database '{_targetDb}' created successfully.");
    }
    else
    {
      Console.WriteLine($"Database '{_targetDb}' already exists.");
    }    
  }
}