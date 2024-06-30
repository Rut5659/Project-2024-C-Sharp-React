using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;

namespace TaskManagement.Common.Entities
{
    public class AssignmentEmployeeDto
    {
        public enum EmployeeAssignmentStatus
        {
            Start,
            Mid,
            NearingCompletion,
            Completion
        }
        public int AssignmentId { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeAssignmentStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
