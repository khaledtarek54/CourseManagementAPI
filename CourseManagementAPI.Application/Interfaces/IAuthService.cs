using CourseManagementAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username);
        Task<AuthResponse> LoginTrainerAsync(LoginModel model);
        Task<AuthResponse> CreateTrainerAsync(CreateTrainerDto model);
    }
}
