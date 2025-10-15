using Education.Application.Contract.BaseData;
using Education.Application.Contract.CourseGroup;
using Education.Application.Contract.TrainingCourse;
using Education.Presentation.Facade.Contracts.CourseGroup;
using Education.Presentation.Facade.Contracts.TrainingCourse;
using Epc.Application.Command;
using Epc.Company.Query;
using Epc.Core.Events;
using System;

namespace Education.Presentation.Facade.Command;

public class TrainingCourseCommandFacade(ICommandBusAsync commandBusAsync,
    IResponsiveCommandBusAsync responsiveCommandBusAsync,
    IEventAggregator eventAggregator) : ITrainingCourseCommandFacade
{
    public async Task<Result<Guid>> Create(CreateTrainingCourseDto command)
        => await responsiveCommandBusAsync.Dispatch<CreateTrainingCourseDto, Result<Guid>>(command);

    public async Task<Result<bool>> Edit(EditTrainingCourseDto command)
        => await responsiveCommandBusAsync.Dispatch<EditTrainingCourseDto, Result<bool>>(command);

    public async Task<Result<bool>> Delete(Guid guid)
        => await responsiveCommandBusAsync.Dispatch<DeleteTrainingCourseDto, Result<bool>>(
            new DeleteTrainingCourseDto(guid));
}
 
    
 