namespace Education.Application.Contract.CourseGroup;

public class EditCourseGroupDto : CreateCourseGroupDto
{
    public int Id { get; set; }
}

public class DeleteCourseGroupDto (int id): CreateCourseGroupDto
{
    public int Id { get; set; } = id;
}