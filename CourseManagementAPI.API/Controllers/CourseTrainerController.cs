using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Application.Interfaces;
using CourseManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTrainerController : ControllerBase
    {
        private readonly ICourseTrainerRepository _courseTrainerRepository;

        public CourseTrainerController(ICourseTrainerRepository courseTrainerRepository)
        {
            _courseTrainerRepository = courseTrainerRepository;
        }

        [HttpPost("link")]
        public async Task<IActionResult> LinkCourseToTrainer(int courseId, string trainerId)
        {
            await _courseTrainerRepository.LinkCourseToTrainerAsync(courseId, trainerId);
            return Ok(new { message = "Trainer linked to course successfully" });
        }

        [HttpDelete("unlink")]
        public async Task<IActionResult> UnlinkCourseFromTrainer(int courseId, string trainerId)
        {
            await _courseTrainerRepository.UnlinkCourseFromTrainerAsync(courseId, trainerId);
            return Ok(new { message = "Trainer unlinked from course successfully" });
        }

        [HttpGet("report")]
        public async Task<ActionResult<IEnumerable<CourseTrainerReportDto>>> GetAllLinks()
        {
            var links = await _courseTrainerRepository.GetAllCourseTrainerLinksAsync();
            return Ok(links);
        }
    }
}
