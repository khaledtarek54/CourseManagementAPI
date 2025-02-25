using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Application.DTOs
{
    public class CourseTrainerReportDto
    {
        public string TrainerId { get; set; } = string.Empty;
        public string TrainerName { get; set; } = string.Empty;
        public string TrainerEmail { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public decimal CoursePrice { get; set; }
        public DateTime AssignedDate { get; set; }
    }
}
