using Epc.Application.Command;
using Epc.Company.Query;
using Epc.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Application.Contract.CourseGroup;
using Education.Domain.CourseGroupAgg;
using Education.Domain.CourseGroupAgg.Service;

namespace Education.Application
{
    public class CourseGroupCommandHandler(ICourseGroupRepository repository,IClaimHelper claimHelper, ICourseSubGroupService service):
        ICommandHandlerAsync<CreateCourseGroupDto,Result<int>>,
        ICommandHandlerAsync<EditCourseGroupDto,Result<bool>>
    {
        public async Task<Result<int>> Handle(CreateCourseGroupDto command)
        {
            var newRecord = new CourseGroup(claimHelper.GetCurrentUserGuid(), command.Title, command.Comment, command.Parent);
            await repository.CreateAsync(newRecord);
            return Result<int>.Success(newRecord.Id);
        }

        public async Task<Result<bool>> Handle(EditCourseGroupDto command)
        {
            var editRecord =await repository.LoadAsync(command.Id);
            if(editRecord==null)
                return Result<bool>.Failure(false, "زیر گروه دسته بندی آموزش پیدا نشد");
            editRecord.Edit(command.Title, command.Comment,command.Parent);

            repository.Update(editRecord);
            return Result<bool>.Success(true);
        }

        //public async Task<Result<bool>> Handle(DeleteCourseSubGroupDto command)
        //{
        //    var delRecord = await repository.LoadAsync(command.Id);
        //    if (delRecord == null)
        //        return Result<bool>.Failure(false, "رکورد مورد نظر جهت حذف یافت نشد");
        //    if (await service.IsUseInTrainingCourse(delRecord.Id))
        //        return Result<bool>.Failure(false, "به دلیل وجود سابقه امکان حذف وجود ندارد");
        //    repository.Delete(delRecord);
        //    return Result<bool>.Success(true);

        //}
    }
}
