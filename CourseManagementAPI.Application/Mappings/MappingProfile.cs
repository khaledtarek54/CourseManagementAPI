using AutoMapper;
using CourseManagementAPI.Application.DTOs;
using CourseManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<Trainer, TrainerDetailsDto>().ReverseMap();
            CreateMap<TrainerUpdateDto, Trainer>();
        }

    }
}
