using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;
using static TaskManagement.Repository.Entities.Assignment;

namespace TaskManagement.Service.Interfaces
{
    public interface IAssignmentService:IService<AssignmentDto>
    {
        public Task<List<AssignmentDto>> ProcessFileAsync(IFormFile file);
        public Task<List<AssignmentDto>> GetByStatus(AssignmentStatus status);

    }
}
