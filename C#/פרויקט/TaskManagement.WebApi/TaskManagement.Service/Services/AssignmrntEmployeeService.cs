using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Service.Interfaces;
using static TaskManagement.Repository.Entities.AssignmentEmployee;

namespace TaskManagement.Service.Services
{
    public class AssignmrntEmployeeService:IAssignmentEmployeeService
    {
        private readonly IAssignmentEmployeeRepository repository;
        private readonly IMapper mapper;
        public AssignmrntEmployeeService(IAssignmentEmployeeRepository repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }

        public async Task<AssignmentEmployeeDto> AddItem(AssignmentEmployeeDto item)
        {
            return mapper.Map<AssignmentEmployeeDto>(await repository.AddItem(mapper.Map<AssignmentEmployee>(item)));
        }

        public async Task DeleteItem(int idEmployee, int idAssignment)
        {
            await repository.DeleteItem(idEmployee,idAssignment);
        }

        public async Task<AssignmentEmployeeDto> get(int idEmployee, int idAssignment)
        {
            return mapper.Map<AssignmentEmployeeDto>(await repository.get(idEmployee,idAssignment));
        }

        public async Task<List<AssignmentEmployeeDto>> getAll()
        {
            return mapper.Map<List<AssignmentEmployeeDto>>(await repository.getAll());
        }
        public async Task<List<AssignmentEmployeeDto>> GetByStatus(EmployeeAssignmentStatus status)
        {
            return mapper.Map<List<AssignmentEmployeeDto>>(await repository.GetByStatus(status));
        }
        public async Task<List<AssignmentEmployeeDto>> GetByEmployeeId(int id)
        {
            return mapper.Map<List<AssignmentEmployeeDto>>(await repository.GetByEmployeeId(id));
        }
        public void UpdateItem(AssignmentEmployeeDto item, int idEmployee, int idAssignment)
        {
            repository.UpdateItem(mapper.Map<AssignmentEmployee>(item), idEmployee,idAssignment);
        }

       
    }
}
