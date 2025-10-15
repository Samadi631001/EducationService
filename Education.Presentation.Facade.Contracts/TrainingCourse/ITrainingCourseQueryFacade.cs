using Education.Infrastructure.Query.Contracts.CourseGroup;
using Education.Infrastructure.Query.Contracts.TrainingCourse;
using Epc.Company.Query;
using Epc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Presentation.Facade.Contracts.TrainingCourse
{
    public interface ITrainingCourseQueryFacade: IFacadeService
    {
        Task<Result<TrainingCourseEditDto>> GetForEdit(Guid guid);
        Task<Result<List<TrainingCourseListDto>>> List();
    }
}
