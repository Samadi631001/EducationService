using Education.Domain.BaseDataAgg;
using Education.Domain.TrainingCourseAgg;
using Epc.Domain;

namespace Education.Domain.CourseGroupAgg
{
    public class CourseGroup:EntityBase<int>
    {
        
        public CourseGroup()
        {
        }
        //
        public CourseGroup(Guid creator, string? title, string? comment, int? parentId):base(creator)
        {
             
            Title = title;
            Comment = comment;
            ParentId = parentId;
        }
        //
        public void Edit(string? title, string? comment, int? parentId)
        {
            Title = title;
            Comment = comment;
            ParentId = parentId;
        }
        //
        public string? Title { get; private set; }
        public string? Comment { get; private set; }
        public int? ParentId { get; private set; }

        public CourseGroup? Parent { get; set; }
        //public List<TrainingCourse> TrainingCourse { get; set; }

    }
}
