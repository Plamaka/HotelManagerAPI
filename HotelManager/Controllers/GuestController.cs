using HotelManager.Interfaces;
using HotelManager.Mappers;
using HotelManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;

        public GuestController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        
        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Guest guest)
        {
            _guestRepository.Add(guest);
            return Ok();
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var guest = _guestRepository.GetAll().Select(g => g.ToGuestDTO());
            return Ok(guest);
        }
    }
}
