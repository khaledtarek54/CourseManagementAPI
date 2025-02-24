using CourseManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> ProcessPaymentAsync(string trainerId, decimal amount);
        Task<IEnumerable<Payment>> GetPaymentsByTrainerAsync(string trainerId);
    }
}
