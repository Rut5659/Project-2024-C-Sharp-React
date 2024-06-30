using Aspose.Email;
using System.Diagnostics;
//using System.Net.Mail;
using System.Text;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TaskManagement.Model;
using TaskManagement.Common.Entities;
using TaskManagement.Service.Services;
using TaskManagement.Repository.Repositories;
using AutoMapper;
using TaskManagement.Service;
using System.Threading;

namespace TaskManagement.Scripts
{
    public class Program1
    {

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices1(services);
            services
            .AddScoped<AssignmentOfTasks, AssignmentOfTasks>()
                .BuildServiceProvider()
                .GetService<AssignmentOfTasks>()
                .AssignTasks();

            var services2 = new ServiceCollection();
            ConfigureServices2(services2);
            services2
            .AddScoped<TaskTracking, TaskTracking>()
                .BuildServiceProvider()
                .GetService<TaskTracking>()
                .Tracking();
        }

        private static void ConfigureServices1(ServiceCollection services)
        {
            
            services.AddDbContext<IContext, MyDataContext>().
                AddScoped<IAssignmentEmployeeRepository,AssignmentEmployeeRepository>().
                AddScoped<IAssignmentRepository, AssignmentRepository>().
                AddScoped<IEmployeeRepository, EmployeeRepository>().
                AddAutoMapper(typeof(MapperProfile))
               .AddScoped<IAssignmentEmployeeService, AssignmrntEmployeeService>()
               .AddScoped<IAssignmentService, AssignmentService>()
               .AddScoped<IEmployeeService, EmployeeService>();


        }
        private static void ConfigureServices2(ServiceCollection services)
        {

            services.AddDbContext<IContext, MyDataContext>().
                AddScoped<IAssignmentRepository, AssignmentRepository>().
                AddScoped<IEmployeeRepository, EmployeeRepository>().
                AddAutoMapper(typeof(MapperProfile))
               .AddScoped<IAssignmentService, AssignmentService>()
               .AddScoped<IEmployeeService, EmployeeService>();


        }
    }
}