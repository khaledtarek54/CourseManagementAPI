using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<Course> AddCourseAsync(CourseDto courseDto);
        Task UpdateCourseAsync(int id, CourseDto courseDto);
        Task DeleteCourseAsync(int id);
    }
}
