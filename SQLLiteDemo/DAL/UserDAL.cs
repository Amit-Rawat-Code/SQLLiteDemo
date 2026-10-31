using Microsoft.Data.Sqlite;
using SQLLiteDemo.Models;

namespace SQLLiteDemo.DAL
{    
    public class UserDAL
    {
        public bool Register(string username, string password)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = @"INSERT INTO Users (Username, PasswordHash, CreatedOn)
                       VALUES (@u, @p, datetime('now'));";

            using var cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", Utility.Hash(password));
            cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            return cmd.ExecuteNonQuery() > 0;
        }

        public User Login(string username, string password)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = @"SELECT Id,Username,CreatedOn FROM Users 
                       WHERE Username=@u AND PasswordHash=@p;";

            using var cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", Utility.Hash(password));

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                Username = reader["Username"].ToString(),
                CreatedOn = reader["CreatedOn"].ToString()
            };
        }
    }

}
