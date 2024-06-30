using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Repository.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Role { get; set; }
        public int Level { get; set; }
        public string Language { get; set; }
        public int YearsOfExperience { get; set; }

        [ForeignKey("Staff")]
        public int? StaffId { get; set; }
        public Staff staff { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string? ProfileImageUrl { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }


        //public virtual ICollection<Assignment> MyTasks { get; set; }
    }
}
