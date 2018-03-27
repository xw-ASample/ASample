using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model.Entities
{
    /// <summary>
    /// 邮寄地址
    /// </summary>
    public class PostAddress:Entity
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 用户填写地址
        /// </summary>
        public string Address { get; set; }
    }
}
