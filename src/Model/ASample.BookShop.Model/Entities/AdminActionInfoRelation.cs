using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Model.Entities
{
    public class AdminActionInfoRelation:Entity
    {
        public short IsPass { get; set; }

        /// <summary>
        /// 控制器标号
        /// </summary>
        public Guid ActionInfoId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid AdminId { get; set; }
    }
}
