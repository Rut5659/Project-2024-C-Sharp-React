using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Repository.Repositories
{
    public class VacationsRepository : IRepository<Vacation>
    {
        private readonly IContext _context;
        public VacationsRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Vacation> AddItem(Vacation item)
        {
            await _context.Vacations.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            _context.Vacations.Remove(_context.Vacations.FirstOrDefault(x => x.Id == id));
            await _context.SaveChanges();
        }

        public async Task<Vacation> get(int id)
        {
            return await _context.Vacations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Vacation>> getAll()
        {
            return await _context.Vacations.ToListAsync();
        }

        public async Task UpdateItem(Vacation item, int id)
        {
            Vacation v = _context.Vacations.FirstOrDefault(x => x.Id == id);
            if (v != null)
            {
                v.StartDate = item.StartDate;
                v.EndDate = item.EndDate;
                v.Reason = item.Reason;
                await _context.SaveChanges();
            }
        }
    }
}
