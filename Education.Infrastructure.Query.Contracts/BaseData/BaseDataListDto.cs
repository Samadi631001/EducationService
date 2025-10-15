namespace Education.Infrastructure.Query.Contracts.BaseData;

public class BaseDataListDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string Created { get; set; }
    public string Status { get; set; }
}