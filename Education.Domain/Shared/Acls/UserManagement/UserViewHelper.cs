using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.Shared.Acls.UserManagement
{
    public class UserViewHelper
    {
        public Guid Guid { get; set; }
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string? NationalCode { get; set; }
        public bool IsSuperAdmin { get; set; }
    }
}
