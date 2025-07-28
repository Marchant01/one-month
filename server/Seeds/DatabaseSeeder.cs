using Microsoft.Data.Sqlite;

public static class DatabaseSeeder
{
    public static async Task CreateTables(SqliteConnection connection)
    {

        var dbPath = connection.DataSource;

        if (File.Exists(dbPath))
        {
            Console.WriteLine($"Database file already exists at: {dbPath}\n");
        }
        else
        {
            Console.WriteLine("Database file does not exist. It will be created upon connection.\n");
        }
        // query string
        var query = @"
            CREATE TABLE IF NOT EXISTS errands (
              id INTEGER PRIMARY KEY AUTOINCREMENT,
              title VARCHAR(255) NOT NULL,
              description TEXT,
              created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
              completed BOOLEAN DEFAULT FALSE
            )";

        try
        {
            await connection.OpenAsync();
            Console.WriteLine("Connected to Database\n");

            Console.WriteLine("Creating Errands table\n");
            using (var cmd = new SqliteCommand(query, connection))
            {
                await cmd.ExecuteNonQueryAsync();
            }
            Console.WriteLine("Creating Errands Table Completed\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}