using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Domain.Entities;
using CourseManagementAPI.Infrastructure.Data;
using CourseManagementAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CourseManagementAPI.Tests.Infrastructure
{
    public class PaymentRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly PaymentRepository _paymentRepository;

        public PaymentRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _paymentRepository = new PaymentRepository(_context);

            _context.Payments.AddRange(new List<Payment>
            {
                new Payment { Id = 1, TrainerId = "trainer1", Amount = 100, Status = "Completed" },
                new Payment { Id = 2, TrainerId = "trainer1", Amount = 200, Status = "Pending" },
                new Payment { Id = 3, TrainerId = "trainer2", Amount = 150, Status = "Completed" }
            });

            _context.SaveChanges();
        }

        [Fact]
        public async Task ProcessPaymentAsync_ShouldAddPayment()
        {

            string trainerId = "trainer3";
            decimal amount = 300;


            var payment = await _paymentRepository.ProcessPaymentAsync(trainerId, amount);


            Assert.NotNull(payment);
            Assert.Equal(trainerId, payment.TrainerId);
            Assert.Equal(amount, payment.Amount);

            var storedPayment = _context.Payments.FirstOrDefault(p => p.TrainerId == trainerId);
            Assert.NotNull(storedPayment);
            Assert.Equal(amount, storedPayment.Amount);
        }

        [Fact]
        public async Task GetPaymentsByTrainerAsync_ShouldReturnPayments()
        {

            string trainerId = "trainer1";

            var payments = await _paymentRepository.GetPaymentsByTrainerAsync(trainerId);

            Assert.NotNull(payments);
            Assert.Equal(2, payments.Count());
            Assert.All(payments, p => Assert.Equal(trainerId, p.TrainerId));
        }
    }
}
