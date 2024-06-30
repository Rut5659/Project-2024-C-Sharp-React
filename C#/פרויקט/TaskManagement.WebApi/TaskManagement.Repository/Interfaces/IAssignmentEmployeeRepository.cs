using TaskManagement.Repository.Entities;
using static TaskManagement.Repository.Entities.AssignmentEmployee;

namespace TaskManagement.Repository.Interfaces
{
    public interface IAssignmentEmployeeRepository
    {
        public Task<List<AssignmentEmployee>> getAll();
        public Task<AssignmentEmployee> get(int idEmployee, int idAssignment);
        
        public Task<AssignmentEmployee> AddItem(AssignmentEmployee item);
        public Task UpdateItem(AssignmentEmployee item, int idEmployee, int idAssignment);
        public Task DeleteItem(int idEmployee, int idAssignment);

        public Task<List<AssignmentEmployee>> GetByStatus(EmployeeAssignmentStatus status);
        public Task<List<AssignmentEmployee>> GetByEmployeeId(int id);

    }
}
