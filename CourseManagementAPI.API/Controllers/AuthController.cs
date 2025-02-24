using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _authService.LoginTrainerAsync(model);
            return result.Success ? Ok(result) : Unauthorized(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> CreateTrainer([FromBody] CreateTrainerDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authService.CreateTrainerAsync(model);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }
    }
}
