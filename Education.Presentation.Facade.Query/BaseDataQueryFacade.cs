using Education.Infrastructure.Query.Contracts.BaseData;
using Education.Presentation.Facade.Contracts.BaseData;
using Epc.Application.Query;
using Epc.Company.Query;

namespace Education.Presentation.Facade.Query;

public class BaseDataQueryFacade(IQueryBusAsync queryBus) : IBaseDataQueryFacade
{
    public async Task<Result<List<BaseDataListDto>>> List(int baseDataType)
        => await queryBus.Dispatch<Result<List<BaseDataListDto>>,int>(baseDataType);

    public async Task<Result<BaseDataEditDto>> GetDetails(int id)
        => await queryBus.Dispatch<Result<BaseDataEditDto>, int>(id);

    public async Task<Result<List<BaseDataComboModel>>> GetForCombo()
        => await queryBus.Dispatch<Result<List<BaseDataComboModel>>>();
}