using Microsoft.EntityFrameworkCore;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Model
{
    public class MyDataContext:DbContext, IContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Staff> Staffers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentEmployee> AssignmentEmployees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignmentEmployee>()
                .HasKey(ae => new { ae.AssignmentId, ae.EmployeeId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-SSNMLFD;database=TaskManagement;trusted_connection=true");
             //optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocaldb;database=TasksManagement;trusted_connection=true");
            // optionsBuilder.UseSqlServer("server=seminar-sql;database=TasksManagement;trusted_connection=true");            
        }
        public async Task SaveChanges()
        {
            await SaveChangesAsync();
        }
    }
}
