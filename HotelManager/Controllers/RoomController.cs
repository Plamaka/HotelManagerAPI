using HotelManager.DTOs;
using HotelManager.Interfaces;
using HotelManager.Mappers;
using HotelManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomClassRepository _roomClassRepository;
        private readonly IRoomStatusRepository _roomStatusRepository;

        public RoomController(IRoomRepository roomRepository, IRoomClassRepository roomClassRepository, IRoomStatusRepository roomStatusRepository)
        {
            _roomRepository = roomRepository;
            _roomClassRepository = roomClassRepository;
            _roomStatusRepository = roomStatusRepository;
        }

        [HttpGet]
        [Route("Index")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var room = _roomRepository.GetAll().Select(r => r.ToRoomDTO());
            return Ok(room);
        }

        [HttpGet]
        [Route("Details/{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Room> GetRoomClass([FromRoute] int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return NotFound("This Id was not found!");
            }

            return Ok(room);
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public IActionResult Create( [FromBody] CreateRoomDTO roomDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_roomClassRepository.RoomClassExists(roomDTO.RoomClassId))
            {
                return BadRequest("RoomClassId dose not exists");
            }

            var room = roomDTO.ToRoomFromDTO(_roomStatusRepository.GetByName("Free"));
            _roomRepository.Add(room);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateRoomDTO updateRoomDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room = _roomRepository.GetById(id);

            if (room == null)
            {
                return NotFound("This Id was not found!");
            }

            room.RoomStatusId = updateRoomDTO.RoomStatusId;
            room.RoomClassId = updateRoomDTO.RoomClassId;
            room.RoomFloor = updateRoomDTO.RoomFloor;
            room.RoomNumber = updateRoomDTO.RoomNumber;

            _roomRepository.Update(room);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return NotFound("This Id was not found!");
            }

            _roomRepository.Delete(room);
            return Ok();
        }
    }
}
