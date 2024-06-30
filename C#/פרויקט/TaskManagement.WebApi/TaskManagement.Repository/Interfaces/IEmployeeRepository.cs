using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;

namespace TaskManagement.Repository.Interfaces
{
    public interface IEmployeeRepository:IRepository<Employee>,ILoginRepository
    {

    }
}
