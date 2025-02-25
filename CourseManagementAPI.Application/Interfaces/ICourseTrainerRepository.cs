using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Interfaces
{
    public interface ICourseTrainerRepository
    {
        Task LinkCourseToTrainerAsync(int courseId, string trainerId);
        Task UnlinkCourseFromTrainerAsync(int courseId, string trainerId);
        Task<IEnumerable<CourseTrainerReportDto>> GetAllCourseTrainerLinksAsync();
    }
}
