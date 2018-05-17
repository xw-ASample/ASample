using ASmaple.Domain.Models;
using System;

namespace ASample.ByhShop.Model
{
    public class Product:AggregateRoot
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 是否是新的
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 订单项编号
        /// </summary>
        public Guid OrderItemId { get; set; }

    }
}
