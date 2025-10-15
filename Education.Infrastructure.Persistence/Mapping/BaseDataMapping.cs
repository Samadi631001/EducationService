using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain.BaseDataAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Persistence.Mapping
{
    public class BaseDataMapping:IEntityTypeConfiguration<BaseData>
    {
        public void Configure(EntityTypeBuilder<BaseData> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Comment).HasMaxLength(1000);
            builder.Property(x => x.BaseDataTypeId).IsRequired();
            //builder.HasMany(x => x.TrainingCourses)
            //    .WithOne(x => x.BaseData)
            //    .HasForeignKey(x => x.BaseDataId)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
