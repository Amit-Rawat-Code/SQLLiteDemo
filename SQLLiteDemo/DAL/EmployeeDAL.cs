using Microsoft.Data.Sqlite;
using SQLLiteDemo.Models;
using System.Data;

namespace SQLLiteDemo.DAL
{
    public class EmployeeDAL
    {
        public bool InsertEmployee(Employee emp)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = @"INSERT OR IGNORE INTO Employee (EmpCode, Name, Salary, DOJ)VALUES (@EmpCode, @Name, @Salary, @DOJ);
    ";

            using var cmd = new SqliteCommand(sql, con);

            cmd.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@DOJ", emp.DOJ.ToString("yyyy-MM-dd"));

            int rowAffected = cmd.ExecuteNonQuery();
            return rowAffected > 0;
        }

        public DataTable GetEmployees()
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = "SELECT * FROM Employee";
            using var cmd = new SqliteCommand(sql, con);

            using var reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        public Employee GetEmployeeById(int Id)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = "SELECT * FROM Employee WHERE Id = @Id";
            using var cmd = new SqliteCommand(sql, con);

            cmd.Parameters.AddWithValue("@Id", Id);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new Employee
            {
                Id = Convert.ToInt32(reader["Id"]),
                EmpCode = reader["EmpCode"].ToString(),
                Name = reader["Name"].ToString(),
                Salary = Convert.ToDecimal(reader["Salary"]),
                DOJ = DateTime.Parse(reader["DOJ"].ToString())
            };
        }
        public Employee GetEmployeeByEmpCode(string EmpCode)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = "SELECT * FROM Employee WHERE EmpCode = @EmpCode";
            using var cmd = new SqliteCommand(sql, con);

            cmd.Parameters.AddWithValue("@EmpCode", EmpCode);

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new Employee
            {
                Id = Convert.ToInt32(reader["Id"]),
                EmpCode = reader["EmpCode"].ToString(),
                Name = reader["Name"].ToString(),
                Salary = Convert.ToDecimal(reader["Salary"]),
                DOJ = DateTime.Parse(reader["DOJ"].ToString())
            };
        }
        public bool DeleteEmployee(int Id)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = "DELETE FROM Employee Where Id='" + Id + "';";
            using var cmd = new SqliteCommand(sql, con);
            int rowAffected = cmd.ExecuteNonQuery();
            return rowAffected > 0;
        }
        public bool UpdateEmployee( Employee emp)
        {
            using var con = DatabaseHelper.GetConnection();
            con.Open();

            string sql = @"UPDATE Employee SET EmpCode = @EmpCode, Name = @Name, Salary = @Salary, DOJ = @DOJ WHERE Id = @Id;";
            using var cmd = new SqliteCommand(sql, con);
            cmd.Parameters.AddWithValue("@Id", emp.Id);
            cmd.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
            cmd.Parameters.AddWithValue("@DOJ", emp.DOJ.ToString("yyyy-MM-dd"));
            int rowAffected = cmd.ExecuteNonQuery();
            return rowAffected > 0;
        }
    }

}
