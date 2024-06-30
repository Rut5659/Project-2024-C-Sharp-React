using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;
using static TaskManagement.Repository.Entities.AssignmentEmployee;

namespace TaskManagement.Service.Interfaces
{
    public interface IAssignmentEmployeeService
    {
        public Task<List<AssignmentEmployeeDto>> getAll();
        public Task<AssignmentEmployeeDto> get(int idEmployee, int idAssignment);
        public Task<AssignmentEmployeeDto> AddItem(AssignmentEmployeeDto item);
        public void UpdateItem(AssignmentEmployeeDto item, int idEmployee, int idAssignment);
        public Task DeleteItem(int idEmployee, int idAssignment);
        public Task<List<AssignmentEmployeeDto>> GetByStatus(EmployeeAssignmentStatus status);
        public Task<List<AssignmentEmployeeDto>> GetByEmployeeId(int id);

    }
}
