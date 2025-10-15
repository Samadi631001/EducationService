using Education.Application.Contract.BaseData;
using Epc.Company.Query;
using Epc.Core;

namespace Education.Presentation.Facade.Contracts.BaseData;

public interface IBaseDataCommandFacade:IFacadeService
{
    Task<Result<int>> Create(CreateBaseDataDto command);
    Task<Result<bool>> Edit(EditBaseDataDto command);
    Task<Result<bool>> Delete(int id);
    Task<Result<bool>> Activate(int id);
    Task<Result<bool>> Deactivate(int id);
}