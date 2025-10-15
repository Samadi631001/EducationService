using Education.Infrastructure.Query.Contracts.CourseGroup;
using Epc.Company.Query;
using Epc.Core;

namespace Education.Presentation.Facade.Contracts.CourseGroup
{
    public interface ICourseGroupQueryFacade:IFacadeService
    {
        Task<Result<List<CourseGroupListDto>>> List();
        Task<Result<CourseGroupEditDto>> GetDetails(int id);
        Task<Result<List<CourseGroupComboModel>>> GetForCombo();
    }
}
