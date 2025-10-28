using chineseAction.Models;
using chineseAction.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ProjectDbContext _projectDbContext;
        private readonly JwtTokenService _jwtTokenService;
        private readonly PasswordHasher<Customer> _passwordHasher;


        //private readonly IManegerServices _ManegerServices;

        public AuthController(JwtTokenService jwtTokenService, ProjectDbContext projectDbContex)
        {
            _jwtTokenService = jwtTokenService; 
            _projectDbContext = projectDbContex;
            _passwordHasher = new PasswordHasher<Customer>();
            //_ManegerServices = ManegerServices;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginRequest request)
        {
          
            List<Maneger>? mm = _projectDbContext.Maneger.ToList();
 
            Maneger maneger =mm.Find(m => m.UserName == request.Username);

            if (maneger !=null)
            {
                if (maneger.Password == request.Password)
                {
                    var roles = new List<string> { "Admin" };

                    var token = _jwtTokenService.GenerateJwtToken(request.Username,maneger.Id, roles);

                    return Ok(new { Token = token , isManeger=true});
                }
                else return Unauthorized("password is not currect");
            }
            else
            {
                List<Customer>? cc = _projectDbContext.Customer.ToList();
                Customer customer = cc.Find(c =>c.UserName == request.Username);

                if (customer!=null)
                {
                    if (_passwordHasher.VerifyHashedPassword(customer, customer.Password, request.Password) == PasswordVerificationResult.Success) { 
                    var roles = new List<string> { "User" };

                    var token = _jwtTokenService.GenerateJwtToken(request.Username,customer.Id, roles);

                    return Ok(new { Token = token, isManeger = false });
                    }
                    else return Unauthorized("password is not currect");
                }
            }
            return Unauthorized("Invalid credentials");
        }
    }
}
