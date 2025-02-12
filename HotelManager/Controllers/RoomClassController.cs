using HotelManager.DTOs;
using HotelManager.Interfaces;
using HotelManager.Mappers;
using HotelManager.Models;
using HotelManager.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomClassController : ControllerBase
    {
        private readonly IRoomClassRepository _roomClassRepository;

        public RoomClassController(IRoomClassRepository roomClassRepository)
        {
            _roomClassRepository = roomClassRepository;
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult<RoomClass> GetRoomClass()
        {
            var roomClass = _roomClassRepository.GetAll().Select(s => s.ToRoomClassDTO());
            return Ok(roomClass);
        }

        [HttpGet]
        [Route("Index/{id}")]
        public ActionResult<RoomClass> GetRoomClass([FromRoute] int id)
        {
            var roomClass = _roomClassRepository.GetById(id);
            return Ok(roomClass);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CreateRoomClassDTO createRoomClassDTO)
        {
            var roomClass = createRoomClassDTO.ToRoomClassFromDTO();

            _roomClassRepository.Add(roomClass);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CreateRoomClassDTO roomClassDTO)
        {
            var roomClass = _roomClassRepository.GetById(id);
            if (roomClass == null)
            {
                return NotFound();
            }
            var existingFeature = roomClass.RoomClassFeatures.Select(rcf => rcf.FeatureId).ToList();
            var newFeature = roomClassDTO.FeaturesId.Except(existingFeature).ToList();
            var removedFeatures = existingFeature.Except(roomClassDTO.FeaturesId).ToList();

            roomClass.ClassName = roomClassDTO.ClassName;
            roomClass.AllowsPet = roomClassDTO.AllowsPet;
            roomClass.Capacity = roomClassDTO.Capacity;
            roomClass.BasePrice = roomClassDTO.BasePrice;

            foreach (var featureId in newFeature)
            {
                roomClass.RoomClassFeatures.Add(new RoomClassFeature { RoomClassId = id, FeatureId = featureId });
            }

            foreach (var featureId in removedFeatures)
            {
                var roomClassFeature = roomClass.RoomClassFeatures.FirstOrDefault(rcf => rcf.FeatureId == featureId);
                if (roomClassFeature != null)
                {
                    roomClass.RoomClassFeatures.Remove(roomClassFeature);
                }
            }

            _roomClassRepository.Update(roomClass);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult<RoomClass> Delete([FromRoute] int id)
        {
            var roomClass = _roomClassRepository.GetById(id);

            if (roomClass == null)
            {
                return NotFound();
            }

            _roomClassRepository.Delete(roomClass);
            return Ok(roomClass);
        }
    }
}
