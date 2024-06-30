using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using static TaskManagement.Repository.Entities.AssignmentEmployee;

namespace TaskManagement.Repository.Repositories
{
    public class AssignmentEmployeeRepository : IAssignmentEmployeeRepository
    {
        private readonly IContext _context;
        public AssignmentEmployeeRepository(IContext context)
        {
            _context = context;
        }

        public async Task<AssignmentEmployee> AddItem(AssignmentEmployee item)
        {
            await _context.AssignmentEmployees.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }



        public async Task DeleteItem(int EmployeeId, int AssignmentId)
        {
            _context.AssignmentEmployees.Remove(_context.AssignmentEmployees.FirstOrDefault(x => x.AssignmentId == AssignmentId && x.EmployeeId == EmployeeId));
            await _context.SaveChanges();
        }



        public async Task<AssignmentEmployee> get(int EmployeeId, int AssignmentId)
        {
            return await _context.AssignmentEmployees.FirstOrDefaultAsync(x => x.AssignmentId == AssignmentId && x.EmployeeId == EmployeeId);
        }

        public async Task<List<AssignmentEmployee>> getAll()
        {
            return await _context.AssignmentEmployees.ToListAsync();
        }
        public async Task<List<AssignmentEmployee>> GetByStatus(EmployeeAssignmentStatus status)
        {
            return await _context.AssignmentEmployees.Where(x => x.Status == status).ToListAsync();
        }
        public async Task<List<AssignmentEmployee>> GetByEmployeeId(int id)
        {
            return await _context.AssignmentEmployees.Where(x => x.EmployeeId == id).ToListAsync();
        }
        public async Task UpdateItem(AssignmentEmployee item, int EmployeeId, int AssignmentId)
        {
            AssignmentEmployee t = _context.AssignmentEmployees.FirstOrDefault(x => x.AssignmentId == AssignmentId && x.EmployeeId==EmployeeId);
            if (t != null)
            {
                t.Status = item.Status;
                await _context.SaveChanges();
            }
        }
    }
    
}
