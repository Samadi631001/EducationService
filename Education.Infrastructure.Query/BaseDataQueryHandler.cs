using Education.Domain.BaseDataAgg;
using Education.Infrastructure.Persistence;
using Education.Infrastructure.Query.Contracts.BaseData;
using Epc.Application.Query;
using Epc.Company.Query;
using Microsoft.EntityFrameworkCore;

namespace Education.Infrastructure.Query;

public class BaseDataQueryHandler(EducationQueryContext context): 
    IQueryHandlerAsync<Result<List<BaseDataListDto>>,int>,
    IQueryHandlerAsync<Result<BaseDataEditDto>,int>,
    IQueryHandlerAsync<Result<List<BaseDataComboModel>>>
{
 

    public async Task<Result<BaseDataEditDto>> Handle(int condition)
    {
        var result = await context.BaseDatas.Where(x => x.Id == condition)
            .Select(x => new BaseDataEditDto()
            {
                Id = x.Id,
                Title = x.Title,
                Comment = x.Comment
            }).FirstOrDefaultAsync();
        return result == null ? Result<BaseDataEditDto>.Failure(null, "موردی یافت نشد") : Result<BaseDataEditDto>.EmptyMessage(result);
    }

    async Task<Result<List<BaseDataComboModel>>> IQueryHandlerAsync<Result<List<BaseDataComboModel>>>.Handle()
    {
        var result = await context.BaseDatas.Select(x => new BaseDataComboModel()
        {
            Id = x.Id,
            Title = x.Title
        }).ToListAsync();
        if (result == null || !result.Any())
            return Result<List<BaseDataComboModel>>.Failure([], "موردی یافت نشد.");

        return Result<List<BaseDataComboModel>>.EmptyMessage(result);
    }

    async Task<Result<List<BaseDataListDto>>> IQueryHandlerAsync<Result<List<BaseDataListDto>>, int>.Handle(int condition)
    {
        var result = await context.BaseDatas.Where(x=>x.BaseDataTypeId==condition).Select(x => new BaseDataListDto()
        {
            Id=x.Id,    
            Title = x.Title,
            Comment = x.Comment,
            Created=x.Created.ToString("yyyy/MM/dd"),
            Status=x.IsActive==1?"فعال":"غیرفعال"
        }).ToListAsync();
        return Result<List<BaseDataListDto>>.EmptyMessage(result);
    }
}