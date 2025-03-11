
﻿using HotelManager.DTOs;
using HotelManager.Interfaces;
﻿using HotelManager.Interfaces;
using HotelManager.Mappers;
using HotelManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<Guest> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Guest> _signInManager;

        public GuestController(IGuestRepository guestRepository, UserManager<Guest> userManager, ITokenService tokenService, SignInManager<Guest> signInManager, IBookingRepository bookingRepository, IHttpContextAccessor httpContextAccessor)
        {
            _guestRepository = guestRepository;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _bookingRepository = bookingRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GuestBooking")]
        [Authorize(Roles = "User")]
        public IActionResult GuestBooking()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userBooking = _bookingRepository.GetBookingsByGuest(curUserId);
            return Ok(userBooking.Select(b => b.ToBookingDTO()));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDTO.Email.ToLower());

            if (user == null) return Unauthorized("Invalid email!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded) return Unauthorized("Password not found!");

            return Ok(
               await _tokenService.CreateToken(user)
            );
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Create([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var guestUser = new Guest
                {
                   FirstName = registerDTO.FirstName,
                   LastName = registerDTO.LastName,
                   UserName = registerDTO.UserName,
                   Email = registerDTO.Email,
                   PhoneNumber = registerDTO.PhoneNumber
                };

                var createGuest = await _userManager.CreateAsync(guestUser, registerDTO.Password);

                if (createGuest.Succeeded)
                {
                    var rollResult = await _userManager.AddToRoleAsync(guestUser, "User");
                    if (rollResult.Succeeded)
                    {
                        return Ok(await _tokenService.CreateToken(guestUser));
                    }
                    else
                    {
                        return StatusCode(500, rollResult);
                    }
                }
                else
                {
                    return StatusCode(500, createGuest.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }       
        }        

        [HttpGet]
        [Route("Index")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var guest = _guestRepository.GetAll().Select(g => g.CreateGuestDTO());
            return Ok(guest);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromRoute] string Id, [FromBody] GuestDTO guestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guest = _guestRepository.GetById(Id);

            if (guest == null)
            {
                return NotFound("This Id was not found!");
            }

            guest.FirstName = guestDto.FirstName;
            guest.LastName = guestDto.LastName;
            guest.Email = guestDto.Email;
            guest.PhoneNumber = guestDto.PhoneNumber;
            _guestRepository.Update(guest);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute] string Id)
        {
            var guestId = _guestRepository.GetById(Id);

            if (guestId == null)
            {
                return NotFound("This Id was not found!");
            }
            _guestRepository.Delete(guestId);
            return Ok();
        }
    }
}
