namespace Education.Infrastructure.Query.Contracts.CourseGroup
{
    public class CourseGroupEditDto
    {
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public int Id { get; set; }
        public int?  Parent { get; set; }
    }
}
