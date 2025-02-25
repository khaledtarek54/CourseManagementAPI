using AutoMapper;
using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;

        public TrainerService(ITrainerRepository trainerRepository, IMapper mapper)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
        }

        public async Task<TrainerDetailsDto?> GetTrainerByIdAsync(string id)
        {
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);
            return trainer == null ? null :  new TrainerDetailsDto
            {
                Id = trainer.Id,
                UserName = trainer.UserName,
                Email = trainer.Email,
                PhoneNumber = trainer.PhoneNumber,
                CreatedAt = trainer.CreatedAt,
                Courses = trainer.CourseTrainers
                    .Select(ct => new TrainerCourseDto
                    {
                        Id = ct.Course.Id,
                        Name = ct.Course.Name,
                        Description = ct.Course.Description,
                        Price = ct.Course.Price,
                        Duration = ct.Course.Duration,
                        CreatedAt = ct.Course.CreatedAt
                    })
                    .ToList()
            }; 
        }

        public async Task<IEnumerable<TrainerDetailsDto>> GetAllTrainersAsync()
        {
            var trainers = await _trainerRepository.GetAllTrainersAsync();
            return _mapper.Map<IEnumerable<TrainerDetailsDto>>(trainers);
        }

        public async Task UpdateTrainerAsync(string id, TrainerUpdateDto trainerDto)
        {
            var trainer = await _trainerRepository.GetTrainerByIdAsync(id);
            if (trainer == null) throw new KeyNotFoundException("Trainer not found");

            trainer.Email = trainerDto.Email ?? trainer.Email;
            trainer.PhoneNumber = trainerDto.PhoneNumber ?? trainer.PhoneNumber;

            await _trainerRepository.UpdateTrainerAsync(trainer);
        }

        public async Task DeleteTrainerAsync(string id)
        {
            await _trainerRepository.DeleteTrainerAsync(id);
        }
    }
}
