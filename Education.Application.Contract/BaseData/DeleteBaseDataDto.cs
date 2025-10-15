using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epc.Application.Command;

namespace Education.Application.Contract.BaseData
{
    public class DeleteBaseDataDto(int id):ICommand
    {
        public int Id { get; set; } = id;
    }
}
