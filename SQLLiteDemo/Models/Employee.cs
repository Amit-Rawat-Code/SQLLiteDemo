using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLiteDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmpCode { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime DOJ { get; set; }
    }
}
