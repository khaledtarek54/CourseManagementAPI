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
    public class CourseTrainerRepository : ICourseTrainerRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseTrainerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LinkCourseToTrainerAsync(int courseId, string trainerId)
        {
            var link = new CourseTrainer { CourseId = courseId, TrainerId = trainerId };
            _context.CourseTrainers.Add(link);
            await _context.SaveChangesAsync();
        }

        public async Task UnlinkCourseFromTrainerAsync(int courseId, string trainerId)
        {
            var link = await _context.CourseTrainers
                .FirstOrDefaultAsync(ct => ct.CourseId == courseId && ct.TrainerId == trainerId);

            if (link != null)
            {
                _context.CourseTrainers.Remove(link);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CourseTrainer>> GetAllCourseTrainerLinksAsync()
        {
            return await _context.CourseTrainers.Include(ct => ct.Course).Include(ct => ct.Trainer).ToListAsync();
        }
    }
}
