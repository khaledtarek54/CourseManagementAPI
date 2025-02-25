using CourseManagementAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Interfaces
{
    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDetailsDto>> GetAllTrainersAsync();
        Task<TrainerDetailsDto?> GetTrainerByIdAsync(string id);
        Task UpdateTrainerAsync(string id, TrainerUpdateDto trainerDto);
        Task DeleteTrainerAsync(string id);
    }
}
