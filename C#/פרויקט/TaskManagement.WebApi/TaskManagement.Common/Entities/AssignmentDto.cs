using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;

namespace TaskManagement.Common.Entities
{
    public class AssignmentDto
    {
        public enum AssignmentPriority
        {
            Low,
            Medium,
            High
        }

        public enum AssignmentStatus
        {
            OnHold,
            InProgress,
            Completed
            
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Language { get; set; }
        public AssignmentPriority Priority { get; set; }
        public AssignmentStatus Status { get; set; }
        public int ProjectId { get; set; }
    }
}
