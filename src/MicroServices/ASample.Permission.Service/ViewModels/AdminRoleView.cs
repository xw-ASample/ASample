using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.ViewModels
{
    public class AdminRoleView
    {
        public Guid AdminId { get; set; }

        public List<Guid> RoleIds { get; set; }
    }
}