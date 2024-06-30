using Microsoft.AspNetCore.Mvc;
using TaskManagement.Common.Entities;
using TaskManagement.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IService<VacationDto> service;
        public VacationController(IService<VacationDto> service)
        {
            this.service = service;
        }
        // GET: api/<VacationController>
        [HttpGet]
        public Task<List<VacationDto>> Get()
        {
            return service.GetAll();
        }

        // GET api/<VacationController>/5
        [HttpGet("{id}")]
        public Task<VacationDto> Get(int id)
        {
            return service.GetById(id);
        }

        // POST api/<VacationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VacationDto value)
        {
            if (value == null)
            {
                return NotFound("Vacation cannt add...");
            }
            return Ok(await service.AddItem(value));
        }

        // PUT api/<VacationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] VacationDto value)
        {
            service.UpdateItem(value,id);
        }

        // DELETE api/<VacationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }
    }
}
