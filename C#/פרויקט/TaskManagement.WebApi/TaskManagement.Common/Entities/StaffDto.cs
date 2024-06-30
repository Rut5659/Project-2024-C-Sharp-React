using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;

namespace TaskManagement.Common.Entities
{
    public class StaffDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumOfEmployee { get; set; }
      //  public virtual ICollection<Employee> Employees { get; set; }
        public int ProjectId { get; set; }
    }
}
