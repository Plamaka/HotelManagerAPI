using HotelManager.DTOs;
using HotelManager.Interfaces;
using HotelManager.Mappers;
using HotelManager.Models;
using HotelManager.Repository;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IRoomRepository _roomRepository;

        public RoomClassController(IRoomClassRepository roomClassRepository, IRoomRepository roomRepository)
        {
            _roomClassRepository = roomClassRepository;
            _roomRepository = roomRepository;
        }

        [HttpPost]
        [Route("SearchByPrice")]
        public ActionResult<RoomClass> GetRoomClass([FromBody] SearchRoomClassByPriceDTO byPriceDTO)
        {
            var roomClass = _roomClassRepository.SearchByPrice(byPriceDTO.PriceMin, byPriceDTO.PriceMax);
            return Ok(roomClass);
        }

        [HttpGet]
        [Route("Index")]
        public ActionResult<RoomClass> GetRoomClass()
        {
            var roomClass = _roomClassRepository.GetAll().Select(s => s.ToRoomClassDTO(_roomRepository.GetAll()));
            return Ok(roomClass);
        }


        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult<RoomClass> GetRoomClass([FromRoute] int id)
        {
            var roomClass = _roomClassRepository.GetById(id);
            if (roomClass == null)
            {
                return NotFound("This Id was not found!");
            }

            return Ok(roomClass);
        }


        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] CreateRoomClassDTO createRoomClassDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomClass = createRoomClassDTO.ToRoomClassFromDTO(_roomRepository.GetAll());

            _roomClassRepository.Add(roomClass);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromRoute] int id, [FromBody] CreateRoomClassDTO roomClassDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomClass = _roomClassRepository.GetById(id);
            if (roomClass == null)
            {
                return NotFound("This Id was not found!");
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
        [Authorize(Roles = "Admin")]
        public ActionResult<RoomClass> Delete([FromRoute] int id)
        {
            var roomClass = _roomClassRepository.GetById(id);

            if (roomClass == null)
            {
                return NotFound("This Id was not found!");
            }

            _roomClassRepository.Delete(roomClass);
            return Ok(roomClass);
        }
    }
}
