using Microsoft.EntityFrameworkCore;
using TaskManagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Repository.Interfaces
{
    public interface IContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Staff> Staffers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentEmployee> AssignmentEmployees { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public Task SaveChanges();
    }
}
