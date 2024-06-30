using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;

namespace TaskManagement.Service
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<Assignment, AssignmentDto>().ReverseMap();
            CreateMap<AssignmentEmployee, AssignmentEmployeeDto>().ReverseMap();
            CreateMap<Vacation, VacationDto>().ReverseMap();

        }

    }
}
