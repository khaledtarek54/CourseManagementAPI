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
    public class CourseRepositoryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly CourseRepository _courseRepository;

        public CourseRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_" + System.Guid.NewGuid())
                .Options;

            _context = new ApplicationDbContext(options);
            _courseRepository = new CourseRepository(_context);
        }

        [Fact]
        public async Task AddCourseAsync_ShouldAddCourse()
        {
            var course = new Course { Name = "Test Course", Description = "Test Desc", Price = 100, Duration = 30 };

            var courseId = await _courseRepository.AddCourseAsync(course);
            var result = await _context.Courses.FindAsync(courseId);

            Assert.NotNull(result);
            Assert.Equal("Test Course", result.Name);
        }

        [Fact]
        public async Task GetAllCoursesAsync_ShouldReturnCourses()
        {
            _context.Courses.AddRange(
                new Course { Name = "Course 1", Description = "Desc 1", Price = 100, Duration = 30 },
                new Course { Name = "Course 2", Description = "Desc 2", Price = 200, Duration = 45 }
            );
            await _context.SaveChangesAsync();

            var result = await _courseRepository.GetAllCoursesAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetCourseByIdAsync_ShouldReturnCourse_WhenExists()
        {
            var course = new Course { Name = "Test Course", Description = "Test Desc", Price = 100, Duration = 30 };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            var result = await _courseRepository.GetCourseByIdAsync(course.Id);

            Assert.NotNull(result);
            Assert.Equal("Test Course", result.Name);
        }

        [Fact]
        public async Task GetCourseByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            var result = await _courseRepository.GetCourseByIdAsync(999);
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateCourseAsync_ShouldUpdateCourse()
        {
            var course = new Course { Name = "Old Name", Description = "Old Desc", Price = 100, Duration = 30 };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            course.Name = "Updated Name";
            await _courseRepository.UpdateCourseAsync(course);

            var updatedCourse = await _context.Courses.FindAsync(course.Id);

            Assert.NotNull(updatedCourse);
            Assert.Equal("Updated Name", updatedCourse.Name);
        }

        [Fact]
        public async Task DeleteCourseAsync_ShouldRemoveCourse()
        {
            var course = new Course { Name = "To Delete", Description = "To Delete Desc", Price = 100, Duration = 30 };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            await _courseRepository.DeleteCourseAsync(course.Id);

            var result = await _context.Courses.FindAsync(course.Id);

            Assert.Null(result);
        }
    }
}
