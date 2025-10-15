using Education.Application.Contract.CourseGroup;
using Epc.Company.Query;

namespace Education.Presentation.Facade.Contracts.CourseGroup
{
    public interface ICourseGroupCommandFacade
    {
        Task<Result<int>> Create(CreateCourseGroupDto command);
        Task<Result<bool>> Edit(EditCourseGroupDto command);
        Task<Result<bool>> Delete(int id);
    }
}
