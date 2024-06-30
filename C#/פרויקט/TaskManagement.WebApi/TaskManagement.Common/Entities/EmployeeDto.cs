using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;

namespace TaskManagement.Common.Entities
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        public string Language { get; set; }
        public int YearsOfExperience { get; set; }
        public int StaffId { get; set; }
        public string Password { get; set; }
        public string? ProfileImageUrl { get; set; }
        public  Byte[]? ImageBytes { get; set; }
        public IFormFile? ProfileImage { get; set; }// ?
        public string? token { get; set; }
       // public virtual ICollection<Vacation> Vacations { get; set; }

    }
}
