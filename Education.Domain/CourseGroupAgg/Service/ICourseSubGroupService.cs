namespace Education.Domain.CourseGroupAgg.Service
{
    public interface ICourseSubGroupService
    {
        Task ThrowWhenDuplicated(string title, int? id);
        Task<bool> IsUseInTrainingCourse(int id);
    }
}
