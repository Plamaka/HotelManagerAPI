using HotelManager.DTOs;
using HotelManager.Interfaces;
using HotelManager.Mappers;
using HotelManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomClassRepository _roomClassRepository;
        private readonly IPaymentStatusRepository _paymentStatusRepository;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public BookingController(IBookingRepository bookingRepository, IRoomRepository roomRepository, IRoomClassRepository roomClassRepository, IHttpContextAccessor httpContextAccessor, IPaymentStatusRepository paymentStatusRepository)
        {
            _bookingRepository = bookingRepository;
            _roomClassRepository = roomClassRepository;
            _roomRepository = roomRepository;
            _httpContextAccessor = httpContextAccessor;
            _paymentStatusRepository = paymentStatusRepository;
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Search([FromBody] SearchRoomDTO searchRoomDTO)
        {
            var busyRooms = _bookingRepository.GetBookingsInDateRange(searchRoomDTO.CheckInDate, searchRoomDTO.CheckOutDate)
                                       .SelectMany(b => b.BookingRooms.Select(br => br.RoomId))
                                       .Distinct()
                                       .ToList();

            var allRooms = _roomRepository.GetAll();

            var freeRooms = allRooms.Where(r => !busyRooms.Contains(r.Id)).ToList();

            if (!searchRoomDTO.pet)
            {
                freeRooms = freeRooms.Where(r => !r.RoomClass.AllowsPet).ToList();
            }

            return Ok(freeRooms.Select(r => r.ToRoomDTO()));
        }

        [HttpGet]
        [Route("Index")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var booking = _bookingRepository.GetAll().Select(b => b.ToBookingDTO());
            return Ok(booking);
        }

        [HttpGet]
        [Route("Details/{id}")]
        [Authorize(Roles = "Admin,User")]
        public IActionResult Index([FromRoute] int id)
        {
            var booking = _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound("This Id was not found!");
            }
            return Ok(booking);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "User")]
        public IActionResult Create([FromBody] CreateBookingDTO createBookingDTO)
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();

            if (curUser == null) return Unauthorized("No user ID found");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal price = 0;
            foreach (var roomId in createBookingDTO.RoomIds)
            {
                var room  = _roomRepository.GetById(roomId);
                price += Convert.ToDecimal(room.RoomClass.BasePrice); 
            }

            if (!_paymentStatusRepository.PaymentStatusExists(createBookingDTO.PaymentStatusId))
            {
                return BadRequest("PaymentStatusId dose not exists");
            }

            var booking = createBookingDTO.ToBookingFromDTO(price);

            _bookingRepository.Add(booking);

            var bookingGuest = new BookingGuest
            {
                GuestId = curUser,
                BookingId = booking.Id
            };
            _bookingRepository.AddBookingGuest(bookingGuest);

            
            return Ok();
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateBookingDTO updateBookingDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound("This Id was not found!");
            }

            booking.CheckInDate = updateBookingDTO.CheckInDate;
            booking.CheckOutDate = updateBookingDTO.CheckOutDate;
            _bookingRepository.Update(booking);
            return Ok();
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound("This Id was not found!");
            }

            _bookingRepository.Delete(booking);
            return Ok();
        }
    }
}
