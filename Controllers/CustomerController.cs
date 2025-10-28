using chineseAction.Models;
using chineseAction.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerServices _CustomerServices;

        public CustomerController(ICustomerServices CustomerServices)
        {
            _CustomerServices = CustomerServices;
        }


        [HttpPost]
        public string Register(Customer customer)
        {

          return  _CustomerServices.Register(customer);
      
        }



    }
}
