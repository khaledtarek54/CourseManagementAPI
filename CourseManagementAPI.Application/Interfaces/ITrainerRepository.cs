using CourseManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Interfaces
{
    public interface ITrainerRepository
    {
        Task<IEnumerable<Trainer>> GetAllTrainersAsync();
        Task<Trainer?> GetTrainerByIdAsync(int id);
        Task UpdateTrainerAsync(Trainer trainer);
        Task DeleteTrainerAsync(int id);
    }
}
