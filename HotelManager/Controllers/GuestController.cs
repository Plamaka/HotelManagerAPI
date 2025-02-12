using HotelManager.DTOs;
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
        public IActionResult Create([FromBody] GuestDTO guestDto)
        {
            var guestModel = guestDto.ToGuestFromGuestDTO();
            _guestRepository.Add(guestModel);
            return Ok();
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var guest = _guestRepository.GetAll().Select(g => g.CreateGuestDTO());
            return Ok(guest);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] GuestDTO guestDto)
        {
            var guest = _guestRepository.GetById(Id);

            if (guest == null)
            {
                return NotFound();
            }
     
            guest.FirstName = guestDto.FirstName;
            guest.LastName = guestDto.LastName;
            guest.Email = guestDto.Email;
            guest.PhoneNumber = guestDto.PhoneNumber;
            _guestRepository.Update(guest);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var guestId = _guestRepository.GetById(Id);

            if (guestId == null)
            {
                return NotFound();
            }
            _guestRepository.Delete(guestId);
            return Ok();
        }
    }
}
