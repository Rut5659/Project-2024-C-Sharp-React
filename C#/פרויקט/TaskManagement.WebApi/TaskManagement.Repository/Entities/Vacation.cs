using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Repository.Entities
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason {  get; set; }

        [ForeignKey("Employee")]
        public int employeeId { get; set; }
        public Employee employee { get; set; }

    }
}
