using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epc.Application.Command;

namespace Education.Application.Contract.BaseData
{
    public class CreateBaseDataDto:ICommand
    {
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public int? BaseDataTypeId  { get; set; }
    }
}
