using Microsoft.AspNetCore.Mvc;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;
using TaskManagement.Service.Interfaces;
using static TaskManagement.Repository.Entities.AssignmentEmployee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentEmployeeController : ControllerBase
    {
        private readonly IAssignmentEmployeeService service;
        public AssignmentEmployeeController(IAssignmentEmployeeService service)
        {
            this.service = service;
        }
        // GET: api/<AssignmentEmployeeController>
        [HttpGet]
        public Task<List<AssignmentEmployeeDto>> Get()
        {
            return service.getAll();
        }

        // GET api/<AssignmentEmployeeController>/5
        [HttpGet("{idAssignment}/{idEmployee}")]
        public Task<AssignmentEmployeeDto> Get(int idEmployee,int idAssignment)
        {
            return service.get(idEmployee,idAssignment);
        }

        // GET: api/<AssignmentEmployeeController>
        [HttpGet("getByStatus/{status}")]
        public Task<List<AssignmentEmployeeDto>> GetByStatus(int status)
        {
            return service.GetByStatus((EmployeeAssignmentStatus)status);
        }

        [HttpGet("getByEmployeeId/{id}")]
        public Task<List<AssignmentEmployeeDto>> GetByEmployeeId(int id)
        {
            return service.GetByEmployeeId(id);
        }

        // POST api/<AssignmentEmployeeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssignmentEmployeeDto value)
        {
            if (value == null)
            {
                return NotFound("AssignmentEmployee cannt add...");
            }
            return Ok(await service.AddItem(value));

        }

        // PUT api/<AssignmentEmployeeController>/5
        [HttpPut("{idAssignment}/{idEmployee}")]
        public void Put(int idEmployee,int idAssignment, [FromBody] AssignmentEmployeeDto value)
        {
            service.UpdateItem(value, idEmployee,idAssignment);
        }

        // DELETE api/<AssignmentEmployeeController>/5
        [HttpDelete("{idAssignment}/{idEmployee}")]
        public void Delete(int idEmployee, int idAssignment)
        {
            service.DeleteItem(idEmployee,idAssignment);
        }
    }
}
