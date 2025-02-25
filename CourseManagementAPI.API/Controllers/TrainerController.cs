using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Application.Interfaces;
using CourseManagementAPI.Application.Services;
using CourseManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainersController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainerDetailsDto>>> GetAll()
        {
            Console.WriteLine($"Received request for Trainers");
            var trainers = await _trainerService.GetAllTrainersAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerDetailsDto>> GetById(string id)
        {
            var trainer = await _trainerService.GetTrainerByIdAsync(id);
            if (trainer == null)
                return NotFound("Trainer not found");

            return Ok(trainer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] TrainerUpdateDto trainerDto)
        {
            if (trainerDto == null)
                return BadRequest("Invalid trainer data");

            await _trainerService.UpdateTrainerAsync(id, trainerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _trainerService.DeleteTrainerAsync(id);
            return NoContent();
        }
    }
}
