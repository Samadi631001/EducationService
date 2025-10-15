using Epc.Application.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Infrastructure.Query.Contracts.CourseGroup;
using Education.Presentation.Facade.Contracts.CourseGroup;
using Epc.Company.Query;

namespace Education.Presentation.Facade.Query
{
    public class CourseGroupQueryFacade(IQueryBusAsync queryBus):ICourseGroupQueryFacade
    {
        public async Task<Result<List<CourseGroupListDto>>> List()
            => await queryBus.Dispatch<Result<List<CourseGroupListDto>>>();

        public async Task<Result<CourseGroupEditDto>> GetDetails(int id)
            => await queryBus.Dispatch<Result<CourseGroupEditDto>, int>(id);

        public async Task<Result<List<CourseGroupComboModel>>> GetForCombo()
            => await queryBus.Dispatch<Result<List<CourseGroupComboModel>>>();
    }
}
