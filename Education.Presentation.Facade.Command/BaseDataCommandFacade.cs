using Education.Application.Contract.BaseData;
using Education.Presentation.Facade.Contracts.BaseData;
using Epc.Application.Command;
using Epc.Company.Query;
using Epc.Core.Events;
using System;

namespace Education.Presentation.Facade.Command;

public class BaseDataCommandFacade(ICommandBusAsync commandBusAsync,
    IResponsiveCommandBusAsync responsiveCommandBusAsync,
    IEventAggregator eventAggregator) : IBaseDataCommandFacade
{
    public async Task<Result<int>> Create(CreateBaseDataDto command)
    => await responsiveCommandBusAsync.Dispatch<CreateBaseDataDto, Result<int>>(command);

    public async Task<Result<bool>> Edit(EditBaseDataDto command)
        => await responsiveCommandBusAsync.Dispatch<EditBaseDataDto, Result<bool>>(command);

    public async Task<Result<bool>> Delete(int id)
        => await responsiveCommandBusAsync.Dispatch<DeleteBaseDataDto, Result<bool>>(
            new DeleteBaseDataDto(id));

    public async Task<Result<bool>> Activate(int id)=>
    await responsiveCommandBusAsync.Dispatch<ActivateBaseDataDto, Result<bool>>(new ActivateBaseDataDto(id));

    public async Task<Result<bool>> Deactivate(int id)=> 
        await responsiveCommandBusAsync.Dispatch<DeactivateBaseDataDto, Result<bool>>(new DeactivateBaseDataDto(id));
     
}