using HotelManager.DTOs;
using HotelManager.Interfaces;
using HotelManager.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomStatusController : ControllerBase
    {
        private readonly IRoomStatusRepository _roomStatusRepository;

        public RoomStatusController(IRoomStatusRepository roomStatusRepository)
        {
            _roomStatusRepository = roomStatusRepository;
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] RoomStatusDTO roomStatusDTO)
        {
            var roomStatusModel = roomStatusDTO.ToRoomStatusFromDTO();
            _roomStatusRepository.Add(roomStatusModel);
            return Ok();
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var roomStatus = _roomStatusRepository.GetAll().Select(rs => rs.ToRoomStatusDTO());
            return Ok(roomStatus);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] RoomStatusDTO roomStatusDTO)
        {
            var model = _roomStatusRepository.GetById(Id);

            if (model == null)
            {
                return NotFound();
            }

            model.StatusName = roomStatusDTO.StatusName;
            _roomStatusRepository.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var model = _roomStatusRepository.GetById(Id);

            if (model == null)
            {
                return NotFound();
            }

            _roomStatusRepository.Delete(model);
            return Ok();
        }
    }
}
