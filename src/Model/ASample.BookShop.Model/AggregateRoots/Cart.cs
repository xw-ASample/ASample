using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model.AggregateRoots
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class Cart : AggregateRoot
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 书本编号
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Count { get; set; }
    }
}
