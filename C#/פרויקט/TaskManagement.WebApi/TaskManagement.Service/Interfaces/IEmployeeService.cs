using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;

namespace TaskManagement.Service.Interfaces
{
    public interface IEmployeeService:IService<EmployeeDto>,ILoginService
    {
        public string SaveEmployeeImage(EmployeeDto employeeDto, IFormFile file);
    }
}
