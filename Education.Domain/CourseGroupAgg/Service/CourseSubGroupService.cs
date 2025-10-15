using System.Linq.Expressions;
using Epc.Core.Exceptions;
using Epc.Domain.Specification;

namespace Education.Domain.CourseGroupAgg.Service
{
    public class CourseSubGroupService(ICourseGroupRepository repository) : ICourseSubGroupService
    {
        private Expression<Func<CourseGroup, bool>>? _predicate;
        public async Task ThrowWhenDuplicated(string title, int? id)
        {
            _predicate = x => x.Title == title;
            if (_predicate is not null)
                _predicate = _predicate.And(x => x.Id != id);
            if (await repository.ExistsAsync(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public async Task<bool> IsUseInTrainingCourse(int id)
        {
            //_predicate = x => x.TrainingCourse.Any(x => x.CourseSubGroupId == id);
            //var result = (await repository.ExistsAsync(_predicate));
            //return result;
            return true;
        }
    }
}
