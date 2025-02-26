﻿using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Application.Interfaces;
using CourseManagementAPI.Domain.Entities;
using CourseManagementAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> ProcessPaymentAsync(string trainerId, decimal amount)
        {
            var payment = new Payment { TrainerId = trainerId, Amount = amount };
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<IEnumerable<PaymentDto>> GetPaymentsByTrainerAsync(string trainerId)
        {
            return await _context.Payments
            .Where(p => p.TrainerId == trainerId)
            .Select(p => new PaymentDto
            {
                 Id = p.Id,
                 TrainerId = p.TrainerId,
                 Amount = p.Amount,
                 PaymentDate = p.PaymentDate,
                 Status = p.Status
            })
                .ToListAsync();
            }
    }
}
