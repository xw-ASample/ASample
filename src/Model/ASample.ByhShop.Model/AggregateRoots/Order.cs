using ASample.ByhShop.Model.Values;
using ASmaple.Domain.Models;
using System;

namespace ASample.ByhShop.Model
{
    public class Order : AggregateRoot
    {
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// 获取或设置订单的发货日期
        /// </summary>
        public DateTime? DispatchedDate { get; set; }

        /// <summary>
        /// 获取或设置订单的派送日期
        /// </summary>
        public DateTime? DeliveredDate { get; set; }
        
        /// <summary>
        /// 订单用户
        /// </summary>
        public  Guid UserId { get; set; }

        /// <summary>
        /// 订单地址
        /// </summary>
        public Guid AddressId { get; set; }

        // 在严格的业务系统中，金额往往以Money模式实现。有关Money模式，请参见：http://martinfowler.com/eaaCatalog/money.html
        public decimal Subtotal{ get; set; }
    }
}
