using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Repository.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        
            private readonly IContext _context;
            public EmployeeRepository(IContext context)
            {
                _context = context;
            }

            public async Task<Employee> AddItem(Employee item)
            {
                await _context.Employees.AddAsync(item);
                await _context.SaveChanges();
                return item;
            }

            public async Task DeleteItem(int id)
            {
                _context.Employees.Remove(_context.Employees.FirstOrDefault(x => x.Id == id));
                await _context.SaveChanges();
            }

            public async Task<Employee> get(int id)
            {
                return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<List<Employee>> getAll()
            {
                return await _context.Employees.ToListAsync();
            }


        public async Task UpdateItem(Employee employee, int id)
            {
                Employee e = _context.Employees.FirstOrDefault(x => x.Id == id);
                if (e != null)
                {
                    e.FirstName=employee.FirstName;
                    e.LastName=employee.LastName;
                    e.PhoneNumber=employee.PhoneNumber;
                    e.Email=employee.Email;
                    e.IsActive=employee.IsActive;
                    e.ProfileImageUrl=employee.ProfileImageUrl;
                    await _context.SaveChanges();
                }
            }

        public Employee Login(string username, string password)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Email == username && x.Password == password);
            if (employee != null)
            {
                return employee;
            }
            return null;
        }

     }
}

