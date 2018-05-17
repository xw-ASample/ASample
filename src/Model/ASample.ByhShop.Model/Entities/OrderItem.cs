using ASmaple.Domain.Models;
using System;

namespace ASample.ByhShop.Model.Entities
{
    public class OrderItem : Entity
    {
        /// <summary>
        /// 订单数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public Guid  OrderId { get; set; }

        /// <summary>
        /// 订单总价
        /// </summary>
        public decimal ItemAmout{ get;set; }
    }
}
