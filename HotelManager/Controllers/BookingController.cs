using HotelManager.DTOs;
using HotelManager.Interfaces;
using HotelManager.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var booking = _bookingRepository.GetAll().Select(b => b.ToBookingDTO());
            return Ok(booking);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Index([FromRoute] int id)
        {
            var booking = _bookingRepository.GetById(id);
            return Ok(booking);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CreateBookingDTO createBookingDTO)
        {
            var booking = createBookingDTO.ToBookingFromDTO();
            _bookingRepository.Add(booking);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateBookingDTO updateBookingDTO)
        {
            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            booking.CheckInDate = updateBookingDTO.CheckInDate;
            booking.CheckOutDate = updateBookingDTO.CheckOutDate;
            _bookingRepository.Update(booking);
            return Ok();
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            _bookingRepository.Delete(booking);
            return Ok();
        }
    }
}
