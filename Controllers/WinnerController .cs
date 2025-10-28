using chineseAction.Models;
using chineseAction.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;

namespace chineseAction.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class WinnerController
    {

        private readonly IWinnerServices _WinnerServices;
        private readonly JwtTokenService _jwtTokenService;

        public WinnerController(IWinnerServices WinnerServices, JwtTokenService jwtTokenService)
        {
            _WinnerServices = WinnerServices;
            _jwtTokenService =jwtTokenService;
    }


        [HttpGet]
        public IEnumerable<WinnerMask> GetAllPresent()
        {
            var Winner = _WinnerServices.GetAllWinner();
            return Winner;
        }



        [HttpGet("byId/{id}")]
        public WinnerMask getById(int id)
        {
            var p = _WinnerServices.getById(id);
            return p;

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public bool Create(PresentId PresentId)
        {
            var a= _WinnerServices.Create(PresentId.Id);
            return a;
        }








    }
}
