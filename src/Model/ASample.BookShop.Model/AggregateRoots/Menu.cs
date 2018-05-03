using ASmaple.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Model.AggregateRoots
{
    public class Menu:AggregateRoot
    {
        /// <summary>
        /// 编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 父级编码
        /// </summary>
        public int ParentCode { get; set; }
    }
}
