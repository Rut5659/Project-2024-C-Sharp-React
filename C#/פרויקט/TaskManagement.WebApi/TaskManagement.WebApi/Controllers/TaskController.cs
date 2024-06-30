using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.IO;
using TaskManagement.Common.Entities;
using TaskManagement.Service.Interfaces;
using static TaskManagement.Repository.Entities.Assignment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IAssignmentService service;
        public TaskController(IAssignmentService service)
        {
            this.service = service;
        }
        // GET: api/<TaskController>
        [HttpGet]
        public Task<List<AssignmentDto>> Get()
        {
            return service.GetAll();
        }

        // GET: api/<TaskController>
        [HttpGet("getByStatus/{status}")]
        public Task<List<AssignmentDto>> GetByStatus(int status)
        {
            return service.GetByStatus((AssignmentStatus)status);
        }


        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public Task<AssignmentDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<TaskController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssignmentDto value)
        {
            if (value == null)
            {
                return NotFound("Task cannt add...");
            }
            return Ok(await service.AddItem(value));
        }

        //POST api/<TaskController>
        [HttpPost("importExcel")]
        public async Task<List<AssignmentDto>> UploadFile(IFormFile file)
        {
            try
            {
               List<AssignmentDto> processedData = await service.ProcessFileAsync(file); 
                return processedData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
     

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AssignmentDto value)
        {
            service.UpdateItem(value, id);
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }
    }
}
