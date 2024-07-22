using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service.Role
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(EchatDbContex context) : base(context)
        {
        }
    }
}
