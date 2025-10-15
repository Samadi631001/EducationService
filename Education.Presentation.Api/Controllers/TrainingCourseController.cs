using Education.Application.Contract.CourseGroup;
using Education.Application.Contract.TrainingCourse;
using Education.Infrastructure.Query.Contracts.CourseGroup;
using Education.Infrastructure.Query.Contracts.TrainingCourse;
using Education.Presentation.Facade.Contracts.TrainingCourse;
using Epc.Company.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingCourseController(ITrainingCourseQueryFacade queryFacade, ITrainingCourseCommandFacade commandFacade) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<Result<Guid>> Create([FromBody] CreateTrainingCourseDto command) =>
            await commandFacade.Create(command);
        //
        [HttpPost("Edit")]
        public async Task<Result<bool>> Edit([FromBody] EditTrainingCourseDto command) =>
            await commandFacade.Edit(command);
        //
        [HttpPost("Delete/{guid:guid}")]
        public async Task<Result<bool>> Delete(Guid guid) =>
            await commandFacade.Delete(guid);
        //
        [HttpGet("GetList")]
        public async Task<Result<List<TrainingCourseListDto>>> List() =>
            await queryFacade.List();
        //

        [HttpGet("GetForEdit/{guid:guid}")]
        public async Task<Result<TrainingCourseEditDto>> GetDetails(Guid guid) =>
            await queryFacade.GetForEdit(guid);
        //
         



    }
}
