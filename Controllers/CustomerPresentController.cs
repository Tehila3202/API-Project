using chineseAction.Models;
using chineseAction.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerPresentController : ControllerBase
    {
        private readonly ICustomerPresentServices _CustomerPresentServices;
        private readonly JwtTokenService _jwtTokenService;

        public CustomerPresentController(ICustomerPresentServices CustomerPresentServices, JwtTokenService jwtTokenService)    
        {
            _jwtTokenService =jwtTokenService;
            _CustomerPresentServices = CustomerPresentServices;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("curt")]
        public IEnumerable<PresentMask> Cart()
        {
            var token =  HttpContext.GetTokenAsync("access_token");
            var customerId = _jwtTokenService.ExtractUserIdFromToken(token.Result);
            var x = _CustomerPresentServices.Cart(Int32.Parse(customerId));
            return x;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("CustomerForPresent{presentId}")]
        public IEnumerable<Customer> CustomerForPresent(int presentId)
        {
            var x = _CustomerPresentServices.CustomerForPresent(presentId);
            return x;
        }

        [Authorize(Roles = "User,Admin")]
        [HttpDelete("{presentId}")]
        public IEnumerable<CustomerPresent> deletePresent(int presentId)
        {
            var token =  HttpContext.GetTokenAsync("access_token");
            var customerId = _jwtTokenService.ExtractUserIdFromToken(token.Result);
            return _CustomerPresentServices.deletePresent(presentId, Int32.Parse(customerId));
        }

        [Authorize(Roles = "User,Admin")]
        [HttpPut]
        public void Update()
        {
            var token =  HttpContext.GetTokenAsync("access_token");
            var CustomerId = _jwtTokenService.ExtractUserIdFromToken(token.Result);
            _CustomerPresentServices.update( Int32.Parse(CustomerId));

        }

        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public IEnumerable<CustomerPresent> Create(PresentId PresentId)
        {
            var token =  HttpContext.GetTokenAsync("access_token");
            var userId = _jwtTokenService.ExtractUserIdFromToken(token.Result);
            return _CustomerPresentServices.Create(PresentId.Id, Int32.Parse( userId));
        }




    }
}
