using Education.Infrastructure.Persistence;
using Education.Infrastructure.Query.Contracts.CourseGroup;
using Epc.Application.Query;
using Epc.Company.Query;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Query
{
    public class CourseGroupQueryHandler(EducationQueryContext context) :
        IQueryHandlerAsync<Result<List<CourseGroupListDto>>>,
        IQueryHandlerAsync<Result<CourseGroupEditDto>, int>,
        IQueryHandlerAsync<Result<List<CourseGroupComboModel>>>
    {
        public async Task<Result<List<CourseGroupListDto>>> Handle()
        {
            var result = await context.CourseGroups.Select(x => new CourseGroupListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Comment = x.Comment,
                Group = x.Parent.Title

            }).ToListAsync();

            return Result<List<CourseGroupListDto>>.EmptyMessage(result);
        }

        public async Task<Result<CourseGroupEditDto>> Handle(int condition)
        {

            var result = await context.CourseGroups.Where(x => x.Id == condition)
                .Select(x => new CourseGroupEditDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Comment = x.Comment,
                    Parent=x.ParentId
                }).FirstOrDefaultAsync();
            return result == null ? Result<CourseGroupEditDto>.Failure(null, "دسته مورد نظر یافت نشد.") : Result<CourseGroupEditDto>.EmptyMessage(result);


        }


        async Task<Result<List<CourseGroupComboModel>>> IQueryHandlerAsync<Result<List<CourseGroupComboModel>>>.Handle()
        => Result<List<CourseGroupComboModel>>.EmptyMessage(
        await context.CourseGroups.Where(x => x.IsActive == 1).Select(x => new CourseGroupComboModel()
        {
            Id = x.Id,
            Title = x.Title,
        }).ToListAsync());
    }
}
