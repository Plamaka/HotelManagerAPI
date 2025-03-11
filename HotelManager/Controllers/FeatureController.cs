using HotelManager.DTOs;
using HotelManager.Interfaces;
using HotelManager.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureController(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] FeatureDTO featureDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var featureModel = featureDTO.ToFeatureFromDTO();
            _featureRepository.Add(featureModel);
            return Ok();
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var paymentStatus = _featureRepository.GetAll().Select(f => f.ToFeatureDTO());
            return Ok(paymentStatus);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] FeatureDTO featureDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _featureRepository.GetById(Id);

            if (model == null)
            {
                return NotFound("This Id was not found!");
            }

            model.FeatureName = featureDTO.FeatureName;
            _featureRepository.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var model = _featureRepository.GetById(Id);

            if (model == null)
            {
                return NotFound("This Id was not found!");
            }

            _featureRepository.Delete(model);
            return Ok();
        }
    }
}
