using Education.Domain.TrainingCourseAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epc.Domain;

namespace Education.Domain.BaseDataAgg
{
    public class BaseData:EntityBase<int>
    {
        public BaseData()
        {
            
        }
        //
        public BaseData(Guid creator, string? title, string? comment, int? baseDataTypeId) : base(creator)
        {
            Title = title;
            Comment = comment;
            BaseDataTypeId = baseDataTypeId;
        }
        //
        public void Edit(string? title, string? comment)
        {
            Title = title;
            Comment = comment;
            
        }
        //
        public string? Title { get; private set; }
        public string? Comment { get; private set; }
        public int? BaseDataTypeId   { get;private set; }
    }
}
