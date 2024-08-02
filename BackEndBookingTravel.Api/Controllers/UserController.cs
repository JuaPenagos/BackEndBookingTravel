using BackEndBookingTravel.Application.Dtos;
using BackEndBookingTravel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndBookingTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {

            _userService = userService;
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogInAsync(LoginDto login)
        {
            var response = await _userService.LoginAsync(login.UserName, login.Password);

            return Ok(response);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUsersync(UserDto user)
        {
            var response = await _userService.CreateUser(user);

            return Ok(response);
        }
    }
}
