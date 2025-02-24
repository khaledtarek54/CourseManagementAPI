using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CourseManagementAPI.Domain.Entities
{
    public class Trainer : IdentityUser
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<CourseTrainer> CourseTrainers { get; set; } = new();
    }
}
