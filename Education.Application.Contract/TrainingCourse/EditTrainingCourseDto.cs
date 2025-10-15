using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Contract.TrainingCourse
{
    public class EditTrainingCourseDto: CreateTrainingCourseDto
    {
        public Guid Guid { get; set; }
    }
}
