using Education.Application.Contract.TrainingCourse;
using Education.Domain.TrainingCourseAgg;
using Education.Domain.TrainingCourseAgg.Service;
using Epc.Application.Command;
using Epc.Company.Query;
using Epc.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application
{
    public class TrainingCourseCommandHandler(ITrainingCourseRepository repository, IClaimHelper claimHelper, ITrainingCourseService service) :
        ICommandHandlerAsync<CreateTrainingCourseDto, Result<Guid>>,
        ICommandHandlerAsync<EditTrainingCourseDto, Result<bool>>,
        ICommandHandlerAsync<DeleteTrainingCourseDto, Result<bool>>
    {
        public async Task<Result<Guid>> Handle(CreateTrainingCourseDto command)
        {
            var trainingCourse = new TrainingCourse(
                claimHelper.GetCurrentUserGuid(), command.Number, command.Title, command.PracticalPeriod, command.VisionaryPeriod
                , command.TitleEnglish, command.CourseTypeId, command.TrainingWayId, command.CategoryId, command.CourseExamId,
                command.CourseGroupId, command.CourseLayoutId, command.CourseSubGroupId, command.Purpose, command.Comment,
                command.Compass, command.IsSpecial, command.CourseLevelId, command.ExclusiveCode, command.CodeCounter,
                command.ExclusivePermit, command.Status, command.IsPortalContent, command.BranchId, command.IsPublic,
                command.Strategies, command.PerformanceEvaluationParameter, command.DaysToExpire, command.TrainingScore,
                command.TrainingFieldId, command.CreateReason, command.Tags, command.Benefit, command.DaysToExtension
            );
            await repository.CreateAsync(trainingCourse);
            return Result<Guid>.Success(trainingCourse.Guid);
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> Handle(EditTrainingCourseDto command)
        {
            var trainingCourse = await repository.LoadAsync(command.Guid);
            if (trainingCourse == null)
                return Result<bool>.Failure(false, "دوره یافت نشد");

            trainingCourse.Edit(
                claimHelper.GetCurrentUserGuid()
                , command.Number, command.Title, command.PracticalPeriod, command.VisionaryPeriod
                , command.TitleEnglish, command.CourseTypeId, command.TrainingWayId, command.CategoryId, command.CourseExamId,
                command.CourseGroupId, command.CourseLayoutId, command.CourseSubGroupId, command.Purpose, command.Comment,
                command.Compass, command.IsSpecial, command.CourseLevelId, command.ExclusiveCode, command.CodeCounter,
                command.ExclusivePermit, command.Status, command.IsPortalContent, command.BranchId, command.IsPublic,
                command.Strategies, command.PerformanceEvaluationParameter, command.DaysToExpire, command.TrainingScore,
                command.TrainingFieldId, command.CreateReason, command.Tags, command.Benefit, command.DaysToExtension
            );

            repository.Update(trainingCourse);
            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> Handle(DeleteTrainingCourseDto command)
        {
            var trainingCourse = await repository.LoadAsync(command.Guid);
            if (trainingCourse == null)
                return Result<bool>.Failure(false, "دوره یافت نشد");
            //if (await service.IsUseInTrainingCourse(courseLayout.Id))
            //    return Result<bool>.Failure(false, "به دلیل وجود سابقه امکان حذف وجود ندارد");
            repository.Delete(trainingCourse);
            return Result<bool>.Success(true);
        }
    }
}
