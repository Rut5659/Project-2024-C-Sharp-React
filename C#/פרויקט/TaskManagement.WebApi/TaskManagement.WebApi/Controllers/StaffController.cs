using Microsoft.AspNetCore.Mvc;
using TaskManagement.Common.Entities;
using TaskManagement.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IService<StaffDto> service;
        public StaffController(IService<StaffDto> service)
        {
            this.service = service;
        }
        // GET: api/<StaffController>
        [HttpGet]
        public Task<List<StaffDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public Task<StaffDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<StaffController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StaffDto value)
        {
            if (value == null)
            {
                return NotFound("Staff cannt add...");
            }
            return Ok(await service.AddItem(value));
        }

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StaffDto value)
        {
            service.UpdateItem(value, id);

        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }
    }
}
