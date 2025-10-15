using Epc.Core.Exceptions;
using Epc.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.BaseDataAgg.Service
{
    public class BaseDataService(IBaseDataRepository repository):IBaseDataService
    {
        private Expression<Func<BaseData, bool>>? _predicate;

        public async Task ThrowWhenDuplicated(string title, int? baseDataTypeId, int? id = null)
        {
            _predicate = x => (x.Title == title) && (x.BaseDataTypeId==baseDataTypeId);
            if (id is not null)
                _predicate = _predicate.And(x => x.Id != id);

            if (await repository.ExistsAsync(_predicate))
                throw new DuplicatedDataEnteredException();
        }

        public async Task<bool> IsUseInTrainingCourse(int id)
        {
            //_predicate = x => x.TrainingCourses.Any(x => x.CourseCategoryId == id);
            //var result = await repository.ExistsAsync(_predicate);
            //return result;
            return true;
        }
    }
}
