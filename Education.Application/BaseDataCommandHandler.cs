using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Application.Contract.BaseData;
using Education.Domain.BaseDataAgg;
using Education.Domain.BaseDataAgg.Service;
using Epc.Application.Command;
using Epc.Company.Query;
using Epc.Identity;

namespace Education.Application
{
    public class BaseDataCommandHandler(IBaseDataRepository repository,IClaimHelper claimHelper,IBaseDataService service):
    ICommandHandlerAsync<CreateBaseDataDto,Result<int>>,
    ICommandHandlerAsync<EditBaseDataDto,Result<bool>>,
    ICommandHandlerAsync<DeleteBaseDataDto,Result<bool>>

    {
        public async Task<Result<int>> Handle(CreateBaseDataDto command)
        {
            var basedata = new BaseData(claimHelper.GetCurrentUserGuid(), command.Title, command.Comment, command.BaseDataTypeId);
            await repository.CreateAsync(basedata);
            return Result<int>.Success(basedata.Id);
        }

        public async Task<Result<bool>> Handle(EditBaseDataDto command)
        {
            var basedata =await repository.LoadAsync(command.Id);
            if(basedata==null)
              Result<bool>.Failure(false);
           basedata.Edit(command.Title,command.Comment);
           repository.Update(basedata);
           return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> Handle(DeleteBaseDataDto command)
        {
            var basedate = await repository.LoadAsync(command.Id);
            if(basedate==null)
                Result<bool>.Failure(false);
            //if (await service.IsUseInTrainingCourse(basedate.Id))
             // Result<bool>.Failure(false, "از این رکورد در بخش دوره های آموزشی استفاده شده است");}
            repository.Delete(basedate);
            return Result<bool>.Success(true);
        }
    }
}
