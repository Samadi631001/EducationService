using Epc.Application.Command;
using Epc.Company.Query;
using Epc.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Application.Contract.CourseGroup;
using Education.Presentation.Facade.Contracts.CourseGroup;

namespace Education.Presentation.Facade.Command
{
    public class CourseGroupCommandFacade(ICommandBusAsync commandBusAsync,
        IResponsiveCommandBusAsync responsiveCommandBusAsync,
        IEventAggregator eventAggregator) : ICourseGroupCommandFacade
    {
        public async Task<Result<int>> Create(CreateCourseGroupDto command)
        => await responsiveCommandBusAsync.Dispatch<CreateCourseGroupDto, Result<int>>(command);

        public async Task<Result<bool>> Edit(EditCourseGroupDto command)
            => await responsiveCommandBusAsync.Dispatch<EditCourseGroupDto, Result<bool>>(command);

        public async Task<Result<bool>> Delete(int id)
            => await responsiveCommandBusAsync.Dispatch<DeleteCourseGroupDto, Result<bool>>(
                new DeleteCourseGroupDto(id));
    }
}
