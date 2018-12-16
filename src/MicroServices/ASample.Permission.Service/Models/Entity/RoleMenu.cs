using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASample.Permission.Service.Models
{
    public class RoleMenu : Entity
    {
        public Guid RoleId { get; set; }

        public Guid MenuId { get; set; }
    }
}