using Education.Domain.TrainingCourseAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Infrastructure.Persistence.Mapping
{
    public class TrainingCourseMapping : IEntityTypeConfiguration<TrainingCourse>
    {
        public void Configure(EntityTypeBuilder<TrainingCourse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number).HasMaxLength(50);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.TitleEnglish).HasMaxLength(200);
            builder.Property(x => x.PracticalPeriod).HasMaxLength(5);
            builder.Property(x => x.VisionaryPeriod).HasMaxLength(5);
            builder.Property(x => x.Purpose).HasMaxLength(4000);
            builder.Property(x => x.Comment).HasMaxLength(4000);
            builder.Property(x => x.Compass).HasMaxLength(50);
            builder.Property(x => x.ExclusiveCode).HasMaxLength(50);
            builder.Property(x => x.ExclusivePermit).HasMaxLength(50);
            builder.Property(x => x.TrainingScore).HasMaxLength(50);

            #region Relations

            //builder.HasOne(c => c.CourseGroup).WithMany(c => c.TrainingCourse).HasForeignKey(c => c.CourseGroupId);
            //builder.HasOne(c => c.CourseLayout).WithMany(c => c.TrainingCourses).HasForeignKey(c => c.CourseLayoutId);
            //builder.HasOne(c => c.CourseLevel).WithMany(c => c.TrainingCourses).HasForeignKey(c => c.CourseLevelId);
            //builder.HasOne(c => c.CourseCategory).WithMany(c => c.TrainingCourse).HasForeignKey(c => c.CourseCategoryId);
            //builder.HasOne(c => c.CourseExam).WithMany(c => c.TrainingCourse).HasForeignKey(x => x.CourseExamId);
            //builder.HasOne(c => c.TrainingWay).WithMany(c => c.TrainingCourses).HasForeignKey(x => x.TrainingWayId);

            #endregion
        }
    }
}
