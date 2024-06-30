using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Repository.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int NumOfEmployee { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project project { get; set; }

    }
}
