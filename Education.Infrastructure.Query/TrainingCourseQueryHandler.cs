using Education.Infrastructure.Persistence;
using Education.Infrastructure.Query.Contracts.CourseGroup;
using Education.Infrastructure.Query.Contracts.TrainingCourse;
using Epc.Application.Query;
using Epc.Company.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Infrastructure.Query
{
    public class TrainingCourseQueryHandler(EducationQueryContext context) :
        IQueryHandlerAsync<Result<List<TrainingCourseListDto>>>,
        IQueryHandlerAsync<Result<TrainingCourseEditDto>, Guid> 
    {
        public async Task<Result<List<TrainingCourseListDto>>> Handle()
        {
            var result = await context.TrainingCourses.Select(x => new TrainingCourseListDto()
            {
                Number = x.Number,
                Title = x.Title,
                PracticalPeriod = x.PracticalPeriod,
                VisionaryPeriod = x.VisionaryPeriod,
                TitleEnglish = x.TitleEnglish,
                Type = x.CourseType.Title,
                Category = x.Category.Title,
                Level = x.CourseLevel.Title,
                Guid = x.Guid,
                CourseTypeId = x.CourseTypeId,
                TrainingWayId = x.TrainingWayId,
                CategoryId = x.CategoryId,
                CourseExamId = x.CourseExamId,
                CourseGroupId = x.CourseGroupId,
                CourseLayoutId = x.CourseLayoutId,
                CourseSubGroupId = x.CourseSubGroupId,
                Purpose = x.Purpose,
                Comment = x.Comment,
                Compass = x.Compass,
                IsSpecial = x.IsSpecial,
                CourseLevelId = x.CourseLevelId,
                ExclusiveCode = x.ExclusiveCode,
                CodeCounter = x.CodeCounter,
                ExclusivePermit = x.ExclusivePermit,
                Status = x.Status,
                IsPortalContent = x.IsPortalContent,
                BranchId = x.BranchId,
                IsPublic = x.IsPublic,
                Strategies = x.Strategies,
                PerformanceEvaluationParameter = x.PerformanceEvaluationParameter,
                DaysToExpire = x.DaysToExpire,
                TrainingScore = x.TrainingScore,
                TrainingFieldId = x.TrainingFieldId,
                CreateReason = x.CreateReason,
                Tags = x.Tags,
                Benefit = x.Benefit,
                DaysToExtension = x.DaysToExtension


                //x.CourseLayoutId != null ? context.BaseDatas.FirstOrDefault(z => z.Id == x.CourseLayoutId).Title : ""

            }).ToListAsync();

            return Result<List<TrainingCourseListDto>>.EmptyMessage(result);
        }

        public async Task<Result<TrainingCourseEditDto>> Handle(Guid condition)
        {
            var result = await context.TrainingCourses.Where(t => t.Guid == condition).Select(x => new TrainingCourseEditDto()
            {
                Number = x.Number,
                Title = x.Title,
                PracticalPeriod = x.PracticalPeriod,
                VisionaryPeriod = x.VisionaryPeriod,
                TitleEnglish = x.TitleEnglish,
                Type = x.CourseType.Title,
                Guid = x.Guid,
                CourseTypeId = x.CourseTypeId,
                TrainingWayId = x.TrainingWayId,
                CategoryId = x.CategoryId,
                CourseExamId = x.CourseExamId,
                CourseGroupId = x.CourseGroupId,
                CourseLayoutId = x.CourseLayoutId,
                CourseSubGroupId = x.CourseSubGroupId,
                Purpose = x.Purpose,
                Comment = x.Comment,
                Compass = x.Compass,
                IsSpecial = x.IsSpecial,
                CourseLevelId = x.CourseLevelId,
                ExclusiveCode = x.ExclusiveCode,
                CodeCounter = x.CodeCounter,
                ExclusivePermit = x.ExclusivePermit,
                Status = x.Status,
                IsPortalContent = x.IsPortalContent,
                BranchId = x.BranchId,
                IsPublic = x.IsPublic,
                Strategies = x.Strategies,
                PerformanceEvaluationParameter = x.PerformanceEvaluationParameter,
                DaysToExpire = x.DaysToExpire,
                TrainingScore = x.TrainingScore,
                TrainingFieldId = x.TrainingFieldId,
                CreateReason = x.CreateReason,
                Tags = x.Tags,
                Benefit = x.Benefit,
                DaysToExtension = x.DaysToExtension
            }).FirstOrDefaultAsync();
            return Result<TrainingCourseEditDto>.EmptyMessage(result);
        }
    }
}
