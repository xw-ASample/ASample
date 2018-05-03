using ASmaple.Domain.Models;
using System;


namespace ASample.BookShop.Model.Entities
{
    public class RoleMenuRelation:Entity
    {
        public Guid RoleId { get; set; }

        public Guid MenuId { get; set; }
    }
}
