using HotelManager.DTOs;
using HotelManager.Interfaces;
using HotelManager.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var model = _featureRepository.GetById(Id);

            if (model == null)
            {
                return NotFound();
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
                return NotFound();
            }

            _featureRepository.Delete(model);
            return Ok();
        }
    }
}
