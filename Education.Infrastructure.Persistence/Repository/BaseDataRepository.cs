using Epc.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Domain.BaseDataAgg;

namespace Education.Infrastructure.Persistence.Repository
{
    public class BaseDataRepository(DbContext commandContext) : BaseRepository<int, BaseData>(commandContext), 
                 IBaseDataRepository;
    
}
