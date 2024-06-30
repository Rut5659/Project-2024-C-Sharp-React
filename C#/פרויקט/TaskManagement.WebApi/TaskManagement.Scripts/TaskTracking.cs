using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Mail;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Service.Interfaces;
using TaskManagement.Repository.Entities;
using TaskManagement.Common.Entities;

namespace TaskManagement.Scripts
{
    public class TaskTracking
    {
        private readonly IContext _dbContext;
        private readonly IAssignmentService _assignmentService;
        private readonly IEmployeeService _employeeService;
        public TaskTracking(IContext dbContext, IAssignmentService assignmentService, IEmployeeService employeeService)
        {
            _dbContext = dbContext;
            _assignmentService = assignmentService;
            _employeeService=employeeService;
        }

        public async void Tracking()
        {
            List<AssignmentEmployee> tasks;
            List<Employee> employees = _dbContext.Employees.ToList();
            foreach (var employee in employees)
            {
                tasks=_dbContext.AssignmentEmployees.Where(e=>e.EmployeeId==employee.Id && e.Status!=AssignmentEmployee.EmployeeAssignmentStatus.Completion)
                                                    .ToList();
                foreach (var task in tasks)
                {
                    Assignment tempTask =  _dbContext.Assignments.Find(task.AssignmentId);
                     if (tempTask != null) 
                    {
                        DateTime dueDate = tempTask.DueDate;
                        DateTime today = DateTime.Today;
                        TimeSpan difference = dueDate-today;

                        int daysDifference = difference.Days;
                        int hoursDifference = difference.Hours;
                        int minutesDifference = difference.Minutes;
                        int secondsDifference = difference.Seconds;

                        if (difference.Days <=7 && difference.Days>=0)
                        {
                            string subject = $"Alert for a task: {tempTask.Title}";
                            string body = $"<h1 style='color:#173F3F;'>Hello {employee.FirstName}</h1>" +
                                $" <p style='font-size:16px;'>\nThe task is a {tempTask.Title} that you have" +
                                $"\n<br>Must be perfect in {daysDifference} days" +
                                $"\n<br>Please hurry and update that it is completed </p>" +
                                $"\n<br> <h4 style='color:#00012B;'>Have a lovely day.</h4>";
                            SendEmail(employee.Email,subject, body);
                        }
                    }
                }
            }
        }
        public static void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                string fromEmail = "taskmanagementalerts@gmail.com";
                string appPassword = "v o r z g c q r c n l m q n r w";

                //string toEmail = "rutish5659@gmail.com";
                //string subject = "Test Email";
                //string body = "This is a test email sent from C# application.-Ruti Shaharabani";

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true; // Enable HTML content

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(fromEmail, appPassword);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                Console.WriteLine("Mail Sent Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send mail. Error: " + ex.Message);
            }
        }
        
    }
}
