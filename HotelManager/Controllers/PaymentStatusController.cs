﻿using HotelManager.DTOs;
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
    [Authorize(Roles = "Admin")]
    public class PaymentStatusController : ControllerBase
    {
        private readonly IPaymentStatusRepository _paymentStatusRepository;

        public PaymentStatusController(IPaymentStatusRepository paymentStatusRepository)
        {
            _paymentStatusRepository = paymentStatusRepository;
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] PaymentStatusDTO paymentStatusDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentStatusModel = paymentStatusDTO.ToPaymentStatusFromDTO();
            _paymentStatusRepository.Add(paymentStatusModel);
            return Ok();
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var paymentStatus = _paymentStatusRepository.GetAll().Select(ps => ps.CreatePaymentStatusDTO());
            return Ok(paymentStatus);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] PaymentStatusDTO paymentStatusDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = _paymentStatusRepository.GetById(Id);

            if (model == null)
            {
                return NotFound("This Id was not found!");
            }
            model.StatusName = paymentStatusDTO.StatusName;
            _paymentStatusRepository.Update(model);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            var model = _paymentStatusRepository.GetById(Id);

            if (model == null)
            {
              return NotFound("This Id was not found!");
            }

            _paymentStatusRepository.Delete(model);
            return Ok();
        }
    }
}
