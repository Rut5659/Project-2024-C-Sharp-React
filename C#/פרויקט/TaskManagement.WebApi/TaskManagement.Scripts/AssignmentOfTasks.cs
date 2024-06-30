//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TaskManagement.Common.Entities;
//using TaskManagement.Repository.Entities;
//using TaskManagement.Repository.Interfaces;
//using TaskManagement.Repository.Repositories;
//using TaskManagement.Service.Interfaces;

//namespace TaskManagement.Scripts
//{
//    public class AssignmentOfTasks
//    {

//        private readonly IAssignmentEmployeeService _assignmentEmployeeService;
//           // private readonly IAssignmentService _assignmentService;
//          // private readonly IEmployeeService _employeeService;
//        private readonly IContext _dbContext; 
//        public AssignmentOfTasks(IAssignmentEmployeeService assignmentEmployeeService,IContext dbContext,IAssignmentService assignmentService,IEmployeeService employeeService)
//        {
//            _assignmentEmployeeService = assignmentEmployeeService;
//            //_assignmentService = assignmentService;
//            //_employeeService = employeeService;
//            _dbContext = dbContext;
//        }

//        public async void AssignTasks()
//        {
//            {
//                List<Assignment> tasks = _dbContext.Assignments
//                                                   .Where(t => t.Status == Assignment.AssignmentStatus.OnHold)
//                                                   .ToList();
//                List<Employee> employees = _dbContext.Employees.ToList();
//                Dictionary<int, int> employeeTaskCount = employees.ToDictionary(e => e.Id, e => 0);

//                var sortedTasks = tasks.OrderBy(t => t.Priority).ThenBy(t => t.DueDate);
//                foreach (var task in sortedTasks)
//                {
//                    var suitableEmployee = employees
//                        .Where(e => e.Language == task.Language && e.IsActive)
//                        .OrderBy(e => employeeTaskCount[e.Id])  
//                        .ThenByDescending(e => e.YearsOfExperience)
//                        .FirstOrDefault();

//                    if (suitableEmployee != null)
//                    {
//                        Console.WriteLine($"Assigning task '{task.Id}' to employee {suitableEmployee.FirstName} {suitableEmployee.LastName}");
//                        task.Status = Assignment.AssignmentStatus.InProgress;

//                        AssignmentEmployee a = new AssignmentEmployee();
//                        a.AssignmentId = task.Id;
//                        a.EmployeeId = suitableEmployee.Id;
//                        _dbContext.AssignmentEmployees.Add(a);
//                       // _assignmentEmployeeService.AddItem(a);

//                        employeeTaskCount[suitableEmployee.Id]++;
//                    }
//                    else
//                    {
//                        Console.WriteLine($"No suitable employee found for task '{task.Title}'");
//                    }

//                }
//                await _dbContext.SaveChanges();
//                Console.WriteLine("All tasks assigned.");
//            }
//        }

//    }
//}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Repository.Repositories;
using TaskManagement.Service.Interfaces;
using TaskManagement.Service.Services;

namespace TaskManagement.Scripts
{
    public class AssignmentOfTasks
    {
        private readonly IAssignmentEmployeeService _assignmentEmployeeService;
        private readonly IContext _dbContext;

        public AssignmentOfTasks(IAssignmentEmployeeService assignmentEmployeeService, IContext dbContext)
        {
            _assignmentEmployeeService = assignmentEmployeeService;
            _dbContext = dbContext;
        }
        public async Task AssignTasks()
        {
            try
            {
                List<Assignment> tasks = _dbContext.Assignments
                                                   .Where(t => t.Status == Assignment.AssignmentStatus.OnHold)
                                                   .OrderBy(t => t.Priority)
                                                   .ThenBy(t => t.DueDate)
                                                   .ToList();

                List<Employee> employees = _dbContext.Employees.ToList();
                Dictionary<int, int> employeeTaskCount = employees.ToDictionary(e => e.Id, e => 0);

                for (int i = 0; i < tasks.Count; i++)
                {
                    var task = tasks[i];
                    var suitableEmployee = employees
                        .Where(e => e.Language == task.Language && e.IsActive)
                        .OrderBy(e => employeeTaskCount[e.Id])
                        .ThenByDescending(e => e.YearsOfExperience)
                        .FirstOrDefault();

                    if (suitableEmployee != null)
                    {
                        Console.WriteLine($"Assigning task '{task.Id}' to employee {suitableEmployee.FirstName} {suitableEmployee.LastName}");
                        task.Status = Assignment.AssignmentStatus.InProgress;
                        _dbContext.Assignments.Update(task);

                        AssignmentEmployee a = new AssignmentEmployee();
                        a.AssignmentId = task.Id;
                        a.EmployeeId = suitableEmployee.Id;

                        _dbContext.AssignmentEmployees.Add(a);
                        employeeTaskCount[suitableEmployee.Id]++;
                    }
                    else
                    {
                        Console.WriteLine($"No suitable employee found for task '{task.Title}'");
                    }
                }

                await _dbContext.SaveChanges();

                Console.WriteLine("All tasks assigned.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //public async Task AssignTasks()
        //{
        //    List<Assignment> tasks = _dbContext.Assignments
        //                                       .Where(t => t.Status == Assignment.AssignmentStatus.OnHold)
        //                                       .OrderBy(t => t.Priority)
        //                                       .ThenBy(t => t.DueDate)
        //                                       .ToList();
        //    List<Employee> employees = _dbContext.Employees.ToList();
        //    Dictionary<int, int> employeeTaskCount = employees.ToDictionary(e => e.Id, e => 0);

        //    for (int i = 0; i < tasks.Count; i++)
        //    {
        //        var task = tasks[i];
        //        var suitableEmployee = employees
        //            .Where(e => e.Language == task.Language && e.IsActive)
        //            .OrderBy(e => employeeTaskCount[e.Id])
        //            .ThenByDescending(e => e.YearsOfExperience)
        //            .FirstOrDefault();

        //        if (suitableEmployee != null)
        //        {
        //            Console.WriteLine($"Assigning task '{task.Id}' to employee {suitableEmployee.FirstName} {suitableEmployee.LastName}");
        //            task.Status = Assignment.AssignmentStatus.InProgress;
        //            _dbContext.Assignments.Update(task);
        //            AssignmentEmployee a = new AssignmentEmployee();
        //            a.AssignmentId = task.Id;
        //            a.EmployeeId = suitableEmployee.Id;
        //            //_assignmentEmployeeService.AddItem(a);
        //            _dbContext.AssignmentEmployees.Add(a);
        //            employeeTaskCount[suitableEmployee.Id]++;
        //        }
        //        else
        //        {
        //            Console.WriteLine($"No suitable employee found for task '{task.Title}'");
        //        }
        //    }

        //    await _dbContext.SaveChanges();

        //    Console.WriteLine("All tasks assigned.");
        //}
    }
}


