using CourseManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.DTOs
{
    public class CourseTrainerDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string TrainerId { get; set; }
        public TrainerDetailsDto Trainer { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
