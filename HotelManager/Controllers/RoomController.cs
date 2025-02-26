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
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomClassRepository _roomClassRepository;

        public RoomController(IRoomRepository roomRepository, IRoomClassRepository roomClassRepository)
        {
            _roomRepository = roomRepository;
            _roomClassRepository = roomClassRepository;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var room = _roomRepository.GetAll().Select(r => r.ToRoomDTO());
            return Ok(room);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult<Room> GetRoomClass([FromRoute] int id)
        {
            var room = _roomRepository.GetById(id);
            return Ok(room);
        }

        [HttpPost]
        [Route("Create/")]
        public IActionResult Create( [FromBody] CreateRoomDTO roomDTO)
        {
            if (!_roomClassRepository.RoomClassExists(roomDTO.RoomClassId))
            {
                return BadRequest("RoomClassId dose not exists");
            }

            var room = roomDTO.ToRoomFromDTO();
            _roomRepository.Add(room);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromRoute] int id,[FromBody] UpdateRoomDTO updateRoomDTO)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            room.Description = updateRoomDTO.Description;
            room.RoomStatusId = updateRoomDTO.RoomStatusId;
            room.RoomClassId = updateRoomDTO.RoomClassId;
            room.RoomFloor = updateRoomDTO.RoomFloor;
            room.RoomNumber = updateRoomDTO.RoomNumber;

            _roomRepository.Update(room);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                return NotFound();
            }

            _roomRepository.Delete(room);
            return Ok();
        }
    }
}
