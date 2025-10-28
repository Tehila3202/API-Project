using chineseAction.Models;
using chineseAction.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chineseAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentController : ControllerBase
    {

        private readonly IPresentServices _presentServices;

        public PresentController(IPresentServices presentServices)
        {
            _presentServices = presentServices;
        }

        [HttpGet]
        public IEnumerable<PresentMask> GetAllPresent()
        {
            var Present = _presentServices.GetAllPresent();
            return Present;
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IEnumerable<PresentMask> deletePresent( int id)
        {
          return  _presentServices.DeletePresentById(id);
           
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("byMany")]
        public IActionResult deleteManyPresent([FromQuery] List<int> list)
        {
            _presentServices.DeleteManyPresent(list);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(PresentMask present)
        {
            _presentServices.updatePresent( present);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IEnumerable<PresentMask> Create(PresentMask Present)
        {
            return _presentServices.CreatePresent(Present);
           
        }
        
        [HttpGet("byId/{id}")]
        public Present getById( int id)
        {
           var p= _presentServices.getById(id);
            return p;

        }

        [HttpGet("ByDonaterId{DonaterId}")]
        public IEnumerable<PresentMask> getByDonaterId(int DonaterId)
        {
            var p = _presentServices.getByDonaterId(DonaterId);
            return p;

        }

        [HttpGet("byNumBuyers/{NumBuyers}")]
        public List<Present> getByNumBuyers(int NumBuyers)
        {
            var p = _presentServices.getByNumBuyers(NumBuyers);
            return p;

        }

        [HttpGet("byName")]
        public List<Present> getByName(string Title)
        {
            var t = _presentServices.getByName(Title);
            return t;

        }

        [HttpGet("expensive")]
        public PresentMask expensive()
        {
            return  _presentServices.expensive();
        }

        [HttpGet("byPrice")]
        public IEnumerable<PresentMask> getByPrice()
        {
            return _presentServices.getByPrice();
        }

        [HttpGet("byCategory")]
        public IEnumerable<PresentMask> category()
        {
            return _presentServices.category();
        }

        [HttpGet("mostPopular")]
        public PresentMask popular()
        {
            return _presentServices.popular();
        }
    }
}

