using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Repository.Repositories
{
    public class StaffRepository:IRepository<Staff>
    {
        private readonly IContext _context;
        public StaffRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Staff> AddItem(Staff item)
        {
            await _context.Staffers.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            _context.Staffers.Remove(_context.Staffers.FirstOrDefault(x => x.Id == id));
            await _context.SaveChanges();
        }

        public async Task<Staff> get(int id)
        {
            return await _context.Staffers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Staff>> getAll()
        {
            return await _context.Staffers.ToListAsync();
        }

        public async Task UpdateItem(Staff staff, int id)
        {
            Staff s = _context.Staffers.FirstOrDefault(x => x.Id == id);
            if (s != null)
            {
                s.NumOfEmployee = staff.NumOfEmployee;
                s.Name = staff.Name;
                s.ProjectId = staff.ProjectId;
                await _context.SaveChanges();
            }
        }
    }
}
