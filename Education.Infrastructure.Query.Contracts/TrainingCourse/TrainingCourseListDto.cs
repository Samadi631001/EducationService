using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Infrastructure.Query.Contracts.TrainingCourse
{
    public class TrainingCourseListDto
    {
        public string? Number { get; set; }
        public string? Title { get; set; }
        public string? PracticalPeriod { get; set; }
        public string? VisionaryPeriod { get; set; }
        public string? TitleEnglish { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public string? Level { get; set; }
        public Guid Guid { get; set; }
        public int? CourseTypeId { get;  set; }
        public int? TrainingWayId { get;  set; }
        public int? CategoryId { get;  set; }
        public int? CourseExamId { get;  set; }
        public int? CourseGroupId { get;  set; }
        public int? CourseLayoutId { get;  set; }
        public int? CourseSubGroupId { get;  set; }
        public string? Purpose { get;  set; }
        public string? Comment { get;  set; }
        public string? Compass { get;  set; }
        public bool? IsSpecial { get;  set; }
        public int? CourseLevelId { get;  set; }
        public string? ExclusiveCode { get;  set; }
        public int? CodeCounter { get;  set; }
        public string? ExclusivePermit { get;  set; }
        public byte? Status { get;  set; }
        public bool? IsPortalContent { get;  set; }
        public int? BranchId { get;  set; }
        public bool? IsPublic { get;  set; }
        public string? Strategies { get;  set; }
        public string? PerformanceEvaluationParameter { get;  set; }
        public int? DaysToExpire { get;  set; }
        public string? TrainingScore { get;  set; }
        public string? TrainingFieldId { get;  set; }
        public string? CreateReason { get;  set; }
        public string? Tags { get;  set; }
        public bool? Benefit { get;  set; }
        public int? DaysToExtension { get;  set; }

    }
}
