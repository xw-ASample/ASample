using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model.Entities
{
    public class CheckEmail:Entity
    {
        /// <summary>
        /// 是否被激活
        /// </summary>
        public bool Actived { get; set; }

        /// <summary>
        /// 激活码
        /// </summary>
        public string ActiveCode { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }
    }
}
