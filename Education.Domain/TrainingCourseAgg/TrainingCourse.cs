using Education.Domain.BaseDataAgg;
using Education.Domain.CourseGroupAgg;
using Epc.Domain;

namespace Education.Domain.TrainingCourseAgg
{
    public class TrainingCourse : AuditableAggregateRootBase<long>
    {
        public TrainingCourse()
        {

        }
        //
        public TrainingCourse(Guid creator,string? number, string? title, string? practicalPeriod, string? visionaryPeriod, 
                              string? titleEnglish, int? courseTypeId, int? trainingWayId, int? categoryId, 
                              int? courseExamId, int? courseGroupId, int? courseLayoutId, int? courseSubGroupId, 
                              string? purpose, string? comment, string? compass, 
                              bool? isSpecial, int? courseLevelId, string? exclusiveCode, int? codeCounter, 
                              string? exclusivePermit, byte? status, bool? isPortalContent, int? branchId, bool? isPublic,
                              string? strategies, string? performanceEvaluationParameter, 
                              int? daysToExpire, string? trainingScore, string? trainingFieldId, string? createReason, 
                              string? tags, bool? benefit, int? daysToExtension):base(creator)
        {
            Number = number;
            Title = title;
            PracticalPeriod = practicalPeriod;
            VisionaryPeriod = visionaryPeriod;
            TitleEnglish = titleEnglish;
            CourseTypeId = courseTypeId;
            TrainingWayId = trainingWayId;
            CategoryId = categoryId;
            CourseExamId = courseExamId;
            CourseGroupId = courseGroupId;
            CourseLayoutId = courseLayoutId;
            CourseSubGroupId = courseSubGroupId;
            Purpose = purpose;
            Comment = comment;
            Compass = compass;
            IsSpecial = isSpecial;
            CourseLevelId = courseLevelId;
            ExclusiveCode = exclusiveCode;
            CodeCounter = codeCounter;
            ExclusivePermit = exclusivePermit;
            Status = status;
            IsPortalContent = isPortalContent;
            BranchId = branchId;
            IsPublic = isPublic;
            Strategies = strategies;
            PerformanceEvaluationParameter = performanceEvaluationParameter;
            DaysToExpire = daysToExpire;
            TrainingScore = trainingScore;
            TrainingFieldId = trainingFieldId;
            CreateReason = createReason;
            Tags = tags;
            Benefit = benefit;
            DaysToExtension = daysToExtension;
        }
        //
        public void  Edit(Guid editor, string? number, string? title, string? practicalPeriod, string? visionaryPeriod,
                              string? titleEnglish, int? courseTypeId, int? trainingWayId, int? categoryId,
                              int? courseExamId, int? courseGroupId, int? courseLayoutId, int? courseSubGroupId,
                              string? purpose, string? comment, string? compass,
                              bool? isSpecial, int? courseLevelId, string? exclusiveCode, int? codeCounter,
                              string? exclusivePermit, byte? status, bool? isPortalContent, int? branchId, bool? isPublic,
                              string? strategies, string? performanceEvaluationParameter,
                              int? daysToExpire, string? trainingScore, string? trainingFieldId, string? createReason,
                                string? tags, bool? benefit, int? daysToExtension)  
        {
            Number = number;
            Title = title;
            PracticalPeriod = practicalPeriod;
            VisionaryPeriod = visionaryPeriod;
            TitleEnglish = titleEnglish;
            CourseTypeId = courseTypeId;
            TrainingWayId = trainingWayId;
            CategoryId = categoryId;
            CourseExamId = courseExamId;
            CourseGroupId = courseGroupId;
            CourseLayoutId = courseLayoutId;
            CourseSubGroupId = courseSubGroupId;
            Purpose = purpose;
            Comment = comment;
            Compass = compass;
            IsSpecial = isSpecial;
            CourseLevelId = courseLevelId;
            ExclusiveCode = exclusiveCode;
            CodeCounter = codeCounter;
            ExclusivePermit = exclusivePermit;
            Status = status;
            IsPortalContent = isPortalContent;
            BranchId = branchId;
            IsPublic = isPublic;
            Strategies = strategies;
            PerformanceEvaluationParameter = performanceEvaluationParameter;
            DaysToExpire = daysToExpire;
            TrainingScore = trainingScore;
            TrainingFieldId = trainingFieldId;
            CreateReason = createReason;
            Tags = tags;
            Benefit = benefit;
            DaysToExtension = daysToExtension;
            Modified(editor);
        }

        public string? Number { get;private set; }
        public string? Title { get; private set; }
        public string? PracticalPeriod { get; private set; }
        public string? VisionaryPeriod { get; private set; }
        public string? TitleEnglish { get; private set; }

        public int? CourseTypeId { get; private set; }
        public int? TrainingWayId { get; private set; }
        public int? CategoryId { get; private set; }
        public int? CourseExamId { get; private set; }
        public int? CourseGroupId { get; private set; }
        public int? CourseLayoutId { get; private set; }
        public int? CourseSubGroupId { get; private set; }
 
        public string? Purpose { get; private set; }
        public string? Comment { get; private set; }
        public string? Compass { get; private set; }
        public bool? IsSpecial { get; private set; }
        public int? CourseLevelId { get; private set; }
        public string? ExclusiveCode { get; private set; }
        public int? CodeCounter { get; private set; }
        public string? ExclusivePermit { get; private set; }
        public byte? Status { get; private set; }
        public bool? IsPortalContent { get; private set; }
        public int? BranchId { get; private set; }
        public bool? IsPublic { get; private set; }
        public string? Strategies { get; private set; }
        public string? PerformanceEvaluationParameter { get; private set; }
        public int? DaysToExpire { get; private set; }
        public string? TrainingScore { get; private set; }
        public string? TrainingFieldId { get; private set; }
        public string? CreateReason { get; private set; }
        public string? Tags { get; private set; }
        public bool? Benefit { get; private set; }
        public int? DaysToExtension { get; private set; }
        public BaseData CourseLayout { get; set; }
        public CourseGroup CourseGroup { get; set; }
        public CourseGroup CourseSubGroup { get; set; }
        public BaseData CourseType { get; set; }
        public BaseData TrainingWay { get; set; }
        public BaseData Category { get; set; }
        public BaseData CourseExam { get; set; }
        public BaseData CourseLevel { get; set; }


    }
}
