using Epc.Application.Command;

namespace Education.Application.Contract.CourseGroup;

public class CreateCourseGroupDto:ICommand
{
    public string Title { get; set; }
    public string Comment { get; set; }
    public int? Parent { get; set; }
}