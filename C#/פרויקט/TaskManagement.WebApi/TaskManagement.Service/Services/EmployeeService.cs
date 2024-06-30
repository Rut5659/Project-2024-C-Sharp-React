using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Service.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repository;
        //private readonly ILoginRepository<Employee> login;
        private readonly IMapper mapper;
        public EmployeeService(IEmployeeRepository repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }
        public async Task<EmployeeDto> AddItem(EmployeeDto item)
        {
            return mapper.Map<EmployeeDto>(await repository.AddItem(mapper.Map<Employee>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<EmployeeDto>> GetAll()
        {
            return mapper.Map<List<EmployeeDto>>(await repository.getAll());
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            return mapper.Map<EmployeeDto>(await repository.get(id));
        }
        public string SaveEmployeeImage(EmployeeDto employeeDto, IFormFile file)
        {
            var imagePath = Path.Combine("./Images/Employees", $"{employeeDto.Id}_{file.FileName}");

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return imagePath;
        }
        public void UpdateItem(EmployeeDto item, int id)
        {
            repository.UpdateItem(mapper.Map<Employee>(item), id);
        }
        public EmployeeDto Login(string username, string password)
        {
            return mapper.Map<EmployeeDto>(repository.Login(username, password));
        }
    }
}
