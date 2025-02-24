using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Domain.Entities
{
    public class CourseTrainer
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;
    }
}
