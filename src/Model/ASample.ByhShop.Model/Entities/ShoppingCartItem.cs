using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.ByhShop.Model.Entities
{
    public class ShoppingCartItem:Entity
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 购物车编号
        /// </summary>
        public Guid ShoppingCartId { get; set; }
    }
}
