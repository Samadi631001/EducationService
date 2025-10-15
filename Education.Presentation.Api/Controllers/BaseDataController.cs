using Education.Application.Contract.BaseData;
using Education.Application.Contract.CourseGroup;
using Education.Infrastructure.Query.Contracts.BaseData;
using Education.Infrastructure.Query.Contracts.CourseGroup;
using Education.Presentation.Facade.Contracts.BaseData;
using Education.Presentation.Facade.Contracts.CourseGroup;
using Epc.Company.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseDataController (IBaseDataQueryFacade  queryFacade, IBaseDataCommandFacade  commandFacade) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<Result<int>> Create([FromBody] CreateBaseDataDto command) =>
            await commandFacade.Create(command);
        //
        [HttpPost("Edit")]
        public async Task<Result<bool>> Edit([FromBody] EditBaseDataDto command) =>
            await commandFacade.Edit(command);
        //
        [HttpPost("Delete/{id:int}")]
        public async Task<Result<bool>> Delete(int id) =>
            await commandFacade.Delete(id);
        //
        [HttpGet("GetList/{type:int}")]
        public async Task<Result<List<BaseDataListDto>>> GetListBy(int type) =>
            await queryFacade.List(type);
        //
        [HttpGet("GetForEdit/{id:int}")]
        public async Task<Result<BaseDataEditDto>> GetDetails(int id) =>
            await queryFacade.GetDetails(id);
        //
        [HttpPost("Activate/{id:int}")]
        public async Task<Result<bool>> Activate(int id) =>
            await commandFacade.Activate(id);

        [HttpPost("Deactivate/{id:int}")]
        public async Task<Result<bool>> Deactivate(int id) =>
            await commandFacade.Deactivate(id);
        //
        [HttpGet("GetForCombo")]
        public async Task<Result<List<BaseDataComboModel>>> GetForCombo() =>
            await queryFacade.GetForCombo();
    }
}
