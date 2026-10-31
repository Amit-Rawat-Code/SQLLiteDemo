using Microsoft.Data.Sqlite;

public static class DatabaseHelper
{
    private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "demo.db");
    private static string _connectionString = $"Data Source={DbPath};Mode=ReadWriteCreate;Default Timeout=15;";

    public static SqliteConnection GetConnection()
    {
        return new SqliteConnection(_connectionString);
    }
    public static void EnableWAL()
    {
        using var con = GetConnection();
        con.Open();

        using var cmd = new SqliteCommand("PRAGMA journal_mode=WAL;", con);
        cmd.ExecuteNonQuery();
    }

}
