using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Contract.BaseData
{
    public class EditBaseDataDto:CreateBaseDataDto
    {
        public int Id { get; set; }
    }
}
