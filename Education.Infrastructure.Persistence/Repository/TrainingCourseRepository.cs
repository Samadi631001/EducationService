using Education.Domain.TrainingCourseAgg;
using Epc.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Persistence.Repository;

public class TrainingCourseRepository(DbContext commandContext) : BaseRepository<long, TrainingCourse>(commandContext),
    ITrainingCourseRepository;


 