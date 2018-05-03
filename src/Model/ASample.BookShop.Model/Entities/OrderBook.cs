using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Model.Entities
{
    public class OrderBook:Entity
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public Guid  OrderId { get; set; }

        /// <summary>
        /// 书本编号
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
