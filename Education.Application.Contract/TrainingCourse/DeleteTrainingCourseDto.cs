using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epc.Application.Command;

namespace Education.Application.Contract.TrainingCourse
{
    public class DeleteTrainingCourseDto(Guid guid):ICommand
    {
        public Guid Guid { get; set; } = guid;
    }
}
