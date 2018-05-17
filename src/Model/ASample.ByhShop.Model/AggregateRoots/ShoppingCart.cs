using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.ByhShop.Model
{
    public class ShoppingCart
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId { get; set;}

        /// <summary>
        /// 商品编号
        /// </summary>
        public Guid ProductId { get; set; }

        
    }
}
