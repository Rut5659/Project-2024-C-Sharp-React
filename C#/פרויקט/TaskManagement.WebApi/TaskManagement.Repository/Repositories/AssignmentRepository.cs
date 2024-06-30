using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using static TaskManagement.Repository.Entities.Assignment;

namespace TaskManagement.Repository.Repositories
{
    public class AssignmentRepository : IAssignmentRepository //  IRepository<Assignment> 
    {
        private readonly IContext _context;
        public AssignmentRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Assignment> AddItem(Assignment item)
        {
            await _context.Assignments.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            _context.Assignments.Remove(_context.Assignments.FirstOrDefault(x => x.Id == id));
            await _context.SaveChanges();
        }

        public async Task<Assignment> get(int id)
        {
            return await _context.Assignments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Assignment>> getAll()
        {
            return await _context.Assignments.ToListAsync();
        }

        public async Task<List<Assignment>> GetByStatus(Assignment.AssignmentStatus status)
        {
            return await _context.Assignments.Where(x => x.Status == status).ToListAsync();
        }

        public async Task UpdateItem(Assignment task, int id)
        {
            Entities.Assignment t = _context.Assignments.FirstOrDefault(x => x.Id == id);
            if (t != null)
            {
                t.Description = task.Description;
                await _context.SaveChanges();
            }
        }
    }
}
