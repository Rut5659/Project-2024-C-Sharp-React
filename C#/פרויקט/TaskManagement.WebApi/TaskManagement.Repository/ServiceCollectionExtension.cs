using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Repository.Repositories;

namespace TaskManagement.Repository
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IRepository<Project>, ProjectRepository>();
            service.AddScoped<IRepository<Staff>, StaffRepository>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<IAssignmentRepository, AssignmentRepository>();
            service.AddScoped<IAssignmentEmployeeRepository, AssignmentEmployeeRepository>();
            service.AddScoped<IRepository<Vacation>, VacationsRepository>();

            return service;
        }
    }
}
