using CourseManagementAPI.Application.Interfaces;
using CourseManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainersController(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetAll()
        {
            var trainers = await _trainerRepository.GetAllTrainersAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetById(int id)
        {
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);
            if (trainer == null)
                return NotFound();
            return Ok(trainer);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Trainer trainer)
        {
            if (id != trainer.Id)
                return BadRequest();

            await _trainerRepository.UpdateTrainerAsync(trainer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _trainerRepository.DeleteTrainerAsync(id);
            return NoContent();
        }
    }
}
