using Microsoft.AspNetCore.Mvc;
using TaskManagement.Common.Entities;
using TaskManagement.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IService<ProjectDto> service;
        public ProjectController(IService<ProjectDto> service)
        {
            this.service = service;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public Task<List<ProjectDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Task<ProjectDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProjectDto value)
        {
            if (value == null)
            {
                return NotFound("Project cannt add...");
            }
            return Ok(await service.AddItem(value));
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProjectDto value)
        {
            service.UpdateItem(value, id);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }
    }
}
