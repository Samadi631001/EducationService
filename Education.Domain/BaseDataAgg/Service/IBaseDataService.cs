using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.BaseDataAgg.Service
{
    public interface IBaseDataService
    {
        
        Task ThrowWhenDuplicated(string title, int? baseDataTypeId, int? id = null);
        Task<bool> IsUseInTrainingCourse(int id);
    }
}
