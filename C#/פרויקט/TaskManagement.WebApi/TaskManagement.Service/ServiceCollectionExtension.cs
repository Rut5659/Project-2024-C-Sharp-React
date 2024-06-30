using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Common.Entities;
using TaskManagement.Service.Interfaces;
using TaskManagement.Service.Services;
using TaskManagement.Repository;
using AutoMapper;

namespace TaskManagement.Service
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddRepositories();
            service.AddScoped<IEmployeeService, EmployeeService>();
            service.AddScoped<IService<ProjectDto>, ProjectService>();
            service.AddScoped<IService<StaffDto>, StaffService>();
            service.AddScoped<IAssignmentService, AssignmentService>();
            service.AddScoped<IAssignmentEmployeeService, AssignmrntEmployeeService>();
            service.AddScoped<IService<VacationDto>, VacationService>();
            service.AddAutoMapper(typeof(MapperProfile));
            return service;
        }
    }
}
