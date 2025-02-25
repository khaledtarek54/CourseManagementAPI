using CourseManagementAPI.Domain.Entities;
using CourseManagementAPI.Infrastructure.Data;
using CourseManagementAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Tests.Infrastructure
{
    public class CourseTrainerRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly CourseTrainerRepository _courseTrainerRepository;
        public CourseTrainerRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_" + System.Guid.NewGuid())
                .Options;

            _context = new ApplicationDbContext(options);
            _courseTrainerRepository = new CourseTrainerRepository(_context);
        }

        [Fact]
        public async Task LinkCourseToTrainerAsync_ShouldAddCourseTrainerLink()
        {
            var trainer = new Trainer { Id = "T1", UserName = "Trainer1", Email = "trainer1@example.com" };
            var course = new Course { Id = 1, Name = "Course1", Price = 200 };

            _context.Trainers.Add(trainer);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            await _courseTrainerRepository.LinkCourseToTrainerAsync(course.Id, trainer.Id);

            var result = await _context.CourseTrainers.FirstOrDefaultAsync(ct => ct.CourseId == course.Id && ct.TrainerId == trainer.Id);

            Assert.NotNull(result);
            Assert.Equal(course.Id, result.CourseId);
            Assert.Equal(trainer.Id, result.TrainerId);
        }

        [Fact]
        public async Task UnlinkCourseFromTrainerAsync_ShouldRemoveCourseTrainerLink()
        {
            var trainer = new Trainer { Id = "T1", UserName = "Trainer1", Email = "trainer1@example.com" };
            var course = new Course { Id = 1, Name = "Course1", Price = 200 };
            var courseTrainer = new CourseTrainer { CourseId = course.Id, TrainerId = trainer.Id };

            _context.Trainers.Add(trainer);
            _context.Courses.Add(course);
            _context.CourseTrainers.Add(courseTrainer);
            await _context.SaveChangesAsync();

            await _courseTrainerRepository.UnlinkCourseFromTrainerAsync(course.Id, trainer.Id);

            var result = await _context.CourseTrainers.FirstOrDefaultAsync(ct => ct.CourseId == course.Id && ct.TrainerId == trainer.Id);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllCourseTrainerLinksAsync_ShouldReturnLinkedCoursesAndTrainers()
        {
            var trainer = new Trainer { Id = "T1", UserName = "Trainer1", Email = "trainer1@example.com" };
            var course = new Course { Id = 1, Name = "Course1", Price = 200 };
            var courseTrainer = new CourseTrainer { CourseId = course.Id, TrainerId = trainer.Id };

            _context.Trainers.Add(trainer);
            _context.Courses.Add(course);
            _context.CourseTrainers.Add(courseTrainer);
            await _context.SaveChangesAsync();

            var result = await _courseTrainerRepository.GetAllCourseTrainerLinksAsync();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("T1", result.First().TrainerId);
            Assert.Equal("Trainer1", result.First().TrainerName);
            Assert.Equal("Course1", result.First().CourseName);
        }
    }
}
