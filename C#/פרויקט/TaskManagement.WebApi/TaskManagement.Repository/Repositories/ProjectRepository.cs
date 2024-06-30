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
    public class ProjectRepository:IRepository<Project>
    {
        private readonly IContext _context;
        public ProjectRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Project> AddItem(Project item)
        {
            await _context.Projects.AddAsync(item);
            await _context.SaveChanges();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            _context.Projects.Remove(_context.Projects.FirstOrDefault(x => x.Id == id));
            await _context.SaveChanges();
        }

        public async Task<Project> get(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Project>> getAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task UpdateItem(Project project, int id)
        {
            Project p = _context.Projects.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                p.Name = project.Name;  
                p.Description = project.Description;
                await _context.SaveChanges();
            }
        }
    }
}
