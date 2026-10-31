using Microsoft.Data.Sqlite;

namespace SQLLiteDemo.DAL
{
    public static class DatabaseMigration
    {
        /* ===============================
           SCHEMA CHANGES (AUTO-RUN)
           =============================== */
        public static void Run()
        {
            CreateEmployeeTable();
            CreateUsersTable();
        }
        private static void CreateEmployeeTable()
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = @"
            CREATE TABLE IF NOT EXISTS Employee (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                EmpCode TEXT UNIQUE NOT NULL,
                Name TEXT NOT NULL,
                Salary REAL,
                DOJ TEXT NOT NULL
            );";

            new SqliteCommand(sql, con).ExecuteNonQuery();
        }

        private static void CreateUsersTable()
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT UNIQUE NOT NULL,
                PasswordHash TEXT NOT NULL,
                CreatedOn TEXT NOT NULL
            );";

            new SqliteCommand(sql, con).ExecuteNonQuery();
        }
        public static void AddEmployeeColumnsIfNotExists()
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            AddColumnIfNotExists(con, "Employee", "EmpCode", "TEXT");
            AddColumnIfNotExists(con, "Employee", "DOJ", "TEXT");
        }

        private static void AddColumnIfNotExists(
            SqliteConnection con,
            string tableName,
            string columnName,
            string columnType)
        {
            string checkSql = $"PRAGMA table_info({tableName});";

            using var checkCmd = new SqliteCommand(checkSql, con);
            using var reader = checkCmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader["name"].ToString() == columnName)
                    return;
            }

            string alterSql =
                $"ALTER TABLE {tableName} ADD COLUMN {columnName} {columnType};";

            using var alterCmd = new SqliteCommand(alterSql, con);
            alterCmd.ExecuteNonQuery();
        }

        /* ===============================
           DATA RESET OPERATIONS (MANUAL)
           =============================== */

        public static void TruncateEmployeeTable()
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = "DELETE FROM Employee;";
            using var cmd = new SqliteCommand(sql, con);
            cmd.ExecuteNonQuery();
        }

        public static void ResetEmployeeIdentity()
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = "DELETE FROM sqlite_sequence WHERE name='Employee';";
            using var cmd = new SqliteCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
    }
}
