using AutoMapper;
using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Application.Interfaces;
using CourseManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            
            var course =  await _courseRepository.GetCourseByIdAsync(id);
            return course;
        }

        public async Task<Course> AddCourseAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepository.AddCourseAsync(course);
            return course;
        }

        public async Task UpdateCourseAsync(int id, CourseDto courseDto)
        {
            var course = await _courseRepository.GetCourseByIdAsync(id);
            if (course == null) throw new KeyNotFoundException("Course not found");

            _mapper.Map(courseDto, course);
            await _courseRepository.UpdateCourseAsync(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteCourseAsync(id);
        }
    }
}
