using CourseManagementAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementAPI.Infrastructure.Configurations
{
    public class CourseTrainerConfiguration : IEntityTypeConfiguration<CourseTrainer>
    {
        public void Configure(EntityTypeBuilder<CourseTrainer> builder)
        {
            builder.HasOne(ct => ct.Course)
                .WithMany(c => c.CourseTrainers)
                .HasForeignKey(ct => ct.CourseId);

            builder.HasOne(ct => ct.Trainer)
                .WithMany(t => t.CourseTrainers)
                .HasForeignKey(ct => ct.TrainerId);
            
        }
    }
}
