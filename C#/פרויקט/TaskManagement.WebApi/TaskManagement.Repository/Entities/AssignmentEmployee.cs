using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Repository.Entities
{
    public class AssignmentEmployee
    {
        public enum EmployeeAssignmentStatus
        {
            Start,
            Mid,
            NearingCompletion,
            Completion
        }
        //public int Id { get; set; }
        [Key,Column(Order =0)]
        [ForeignKey("Assignment")]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public EmployeeAssignmentStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
