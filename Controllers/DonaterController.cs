using chineseAction.Models;
using chineseAction.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace chineseAction.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DonaterController : ControllerBase
    {

        private readonly IDonaterServices _DonaterServices;

        public DonaterController(IDonaterServices DonaterServices)
        {
            _DonaterServices = DonaterServices;
        }


        [HttpGet]
        public IEnumerable<Donater> GetAllDonater()
        {
             return _DonaterServices.GetAllDonatert();
        }


        [HttpDelete("{id}")]
        public IActionResult deleteDonater( int id)
        {
            _DonaterServices.deleteDonater(id);
            return Ok();
        }


        [HttpPut]
        public IActionResult Update(Donater donater)
        {
            _DonaterServices.update(donater);
            return Ok();
        }

        [HttpPost]
        public IEnumerable<Donater> Create(Donater Donater)
        {
           return _DonaterServices.CreateDonater(Donater);
           
        }


        [HttpGet("byPresentId/{id}")]
        public Donater byPresentId(int id)
        {
            var d = _DonaterServices.byPresentId(id);
            return d;

        }

        [HttpGet("byId/{id}")]
        public Donater getById(int id)
        {
            var d = _DonaterServices.getById(id);
            return d;

        }

        [HttpGet("byMail/{mail}")]
        public List<Donater> getByMail(string mail)
        {
            var d = _DonaterServices.getByMail(mail);
            return d;

        }

        [HttpGet("byName")]
        public List<Donater> getByName(string name)
        {
            var d = _DonaterServices.getByName(name);
            return d;

        }
    }
}
