using DemoWebApi.Models;
using DemoWebApi.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        private IConfiguration Configuration;

        public EmployeeController(IEmployee employee, IConfiguration configuration)
        {
            _employee = employee;
            Configuration = configuration;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post(Employee emp)
        {
            var result = await _employee.AddEmployee(emp);
            if (result.EmployeeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpPost]
        [Route("Filter")]
        public async Task<IActionResult> Filter(Filter filter)
        {
            var result = await _employee.Filter(filter);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public JsonResult Delete(int id)
        {
            var result = _employee.DeleteEmployee(id);
            
            return new JsonResult("Deleted Successfully");
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> TokenAsync([FromBody] Login user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            var result = await _employee.GetEmployees();
            var employee = result.First(x => x.Email.ToLower() == user.Email.ToLower());

            if (user.Email == employee.Email && user.Password == employee.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: Configuration["JWT:ValidIssuer"], audience: Configuration["JWT:ValidAudience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse
                {
                    Token = tokenString
                });
            }
            return Unauthorized();
        }
    }
}
