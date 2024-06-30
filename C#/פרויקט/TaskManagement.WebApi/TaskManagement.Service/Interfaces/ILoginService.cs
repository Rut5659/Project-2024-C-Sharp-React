using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;

namespace TaskManagement.Service.Interfaces
{
    public interface ILoginService
    {
        EmployeeDto Login(string username, string password);
    }
}
