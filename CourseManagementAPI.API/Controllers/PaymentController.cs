using CourseManagementAPI.Application.Interfaces;
using CourseManagementAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementAPI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment(string trainerId, decimal amount)
        {
            var payment = await _paymentRepository.ProcessPaymentAsync(trainerId, amount);
            return Ok(new { message = "Payment processed successfully", payment });
        }

        [HttpGet("trainer/{trainerId}")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentsByTrainer(string trainerId)
        {
            var payments = await _paymentRepository.GetPaymentsByTrainerAsync(trainerId);
            return Ok(payments);
        }
    }
}
