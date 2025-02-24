using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public string TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
    }
}
