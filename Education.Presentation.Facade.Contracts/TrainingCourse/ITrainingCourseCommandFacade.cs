using Education.Application.Contract.CourseGroup;
using Education.Application.Contract.TrainingCourse;
using Epc.Company.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Presentation.Facade.Contracts.TrainingCourse
{
    public  interface ITrainingCourseCommandFacade
    {
        Task<Result<Guid>> Create(CreateTrainingCourseDto command);
        Task<Result<bool>> Edit(EditTrainingCourseDto command);
        Task<Result<bool>> Delete(Guid guid);
    }
}
