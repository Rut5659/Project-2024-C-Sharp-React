using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;
using TaskManagement.Service.Interfaces;
using TaskManagement.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service, IConfiguration config)
        {
            this.service = service;
            this._configuration = config;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
       //  [Authorize(Roles = "Team-leader")]
        // [Authorize]
        //public Task<List<EmployeeDto>> Get()
        //{
        //    return service.GetAll();
        //}


        public async Task<List<EmployeeDto>> Get()
        {

            List<EmployeeDto> employees = await service.GetAll();
            foreach (EmployeeDto employee in employees)
            {
                employee.ImageBytes = GetImage(employee.ProfileImageUrl);
            }
            return employees;
        }

        //    //GET api/<EmployeeController>/5
        //    [HttpGet("showImage/{image}")]
        //public IActionResult Get(string image)
        //{
        //    var path = Path.Combine(Environment.CurrentDirectory, "Images", image);
        //    Byte[] b = System.IO.File.ReadAllBytes(path);

        //    return File(b, "image/jpg");
        //}
        //GET api/<EmployeeController>/5
        [HttpGet("showImage/{image}")]
        public Byte[] GetImage(string image)
        {
            if (image != null)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Images", image);
                bool isExists = System.IO.File.Exists(path);
                if (isExists)
                {
                    Byte[] b = System.IO.File.ReadAllBytes(path);
                    return b;
                }
            }
          
            return null;
           
        }

        //[HttpGet("{id}/picture")]
        //public EmployeeDto GetPictures(EmployeeDto employee)
        //{
        //    if (employee != null && employee.ProfileImage != null)
        //    {
        //        var path = Path.Combine(Environment.CurrentDirectory, "Images", employee.ProfileImageUrl);
        //        //bool isExists = System.IO.File.Exists(path);
        //        //if (isExists)
        //        //{
        //        var b = System.IO.File.ReadAllBytes(path);
        //        employee.ImageBytes = b;               
        //        //}
        //            ////var filePath = Path.Combine(Directory.GetCurrentDirectory(), item);
        //            //bool isExists = System.IO.File.Exists(path);
        //            //if (isExists)
        //            //{
        //            //    var fileBytes = System.IO.File.ReadAllBytes(path);
        //            //    employee.ImageBytes = fileBytes;
        //            //}
        //    }
        //    return employee;
        //}

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeDto> Get(int id)
        {
            EmployeeDto employee = await service.GetById(id);
            if (employee != null && employee.ProfileImageUrl != null)
            {
                employee.ImageBytes = GetImage(employee.ProfileImageUrl);
            }
                //employee = GetPictures(employee);
            return employee;
        }
        //POST api/<EmployeeController>/5
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] EmployeeDto employeeDto)
        {
            
            if (employeeDto == null)
            {
                return BadRequest("Employee data is required.");
            }
            if(employeeDto.ProfileImage!=null)
            {
                var path = Path.Combine(Environment.CurrentDirectory, "Images/", employeeDto.ProfileImage.FileName); //+"_"+DateTime.Now
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    employeeDto.ProfileImage.CopyTo(fs);
                    fs.Close();
                }
                employeeDto.ProfileImageUrl = employeeDto.ProfileImage.FileName;

            }

            return Ok(await service.AddItem(employeeDto));           
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] EmployeeDto value)
        {
            service.UpdateItem(value, id);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.DeleteItem(id);
        }

        [HttpGet("Login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            EmployeeDto employee = service.Login(username, password);
            if (employee != null)
            {
                var token = Generate(employee);
                employee.token = token;
                employee.ImageBytes = GetImage(employee.ProfileImageUrl);
                return Ok(employee);
            }
            return BadRequest("User not found");

        }

        [HttpPost("Login")]
        public IActionResult LoginPost([FromForm] LoginDto loginDto)
        {
            string username = loginDto.UserName;
            string password = loginDto.Password;
            EmployeeDto employee = service.Login(username, password);
            if (employee != null)
            {
                var token = Generate(employee);
                employee.token = token;
                employee.ImageBytes = GetImage(employee.ProfileImageUrl);
                return Ok(new { employee, token });
            }
            return BadRequest("User not found");

        }
        //private EmployeeDto GetCuttentEmployee()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    if (identity != null)
        //    {
        //        var UserClaim = identity.Claims;
        //        return new EmployeeDto()
        //        {
        //            //FirstName = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
        //            // Email = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
        //            Role = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
        //            // GivenName = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
        //            //  SurName = UserClaim.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value
        //        };

        //    }
        //    return null;
        //}
        private string Generate(EmployeeDto employee)
        {
            //מפתח להצפנה
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //אלגוריתם להצפנה
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
           // new Claim(ClaimTypes.NameIdentifier,employee.Name),
           // new Claim(ClaimTypes.Email,user.),
            //new Claim(ClaimTypes.Surname,employee.Name),
            new Claim(ClaimTypes.Role,employee.Role),
            new Claim(ClaimTypes.Email,employee.Email),
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
