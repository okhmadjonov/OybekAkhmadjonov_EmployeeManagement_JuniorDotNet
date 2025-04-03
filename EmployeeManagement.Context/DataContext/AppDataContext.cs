

using EmployeeManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Context.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
