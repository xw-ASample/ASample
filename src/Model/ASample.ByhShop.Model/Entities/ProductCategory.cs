using ASmaple.Domain.Models;
using System;

namespace ASample.ByhShop.Model.Entities
{
    public class ProductCategory:Entity
    {
        /// <summary>
        /// 类别编号
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// 商品编号
        /// </summary>
        public Guid ProductId { get; set; }
       
    }
}
