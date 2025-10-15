using Education.Domain.TrainingCourseAgg;
using Education.Infrastructure.Query.Contracts.BaseData;
using Education.Infrastructure.Query.Contracts.CourseGroup;
using Education.Infrastructure.Query.Contracts.TrainingCourse;
using Education.Presentation.Facade.Contracts.BaseData;
using Education.Presentation.Facade.Contracts.TrainingCourse;
using Epc.Application.Query;
using Epc.Company.Query;

namespace Education.Presentation.Facade.Query;

public class TrainingCourseQueryFacade(IQueryBusAsync queryBus) : ITrainingCourseQueryFacade
{
    public async Task<Result<TrainingCourseEditDto>> GetForEdit(Guid guid)
        => await queryBus.Dispatch<Result<TrainingCourseEditDto>, Guid>(guid);

    public async Task<Result<List<TrainingCourseListDto>>> List()
        => await queryBus.Dispatch<Result<List<TrainingCourseListDto>>>();
}