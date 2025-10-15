using Education.Application.Contract.CourseGroup;
using Education.Infrastructure.Query.Contracts.CourseGroup;
using Education.Presentation.Facade.Contracts.CourseGroup;
using Epc.Company.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGroupController(ICourseGroupQueryFacade queryFacade, ICourseGroupCommandFacade commandFacade) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<Result<int>> Create([FromBody] CreateCourseGroupDto command) =>
            await commandFacade.Create(command);
        //
        [HttpPost("Edit")]
        public async Task<Result<bool>> Edit([FromBody] EditCourseGroupDto command) =>
            await commandFacade.Edit(command);
        //
        [HttpPost("Delete/{id:int}")]
        public async Task<Result<bool>> Delete(int id) =>
            await commandFacade.Delete(id);
        //
        [HttpGet("GetList")]
        public async Task<Result<List<CourseGroupListDto>>> List() =>
            await queryFacade.List();
        //

        [HttpGet("GetForEdit/{id:int}")]
        public async Task<Result<CourseGroupEditDto>> GetDetails(int id) =>
            await queryFacade.GetDetails(id);
        //
        [HttpGet("GetForCombo")]
        public async Task<Result<List<CourseGroupComboModel>>> GetForCombo() =>
            await queryFacade.GetForCombo();
    }
}
