using ASample.BookShop.Model.Values;
using ASmaple.Domain.Models;
using System;

namespace ASample.BookShop.Model.AggregateRoots
{
    public class Order:AggregateRoot
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 邮寄地址编号
        /// </summary>
        public Guid AddressId { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderState State { get; set; }
    }
}
