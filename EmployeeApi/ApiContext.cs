using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "EmployeeDb");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
