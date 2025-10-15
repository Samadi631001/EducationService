using Education.Domain.TrainingCourseAgg;
using Education.Infrastructure.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain.BaseDataAgg;
using Education.Domain.CourseGroupAgg;

namespace Education.Infrastructure.Persistence
{
    public class EducationCommandContext(DbContextOptions<EducationCommandContext> options) : DbContext(options)
    {
        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<TrainingCourse> TrainingCourses { get; set; }
        public DbSet<BaseData> BaseDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            var assembly = typeof(CourseGroupMapping).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(builder);
        }
    }
}
