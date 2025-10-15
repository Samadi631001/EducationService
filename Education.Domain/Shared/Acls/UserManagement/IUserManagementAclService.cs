using Epc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Shared.Acls.UserManagement
{
    public interface IUserManagementAclService : IAclService
    {
        Task<SystemViewHelper> GetSystemByAsync(string clientId);
        Task<UserViewHelper> GetUserByAsync(Guid guid);
        Task<List<UserViewHelper>> GetUsersByGuidsAsync(List<Guid?> userGuids);
    }
}
