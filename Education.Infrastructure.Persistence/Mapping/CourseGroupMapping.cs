using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain.CourseGroupAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Persistence.Mapping
{
    public class CourseGroupMapping: IEntityTypeConfiguration<CourseGroup>
    {
        public void Configure(EntityTypeBuilder<CourseGroup> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Comment).HasMaxLength(4000);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            
            
            //builder.HasMany(x => x.TrainingCourse)
            //    .WithOne(x => x.CourseGroup)
            //    .HasForeignKey(x => x.CourseGroupId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
