using Epc.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain.CourseGroupAgg;

namespace Education.Infrastructure.Persistence.Repository
{
    public class CourseGroupRepository(DbContext commandContext): BaseRepository<int, CourseGroup>(commandContext),
        ICourseGroupRepository
    {
    }
}
