using Education.Infrastructure.Query.Contracts.BaseData;
using Epc.Company.Query;
using Epc.Core;

namespace Education.Presentation.Facade.Contracts.BaseData;

public interface IBaseDataQueryFacade:IFacadeService
{
    Task<Result<List<BaseDataListDto>>> List(int baseDataType);
    Task<Result<BaseDataEditDto>> GetDetails(int id);
    Task<Result<List<BaseDataComboModel>>> GetForCombo();
}